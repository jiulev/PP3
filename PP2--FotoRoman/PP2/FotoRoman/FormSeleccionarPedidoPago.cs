using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FotoRoman
{
    public partial class FormSeleccionarPedidoPago : Form
    {
        public int IDPedidoSeleccionado { get; private set; }

        public FormSeleccionarPedidoPago(List<int> pedidos)
        {
            InitializeComponent();
            CargarPedidos(pedidos);
        }

        private void CargarPedidos(List<int> pedidos)
        {
            dataGridViewPedidos.DataSource = pedidos.ConvertAll(p => new { IDPedido = p });
        }

        private void buttonSeleccionar_Click(object sender, EventArgs e)
        {
            if (dataGridViewPedidos.SelectedRows.Count > 0)
            {
                IDPedidoSeleccionado = (int)dataGridViewPedidos.SelectedRows[0].Cells["IDPedido"].Value;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Seleccione un pedido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
