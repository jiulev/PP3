using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;
using CapaDatos;


namespace FotoRoman
{
    public partial class FormVerProducto : Form
    {
        public FormVerProducto()
        {
            InitializeComponent();
            Load += FormVerProducto_Load; // Importante: vinculás el evento Load acá
        }

        private void FormVerProducto_Load(object sender, EventArgs e)
        {
            comboBoxEstado.SelectedIndex = 0;

            var categorias = CNCategoria.ListarDescripciones();

            // Insertamos opción "Todas" al principio
            categorias.Insert(0, new Categoria
            {
                IDCATEGORIA = 0,
                DESCRIPCION = "Todas las categorías"
            });
           

            comboBoxCategoria.DataSource = categorias;
            comboBoxCategoria.DisplayMember = "DESCRIPCION";
            comboBoxCategoria.ValueMember = "IDCATEGORIA";
            comboBoxCategoria.SelectedIndex = 0;  // Por defecto: muestra "Todas"

            CargarProductos();
        }

        private void CargarProductos()
        {
            var productos = CNProducto.ListarTodos();

            string filtroNombre = txtBuscarProducto.Text.ToLower();
            if (!string.IsNullOrEmpty(filtroNombre))
                productos = productos.Where(p => p.Nombre.ToLower().Contains(filtroNombre)).ToList();

            if (comboBoxCategoria.SelectedIndex != -1)
            {
                var categoriaSeleccionada = (CapaEntidad.Categoria)comboBoxCategoria.SelectedItem;
                if (categoriaSeleccionada.IDCATEGORIA != 0) // 0 = Todas las categorías
                {
                    int idCat = categoriaSeleccionada.IDCATEGORIA;
                    productos = productos.Where(p => p.IDCATEGORIA == idCat).ToList();
                }
            }


            string estado = comboBoxEstado.SelectedItem?.ToString() ?? "Todos";
            if (estado == "Activos") productos = productos.Where(p => p.EstadoActivo == "A").ToList();
            else if (estado == "Inactivos") productos = productos.Where(p => p.EstadoActivo == "D").ToList();
            labelCantidadProductos.Text = $"{productos.Count} producto{(productos.Count == 1 ? "" : "s")} encontrados";
            dataGridViewProductos.DataSource = productos.Select(p => new
            {
                p.IdProducto,
                p.Nombre,
                p.Precio,
                Categoría = p.DescripcionCategoria,
                Estado = p.EstadoActivo == "A" ? "Activo" : "Inactivo"
            }).ToList();
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e) => CargarProductos();
        private void comboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e) => CargarProductos();
        private void comboBoxEstado_SelectedIndexChanged(object sender, EventArgs e) => CargarProductos();

        private void btnEditarProducto_Click(object sender, EventArgs e)
        {
            if (dataGridViewProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un producto para editar.");
                return;
            }

            int idProducto = Convert.ToInt32(dataGridViewProductos.SelectedRows[0].Cells["IdProducto"].Value);
            var producto = CNProducto.ListarTodos().FirstOrDefault(p => p.IdProducto == idProducto);

            if (producto != null)
            {
                FormEditarProducto form = new FormEditarProducto(producto);
                if (form.ShowDialog() == DialogResult.OK)
                    CargarProductos();
            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (dataGridViewProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un producto para eliminar.");
                return;
            }

            // Obtener el producto completo
            int idProducto = Convert.ToInt32(dataGridViewProductos.SelectedRows[0].Cells["IdProducto"].Value);
            var producto = CNProducto.ListarTodos().FirstOrDefault(p => p.IdProducto == idProducto);

            if (producto != null)
            {
                FormEliminarProducto form = new FormEliminarProducto(producto);
                if (form.ShowDialog() == DialogResult.OK)
                    CargarProductos();
            }

        }
        private void btnAumentoPrecios_Click(object sender, EventArgs e)
        {
            FormAumentoPrecios form = new FormAumentoPrecios();
            if (form.ShowDialog() == DialogResult.OK)
            {
                CargarProductos(); // Refrescamos los productos luego del aumento
            }
        }




    }
}
