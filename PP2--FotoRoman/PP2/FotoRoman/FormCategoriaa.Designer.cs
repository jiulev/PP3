namespace FotoRoman
{
    partial class FormCategoriaa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCategoriaa));
            label1 = new Label();
            label2 = new Label();
            CrearCategoria = new Button();
            CancelarCategoria = new Button();
            textBoxCategoria = new TextBox();
            pictureBoxLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(33, 37, 41);
            label1.Location = new Point(30, 30);
            label1.Name = "label1";
            label1.Size = new Size(245, 25);
            label1.TabIndex = 0;
            label1.Text = "Registrar Nueva Categoría";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 11.25F);
            label2.Location = new Point(40, 100);
            label2.Name = "label2";
            label2.Size = new Size(173, 20);
            label2.TabIndex = 1;
            label2.Text = "Nombre de la Categoría:";
            // 
            // CrearCategoria
            // 
            CrearCategoria.BackColor = Color.LightGray;
            CrearCategoria.FlatAppearance.BorderColor = Color.Gray;
            CrearCategoria.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            CrearCategoria.ForeColor = Color.Black;
            CrearCategoria.Location = new Point(240, 160);
            CrearCategoria.Name = "CrearCategoria";
            CrearCategoria.Size = new Size(120, 40);
            CrearCategoria.TabIndex = 0;
            CrearCategoria.Text = "Registrar";
            CrearCategoria.UseVisualStyleBackColor = false;
            CrearCategoria.Click += CrearCategoria_Click;
            // 
            // CancelarCategoria
            // 
            CancelarCategoria.BackColor = Color.LightGray;
            CancelarCategoria.FlatAppearance.BorderColor = Color.Gray;
            CancelarCategoria.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            CancelarCategoria.ForeColor = Color.Black;
            CancelarCategoria.Location = new Point(420, 160);
            CancelarCategoria.Name = "CancelarCategoria";
            CancelarCategoria.Size = new Size(120, 40);
            CancelarCategoria.TabIndex = 1;
            CancelarCategoria.Text = "Cancelar";
            CancelarCategoria.UseVisualStyleBackColor = false;
            CancelarCategoria.Click += CancelarCategoria_Click;
            // 
            // textBoxCategoria
            // 
            textBoxCategoria.Font = new Font("Segoe UI", 11F);
            textBoxCategoria.Location = new Point(240, 96);
            textBoxCategoria.Name = "textBoxCategoria";
            textBoxCategoria.Size = new Size(300, 27);
            textBoxCategoria.TabIndex = 2;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackColor = Color.Transparent;
            pictureBoxLogo.Image = (Image)resources.GetObject("pictureBoxLogo.Image");
            pictureBoxLogo.Location = new Point(490, 12);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(82, 78);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxLogo.TabIndex = 3;
            pictureBoxLogo.TabStop = false;
            // 
            // FormCategoriaa
            // 
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(600, 320);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(textBoxCategoria);
            Controls.Add(CrearCategoria);
            Controls.Add(CancelarCategoria);
            Controls.Add(pictureBoxLogo);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormCategoriaa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nueva Categoría";
            Load += FormCategoriaa_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private System.Windows.Forms.Label label1;
        private Label label2;
        private Button CrearCategoria;
        private Button CancelarCategoria;
        private TextBox textBoxCategoria;
        private PictureBox pictureBoxLogo;

    }
}
