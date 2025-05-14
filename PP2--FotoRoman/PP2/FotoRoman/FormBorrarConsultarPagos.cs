using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing.Drawing2D;


namespace FotoRoman
{
    public partial class FormBorrarConsultarPagos : Form
    {
        public FormBorrarConsultarPagos()
        {
            InitializeComponent();
            this.Load += FormVerPagos_Load; // para que see ejecute ell método que carga los clientes
            textBoxIdPedido.Click += textBoxIdPedido_Click;
        }

        private void FormVerPagos_Load(object sender, EventArgs e)
        {
            try
            {
                var clientes = CNPedido.ListarTodosLosClientes();
                comboBoxClientes.DataSource = clientes;
                comboBoxClientes.DisplayMember = "NOMBRE";
                comboBoxClientes.ValueMember = "IDCliente";
                comboBoxClientes.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.White,         // Blanco arriba
                Color.LightGray,     // Gris claro abajo
                90F))                // Vertical
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void ButtonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(textBoxIdPedido.Text, out int idPedido))
                {
                    MessageBox.Show("Ingrese un ID de pedido válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBoxClientes.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un cliente antes de buscar pagos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idCliente = Convert.ToInt32(comboBoxClientes.SelectedValue);

                // Obtener los pagos solo si el pedido pertenece al cliente
                var pagos = CNPago.ObtenerPagosDelPedido(idPedido);

                if (pagos != null && pagos.Count > 0)
                {
                    dataGridViewPagos.DataSource = pagos;
                }
                else
                {
                    MessageBox.Show("No se encontraron pagos para este pedido y cliente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewPagos.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar pagos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ButtonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxIdPedido.Clear();
            comboBoxClientes.SelectedIndex = -1;
            dataGridViewPagos.DataSource = null;
        }

        private void ButtonCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxIdPedido_Click(object sender, EventArgs e)
        {
            if (comboBoxClientes.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un cliente primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreSeleccionado = comboBoxClientes.Text;
            int idCliente = CNPedido.ObtenerIdClientePorNombre(nombreSeleccionado);

            List<Pedido> pedidosCliente = CNPedido.BuscarPedidosPorIdCliente(idCliente);

            // info de depuración
            MessageBox.Show($"IDCliente seleccionado: {idCliente}\nCantidad de pedidos encontrados: {pedidosCliente.Count}",
                "Depuración", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (pedidosCliente.Count == 0)
            {
                MessageBox.Show("Este cliente no tiene pedidos registrados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (FormSeleccionarPagos form = new FormSeleccionarPagos(pedidosCliente))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    int idPedidoSeleccionado = form.IDPedidoSeleccionado;
                    textBoxIdPedido.Text = idPedidoSeleccionado.ToString();

                    List<Pago> pagos = CNPago.ObtenerPagosDelPedido(idPedidoSeleccionado);
                    if (pagos.Count == 0)
                    {
                        MessageBox.Show("El pedido seleccionado no tiene pagos registrados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridViewPagos.DataSource = null;
                    }
                    else
                    {
                        dataGridViewPagos.DataSource = pagos;
                    }
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxIdPedido.Text))
                {
                    MessageBox.Show("Primero debes buscar un pedido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idPedido = Convert.ToInt32(textBoxIdPedido.Text);
               int idCliente = Convert.ToInt32(comboBoxClientes.SelectedValue);
List<Pago> pagos = CNPago.ObtenerPagosDelPedido(idPedido);


                if (pagos == null || pagos.Count == 0)
                {
                    MessageBox.Show("No se encontraron pagos para este pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string rutaPDF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Pagos_{idPedido}.pdf");

                using (Document documento = new Document(PageSize.A4, 36, 36, 36, 36))
                {
                    PdfWriter.GetInstance(documento, new FileStream(rutaPDF, FileMode.Create));
                    documento.Open();

                    documento.Add(new Paragraph("Detalle de Pagos", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14)));
                    documento.Add(new Paragraph($"\nID del Pedido: {idPedido}", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                    documento.Add(new Paragraph("\n"));

                    PdfPTable tablaPagos = new PdfPTable(3);
                    tablaPagos.WidthPercentage = 100;

                    tablaPagos.AddCell(CrearCelda("Fecha de Pago", true));
                    tablaPagos.AddCell(CrearCelda("Monto", true));
                    tablaPagos.AddCell(CrearCelda("Método de Pago", true));

                    foreach (var pago in pagos)
                    {
                        tablaPagos.AddCell(CrearCelda(pago.FECHAPAGO.ToString("dd/MM/yyyy")));
                        tablaPagos.AddCell(CrearCelda($"${pago.MONTOPAGO:F2}"));
                        tablaPagos.AddCell(CrearCelda(pago.METODOPAGO));
                    }

                    documento.Add(tablaPagos);
                    documento.Close();

                    MessageBox.Show($"PDF generado correctamente en: {rutaPDF}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = rutaPDF,
                        UseShellExecute = true
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
    }
}
