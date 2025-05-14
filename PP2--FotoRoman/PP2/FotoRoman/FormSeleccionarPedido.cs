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

namespace FotoRoman
{
    public partial class FormSeleccionarPedido : Form
    {
        public Pedido PedidoSeleccionado { get; private set; }

        public FormSeleccionarPedido(List<Pedido> pedidos)
        {
            InitializeComponent();
            dataGridViewPedidos.DataSource = pedidos.Select(p => new
            {
                IDPedido = p.IDPEDIDO,
                FechaPedido = p.FECHAPEDIDO
            }).ToList();
            dataGridViewPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPedidos.MultiSelect = false;
        }

        private void buttonSeleccionar_Click(object sender, EventArgs e)
        {
            if (dataGridViewPedidos.SelectedRows.Count > 0)
            {
                // Obtener el ID del pedido seleccionado
                int idPedido = (int)dataGridViewPedidos.SelectedRows[0].Cells["IDPedido"].Value;

                // Asignar el pedido seleccionado
                PedidoSeleccionado = CNPedido.BuscarPedidoPorId(idPedido);

                // Cerrar el formulario y devolver el resultado
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un pedido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
