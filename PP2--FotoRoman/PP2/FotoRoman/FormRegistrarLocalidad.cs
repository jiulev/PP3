using System;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace FotoRoman
{
    public partial class FormRegistrarLocalidad : Form
    {
        public FormRegistrarLocalidad()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Obtener el nombre de la localidad ingresada
            string nombreLocalidad = textBoxLocalidad.Text.Trim();

            // Obtener el ID de la provincia desde el Tag
            int idProvincia = (int)this.Tag;

            // Validar que el campo no esté vacío
            if (string.IsNullOrWhiteSpace(nombreLocalidad))
            {
                MessageBox.Show("El nombre de la localidad no puede estar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Intentar insertar la nueva localidad
                string mensaje;
                int idLocalidad = CN_Localidades.InsertarLocalidad(nombreLocalidad, idProvincia, out mensaje);

                if (idLocalidad > 0)
                {
                    MessageBox.Show("Localidad registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Devuelve OK al formulario padre
                    this.Close();
                }
                else
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar la localidad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void CargarProvincias()
        {
            try
            {
                // Obtén las provincias desde la capa de negocio
                List<Provincia> provincias = CN_Localidades.ListarProvincias();

                if (provincias == null || provincias.Count == 0)
                {
                    MessageBox.Show("No se encontraron provincias en la base de datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Asigna las provincias al ComboBox
                comboBoxProvincia.DataSource = provincias;
                comboBoxProvincia.DisplayMember = "Nombre"; // Campo visible
                comboBoxProvincia.ValueMember = "IDProvincia"; // Valor interno
                comboBoxProvincia.SelectedIndex = -1; // Sin selección inicial
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las provincias: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormRegistrarLocalidad_Load(object sender, EventArgs e)
        {
            CargarProvincias();
        }

    }
}
