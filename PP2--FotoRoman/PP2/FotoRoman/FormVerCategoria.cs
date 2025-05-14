using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace FotoRoman
{
    public partial class FormVerCategoria : Form
    {
        private List<Categoria> categorias = new List<Categoria>();

        public FormVerCategoria()
        {
            InitializeComponent();
            // Configurar el DataGridView para mostrar solo la columna deseada
            ConfigurarDataGridView();
        }

        private void FormVerCategoria_Load(object sender, EventArgs e)
        {
            CargarCategorias();
        }

        private void CargarCategorias()
        {
            try
            {
                var categorias = CNCategoria.ListarDescripciones();

                // Mostrar solo columnas relevantes en el DataGridView
                var categoriasFormateadas = categorias.Select(c => new
                {
                    c.IDCATEGORIA,
                    c.DESCRIPCION,
                    Estado = c.ACTIVO == "A" ? "Activo" : "Inactivo"
                }).ToList();

                dataGridViewCategorias.DataSource = categoriasFormateadas;

                // Configurar columnas visibles y headers
                ConfigurarDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ConfigurarDataGridView()
        {
            if (dataGridViewCategorias.Columns.Count > 0)
            {
                foreach (DataGridViewColumn column in dataGridViewCategorias.Columns)
                {
                    column.Visible = true;
                }

                // Ocultá el ID si no lo querés mostrar
                if (dataGridViewCategorias.Columns["IDCATEGORIA"] != null)
                {
                    dataGridViewCategorias.Columns["IDCATEGORIA"].Visible = false;
                }

                // Nombres más amigables
                if (dataGridViewCategorias.Columns["DESCRIPCION"] != null)
                    dataGridViewCategorias.Columns["DESCRIPCION"].HeaderText = "Descripción";

                if (dataGridViewCategorias.Columns["Estado"] != null)
                    dataGridViewCategorias.Columns["Estado"].HeaderText = "Estado";
            }

            // Configuraciones generales
            dataGridViewCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCategorias.MultiSelect = false;
        }



        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string textoBusqueda = textBoxBuscar.Text.Trim().ToLower();

                // Obtener todas las categorías
                var categorias = CNCategoria.ListarDescripciones();

                // Si no hay texto, mostrar todas las categorías
                if (string.IsNullOrEmpty(textoBusqueda))
                {
                    dataGridViewCategorias.DataSource = categorias;
                    return;
                }

                // Filtrar las categorías por descripción
                var categoriasFiltradas = categorias
                    .Where(c => c.DESCRIPCION.ToLower().Contains(textoBusqueda))
                    .ToList();

                // Actualizar el DataGridView con los resultados filtrados
                dataGridViewCategorias.DataSource = categoriasFiltradas;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewCategorias.SelectedRows.Count > 0)
            {
                // Recuperamos la categoría seleccionada desde el DataGridView original
                var idCategoria = Convert.ToInt32(dataGridViewCategorias.SelectedRows[0].Cells["IDCATEGORIA"].Value);
                var categoriaSeleccionada = CNCategoria.ListarDescripciones().FirstOrDefault(c => c.IDCATEGORIA == idCategoria);

                if (categoriaSeleccionada == null)
                {
                    MessageBox.Show("No se pudo encontrar la categoría seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Abrimos el formulario de edición
                FormEditarCategoria form = new FormEditarCategoria(categoriaSeleccionada);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        CNCategoria.EditarCategoria(form.CategoriaEditada);

                        // Si se desactivó, mostramos advertencia

                        if (form.CategoriaEditada.ACTIVO == "I")

                        if (form.CategoriaEditada.ACTIVO == "I")

                        if (form.CategoriaEditada.ACTIVO == "D")

                        {
                            MessageBox.Show("Categoría inactivada. Ya no estará disponible para nuevos productos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Categoría actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        CargarCategorias(); // Refrescamos la grilla
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al editar la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una categoría para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewCategorias.SelectedRows.Count > 0)
            {
                var categoriaSeleccionada = (Categoria)dataGridViewCategorias.SelectedRows[0].DataBoundItem;

                var confirmacion = MessageBox.Show(
                    $"¿Está seguro de eliminar la categoría '{categoriaSeleccionada.DESCRIPCION}'?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    try
                    {
                        CNCategoria.EliminarCategoria(categoriaSeleccionada.IDCATEGORIA);
                        MessageBox.Show("Categoría eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarCategorias();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una categoría para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
