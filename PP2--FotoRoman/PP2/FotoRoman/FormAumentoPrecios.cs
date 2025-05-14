using System;
using System.Windows.Forms;
using CapaDatos;

namespace FotoRoman
{
    public partial class FormAumentoPrecios : Form
    {
        public FormAumentoPrecios()
        {
            InitializeComponent();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtPorcentaje.Text, out decimal porcentaje) && porcentaje > 0)
            {
                try
                {
                    CD_Producto.AumentarPrecios(porcentaje);
                    MessageBox.Show("Precios actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar los precios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un porcentaje válido.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
