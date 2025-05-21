using FotoRoman.Properties;

namespace FotoRoman
{
    partial class FrmEditarUsuario
    {
        private System.ComponentModel.IContainer components = null;

        // Controles del formulario
        private TextBox textNombre;
        private TextBox textPassword;
        private TextBox textEmail;
        private TextBox textDocumento;
        private Label Nombre;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox cmbRol;
        private Button btnGuardar;
        private Button btnCancelar;
        private PictureBox pictureBoxLogo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditarUsuario));
            textNombre = new TextBox();
            textPassword = new TextBox();
            textEmail = new TextBox();
            textDocumento = new TextBox();
            Nombre = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            cmbRol = new ComboBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            pictureBoxLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // textNombre
            // 
            textNombre.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textNombre.Location = new Point(191, 103);
            textNombre.Name = "textNombre";
            textNombre.Size = new Size(300, 33);
            textNombre.TabIndex = 10;
            // 
            // textPassword
            // 
            textPassword.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textPassword.Location = new Point(191, 253);
            textPassword.Name = "textPassword";
            textPassword.Size = new Size(300, 33);
            textPassword.TabIndex = 9;
            // 
            // textEmail
            // 
            textEmail.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textEmail.Location = new Point(191, 203);
            textEmail.Name = "textEmail";
            textEmail.Size = new Size(300, 33);
            textEmail.TabIndex = 8;
            // 
            // textDocumento
            // 
            textDocumento.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textDocumento.Location = new Point(191, 153);
            textDocumento.Name = "textDocumento";
            textDocumento.ReadOnly = true;
            textDocumento.Size = new Size(300, 33);
            textDocumento.TabIndex = 7;
            // 
            // Nombre
            // 
            Nombre.AutoSize = true;
            Nombre.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            Nombre.Location = new Point(41, 108);
            Nombre.Name = "Nombre";
            Nombre.Size = new Size(127, 17);
            Nombre.TabIndex = 6;
            Nombre.Text = "Apellido y Nombre";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            label1.Location = new Point(44, 158);
            label1.Name = "label1";
            label1.Size = new Size(124, 17);
            label1.TabIndex = 5;
            label1.Text = "DNI (Solo lectura)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            label2.Location = new Point(124, 208);
            label2.Name = "label2";
            label2.Size = new Size(44, 17);
            label2.TabIndex = 4;
            label2.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            label3.Location = new Point(86, 258);
            label3.Name = "label3";
            label3.Size = new Size(82, 17);
            label3.TabIndex = 3;
            label3.Text = "Contraseña";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Brown;
            label4.Location = new Point(52, 22);
            label4.Name = "label4";
            label4.Size = new Size(123, 23);
            label4.TabIndex = 2;
            label4.Text = "Editar Usuario";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            label5.Location = new Point(139, 308);
            label5.Name = "label5";
            label5.Size = new Size(29, 17);
            label5.TabIndex = 11;
            label5.Text = "Rol";
            // 
            // cmbRol
            // 
            cmbRol.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbRol.FormattingEnabled = true;
            cmbRol.Items.AddRange(new object[] { "Director", "Vendedor" });
            cmbRol.Location = new Point(191, 303);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(300, 33);
            cmbRol.TabIndex = 13;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.LightGray;
            btnGuardar.Font = new Font("Yu Gothic", 11.25F, FontStyle.Bold);
            btnGuardar.Location = new Point(191, 371);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(120, 40);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.LightGray;
            btnCancelar.Font = new Font("Yu Gothic", 11.25F, FontStyle.Bold);
            btnCancelar.Location = new Point(371, 371);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(120, 40);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackColor = Color.Transparent;
            pictureBoxLogo.Image = (Image)resources.GetObject("pictureBoxLogo.Image");
            pictureBoxLogo.Location = new Point(402, 12);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(89, 78);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // FrmEditarUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(537, 450);
            Controls.Add(pictureBoxLogo);
            Controls.Add(label4);
            Controls.Add(Nombre);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(textNombre);
            Controls.Add(textDocumento);
            Controls.Add(textEmail);
            Controls.Add(textPassword);
            Controls.Add(cmbRol);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Name = "FrmEditarUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editar Usuario";
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
