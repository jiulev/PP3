using CapaEntidad;
using CapaNegocio;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq; // Necesario para métodos como Select y Sum
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;



namespace FotoRoman
{
    public partial class FormReporteVendedor : Form
    {
        public FormReporteVendedor()
        {
            InitializeComponent();
        }

        private void FormReporteVendedor_Load(object sender, EventArgs e)
        {
            try
            {
                // Obtener los nombres de los usuarios
                CNUsuario cnUsuario = new CNUsuario();
                List<string> nombres = cnUsuario.ListarNombres();

                if (nombres == null || nombres.Count == 0)
                {
                    MessageBox.Show("No se encontraron usuarios en la base de datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cargar los nombres en el ComboBox
                comboBoxUsuarios.DataSource = nombres;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string GenerarGraficoDeTorta(decimal ventasUsuario, decimal totalVentas)
        {
            string rutaImagen = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "GraficoTorta.png");

            using (Bitmap bitmap = new Bitmap(500, 350))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.Clear(Color.White); // Fondo blanco

                    // Colores modernos
                    Brush brushUsuario = new SolidBrush(Color.FromArgb(231, 76, 60));  // Rojo elegante
                    Brush brushRestante = new SolidBrush(Color.Silver);                // Gris plata
                    Brush brushTexto = Brushes.Black;


                    // Calcular proporciones
                    float anguloUsuario = totalVentas > 0 ? (float)ventasUsuario / (float)totalVentas * 360f: 0f;

                    float anguloRestante = 360f - anguloUsuario;


                    // Dibujar la torta
                    System.Drawing.Rectangle rect = new System.Drawing.Rectangle(50, 50, 200, 200);
                    g.FillPie(brushUsuario, rect, 0, anguloUsuario);
                    g.FillPie(brushRestante, rect, anguloUsuario, anguloRestante);

                    // Leyendas
                    g.FillRectangle(brushUsuario, 280, 70, 20, 20);
                    g.DrawString("Vendedor", new System.Drawing.Font("Yu Gothic", 10), brushTexto, 310, 70);

                    g.FillRectangle(brushRestante, 280, 100, 20, 20);
                    g.DrawString("Resto", new System.Drawing.Font("Yu Gothic", 10), brushTexto, 310, 100);

                    // Porcentaje al medio del gráfico
                    if (totalVentas > 0)
                    {
                        float porcentaje = (float)(ventasUsuario / totalVentas * 100);
                        string textoPorc = $"{porcentaje:F1}%";

                        System.Drawing.Font fuente = new System.Drawing.Font("Yu Gothic", 12, System.Drawing.FontStyle.Bold);
                        SizeF size = g.MeasureString(textoPorc, fuente);
                        g.DrawString(textoPorc, fuente, brushTexto,
                            rect.Left + rect.Width / 2 - size.Width / 2,
                            rect.Top + rect.Height / 2 - size.Height / 2);
                    }
                }

                bitmap.Save(rutaImagen, System.Drawing.Imaging.ImageFormat.Png);
            }

            return rutaImagen;
        }


        private void buttonGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar el usuario
                string usuarioNombre = comboBoxUsuarios.Text.Trim();
                CNUsuario cnUsuario = new CNUsuario();
                Usuario? usuario = cnUsuario.Listar().FirstOrDefault(u => u.NOMBRE.Equals(usuarioNombre, StringComparison.OrdinalIgnoreCase));

                if (usuario == null)
                {
                    MessageBox.Show("Usuario no encontrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validaciones de fechas
                if (dtpFechaHasta.Value.Date > DateTime.Today)
                {
                    MessageBox.Show("La fecha 'Hasta' no puede ser posterior al día de hoy.", "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dtpFechaDesde.Value.Date > dtpFechaHasta.Value.Date)
                {
                    MessageBox.Show("La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'.", "Rango inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ajustar el rango de fechas una vez validadas
                DateTime fechaDesde = dtpFechaDesde.Value.Date;
                DateTime fechaHasta = dtpFechaHasta.Value.Date.AddDays(1).AddSeconds(-1); // Incluir todo el día 'hasta'

                // Obtener pedidos
                var pedidos = CNPedido.ObtenerPedidosPorUsuarioYFechas(usuario.IDUSUARIO, fechaDesde, fechaHasta);

                if (pedidos == null || pedidos.Count == 0)
                {
                    MessageBox.Show("No se encontraron pedidos para el usuario en el rango de fechas especificado.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblTotal.Text = "Total: $0.00";
                    dataGridViewPedidos.DataSource = null; // Limpiar si no hay resultados
                    return;
                }

                // Preparar datos
                var detalles = pedidos.Select(p => new
                {
                    p.IDPEDIDO,
                    TOTAL = p.TOTAL,
                    FECHA = p.FECHAPEDIDO.ToString("dd/MM/yyyy HH:mm:ss")
                }).ToList();

                dataGridViewPedidos.DataSource = detalles;

                dataGridViewPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridViewPedidos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridViewPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

                decimal sumaTotal = detalles.Sum(d => d.TOTAL);
                lblTotal.Text = $"Total: {sumaTotal:C2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewPedidos.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para generar el reporte.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar el usuario
                string usuarioNombre = comboBoxUsuarios.Text.Trim();
                CNUsuario cnUsuario = new CNUsuario();
                Usuario? usuario = cnUsuario.Listar().FirstOrDefault(u => u.NOMBRE.Equals(usuarioNombre, StringComparison.OrdinalIgnoreCase));

                if (usuario == null)
                {
                    MessageBox.Show("Usuario no encontrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ajustar el rango de fechas
                DateTime fechaDesde = dtpFechaDesde.Value.Date;
                DateTime fechaHasta = dtpFechaHasta.Value.Date.AddDays(1).AddSeconds(-1);

                // Calcular estadísticas
                var (totalVentas, ventasUsuario, porcentaje) = CNPedido.CalcularEstadisticas(usuario.IDUSUARIO, fechaDesde, fechaHasta);

                // Generar el gráfico de torta
                string rutaGrafico = GenerarGraficoDeTorta(ventasUsuario, totalVentas);

                // Ruta para guardar el PDF
                string rutaPDF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ReporteVentas.pdf");

                // Ruta del logo
                string rutaLogo = @"C:\Users\JSofia\Desktop\ISSD\2022 SEGUNDO SEMESTRE\PP1\imagens\roman.png";
                if (!System.IO.File.Exists(rutaLogo))
                {
                    MessageBox.Show("El archivo de logo no existe en la ruta especificada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Crear PDF
                using (FileStream stream = new FileStream(rutaPDF, FileMode.Create))
                {
                    Document documento = new Document(PageSize.A4, 25, 25, 30, 30);
                    PdfWriter writer = PdfWriter.GetInstance(documento, stream);

                    documento.Open();

                    // Logo
                    try
                    {
                        iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(rutaLogo);
                        logo.ScaleToFit(200, 100);
                        logo.Alignment = Element.ALIGN_LEFT;
                        documento.Add(logo);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al agregar el logo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Título
                    Paragraph titulo = new Paragraph("Reporte de Pedidos", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16));
                    titulo.Alignment = Element.ALIGN_CENTER;
                    titulo.SpacingAfter = 20;
                    documento.Add(titulo);

                    // Subtítulo
                    Paragraph info = new Paragraph($"Usuario: {comboBoxUsuarios.Text}\nDesde: {dtpFechaDesde.Value:dd/MM/yyyy}\nHasta: {dtpFechaHasta.Value:dd/MM/yyyy}\n",
                        FontFactory.GetFont(FontFactory.HELVETICA, 12));
                    info.Alignment = Element.ALIGN_LEFT;
                    info.SpacingAfter = 20;
                    documento.Add(info);

                    // Tabla de pedidos
                    PdfPTable tabla = new PdfPTable(3);
                    tabla.WidthPercentage = 100;
                    tabla.SetWidths(new float[] { 1, 1, 1 });

                    tabla.AddCell(new PdfPCell(new Phrase("ID Pedido", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))
                    {
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        BackgroundColor = new BaseColor(211, 211, 211)
                    });
                    tabla.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))
                    {
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        BackgroundColor = new BaseColor(211, 211, 211)
                    });
                    tabla.AddCell(new PdfPCell(new Phrase("Fecha", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))
                    {
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        BackgroundColor = new BaseColor(211, 211, 211)
                    });

                    foreach (DataGridViewRow fila in dataGridViewPedidos.Rows)
                    {
                        if (fila.Cells["IDPEDIDO"].Value != null) tabla.AddCell(fila.Cells["IDPEDIDO"].Value.ToString());
                        if (fila.Cells["TOTAL"].Value != null) tabla.AddCell(fila.Cells["TOTAL"].Value.ToString());
                        if (fila.Cells["FECHA"].Value != null) tabla.AddCell(fila.Cells["FECHA"].Value.ToString());
                    }

                    documento.Add(tabla);

                    // Total
                    Paragraph total = new Paragraph($"\nTotal: {lblTotal.Text}", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12));
                    total.Alignment = Element.ALIGN_RIGHT;
                    documento.Add(total);

                    // Estadísticas
                    Paragraph estadisticas = new Paragraph($"\nEstadísticas de Ventas:\n" +
                                                          $"Total Ventas (Global): {totalVentas:C2}\n" +
                                                          $"Ventas del Vendedor: {ventasUsuario:C2}\n" +
                                                          $"Porcentaje de Ventas: {porcentaje:F2}%",
                                                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12));
                    estadisticas.Alignment = Element.ALIGN_LEFT;
                    estadisticas.SpacingBefore = 20;
                    documento.Add(estadisticas);

                    // Si no hay espacio suficiente para el gráfico en esta página, crear una nueva
                    // Preparamos los elementos pero NO los agregamos aún
                    Paragraph tituloGrafico = new Paragraph("Participación del Vendedor en las Ventas", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12));
                    tituloGrafico.Alignment = Element.ALIGN_CENTER;
                    tituloGrafico.SpacingBefore = 20;

                    iTextSharp.text.Image grafico = iTextSharp.text.Image.GetInstance(rutaGrafico);
                    grafico.ScaleToFit(300, 200);
                    grafico.Alignment = Element.ALIGN_CENTER;
                    grafico.SpacingBefore = 10;

                    // Estimamos el alto necesario (aproximado: título + espaciado + imagen)
                    float altoEstimado = 20 + 10 + grafico.ScaledHeight + 20;  // margen de seguridad

                    float espacioDisponible = writer.GetVerticalPosition(true) - documento.BottomMargin;

                    if (espacioDisponible < altoEstimado)
                    {
                        documento.NewPage();
                        Paragraph nuevoTitulo = new Paragraph("-", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14));
                        nuevoTitulo.Alignment = Element.ALIGN_CENTER;
                        nuevoTitulo.SpacingAfter = 15;
                        documento.Add(nuevoTitulo);
                    }

                    // Ahora sí: agregar ambos juntos
                    documento.Add(tituloGrafico);
                    documento.Add(grafico);


                    documento.Close();
                    writer.Close();
                }

                // Abrir PDF
                MessageBox.Show($"Reporte generado exitosamente en:\n{rutaPDF}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = rutaPDF,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el nombre seleccionado
            string usuarioSeleccionado = comboBoxUsuarios.SelectedItem.ToString();
            // Limpiar los datos del DataGridView
            dataGridViewPedidos.DataSource = null;

            // Opcional: restablecer el texto del total
            lblTotal.Text = "Total: $0.00";


        }
    }
}
