using CapaEntidad;
using CapaNegocio;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FotoRoman
{
    public partial class FormEditarProducto : Form
    {
        private Producto producto;

        public FormEditarProducto(Producto producto)
        {
            InitializeComponent();
            this.producto = producto;
            CargarCategorias();
            MostrarDatos();
        }

        private void CargarCategorias()
        {
            var categorias = CNCategoria.ListarDescripciones();
            comboBoxCategoria.DataSource = categorias;
            comboBoxCategoria.DisplayMember = "DESCRIPCION";
            comboBoxCategoria.ValueMember = "IDCATEGORIA";
        }

        private void MostrarDatos()
        {
            textBoxNombre.Text = producto.Nombre;
            textBoxPrecio.Text = producto.Precio.ToString("F2");
            comboBoxCategoria.SelectedValue = producto.IDCATEGORIA;

            comboBoxEstado.Items.Clear();
            comboBoxEstado.Items.Add("Activo");
            comboBoxEstado.Items.Add("Inactivo");

            // Seleccionar el estado actual
            comboBoxEstado.SelectedItem = producto.EstadoActivo == "A" ? "Activo" : "Inactivo";


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = textBoxNombre.Text.Trim();
            string precioTexto = textBoxPrecio.Text.Trim();

            // Estado seleccionado: "A" o "I"
            string estado = comboBoxEstado.SelectedItem.ToString() == "Activo" ? "A" : "I";
            producto.EstadoActivo = estado;


            // Validar si la categoría está inactiva y se quiere activar el producto
            var categoriaSeleccionada = (Categoria)comboBoxCategoria.SelectedItem;
            if (estado == "A" && categoriaSeleccionada.ACTIVO == "I")
            {
                MessageBox.Show("No se puede activar un producto que pertenece a una categoría inactiva. Por favor, active primero la categoría.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(precioTexto))
            {
                MessageBox.Show("Por favor, completá todos los campos.");
                return;
            }

            if (!decimal.TryParse(precioTexto, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("El precio debe ser un número válido mayor a 0.");
                return;
            }

            int idCategoria = (int)comboBoxCategoria.SelectedValue;

            producto.Nombre = nombre;
            producto.Precio = precio;
            producto.IDCATEGORIA = idCategoria;

            if (CNProducto.EditarProducto(producto, out string mensaje))
            {
                MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
     
        }




    }







