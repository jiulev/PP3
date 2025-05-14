using System;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace FotoRoman
{
    public partial class FormEliminarProducto : Form
    {
        private Producto producto;

        public FormEliminarProducto(Producto productoSeleccionado)
        {
            InitializeComponent();
            producto = productoSeleccionado;
        }

        private void FormEliminarProducto_Load(object sender, EventArgs e)
        {
            // Mostrar info del producto
            labelProducto.Text = $"¿Deseás eliminar el producto \"{producto.Nombre}\"?";
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string mensaje;

            if (CNProducto.EstaEnPedidos(producto.IdProducto))
            {
                // El producto ya fue parte de algún pedido → desactivar (lógico)
                if (CNProducto.DesactivarProducto(producto.IdProducto, out mensaje))
                {
                    MessageBox.Show(mensaje + "\nEl estado fue cambiado a INACTIVO.", "Producto Desactivado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // El producto nunca se usó → también lo desactivamos (lógica uniforme)
                if (CNProducto.DesactivarProducto(producto.IdProducto, out mensaje))
                {
                    MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
