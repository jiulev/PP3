using CapaEntidad;
using CapaNegocio;
using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace FotoRoman
{
    public partial class FormCategoriaa : Form
    {
        public FormCategoriaa()
        {
            InitializeComponent();
        }

        private void FormCategoriaa_Load(object sender, EventArgs e)
        {

        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.White,         // Blanco arriba
                Color.LightGray,     // Gris claro abajo
                90F))                // Vertical
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CrearCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que el usuario haya ingresado una descripción
                if (string.IsNullOrWhiteSpace(textBoxCategoria.Text))
                {
                    MessageBox.Show("Por favor, ingrese una descripción para la categoría.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear instancia de Categoria y asignar la descripción desde textBoxCategoria
                Categoria categoria = new Categoria
                {
                    DESCRIPCION = textBoxCategoria.Text.Trim()
                };

                // Llamar al método estático InsertarCategoria en CNCategoria
                CNCategoria.InsertarCategoria(categoria);

                MessageBox.Show("Categoría registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar el TextBox después de registrar la categoría
                textBoxCategoria.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la categoría: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelarCategoria_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
