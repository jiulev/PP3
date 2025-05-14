using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace FotoRoman
{
    public partial class FormEditarCobro : Form
    {
        private List<Cliente> listaClientes;

        public FormEditarCobro()
        {
            InitializeComponent();
        }

        private void FormEditarCobro_Load(object sender, EventArgs e)
        {
            CargarClientes();
            dateTimePickerDesde.Value = DateTime.Now.AddMonths(-1);
            dateTimePickerHasta.Value = DateTime.Now;

            // Definir columnas si no usás DataSource
            dataGridViewCobros.Columns.Clear();
            dataGridViewCobros.Columns.Add("IDPEDIDO", "ID Pedido");
            dataGridViewCobros.Columns.Add("FECHAPEDIDO", "Fecha");
            dataGridViewCobros.Columns.Add("ESTADO", "Estado");
            dataGridViewCobros.Columns.Add("TOTAL", "Total Pedido");
            dataGridViewCobros.Columns.Add("TOTALPAGADO", "Total Pagado");
            // Configuración del combo para que permita buscar escribiendo
            comboClientes.DropDownStyle = ComboBoxStyle.DropDown;
          comboClientes.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboClientes.AutoCompleteSource = AutoCompleteSource.ListItems;

            comboClientes.TextUpdate += (s, e) =>
            {
                if (comboClientes.DroppedDown)
                    comboClientes.DroppedDown = false;
            };

        }


        private void CargarClientes()
        {
            listaClientes = CNCliente.ListarClientes();

            // Ordenar por nombre
            listaClientes.Sort((c1, c2) => string.Compare(c1.NOMBRE, c2.NOMBRE, StringComparison.OrdinalIgnoreCase));

            comboClientes.Items.Clear();
            foreach (var cliente in listaClientes)
            {
                comboClientes.Items.Add(cliente);
            }

            comboClientes.DisplayMember = "NOMBRE";
            comboClientes.ValueMember = "IDCliente";

            // Seleccionar automáticamente el primero
            if (comboClientes.Items.Count > 0)
                comboClientes.SelectedIndex = 0;
        }


        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            if (comboClientes.SelectedItem is Cliente clienteSeleccionado)
            {
                int idCliente = clienteSeleccionado.IDCliente;
                DateTime fechaDesde = dateTimePickerDesde.Value.Date;
                DateTime fechaHasta = dateTimePickerHasta.Value.Date;

                var pedidos = CNPago.ObtenerPedidosConImporteYEstado(idCliente);

                var pagos = new List<(Pedido pedido, decimal totalPagado)>();

                foreach (var pedido in pedidos)
                {
                    if (pedido.FECHAPEDIDO.Date >= fechaDesde && pedido.FECHAPEDIDO.Date <= fechaHasta)
                    {
                        var pagosPedido = CNPago.ObtenerPagosDelPedido(pedido.IDPEDIDO);
                        decimal totalPagado = 0;

                        foreach (var p in pagosPedido)
                        {
                            totalPagado += p.MONTOPAGO;
                        }

                        pagos.Add((pedido, totalPagado));
                    }
                }

                dataGridViewCobros.Rows.Clear();
                foreach (var item in pagos)
                {
                    dataGridViewCobros.Rows.Add(
                        item.pedido.IDPEDIDO,
                        item.pedido.FECHAPEDIDO.ToShortDateString(),
                        item.pedido.ESTADO,
                        item.pedido.TOTAL.ToString("0.00"),
                        item.totalPagado.ToString("0.00")
                    );
                }
            }
        }
        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewCobros.SelectedRows.Count > 0)
            {
                int idPedido = Convert.ToInt32(dataGridViewCobros.SelectedRows[0].Cells[0].Value);
                FormEditarPagoSeleccionado formEditarPago = new FormEditarPagoSeleccionado(idPedido);
                formEditarPago.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione un pedido para editar el cobro.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}