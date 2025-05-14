using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FotoRoman
{
    public partial class FormSeleccionarPagos : Form
    {
        public int IDPedidoSeleccionado { get; private set; }

        public FormSeleccionarPagos(List<Pedido> pedidos)
        {
            InitializeComponent();
            CargarPedidos(pedidos);
        }

        private void CargarPedidos(List<Pedido> pedidos)
        {
            dataGridViewPedidos.DataSource = pedidos.Select(p => new
            {
                IDPedido = p.IDPEDIDO,
                Fecha = p.FECHAPEDIDO.ToString("dd/MM/yyyy HH:mm")
            }).ToList();

            // Estilos y ajustes automáticos
            dataGridViewPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPedidos.RowHeadersVisible = false;
            dataGridViewPedidos.ReadOnly = true;
            dataGridViewPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPedidos.AllowUserToResizeColumns = false;
            dataGridViewPedidos.AllowUserToResizeRows = false;
            dataGridViewPedidos.MultiSelect = false;
        }

        private void buttonSeleccionar_Click(object sender, EventArgs e)
        {
            if (dataGridViewPedidos.SelectedRows.Count > 0)
            {
                IDPedidoSeleccionado = Convert.ToInt32(dataGridViewPedidos.SelectedRows[0].Cells["IDPedido"].Value);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Seleccione un pedido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormSeleccionarPagos_Load(object sender, EventArgs e)
        {
            // Centrar el botón cuando se carga
            buttonSeleccionar.Left = (this.ClientSize.Width - buttonSeleccionar.Width) / 2;
        }
    }
}
