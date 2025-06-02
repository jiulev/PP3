using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;




namespace FotoRoman
{
    public partial class FormVerPedido : Form
    {
        private List<Cliente> listaClientesCompleta;

        public FormVerPedido()
        {
            InitializeComponent();
        }


        private void MostrarPedido(Pedido pedido)
        {
            try
            {
                if (pedido.oCliente == null)
                {
                    MessageBox.Show("No se encontraron datos del cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Asignar datos
                textBoxIdPedido.Text = pedido.IDPEDIDO.ToString();
                textBoxEstado.Text = pedido.ESTADO;

                // Estilo y comportamiento del botón Editar
                if (pedido.ESTADO.Equals("Finalizado", StringComparison.OrdinalIgnoreCase))
                {
                    buttonEditar.Enabled = false;
                    buttonEditar.BackColor = Color.LightGray;
                    buttonEditar.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold);
                    buttonEditar.FlatStyle = FlatStyle.Standard;
                    labelPedidoFinalizado.Visible = true;
                }
                else
                {
                    buttonEditar.Enabled = true;
                    buttonEditar.BackColor = Color.DarkSalmon;
                    buttonEditar.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold);
                    buttonEditar.FlatStyle = FlatStyle.Standard;
                    labelPedidoFinalizado.Visible = false;
                }

                // Cliente y observaciones
                comboBoxClientes.Text = pedido.oCliente.NOMBRE;
                textBoxDatosCliente.Text = pedido.oCliente.NOMBRE;
                textBoxCorreo.Text = pedido.oCliente.CORREO ?? "Sin Correo";
                textBoxLocalidad.Text = pedido.oCliente.LOCALIDAD ?? "Sin Localidad";
                textBoxProvincia.Text = pedido.oCliente.PROVINCIA ?? "Sin Provincia";

                // Observaciones
                label2.Text = "Observaciones del pedido:\n" +
                    (string.IsNullOrWhiteSpace(pedido.OBSERVACIONES) ? "Sin observaciones Indicadas" : pedido.OBSERVACIONES);

                // Detalles
                var detalles = CNPedido.ObtenerDetallesDelPedido(pedido.IDPEDIDO);
                dataGridViewDetallePedido.DataSource = detalles.Select(detalle => new
                {
                    Producto = detalle.oProducto.Nombre,
                    Cantidad = detalle.CANTIDAD,
                    PrecioUnitario = detalle.PRECIOUNITARIO,
                    Subtotal = detalle.SUBTOTAL
                }).ToList();

                // Pagos
                dataGridViewPagos.DataSource = CNPedido.ObtenerPagosDelPedido(pedido.IDPEDIDO);
                dataGridViewPagos.AutoResizeColumns();
                dataGridViewPagos.AutoResizeRows();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar el pedido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textBoxIdPedido.Text))
                {
                    // Buscar por ID de pedido si el campo no está vacío
                    if (int.TryParse(textBoxIdPedido.Text, out int idPedido))
                    {
                        Pedido? pedido = CNPedido.BuscarPedidoPorId(idPedido);

                        if (pedido != null)
                        {
                            // Si se encuentra el pedido, mostrarlo
                            MostrarPedido(pedido);
                        }
                        else
                        {
                            MessageBox.Show("No se encontró un pedido con este ID.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El ID de pedido debe ser un número válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (!string.IsNullOrWhiteSpace(comboBoxClientes.Text))
                {
                    // Si se ingresó un nombre de cliente, buscar por cliente
                    List<Pedido> pedidos = CNPedido.BuscarPedidosPorNombreCliente(comboBoxClientes.Text);

                    if (pedidos.Count == 1)
                    {
                        // Si hay un solo pedido, mostrar directamente
                        MostrarPedido(pedidos[0]);
                    }
                    else if (pedidos.Count > 1)
                    {
                        // Si hay múltiples pedidos, abrir el formulario de selección
                        using (var formSeleccionar = new FormSeleccionarPedido(pedidos))
                        {
                            if (formSeleccionar.ShowDialog() == DialogResult.OK)
                            {
                                // Cargar el pedido seleccionado
                                Pedido pedidoSeleccionado = formSeleccionar.PedidoSeleccionado;
                                MostrarPedido(pedidoSeleccionado);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron pedidos para este cliente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un ID de pedido o un nombre de cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar pedidos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxIdPedido.Text))
                {
                    MessageBox.Show("Primero debes buscar un pedido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idPedido = Convert.ToInt32(textBoxIdPedido.Text);
                Pedido? pedido = CNPedido.BuscarPedidoPorId(idPedido);

                if (pedido == null)
                {
                    MessageBox.Show("No se encontró el pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Definir la ruta del archivo PDF
                string rutaPDF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Pedido_{idPedido}.pdf");

                // Crear el documento PDF
                using (Document documento = new Document(PageSize.A4, 36, 36, 36, 36))
                {
                    PdfWriter.GetInstance(documento, new FileStream(rutaPDF, FileMode.Create));
                    documento.Open();

                    // Agregar logo a la derecha
                    string logoPath = @"C:\Users\JSofia\Desktop\ISSD\2022 SEGUNDO SEMESTRE\PP1\imagens\roman.png";
                    if (File.Exists(logoPath))
                    {
                        iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoPath);
                        logo.Alignment = Element.ALIGN_RIGHT; // Alineación del logo a la derecha
                        float width = 230; // Ancho máximo
                        float height = 150; // Alto máximo
                        logo.ScaleToFit(width, height); // Escalar el logo manteniendo la relación de aspecto
                        float marginRight = 10; // Margen derecho
                        float marginTop = 20; // Margen superior
                        logo.SetAbsolutePosition(documento.PageSize.Width - width - marginRight, documento.PageSize.Height - height - marginTop);
                        documento.Add(logo);
                    }

                    // Espacio entre logo y contenido
                    documento.Add(new Paragraph("\n"));

                    // Encabezado principal
                    documento.Add(new Paragraph("Detalle del Pedido\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14)));
                    documento.Add(new Paragraph("\n"));

                    // Tabla de datos del cliente
                    PdfPTable tablaCliente = new PdfPTable(2); // 2 columnas
                    tablaCliente.WidthPercentage = 50; // Ajustar el ancho de la tabla al 50% del ancho de la página
                    tablaCliente.HorizontalAlignment = Element.ALIGN_LEFT; // Alineación a la izquierda
                    tablaCliente.SpacingBefore = 10f;

                    // Filas de datos del cliente
                    tablaCliente.AddCell(CrearCelda("ID Pedido:", true));
                    tablaCliente.AddCell(CrearCelda(pedido.IDPEDIDO.ToString()));

                    tablaCliente.AddCell(CrearCelda("Cliente:", true));
                    tablaCliente.AddCell(CrearCelda(pedido.oCliente?.NOMBRE ?? "Sin Nombre"));

                    tablaCliente.AddCell(CrearCelda("Correo:", true));
                    tablaCliente.AddCell(CrearCelda(pedido.oCliente?.CORREO ?? "Sin Correo"));

                    tablaCliente.AddCell(CrearCelda("Localidad:", true));
                    tablaCliente.AddCell(CrearCelda(pedido.oCliente?.LOCALIDAD ?? "Sin Localidad"));

                    tablaCliente.AddCell(CrearCelda("Provincia:", true));
                    tablaCliente.AddCell(CrearCelda(pedido.oCliente?.PROVINCIA ?? "Sin Provincia"));

                    documento.Add(tablaCliente);

                    // Espacio entre tablas
                    documento.Add(new Paragraph("\n"));

                    // Tabla de productos
                    documento.Add(new Paragraph("Detalle de Productos\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14)));

                    PdfPTable tablaProductos = new PdfPTable(4); // 4 columnas
                    tablaProductos.WidthPercentage = 100; // Ancho de la tabla
                    tablaProductos.SpacingBefore = 10f;

                    // Encabezados de la tabla
                    tablaProductos.AddCell(CrearCelda("Producto", true));
                    tablaProductos.AddCell(CrearCelda("Cantidad", true));
                    tablaProductos.AddCell(CrearCelda("Precio Unitario", true));
                    tablaProductos.AddCell(CrearCelda("Subtotal", true));

                    // Detalles de los productos
                    var detalles = CNPedido.ObtenerDetallesDelPedido(pedido.IDPEDIDO);
                    foreach (var detalle in detalles)
                    {
                        tablaProductos.AddCell(CrearCelda(detalle.oProducto?.Nombre ?? "Sin Nombre"));
                        tablaProductos.AddCell(CrearCelda(detalle.CANTIDAD.ToString()));
                        tablaProductos.AddCell(CrearCelda(detalle.PRECIOUNITARIO.ToString("F2")));
                        tablaProductos.AddCell(CrearCelda(detalle.SUBTOTAL.ToString("F2")));
                    }

                    documento.Add(tablaProductos);

                    // Total del pedido
                    documento.Add(new Paragraph("\n"));

                    Paragraph totalParagraph = new Paragraph($"Total del Pedido: ${pedido.TOTAL:F2}", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14))
                    {
                        Alignment = Element.ALIGN_RIGHT // Alinear a la derecha
                    };

                    documento.Add(totalParagraph);


                    // Mostrar mensaje de éxito
                    MessageBox.Show($"Archivo PDF generado exitosamente en:\n{rutaPDF}", "Archivo Generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = rutaPDF,
                        UseShellExecute = true
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el archivo PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método auxiliar para crear celdas
        private PdfPCell CrearCelda(string texto, bool esEncabezado = false)
        {
            var fuente = esEncabezado ? FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12) : FontFactory.GetFont(FontFactory.HELVETICA, 12);
            var celda = new PdfPCell(new Phrase(texto, fuente))
            {
                Border = PdfPCell.BOX,
                Padding = 5,
                HorizontalAlignment = Element.ALIGN_LEFT
            };
            return celda;
        }


        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                // Limpiar todos los campos del formulario
                textBoxIdPedido.Clear();
                comboBoxClientes.SelectedIndex = -1;
                textBoxDatosCliente.Clear();
                textBoxCorreo.Clear();
                textBoxLocalidad.Clear();
                textBoxProvincia.Clear();
           
                dataGridViewDetallePedido.DataSource = null;
                dataGridViewPagos.DataSource = null;
                label2.Text = "Observaciones del pedido:\nSin observaciones indicadas";


                MessageBox.Show("Formulario limpiado exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al limpiar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormVerPedido_Load(object sender, EventArgs e)
        {
           
            try
            {

               
                // Obtener la lista de clientes desde la capa de negocio
                var clientes = CNPedido.ListarTodosLosClientes();
                listaClientesCompleta = clientes;
                // Configurar el comboBoxClientes
                comboBoxClientes.DataSource = clientes;             // Asignar la lista de clientes como fuente de datos
                comboBoxClientes.DisplayMember = "NOMBRE";         // Campo que se mostrará en el combo box
                comboBoxClientes.ValueMember = "IDCliente";        // Campo asociado al valor del combo box
                comboBoxClientes.SelectedIndex = -1;               // Inicialmente, sin selección
                comboBoxClientes.DropDownStyle = ComboBoxStyle.DropDown;
                comboBoxClientes.AutoCompleteMode = AutoCompleteMode.None;
                comboBoxClientes.AutoCompleteSource = AutoCompleteSource.None;
                comboBoxClientes.TextChanged += comboBoxClientes_TextChanged;

           
                // Estilo visual personalizado
            
                comboBoxClientes.BackColor = Color.White;
                comboBoxClientes.ForeColor = Color.Black;
                comboBoxClientes.FlatStyle = FlatStyle.Flat;




            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboBoxClientes_TextChanged(object sender, EventArgs e)
        {
            string textoActual = comboBoxClientes.Text;

            // Evita autoselección si ya se está editando
            if (comboBoxClientes.Focused == false)
                return;

            // Buscar coincidencias
            var coincidencias = listaClientesCompleta
                .Where(c => c.NOMBRE.IndexOf(textoActual, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            // Detener evento momentáneamente
            comboBoxClientes.TextChanged -= comboBoxClientes_TextChanged;

            // Guardar posición actual del cursor
            int posicionCursor = comboBoxClientes.SelectionStart;

            comboBoxClientes.DroppedDown = false;
            comboBoxClientes.DataSource = null;

            if (coincidencias.Any())
            {
                comboBoxClientes.DataSource = coincidencias;
                comboBoxClientes.DisplayMember = "NOMBRE";
                comboBoxClientes.SelectedIndex = -1;

                comboBoxClientes.MaxDropDownItems = Math.Min(coincidencias.Count, 8);
                comboBoxClientes.DroppedDown = true;
            }

            // Restaurar el texto escrito manualmente
            comboBoxClientes.Text = textoActual;
            comboBoxClientes.SelectionStart = posicionCursor;
            comboBoxClientes.SelectionLength = 0;

            // Reactivar evento
            comboBoxClientes.TextChanged += comboBoxClientes_TextChanged;
        }






        private void buttonEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxIdPedido.Text))
                {
                    MessageBox.Show("Primero debes buscar y seleccionar un pedido para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idPedido = Convert.ToInt32(textBoxIdPedido.Text);
                Pedido? pedido = CNPedido.BuscarPedidoPorId(idPedido);

                if (pedido == null)
                {
                    MessageBox.Show("No se encontró el pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ✅ Nueva validación: si el pedido está finalizado, mostrar mensaje y salir
                if (pedido.ESTADO.Equals("Finalizado", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Este pedido está finalizado y no puede ser editado.", "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<DetallePedido> detalles = CNPedido.ObtenerDetallesDelPedido(idPedido);

                // Abrimos el formulario de edición y le pasamos el pedido + detalles
                using (FormEditarPedido formEditar = new FormEditarPedido(pedido, detalles))
                {
                    if (formEditar.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Este pedido ha sido Editado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarPedido(CNPedido.BuscarPedidoPorId(idPedido)); // Actualizar visualización
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar editar el pedido: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
