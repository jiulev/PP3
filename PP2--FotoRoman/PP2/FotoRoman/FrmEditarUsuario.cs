using System;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;

namespace FotoRoman
{
    public partial class FrmEditarUsuario : Form
    {
        private Usuario usuario;

        // Constructor que recibe un objeto Usuario
        public FrmEditarUsuario(Usuario usuarioSeleccionado)
        {
            InitializeComponent();
            usuario = usuarioSeleccionado;

            // Cargar datos del usuario en los controles del formulario
            textNombre.Text = usuario.NOMBRE;
            textDocumento.Text = usuario.DOCUMENTO;
            textDocumento.ReadOnly = true;
            textEmail.Text = usuario.EMAIL;
            textPassword.Text = usuario.PASSWORD;

            // Configurar el ComboBox dinámicamente
            var roles = new List<Rol>
    {
        new Rol { IDROL = 1, DESCRIPCION = "Vendedor" },
        new Rol { IDROL = 2, DESCRIPCION = "Administrador" }
    };

            cmbRol.DataSource = roles;
            cmbRol.DisplayMember = "DESCRIPCION";
            cmbRol.ValueMember = "IDROL";

            // Seleccionar el rol actual del usuario
            if (usuario.oRol?.IDROL > 0)
            {
                cmbRol.SelectedValue = usuario.oRol.IDROL;
            }
            else
            {
                cmbRol.SelectedValue = 1; // Valor predeterminado
            }

            // Depuración: Verificar valores
            foreach (var rol in roles)
            {
                Console.WriteLine($"IDROL: {rol.IDROL}, DESCRIPCION: {rol.DESCRIPCION}");
            }
            Console.WriteLine($"Rol seleccionado: {cmbRol.SelectedValue}");
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Actualizar solo los datos editables
                usuario.NOMBRE = textNombre.Text ?? string.Empty;
                usuario.EMAIL = textEmail.Text ?? string.Empty;
                usuario.PASSWORD = textPassword.Text ?? string.Empty;

                // Actualizar el IDROL seleccionado en el ComboBox
                usuario.oRol.IDROL = cmbRol.SelectedValue != null ? (int)cmbRol.SelectedValue : 0;



                // Llamar al método de la capa de negocio para actualizar el usuario
                CNUsuario cnUsuario = new CNUsuario();
                cnUsuario.Editar(usuario);

                MessageBox.Show("Usuario actualizado correctamente.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el usuario: " + ex.Message);
            }
        }


        // Clase Rol para manejar el ComboBox
        public class Rol
        {
            public int IDROL { get; set; }
            public string DESCRIPCION { get; set; }
        }
        // Evento para el botón Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario sin guardar cambios
            this.Close();
        }

        // Evento Load del formulario
        private void FrmEditarUsuario_Load(object sender, EventArgs e)
        {
            // Este evento está definido para evitar errores, aunque no se usa.
        }

        // Evento para el TextBox Nombre (no se utiliza, pero lo definimos por seguridad)
        private void textNombre_TextChanged(object sender, EventArgs e)
        {
        }

        // Evento para el TextBox Email
        private void textEmail_TextChanged(object sender, EventArgs e)
        {
        }

        // Evento para el TextBox Password
        private void textPassword_TextChanged(object sender, EventArgs e)
        {
        }

        // Evento para el TextBox Documento (aunque es de solo lectura)
        private void textDocumento_TextChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
