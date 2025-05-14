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
using CapaDatos;
using CapaEntidad;

namespace FotoRoman
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmClosing(object sender, FormClosingEventArgs e)
        {
            // Limpiar los campos del formulario de inicio de sesión
            txtdocumento.Text = string.Empty;
            txtclave.Text = string.Empty;

            // Mostrar el formulario actual (Login)
            this.Show();
        }



        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener la lista de usuarios
                List<Usuario> usuarios = new CNUsuario().Listar();

                // Buscar el usuario con el documento y clave ingresados
                Usuario? usuarioEncontrado = usuarios
                    .FirstOrDefault(u => u.DOCUMENTO == txtdocumento.Text &&
                                         u.PASSWORD.Equals(txtclave.Text, StringComparison.OrdinalIgnoreCase));

                if (usuarioEncontrado != null)
                {
                    // Verificar que tenga un rol válido asignado
                    if (usuarioEncontrado.oRol != null && usuarioEncontrado.oRol.IDROL > 0)
                    {
                        // Guardar la información del usuario en UsuarioActual
                        UsuarioActual.IniciarSesion(usuarioEncontrado);

                        // Mostrar mensaje de bienvenida
                        MessageBox.Show($"Bienvenido, {usuarioEncontrado.NOMBRE}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Mostrar el formulario Inicio
                        Inicio form = new Inicio();
                        form.Show();

                        // Ocultar el formulario actual
                        this.Hide();

                        // Suscribirse al evento FormClosing del formulario Inicio
                        form.FormClosing += FrmClosing;
                    }
                    else
                    {
                        MessageBox.Show("Este usuario no tiene un rol asignado. Contacte al administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Documento o clave incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar sesión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            txtdocumento.Text = "";
            txtclave.Text = "";

            this.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
