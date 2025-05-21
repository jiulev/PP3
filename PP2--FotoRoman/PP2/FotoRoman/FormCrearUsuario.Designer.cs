namespace FotoRoman
{
    partial class FormCrearUsuario
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
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCrearUsuario));
            Nombre = new Label();
            Documento = new Label();
            Email = new Label();
            Contraseña = new Label();
            Rol = new Label();
            textNombre = new TextBox();
            textDocumento = new TextBox();
            textEmail = new TextBox();
            textPassword = new TextBox();
            cmbRol = new ComboBox();
            aceptarCrearUsuario = new Button();
            cancelarCrearUsuario = new Button();
            pictureBoxLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // Nombre
            // 
            Nombre.AutoSize = true;
            Nombre.BackColor = Color.Transparent;
            Nombre.Font = new Font("Yu Gothic", 11.25F, FontStyle.Bold);
            Nombre.Location = new Point(54, 73);
            Nombre.Name = "Nombre";
            Nombre.Size = new Size(147, 19);
            Nombre.TabIndex = 1;
            Nombre.Text = "Nombre y Apellido:";
            // 
            // Documento
            // 
            Documento.AutoSize = true;
            Documento.BackColor = Color.Transparent;
            Documento.Font = new Font("Yu Gothic", 11.25F, FontStyle.Bold);
            Documento.Location = new Point(54, 123);
            Documento.Name = "Documento";
            Documento.Size = new Size(99, 19);
            Documento.TabIndex = 2;
            Documento.Text = "Documento:";
            // 
            // Email
            // 
            Email.AutoSize = true;
            Email.BackColor = Color.Transparent;
            Email.Font = new Font("Yu Gothic", 11.25F, FontStyle.Bold);
            Email.Location = new Point(54, 173);
            Email.Name = "Email";
            Email.Size = new Size(55, 19);
            Email.TabIndex = 3;
            Email.Text = "Email:";
            // 
            // Contraseña
            // 
            Contraseña.AutoSize = true;
            Contraseña.BackColor = Color.Transparent;
            Contraseña.Font = new Font("Yu Gothic", 11.25F, FontStyle.Bold);
            Contraseña.Location = new Point(54, 223);
            Contraseña.Name = "Contraseña";
            Contraseña.Size = new Size(99, 19);
            Contraseña.TabIndex = 4;
            Contraseña.Text = "Contraseña:";
            // 
            // Rol
            // 
            Rol.AutoSize = true;
            Rol.BackColor = Color.Transparent;
            Rol.Font = new Font("Yu Gothic", 11.25F, FontStyle.Bold);
            Rol.Location = new Point(54, 273);
            Rol.Name = "Rol";
            Rol.Size = new Size(37, 19);
            Rol.TabIndex = 5;
            Rol.Text = "Rol:";
            // 
            // textNombre
            // 
            textNombre.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textNombre.Location = new Point(207, 68);
            textNombre.Name = "textNombre";
            textNombre.Size = new Size(256, 29);
            textNombre.TabIndex = 6;
            // 
            // textDocumento
            // 
            textDocumento.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textDocumento.Location = new Point(207, 118);
            textDocumento.Name = "textDocumento";
            textDocumento.Size = new Size(256, 29);
            textDocumento.TabIndex = 7;
            // 
            // textEmail
            // 
            textEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textEmail.Location = new Point(207, 168);
            textEmail.Name = "textEmail";
            textEmail.Size = new Size(256, 29);
            textEmail.TabIndex = 8;
            // 
            // textPassword
            // 
            textPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textPassword.Location = new Point(207, 218);
            textPassword.Name = "textPassword";
            textPassword.Size = new Size(256, 29);
            textPassword.TabIndex = 9;
            textPassword.UseSystemPasswordChar = true;
            // 
            // cmbRol
            // 
            cmbRol.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbRol.FormattingEnabled = true;
            cmbRol.Items.AddRange(new object[] { "Director", "Vendedor" });
            cmbRol.Location = new Point(207, 268);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(256, 29);
            cmbRol.TabIndex = 10;
            // 
            // aceptarCrearUsuario
            // 
            aceptarCrearUsuario.BackColor = Color.LightGray;
            aceptarCrearUsuario.Font = new Font("Yu Gothic", 11.25F, FontStyle.Bold);
            aceptarCrearUsuario.Location = new Point(207, 340);
            aceptarCrearUsuario.Name = "aceptarCrearUsuario";
            aceptarCrearUsuario.Size = new Size(120, 40);
            aceptarCrearUsuario.TabIndex = 11;
            aceptarCrearUsuario.Text = "Aceptar";
            aceptarCrearUsuario.UseVisualStyleBackColor = false;
            aceptarCrearUsuario.Click += aceptar_Click;
            // 
            // cancelarCrearUsuario
            // 
            cancelarCrearUsuario.BackColor = Color.LightGray;
            cancelarCrearUsuario.Font = new Font("Yu Gothic", 11.25F, FontStyle.Bold);
            cancelarCrearUsuario.Location = new Point(343, 340);
            cancelarCrearUsuario.Name = "cancelarCrearUsuario";
            cancelarCrearUsuario.Size = new Size(120, 40);
            cancelarCrearUsuario.TabIndex = 12;
            cancelarCrearUsuario.Text = "Cancelar";
            cancelarCrearUsuario.UseVisualStyleBackColor = false;
            cancelarCrearUsuario.Click += cancelar_click;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackColor = Color.Transparent;
            pictureBoxLogo.Image = (Image)resources.GetObject("pictureBoxLogo.Image");
            pictureBoxLogo.Location = new Point(488, 12);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(100, 100);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // FormCrearUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 450);
            Controls.Add(pictureBoxLogo);
            Controls.Add(Nombre);
            Controls.Add(textNombre);
            Controls.Add(Documento);
            Controls.Add(textDocumento);
            Controls.Add(Email);
            Controls.Add(textEmail);
            Controls.Add(Contraseña);
            Controls.Add(textPassword);
            Controls.Add(Rol);
            Controls.Add(cmbRol);
            Controls.Add(aceptarCrearUsuario);
            Controls.Add(cancelarCrearUsuario);
            Name = "FormCrearUsuario";
            Text = "Registrar Usuario";
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label Nombre;
        private Label Documento;
        private Label Email;
        private Label Contraseña;
        private Label Rol;
        private TextBox textNombre;
        private TextBox textDocumento;
        private TextBox textEmail;
        private TextBox textPassword;
        private ComboBox cmbRol;
        private Button aceptarCrearUsuario;
        private Button cancelarCrearUsuario;
        private PictureBox pictureBoxLogo;
    }
}
