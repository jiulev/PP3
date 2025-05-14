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
            // Ruta para guardar la imagen del gráfico
            string rutaImagen = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "GraficoTorta.png");

            // Crear un bitmap donde dibujar
            using (Bitmap bitmap = new Bitmap(400, 300))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    // Colores para las partes del gráfico
                    Brush brushUsuario = Brushes.Red;
                    Brush brushRestante = Brushes.Gray;

                    // Fondo blanco
                    g.Clear(Color.White);

                    // Calcular ángulos para el gráfico
                    float porcentajeUsuario = totalVentas > 0 ? (float)((ventasUsuario / totalVentas) * 360) : 0;
                    float porcentajeRestante = 360 - porcentajeUsuario;

                    // Dibujar gráfico
                    System.Drawing.Rectangle rect = new System.Drawing.Rectangle(50, 50, 200, 200);
                    g.FillPie(brushUsuario, rect, 0, porcentajeUsuario);
                    g.FillPie(brushRestante, rect, porcentajeUsuario, porcentajeRestante);

                    // Dibujar leyenda
                    g.DrawString("Vendedor", new System.Drawing.Font("Arial", 12), brushUsuario, 270, 70);
                    g.DrawString("Resto", new System.Drawing.Font("Arial", 12), brushRestante, 270, 100);
                }

                // Guardar la imagen
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

                // Ajustar el rango de fechas
                DateTime fechaDesde = dtpFechaDesde.Value.Date;
                DateTime fechaHasta = dtpFechaHasta.Value.Date.AddDays(1).AddSeconds(-1);

                // Obtener los pedidos del usuario en el rango de fechas
                var pedidos = CNPedido.ObtenerPedidosPorUsuarioYFechas(usuario.IDUSUARIO, fechaDesde, fechaHasta);

                if (pedidos == null || pedidos.Count == 0)
                {
                    MessageBox.Show("No se encontraron pedidos para el usuario en el rango de fechas especificado.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblTotal.Text = "Total: $0.00";
                    return;
                }

                // Preparar los datos para mostrar en el DataGridView
                var detalles = pedidos.Select(p => new
                {
                    p.IDPEDIDO,
                    TOTAL = p.TOTAL, // Mostrar la columna TOTAL
                    FECHA = p.FECHAPEDIDO.ToString("dd/MM/yyyy HH:mm:ss") // Mostrar fecha y hora
                }).ToList();

                // Asignar el DataSource al DataGridView
                dataGridViewPedidos.DataSource = detalles;

                // Ajustar las columnas y filas al contenido
                dataGridViewPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridViewPedidos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridViewPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

                // Calcular el total directamente desde el origen de datos
                decimal sumaTotal = detalles.Sum(d => d.TOTAL);

                // Mostrar el total en el label
                lblTotal.Text = $"Total: {sumaTotal:C2}"; // Mostrar el total en formato moneda
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

                // Ruta para guardar el archivo PDF
                string rutaPDF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ReporteVentas.pdf");

                // Ruta del logo
                string rutaLogo = @"C:\Users\JSofia\Desktop\ISSD\2022 SEGUNDO SEMESTRE\PP1\imagens\roman.png";
                
                // Verificar si la imagen existe
                if (!System.IO.File.Exists(rutaLogo))
                {
                    MessageBox.Show("El archivo de logo no existe en la ruta especificada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Crear el documento PDF
                using (FileStream stream = new FileStream(rutaPDF, FileMode.Create))
                {
                    Document documento = new Document(PageSize.A4, 25, 25, 30, 30);
                    PdfWriter writer = PdfWriter.GetInstance(documento, stream);

                    documento.Open();

                    // Agregar logo al reporte
                    try
                    {
                        iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(rutaLogo);
                        logo.ScaleToFit(200, 100); // Ajustar tamaño del logo
                        logo.Alignment = iTextSharp.text.Element.ALIGN_LEFT;
                        documento.Add(logo);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al agregar el logo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Título del reporte
                    Paragraph titulo = new Paragraph("Reporte de Pedidos", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16));
                    titulo.Alignment = Element.ALIGN_CENTER;
                    titulo.SpacingAfter = 20;
                    documento.Add(titulo);

                    // Subtítulo con información del usuario y fechas
                    Paragraph info = new Paragraph($"Usuario: {comboBoxUsuarios.Text}\n" +
                                                    $"Desde: {dtpFechaDesde.Value:dd/MM/yyyy}\n" +
                                                    $"Hasta: {dtpFechaHasta.Value:dd/MM/yyyy}\n",
                                                    FontFactory.GetFont(FontFactory.HELVETICA, 12));
                    info.Alignment = Element.ALIGN_LEFT;
                    info.SpacingAfter = 20;
                    documento.Add(info);

                    // Crear la tabla con los datos
                    PdfPTable tabla = new PdfPTable(3);
                    tabla.WidthPercentage = 100;
                    tabla.SetWidths(new float[] { 1, 1, 1 }); // Proporción de las columnas

                    // Encabezados de la tabla
                    tabla.AddCell(new PdfPCell(new Phrase("ID Pedido", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))
                    {
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        BackgroundColor = new iTextSharp.text.BaseColor(211, 211, 211) // Gris claro
                    });
                    tabla.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))
                    {
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        BackgroundColor = new iTextSharp.text.BaseColor(211, 211, 211)
                    });
                    tabla.AddCell(new PdfPCell(new Phrase("Fecha", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))
                    {
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        BackgroundColor = new iTextSharp.text.BaseColor(211, 211, 211)
                    });

                    // Agregar las filas del DataGridView al PDF
                    foreach (DataGridViewRow fila in dataGridViewPedidos.Rows)
                    {
                        if (fila.Cells["IDPEDIDO"].Value != null) tabla.AddCell(fila.Cells["IDPEDIDO"].Value.ToString());
                        if (fila.Cells["TOTAL"].Value != null) tabla.AddCell(fila.Cells["TOTAL"].Value.ToString());
                        if (fila.Cells["FECHA"].Value != null) tabla.AddCell(fila.Cells["FECHA"].Value.ToString());
                    }

                    documento.Add(tabla);

                    // Agregar el total al final
                    Paragraph total = new Paragraph($"\nTotal: {lblTotal.Text}", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12));
                    total.Alignment = Element.ALIGN_RIGHT;
                    documento.Add(total);

                    // Agregar estadísticas de ventas
                    Paragraph estadisticas = new Paragraph($"\nEstadísticas de Ventas:\n" +
                                                          $"Total Ventas (Global): {totalVentas:C2}\n" +
                                                          $"Ventas del Vendedor: {ventasUsuario:C2}\n" +
                                                          $"Porcentaje de Ventas: {porcentaje:F2}%",
                                                          FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12));
                    estadisticas.Alignment = Element.ALIGN_LEFT;
                    estadisticas.SpacingBefore = 20;
                    documento.Add(estadisticas);

                    // Agregar el gráfico de torta al reporte
                    iTextSharp.text.Image grafico = iTextSharp.text.Image.GetInstance(rutaGrafico);
                    grafico.ScaleToFit(300, 200);
                    grafico.Alignment = Element.ALIGN_CENTER;
                    grafico.SpacingBefore = 20;
                    documento.Add(grafico);

                    documento.Close();
                    writer.Close();
                }

                // Abrir el PDF generado
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
