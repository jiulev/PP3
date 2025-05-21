using CapaEntidad;
using CapaNegocio;
using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace FotoRoman
{
    public partial class FmCliente : Form
    {
        public FmCliente()
        {
            InitializeComponent();
        }
        private void FmCliente_Load(object sender, EventArgs e)
        {

            CargarProvincias();
            // Deshabilitar campos fiscales al cargar
            razonSocial.ReadOnly = true;
            cuit.ReadOnly = true;
            checkBoxFiscal.Checked = false;
        }
        // Método para cargar las provincias en el comboBoxProvincia
        private void CargarProvincias()
        {
            try
            {
                // Deshabilita el evento mientras se carga
                comboBoxProvincia.SelectedIndexChanged -= comboBoxProvincia_SelectedIndexChanged;

                comboBoxProvincia.DataSource = null;
                comboBoxProvincia.Items.Clear();

                // Obtén la lista de provincias desde la base de datos
                List<Provincia> provincias = CN_Localidades.ListarProvincias();

                if (provincias == null || provincias.Count == 0)
                {
                    MessageBox.Show("No se encontraron provincias en la base de datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Añade la opción de registrar nueva provincia
                provincias.Add(new Provincia { IDProvincia = -1, Nombre = "Registrar nueva provincia" });

                // Asigna el DataSource
                comboBoxProvincia.DataSource = provincias;
                comboBoxProvincia.DisplayMember = "Nombre";
                comboBoxProvincia.ValueMember = "IDProvincia";
                comboBoxProvincia.SelectedIndex = -1;

                comboBoxProvincia.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las provincias: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Reactiva el evento
                comboBoxProvincia.SelectedIndexChanged += comboBoxProvincia_SelectedIndexChanged;
            }
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.White,         // blanco arriba
                Color.LightGray,     // gris claro abajo
                90F))                // vertical
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void checkBoxFiscal_CheckedChanged(object sender, EventArgs e)
        {
            bool habilitar = checkBoxFiscal.Checked;

            // Cambiar modo edición
            razonSocial.ReadOnly = !habilitar;
            cuit.ReadOnly = !habilitar;

            // Cambiar color de fondo según estado
            Color fondoEditable = Color.White;
            Color fondoSoloLectura = Color.LightGray; // o un gris más oscuro como Color.Silver

            razonSocial.BackColor = habilitar ? fondoEditable : fondoSoloLectura;
            cuit.BackColor = habilitar ? fondoEditable : fondoSoloLectura;
        }




        // Evento para cargar localidades al seleccionar una provincia
        private void comboBoxProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProvincia.SelectedIndex != -1)
            {
                int idProvincia = (int)comboBoxProvincia.SelectedValue;

                if (idProvincia == -1) // Registrar nueva provincia
                {
                    FormRegistrar formRegistrar = new FormRegistrar();
                    if (formRegistrar.ShowDialog() == DialogResult.OK)
                    {
                        // Si el formulario devuelve OK, recarga las provincias
                        CargarProvincias();
                    }
                }
                else
                {
                    CargarLocalidades(idProvincia);
                }
            }
        }



        // Evento para abrir un pop-up para agregar una nueva provincia
        private void btnAgregarProvincia_Click(object sender, EventArgs e)
        {
            string nuevaProvincia = PromptDialog.ShowDialog("Ingrese el nombre de la nueva provincia:", "Agregar Provincia");
            if (!string.IsNullOrWhiteSpace(nuevaProvincia))
            {
                try
                {
                    string mensaje;
                    int idProvincia = CN_Localidades.InsertarProvincia(nuevaProvincia, out mensaje);

                    if (idProvincia > 0)
                    {
                        MessageBox.Show("Provincia agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarProvincias(); // Recargar provincias
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al agregar la provincia: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }





        // Evento para abrir un pop-up para agregar una nueva localidad
        private void btnAgregarLocalidad_Click(object sender, EventArgs e)
        {
            if (comboBoxProvincia.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una provincia antes de agregar una localidad.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nuevaLocalidad = PromptDialog.ShowDialog("Ingrese el nombre de la nueva localidad:", "Agregar Localidad");
            if (!string.IsNullOrWhiteSpace(nuevaLocalidad))
            {
                try
                {
                    int idProvincia = (int)comboBoxProvincia.SelectedValue;
                    string mensaje;
                    int idLocalidad = CN_Localidades.InsertarLocalidad(nuevaLocalidad, idProvincia, out mensaje);

                    if (idLocalidad > 0)
                    {
                        MessageBox.Show("Localidad agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarLocalidades(idProvincia); // Recargar localidades de la provincia seleccionada
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al agregar la localidad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxProvincia.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, seleccione una provincia.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBoxLocalidad.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, seleccione una localidad.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Por favor, ingrese un número de teléfono.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Cliente cliente = new Cliente
                {
                    DOCUMENTO = int.Parse(textDocumento.Text.Trim()),
                    NOMBRE = textNombre.Text.Trim(),
                    CORREO = textCorreo.Text.Trim(),
                    TELEFONO = textBox1.Text.Trim(),
                    ESTADO = "Activo",
                    LOCALIDAD = comboBoxLocalidad.Text,
                    PROVINCIA = comboBoxProvincia.Text,
                    FECHACREACION = DateTime.Now,
                    CUIT = checkBoxFiscal.Checked ? cuit.Text.Trim() : null,
                    RAZONSOCIAL = checkBoxFiscal.Checked ? razonSocial.Text.Trim() : null
                };

                string mensaje;
                bool exito = CNCliente.InsertarCliente(cliente, out mensaje);

                MessageBox.Show(mensaje, exito ? "Éxito" : "Error", MessageBoxButtons.OK, exito ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (exito)
                {
                    LimpiarCampos();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese un número válido para el documento.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        // Método para cargar las localidades de una provincia en el comboBoxLocalidad
        private void CargarLocalidades(int idProvincia)
        {
            try
            {
                // Obtén las localidades desde la capa de negocio
                List<Localidad> localidades = CN_Localidades.ListarLocalidadesPorProvincia(idProvincia);

                // Si no hay localidades, muestra un mensaje pero sigue cargando la opción "Registrar nueva localidad"
                if (localidades == null || localidades.Count == 0)
                {
                    MessageBox.Show("No se encontraron localidades para la provincia seleccionada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    localidades = new List<Localidad>();
                }

                // Añade la opción de registrar nueva localidad
                localidades.Add(new Localidad { IDLocalidad = -1, Nombre = "Registrar nueva localidad" });

                // Asigna el DataSource y configura las propiedades de visualización
                comboBoxLocalidad.DataSource = null; // Limpia primero el DataSource
                comboBoxLocalidad.DataSource = localidades;
                comboBoxLocalidad.DisplayMember = "Nombre"; // Campo visible
                comboBoxLocalidad.ValueMember = "IDLocalidad"; // Valor interno
                comboBoxLocalidad.SelectedIndex = -1; // Sin selección inicial
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las localidades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        public static class PromptDialog
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 400,
                    Height = 200,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };

                Label textLabel = new Label() { Left = 20, Top = 20, Text = text, Width = 340 };
                TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 340 };
                Button confirmation = new Button() { Text = "Aceptar", Left = 270, Width = 90, Top = 90, DialogResult = DialogResult.OK };
                Button cancel = new Button() { Text = "Cancelar", Left = 160, Width = 90, Top = 90, DialogResult = DialogResult.Cancel };

                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(cancel);
                prompt.AcceptButton = confirmation;
                prompt.CancelButton = cancel;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : string.Empty;
            }
        }

        private void textLocalidad_TextChanged(object sender, EventArgs e)
        {
            // Código adicional si es necesario
        }

        private void textestadoo_TextChanged(object sender, EventArgs e)
        {
            // Código adicional si es necesario
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Código adicional si es necesario
        }



        private void Nombre_Click(object sender, EventArgs e)
        {

        }

        private void CancelarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                // Limpiar los campos del formulario
                // Limpiar los campos del formulario
                textNombre.Clear();
                textDocumento.Clear();
                textCorreo.Clear();
                comboBoxLocalidad.SelectedIndex = -1; // Resetea la selección de la localidad
                comboBoxProvincia.SelectedIndex = -1; // Resetea la selección de la provincia


                // Opcional: Mostrar un mensaje de confirmación
                MessageBox.Show("Los campos han sido limpiados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que ocurra al limpiar los campos
                MessageBox.Show($"Error al limpiar los campos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarCampos()
        {
            try
            {
                // Limpia los campos de texto
                textNombre.Clear();
                textDocumento.Clear();
                textCorreo.Clear();

                // Resetea los ComboBox
                comboBoxProvincia.SelectedIndex = -1; // Limpia la selección de provincia
                comboBoxLocalidad.DataSource = null; // Limpia localidades
                comboBoxLocalidad.Items.Clear();
                comboBoxLocalidad.SelectedIndex = -1;
                textBox1.Clear(); // Limpiar Teléfono
                razonSocial.Clear();
                cuit.Clear();
                checkBoxFiscal.Checked = false; // Desmarcar checkbox y deshabilitar campos

                // Opcional: Mostrar un mensaje de confirmación
                MessageBox.Show("Campos limpiados correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Maneja cualquier error al limpiar
                MessageBox.Show($"Error al limpiar los campos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica si hay un ítem seleccionado
            if (comboBoxLocalidad.SelectedIndex != -1)
            {
                // Obtiene el ID de la localidad seleccionada
                var localidadSeleccionada = comboBoxLocalidad.SelectedItem as Localidad;

                if (localidadSeleccionada != null && localidadSeleccionada.IDLocalidad == -1) // Registrar nueva localidad
                {
                    // Abre el formulario para registrar una nueva localidad
                    FormRegistrarLocalidad formRegistrarLocalidad = new FormRegistrarLocalidad();
                    formRegistrarLocalidad.Tag = comboBoxProvincia.SelectedValue; // Pasa el ID de la provincia seleccionada

                    if (formRegistrarLocalidad.ShowDialog() == DialogResult.OK)
                    {
                        // Si se registra una nueva localidad, recarga las localidades
                        int idProvincia = (int)comboBoxProvincia.SelectedValue;
                        CargarLocalidades(idProvincia);
                    }

                    // Restablece la selección del ComboBox después de cerrar el formulario
                    comboBoxLocalidad.SelectedIndex = -1;
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
