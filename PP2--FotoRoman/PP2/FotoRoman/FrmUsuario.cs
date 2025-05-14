using System;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;

namespace FotoRoman
{
    public partial class FrmUsuario : Form
    {
        public FrmUsuario()
        {
            InitializeComponent();
            CargarUsuarios();
        }

        // Método para cargar los usuarios y sus roles
        private void CargarUsuarios()
        {
            CNUsuario cnUsuario = new CNUsuario();
            var usuarios = cnUsuario.Listar().Select(u => new
            {
                IDUSUARIO = u.IDUSUARIO,
                NOMBRE = u.NOMBRE,
                DOCUMENTO = u.DOCUMENTO,
                EMAIL = u.EMAIL,
                PASSWORD = u.PASSWORD,
                ROL = string.IsNullOrEmpty(u.oRol.DESCRIPCION) ? "Sin Rol" : u.oRol.DESCRIPCION,
                FECHACREACION = u.FECHACREACION
            }).ToList();

            dataGridViewUsuarios.DataSource = usuarios;
        }

        // Método para el botón Editar
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un usuario para editar.");
                return;
            }

            // Verificar si la celda contiene el ID del usuario
            if (dataGridViewUsuarios.SelectedRows[0].Cells["IDUSUARIO"].Value is null)
            {
                MessageBox.Show("No se pudo obtener el ID del usuario seleccionado.");
                return;
            }

            int idUsuario = Convert.ToInt32(dataGridViewUsuarios.SelectedRows[0].Cells["IDUSUARIO"].Value);
            EditarUsuario(idUsuario);
        }


        // Método para editar un usuario
        private void EditarUsuario(int idUsuario)
        {
            CNUsuario cnUsuario = new CNUsuario();

            // Manejar el posible valor nulo con 'asignación nula'
            Usuario usuario = cnUsuario.Listar().Find(u => u.IDUSUARIO == idUsuario) ?? new Usuario();

            if (usuario.IDUSUARIO == 0)
            {
                MessageBox.Show("Usuario no encontrado.");
                return;
            }

            FrmEditarUsuario frmEditarUsuario = new FrmEditarUsuario(usuario);
            frmEditarUsuario.ShowDialog();

            CargarUsuarios();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Obtener el texto ingresado en el TextBox
            string filtro = txtBuscar.Text.ToLower();

            // Aplicar el filtro a los datos del DataGridView
            var usuariosFiltrados = new CNUsuario().Listar()
                .Where(u => u.NOMBRE.ToLower().Contains(filtro))
                .Select(u => new
                {
                    IDUSUARIO = u.IDUSUARIO,
                    NOMBRE = u.NOMBRE,
                    DOCUMENTO = u.DOCUMENTO,
                    EMAIL = u.EMAIL,
                    PASSWORD = u.PASSWORD,
                    ROL = string.IsNullOrEmpty(u.oRol.DESCRIPCION) ? "Sin Rol" : u.oRol.DESCRIPCION,
                    FECHACREACION = u.FECHACREACION
                })
                .ToList();

            // Asignar los datos filtrados al DataGridView
            dataGridViewUsuarios.DataSource = usuariosFiltrados;
        }

        // Método para el botón Eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un usuario para eliminar.");
                return;
            }

            int idUsuario = Convert.ToInt32(dataGridViewUsuarios.SelectedRows[0].Cells["IDUSUARIO"].Value);
            EliminarUsuario(idUsuario);
        }

        // Método para eliminar un usuario
        private void EliminarUsuario(int idUsuario)
        {
            if (MessageBox.Show("¿Estás seguro de eliminar este usuario?", "Confirmar eliminación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    CNUsuario cnUsuario = new CNUsuario();
                    cnUsuario.Eliminar(idUsuario);
                    MessageBox.Show("Usuario eliminado correctamente.");
                    CargarUsuarios();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el usuario: " + ex.Message);
                }
            }
        }

        private void btnBloquear_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un usuario para Eliminar.");
                return;
            }

            int idUsuario = Convert.ToInt32(dataGridViewUsuarios.SelectedRows[0].Cells["IDUSUARIO"].Value);

            if (MessageBox.Show("¿Estás seguro de eliminar este usuario?", "Confirmar Eliminación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    // Instancia de CNUsuario
                    CNUsuario cnUsuario = new CNUsuario();

                    // Llamada al método Bloquear
                    cnUsuario.Bloquear(idUsuario);

                    MessageBox.Show("Usuario Eliminado correctamente.");
                    CargarUsuarios();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al Eliminar el usuario: " + ex.Message);
                }
            }
        }


    

        private void dataGridViewUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
