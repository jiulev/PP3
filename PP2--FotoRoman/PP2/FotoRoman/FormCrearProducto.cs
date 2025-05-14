using CapaEntidad;
using CapaNegocio;
using System;
using System.Windows.Forms;

namespace FotoRoman
{
    public partial class FormCrearProducto : Form
    {
        public FormCrearProducto()
        {
            InitializeComponent();
            CargarCategorias();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // Código opcional si deseas agregar funcionalidad adicional al label
        }

        private void comboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Este evento puede usarse para responder a cambios en la selección del ComboBox si es necesario
        }

        private void btnRegistrarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar precio como decimal
                if (!decimal.TryParse(txtPrecioProducto.Text, out decimal precio))
                {
                    MessageBox.Show("Por favor, ingrese un precio válido.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Crear instancia de Producto con los valores ingresados
                Producto producto = new Producto
                {
                    Nombre = txtNombreProducto.Text.Trim(),
                    Precio = precio,
                    DescripcionCategoria = comboBoxCategoria.SelectedItem?.ToString() ?? string.Empty
                };

                CNProducto cnProducto = new CNProducto();
                string mensaje;
                bool exito = cnProducto.InsertarProducto(producto, out mensaje);

                // Mostrar el resultado de la operación
                MessageBox.Show(mensaje, exito ? "Éxito" : "Error", MessageBoxButtons.OK, exito ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (exito)
                {
                    // Limpiar campos después de la inserción exitosa
                    txtNombreProducto.Clear();
                    txtPrecioProducto.Clear();
                    comboBoxCategoria.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al registrar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarProducto_Click(object sender, EventArgs e)
        {
            this.Close();  // Cerrar el formulario
        }

        private void CargarCategorias()
        {
            CNProducto cnProducto = new CNProducto();
            var categorias = cnProducto.ObtenerDescripcionesCategorias();
            comboBoxCategoria.Items.Clear();
            comboBoxCategoria.Items.AddRange(categorias.ToArray());
        }
    }
}
