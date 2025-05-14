using System;
using System.Windows.Forms;
using CapaEntidad;

namespace FotoRoman
{
    public partial class FormEditarCategoria : Form
    {
        public Categoria CategoriaEditada { get; private set; }

        public FormEditarCategoria(Categoria categoria)
        {
            InitializeComponent();
            textBoxDescripcion.Text = categoria.DESCRIPCION;

            checkBoxInactiva.Checked = categoria.ACTIVO == "I";

            checkBoxInactiva.Checked = categoria.ACTIVO == "I";

            checkBoxInactiva.Checked = categoria.ACTIVO == "D";



            CategoriaEditada = categoria;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            string nuevaDesc = textBoxDescripcion.Text.Trim();
            if (string.IsNullOrWhiteSpace(nuevaDesc))
            {
                MessageBox.Show("La descripción no puede estar vacía.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CategoriaEditada.DESCRIPCION = nuevaDesc;

            CategoriaEditada.ACTIVO = checkBoxInactiva.Checked ? "I" : "A";

            CategoriaEditada.ACTIVO = checkBoxInactiva.Checked ? "I" : "A";

            CategoriaEditada.ACTIVO = checkBoxInactiva.Checked ? "D" : "A";


            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
