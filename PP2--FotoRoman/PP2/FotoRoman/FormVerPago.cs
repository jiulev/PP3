using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace FotoRoman
{
    public partial class FormVerPago : Form
    {
        public FormVerPago()
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

                // Asignar datos al TextBox del ID de pedido
                textBoxIdPedido.Text = pedido.IDPEDIDO.ToString();

                // Asignar datos al ComboBox de clientes
                comboBoxClientes.Text = pedido.oCliente.NOMBRE;

                // Asignar datos a los TextBox individuales
                textBoxDatosCliente.Text = pedido.oCliente.NOMBRE; // Apellido y Nombre
                textBoxCorreo.Text = pedido.oCliente.CORREO ?? "Sin Correo"; // Correo
                textBoxLocalidad.Text = pedido.oCliente.LOCALIDAD ?? "Sin Localidad"; // Localidad
                textBox1.Text = pedido.oCliente.PROVINCIA ?? "Sin Provincia"; // Provincia

                // Asignar datos al DataGridView de pagos
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
                    int idPedido = Convert.ToInt32(textBoxIdPedido.Text);
                    Pedido? pedido = CNPedido.BuscarPedidoPorId(idPedido);

                    if (pedido != null)
                    {
                        MostrarPedido(pedido);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el pedido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (!string.IsNullOrWhiteSpace(comboBoxClientes.Text))
                {
                    List<Pedido> pedidos = CNPedido.BuscarPedidosPorNombreCliente(comboBoxClientes.Text);

                    if (pedidos.Count == 1)
                    {
                        MostrarPedido(pedidos[0]);
                    }
                    else if (pedidos.Count > 1)
                    {
                        MessageBox.Show("Hay múltiples coincidencias. Por favor, ingrese el ID del pedido para detalles específicos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron coincidencias.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese el ID del pedido o seleccione un cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar el pedido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string rutaPDF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Pagos_Pedido_{idPedido}.pdf");

                // Crear el documento PDF
                using (Document documento = new Document())
                {
                    PdfWriter.GetInstance(documento, new FileStream(rutaPDF, FileMode.Create));
                    documento.Open();

                    // Información del cliente
                    documento.Add(new Paragraph("Detalle del Cliente\n", iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 14)));
                    documento.Add(new Paragraph($"ID Pedido: {pedido.IDPEDIDO}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                    documento.Add(new Paragraph($"Cliente: {pedido.oCliente?.NOMBRE ?? "Sin Nombre"}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                    documento.Add(new Paragraph($"Correo: {textBoxCorreo.Text}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                    documento.Add(new Paragraph($"Localidad: {textBoxLocalidad.Text}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                    documento.Add(new Paragraph($"Provincia: {textBox1.Text}\n\n", FontFactory.GetFont(FontFactory.HELVETICA, 12)));

                    // Tabla de pagos
                    documento.Add(new Paragraph("Detalle de Pagos\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14)));

                    PdfPTable tabla = new PdfPTable(4); // 4 columnas
                    tabla.WidthPercentage = 100;

                    // Encabezados
                    tabla.AddCell("ID Pago");
                    tabla.AddCell("Monto");
                    tabla.AddCell("Fecha");
                    tabla.AddCell("Método de Pago");

                    // Detalles de pagos
                    var pagos = CNPedido.ObtenerPagosDelPedido(pedido.IDPEDIDO);
                    if (pagos.Count > 0)
                    {
                        foreach (var pago in pagos)
                        {
                            tabla.AddCell(pago.IDPAGO.ToString());
                            tabla.AddCell(pago.MONTOPAGO.ToString("F2"));
                            tabla.AddCell(pago.FECHAPAGO.ToShortDateString());
                            tabla.AddCell(pago.METODOPAGO);
                        }
                    }
                    else
                    {
                        PdfPCell celdaSinDatos = new PdfPCell(new Phrase("Sin pagos registrados"))
                        {
                            Colspan = 4,
                            HorizontalAlignment = Element.ALIGN_CENTER
                        };
                        tabla.AddCell(celdaSinDatos);
                    }

                    documento.Add(tabla);
                    documento.Close();
                }

                // Mostrar mensaje de éxito
                MessageBox.Show($"Archivo PDF generado exitosamente en:\n{rutaPDF}", "Archivo Generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = rutaPDF,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el archivo PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                // Limpiar todos los campos del formulario
                textBoxIdPedido.Clear();
                comboBoxClientes.SelectedIndex = -1;
                textBoxDatosCliente.Clear();

                dataGridViewPagos.DataSource = null;

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

        private void FormVerPago_Load(object sender, EventArgs e)
        {
            try
            {
                // Obtener la lista de clientes desde la capa de negocio
                var clientes = CNPedido.ListarTodosLosClientes();

                // Configurar el comboBoxClientes
                comboBoxClientes.DataSource = clientes;
                comboBoxClientes.DisplayMember = "NOMBRE";
                comboBoxClientes.ValueMember = "IDCliente";
                comboBoxClientes.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

