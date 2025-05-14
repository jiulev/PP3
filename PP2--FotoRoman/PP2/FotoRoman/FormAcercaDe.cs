using System;
using System.Drawing;
using System.Windows.Forms;

namespace FotoRoman
{
    public partial class FormAcercaDe : Form
    {
        public FormAcercaDe()
        {
            InitializeComponent();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            // Configuración general del formulario
            this.Text = "Acerca de";
            //this.Size = new Size(400, 300);
            //this.BackColor = ColorTranslator.FromHtml("#2C3E50");
           // this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Panel superior
            Panel panelSuperior = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                //BackColor = ColorTranslator.FromHtml("#34495E")
            };
            this.Controls.Add(panelSuperior);

            Label lblTitulo = new Label
            {
                Text = "Acerca de",
               // Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
               // TextAlign = ContentAlignment.MiddleCenter
            };
            panelSuperior.Controls.Add(lblTitulo);

            // Logo o Imagen
            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(100, 100),
                Location = new Point((this.ClientSize.Width - 100) / 2, 70),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            // *** Cargar el logo desde un archivo local ***
            try
            {
                pictureBox.Image = Image.FromFile("C:\\Users\\Usuario\\Desktop\\ISSD\\2022 SEGUNDO SEMESTRE\\PP1\\imagens\\roman.png"); // Cambia esta ruta por la ubicación real de tu logo
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Error al cargar el logo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Controls.Add(pictureBox);

            // Texto descriptivo
            Label lblDescripcion = new Label
            {
                Text = "System SJ creado por Julieta Sofia\npara la gestión de pedidos de Fotolaboratorio Roman.",
                AutoSize = false,
                Size = new Size(360, 60),
                Location = new Point((this.ClientSize.Width - 360) / 2, 180),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                //TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(lblDescripcion);

            // Botón Cerrar
            Button btnCerrar = new Button
            {
                Text = "Cerrar",
                Size = new Size(100, 40),
               // Location = new Point((this.ClientSize.Width - 100) / 2, 250),
                //BackColor = ColorTranslator.FromHtml("#E74C3C"),
               // ForeColor = Color.White,
              
            };
            //btnCerrar.FlatAppearance.BorderSize = 0; // Sin borde
            btnCerrar.Click += BtnCerrar_Click;
            this.Controls.Add(btnCerrar);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblDescripcion_Click(object sender, EventArgs e)
        {

        }
    }
}
