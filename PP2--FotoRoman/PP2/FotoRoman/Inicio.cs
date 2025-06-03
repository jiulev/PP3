using System;
using System.Windows.Forms;
using CapaEntidad;
using CapaPresentacion;


namespace FotoRoman
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();

            // Configurar visibilidad de menús según el rol del usuario
            if (UsuarioActual.Usuario == null)
            {
                MessageBox.Show("No se ha iniciado sesión correctamente. Se cerrará la aplicación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            ConfigurarMenusPorRol();
        }

        /// <summary>
        /// Configurar los menús visibles según el rol del usuario actual.
        /// </summary>
        private void ConfigurarMenusPorRol()
        {
            // Obtener el rol del usuario actual
            int idRol = UsuarioActual.Usuario.oRol.IDROL;

            // Configurar menús según el rol
            if (idRol == 2) // Vendedor
            {
                // Ocultar el menú de reportes
                menureportes.Visible = false;

                // Ocultar el menú de usuarios
                menuusuario.Visible = false;
            }
            else if (idRol == 1) // Director
            {
                // No se oculta nada, tiene acceso completo
            }
            else
            {
                MessageBox.Show("Rol no reconocido. Contacte al administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void abrirFormulario(object sender, EventArgs e)
        {
            // Este método está vacío, puedes agregar lógica si lo necesitas
        }

        private void menuusuario_Click(object sender, EventArgs e)
        {
            // Este método está vacío, puedes agregar lógica si lo necesitas
        }

        private void iconMenuItem21_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario FrmUsuario
            FrmUsuario frmUsuario = new FrmUsuario();

            // Mostrar el formulario
            frmUsuario.Show(); // Usa ShowDialog() si quieres que sea modal
        }

        private void crearUsuario(object sender, EventArgs e)
        {
            // Crea una instancia del formulario FormCrearUsuario
            FormCrearUsuario formCrearUsuario = new FormCrearUsuario();

            // Mostrar el formulario (puedes usar ShowDialog si prefieres que sea modal)
            formCrearUsuario.Show();
        }

        private void iconMenuItem8_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario FmCliente
            FmCliente fmCliente = new FmCliente();

            // Mostrar el formulario como una ventana modal
            fmCliente.ShowDialog();
        }

        private void iconMenuItem15_Click(object sender, EventArgs e)
        {
            FormCategoriaa formCategoriaa = new FormCategoriaa();
            formCategoriaa.ShowDialog(); // Abre FormCategoriaa como un diálogo modal
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario FormCrearProducto
            FormCrearProducto formCrearProducto = new FormCrearProducto();

            // Mostrar el formulario como una ventana modal
            formCrearProducto.ShowDialog();
        }

        private void iconMenuItem19_Click(object sender, EventArgs e)
        {
            // Aquí puedes agregar lógica para editar un usuario
        }

        private void iconMenuItem1_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario FormCrearPedido
            FormCrearPedido formCrearPedido = new FormCrearPedido();

            // Mostrar el formulario como ventana modal
            formCrearPedido.ShowDialog();
        }

        private void iconMenuItem4_Click(object sender, EventArgs e)
        {
            FormVerPedido formVerPedido = new FormVerPedido();

            // Mostrar el formulario de forma modal
            formVerPedido.ShowDialog();
        }

        private void iconMenuItem7_Click(object sender, EventArgs e)
        {

            FormBorrarConsultarPagos formPagos = new FormBorrarConsultarPagos();
            formPagos.Show(); // O usar ShowDialog() si es modal

            // FormVerPago formVerPago = new FormVerPago();


            // formVerPago.ShowDialog();
        }

        private void iconMenuItem22_Click(object sender, EventArgs e)
        {


            // Instanciar el formulario
            FormReporteVendedor formReporteVendedor = new FormReporteVendedor();

            // Mostrar el formulario como una ventana modal
            formReporteVendedor.ShowDialog();




            //FormVerReporte formVerReporte = new FormVerReporte();

            // Mostrar el formulario de reportes de forma modal
            //formVerReporte.ShowDialog();
        }

        /// <summary>
        /// Evento para cerrar la sesión del usuario actual.
        /// </summary>
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Cerrar la sesión del usuario actual
            UsuarioActual.CerrarSesion();

            // Cerrar el formulario actual
            this.Close();

            // Mostrar el formulario de login nuevamente
            new Login().Show();
        }

        private void iconMenuItem11_Click(object sender, EventArgs e)
        {

            // Verifica si ya está abierto
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(FrmVerCliente))
                {
                    frm.BringToFront();
                    return;
                }
            }

            // Si no está abierto, crea una nueva instancia y muéstrala
            FrmVerCliente frmVerCliente = new FrmVerCliente();
            frmVerCliente.Show();


        }

        private void VerCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear una nueva instancia del formulario de categorías
                FormVerCategoria formVerCategoria = new FormVerCategoria();

                // Mostrar el formulario de manera modal
                formVerCategoria.ShowDialog();
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error en caso de que ocurra una excepción
                MessageBox.Show($"Ocurrió un error al intentar abrir el formulario de categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // Instanciar el formulario
            FormAcercaDe formAcercaDe = new FormAcercaDe();

            // Mostrar el formulario como una ventana modal
            formAcercaDe.ShowDialog();

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void iconMenuItem6_Click(object sender, EventArgs e)
        {
            FormEditarCobro form = new FormEditarCobro();
            form.ShowDialog();  // Se abre como ventana modal (bloquea la principal hasta que se cierre)

        }

        private void reporteProducto_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario
            FormReporteProducto formReporte = new FormReporteProducto();

            // Mostrar el formulario
            formReporte.Show(); // Usa Show() si quieres que el formulario se abra de forma no modal
                                // formReporte.ShowDialog(); // Usa ShowDialog() si quieres que sea modal (bloquea otros formularios)
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            FormVerProducto form = new FormVerProducto();
            form.ShowDialog(); // menu producto
        }

        private void verCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                FormVerCategoria form = new FormVerCategoria();
                form.ShowDialog(); // menu categoria  para ver
            }

        }

        private void listadoDePedidosPorClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReportePedidos form = new FormReportePedidos();
            form.ShowDialog();

        }
    }
}
