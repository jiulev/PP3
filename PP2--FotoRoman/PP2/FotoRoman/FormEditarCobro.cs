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
            dateTimePickerHasta.Value = DateTime.Now;

            // Validación de rol
            if (UsuarioActual.Usuario.oRol.DESCRIPCION == "Vendedor")
            {
                dateTimePickerDesde.Enabled = false;
                dateTimePickerDesde.Value = DateTime.Now.AddDays(-30); // solo últimos 30 días
            }
            else
            {
                dateTimePickerDesde.Enabled = true;
                dateTimePickerDesde.Value = DateTime.Now.AddMonths(-1);
            }

            // Configuración columnas
            dataGridViewCobros.Columns.Clear();
            dataGridViewCobros.Columns.Add("IDPEDIDO", "ID Pedido");
            dataGridViewCobros.Columns.Add("FECHAPEDIDO", "Fecha");
            dataGridViewCobros.Columns.Add("ESTADO", "Estado");
            dataGridViewCobros.Columns.Add("TOTAL", "Total Pedido");
            dataGridViewCobros.Columns.Add("TOTALPAGADO", "Total Pagado");

            // Configurar combo
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
                        decimal totalPagado = pagosPedido.Sum(p => p.MONTOPAGO);
                        pagos.Add((pedido, totalPagado));
                    }
                }

                dataGridViewCobros.Rows.Clear();

                foreach (var item in pagos)
                {
                    int rowIndex = dataGridViewCobros.Rows.Add(
                        item.pedido.IDPEDIDO,
                        item.pedido.FECHAPEDIDO.ToShortDateString(),
                        item.pedido.ESTADO,
                          $"${item.pedido.TOTAL:0.00}",
                          $"${item.totalPagado:0.00}"
                    );

                    DataGridViewRow row = dataGridViewCobros.Rows[rowIndex];
                    string estado = item.pedido.ESTADO;
                    row.DefaultCellStyle.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);

                    if (estado == "Finalizado")
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 160, 160); // Rojo claro
                        row.DefaultCellStyle.ForeColor = Color.Black;
                        row.DefaultCellStyle.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
                    }
                    else if (estado == "En proceso")
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(144, 238, 144); // Verde claro
                        row.DefaultCellStyle.ForeColor = Color.Black;
                        row.DefaultCellStyle.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
                    }
                    // "Pendiente" → sin formato: queda en blanco
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
                string estado = dataGridViewCobros.SelectedRows[0].Cells["ESTADO"].Value.ToString();
                DateTime fecha = Convert.ToDateTime(dataGridViewCobros.SelectedRows[0].Cells["FECHAPEDIDO"].Value);
                string rolUsuario = UsuarioActual.Usuario.oRol.DESCRIPCION;

                // Restricciones para vendedores
                if (rolUsuario == "Vendedor")
                {
                    if (estado == "Finalizado")
                    {
                        MessageBox.Show("No tiene permiso para editar cobros de pedidos finalizados.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (fecha < DateTime.Now.AddDays(-30))
                    {
                        MessageBox.Show("Solo puede editar cobros de los últimos 30 días.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // ✅ Mostrar y esperar el cierre
                FormEditarPagoSeleccionado formEditarPago = new FormEditarPagoSeleccionado(idPedido);
                var resultado = formEditarPago.ShowDialog();

                // ✅ Si se cerró correctamente, volver a ejecutar búsqueda
                if (resultado == DialogResult.OK)
                {
                    buttonBuscar.PerformClick();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un pedido para editar el cobro.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



    }
}