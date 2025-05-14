using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FotoRoman
{
    public partial class FormAgregarItem : Form
    {
        public DetallePedido DetalleAgregado { get; private set; }

        private List<Producto> productosFiltrados = new List<Producto>();

        public FormAgregarItem()
        {
            InitializeComponent();
            CargarCategorias();

            comboBoxCategoria.SelectedIndexChanged += comboBoxCategoria_SelectedIndexChanged;
            comboBoxProducto.SelectedIndexChanged += comboBoxProducto_SelectedIndexChanged;
            numericCantidad.ValueChanged += numericCantidad_ValueChanged;

            textBoxPrecio.ReadOnly = true;
        }

        private void CargarCategorias()
        {
            var categorias = CNCategoria.ListarCategoriasActivas()
                .Where(c => c.ACTIVO == "A")
                .ToList();

            comboBoxCategoria.DataSource = categorias;
            comboBoxCategoria.DisplayMember = "DESCRIPCION";
            comboBoxCategoria.ValueMember = "IDCATEGORIA";
        }

        private void comboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCategoria.SelectedItem is Categoria categoriaSeleccionada)
            {
                productosFiltrados = CNProducto.ListarProductosActivos()
                    .Where(p => p.EstadoActivo == "A" && p.IDCATEGORIA == categoriaSeleccionada.IDCATEGORIA)
                    .ToList();

                comboBoxProducto.DataSource = productosFiltrados;
                comboBoxProducto.DisplayMember = "Nombre";
                comboBoxProducto.ValueMember = "IdProducto";
            }
        }

        private void comboBoxProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProducto.SelectedItem is Producto producto)
            {
                textBoxPrecio.Text = producto.Precio.ToString("F2");
                CalcularSubtotal();
            }
        }

        private void numericCantidad_ValueChanged(object sender, EventArgs e)
        {
            CalcularSubtotal();
        }

        private void CalcularSubtotal()
        {
            if (comboBoxProducto.SelectedItem is Producto producto)
            {
                int cantidad = (int)numericCantidad.Value;
                decimal precio = producto.Precio;
                decimal subtotal = cantidad * precio;
                labelSubtotal.Text = $"Subtotal: ${subtotal:F2}";
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            if (comboBoxProducto.SelectedItem is Producto producto)
            {
                DetalleAgregado = new DetallePedido
                {
                    oProducto = producto,
                    CANTIDAD = (int)numericCantidad.Value,
                    PRECIOUNITARIO = producto.Precio,
                    SUBTOTAL = (int)numericCantidad.Value * producto.Precio
                };

                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
