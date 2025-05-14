using CapaEntidad;
using CapaNegocio;
using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace FotoRoman
{
    public partial class FormCrearUsuario : Form
    {
        public FormCrearUsuario()
        {
            InitializeComponent();

            // Limpiar el ComboBox antes de agregar los ítems
            cmbRol.Items.Clear();

            // Poblar el ComboBox con las opciones de roles
            cmbRol.Items.Add("Administrador");  // Agrega la opción "Vendedor"
            cmbRol.Items.Add("Vendedor");  // Agrega la opción "Director"

            // Selecciona por defecto el primer ítem (opcional)
            cmbRol.SelectedIndex = 0;  // Esto es opcional, selecciona el primer rol por defecto
        }

        private void FormCrearUsuario_Load(object sender, EventArgs e)
        {
            // Este método puede dejarse vacío si no tienes lógica específica al cargar el formulario
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



        private void aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear una nueva instancia de Usuario solo cuando el usuario hace clic en el botón
                Usuario nuevoUsuario = new Usuario();

                // Asignar el valor del documento como IDUSUARIO (usaremos el DNI para ambos)
                if (!string.IsNullOrEmpty(textDocumento.Text) && int.TryParse(textDocumento.Text.Trim(), out int documento))
                {
                    nuevoUsuario.IDUSUARIO = documento;
                    nuevoUsuario.DOCUMENTO = documento.ToString(); // Se guarda el DNI como documento
                }
                else
                {
                    MessageBox.Show("El documento debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;  // Detener el proceso si el documento no es un número
                }

                // Asignar los demás valores
                nuevoUsuario.NOMBRE = textNombre.Text?.Trim() ?? string.Empty;
                nuevoUsuario.EMAIL = textEmail.Text?.Trim() ?? string.Empty;
                nuevoUsuario.PASSWORD = textPassword?.Text?.Trim() ?? string.Empty;

                // Verificar que los campos obligatorios no estén vacíos antes de proceder
                if (string.IsNullOrEmpty(nuevoUsuario.NOMBRE) || string.IsNullOrEmpty(nuevoUsuario.EMAIL) || string.IsNullOrEmpty(nuevoUsuario.PASSWORD))
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;  // Detener el proceso si faltan datos
                }

                // Asignar el rol dependiendo de la selección del ComboBox
                if (cmbRol.SelectedIndex == 0) // 0 = Administrador
                {
                    nuevoUsuario.oRol = new Rol
                    {
                        IDROL = 1 // Administrador es ID 1
                    };
                }
                else if (cmbRol.SelectedIndex == 1) // 1 = Vendedor
                {
                    nuevoUsuario.oRol = new Rol
                    {
                        IDROL = 2 // Vendedor es ID 2
                    };
                }

                else
                {
                    MessageBox.Show("Por favor, seleccione un rol válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;  // Detener el proceso si no se seleccionó un rol válido
                }

                // Asignar la fecha de creación
                nuevoUsuario.FECHACREACION = DateTime.Now;

                // Llamar a la capa de negocio para insertar el usuario
                CNUsuario cnUsuario = new CNUsuario();
                cnUsuario.Insertar(nuevoUsuario);

                // Mostrar mensaje de éxito
                MessageBox.Show("Usuario registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar los campos del formulario
                textNombre.Clear();
                textDocumento.Clear();
                textEmail.Clear();
                textPassword?.Clear();
                cmbRol.SelectedIndex = 0;  // Restablecer el ComboBox
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error si la inserción falla
                MessageBox.Show($"Error al registrar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void cancelar_click(object sender, EventArgs e)
        {
            this.Close();  // Cerrar el formulario sin realizar cambios
        }

        // Métodos de eventos no usados o vacíos
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e) { }
        private void Label1_Click(object sender, EventArgs e) { }
        private void Label2_Click(object sender, EventArgs e) { }
        private void Label3_Click(object sender, EventArgs e) { }
        private void Label4_Click(object sender, EventArgs e) { }
        private void Rol_Click(object sender, EventArgs e) { }

        private void FormCrearUsuario_Load_1(object sender, EventArgs e)
        {

        }
    }
}


