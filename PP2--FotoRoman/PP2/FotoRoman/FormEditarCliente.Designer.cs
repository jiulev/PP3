namespace FotoRoman
{
    partial class FormEditarCliente
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos utilizados.
        /// </summary>
        /// <param name="disposing">true si se deben eliminar los recursos administrados.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            textBoxNombre = new TextBox();
            textBoxCorreo = new TextBox();
            comboBoxEstado = new ComboBox();
            textBoxLocalidad = new TextBox();
            textBoxProvincia = new TextBox();
            textBoxDocumento = new TextBox();
            buttonGuardar = new Button();
            buttonCancelar = new Button();
            textBoxTelefono = new TextBox();
            textBoxRazon = new TextBox();
            textBoxCuit = new TextBox();
            labelNombre = new Label();
            labelTelefono = new Label();
            labelEstado = new Label();
            labelLocalidad = new Label();
            labelProvincia = new Label();
            labelDocumento = new Label();
            labelCorreo = new Label();
            labelRazon = new Label();
            labelCuit = new Label();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(180, 12);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.PlaceholderText = "Apellido y Nombre";
            textBoxNombre.Size = new Size(300, 23);
            textBoxNombre.TabIndex = 0;
            // 
            // textBoxCorreo
            // 
            textBoxCorreo.Location = new Point(180, 253);
            textBoxCorreo.Name = "textBoxCorreo";
            textBoxCorreo.PlaceholderText = "Correo";
            textBoxCorreo.Size = new Size(300, 23);
            textBoxCorreo.TabIndex = 1;
            // 
            // comboBoxEstado
            // 
            comboBoxEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEstado.FormattingEnabled = true;
            comboBoxEstado.Items.AddRange(new object[] { "Activo", "Inactivo" });
            comboBoxEstado.Location = new Point(180, 93);
            comboBoxEstado.Name = "comboBoxEstado";
            comboBoxEstado.Size = new Size(300, 23);
            comboBoxEstado.TabIndex = 2;
            // 
            // textBoxLocalidad
            // 
            textBoxLocalidad.Location = new Point(180, 132);
            textBoxLocalidad.Name = "textBoxLocalidad";
            textBoxLocalidad.PlaceholderText = "Localidad";
            textBoxLocalidad.Size = new Size(300, 23);
            textBoxLocalidad.TabIndex = 3;
            // 
            // textBoxProvincia
            // 
            textBoxProvincia.Location = new Point(180, 172);
            textBoxProvincia.Name = "textBoxProvincia";
            textBoxProvincia.PlaceholderText = "Provincia";
            textBoxProvincia.Size = new Size(300, 23);
            textBoxProvincia.TabIndex = 4;
            // 
            // textBoxDocumento
            // 
            textBoxDocumento.Location = new Point(180, 211);
            textBoxDocumento.Name = "textBoxDocumento";
            textBoxDocumento.ReadOnly = true;
            textBoxDocumento.Size = new Size(300, 23);
            textBoxDocumento.TabIndex = 5;
            // 
            // buttonGuardar
            // 
            buttonGuardar.BackColor = Color.LightGray;
            buttonGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonGuardar.Location = new Point(180, 386);
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.Size = new Size(120, 40);
            buttonGuardar.TabIndex = 6;
            buttonGuardar.Text = "Guardar";
            buttonGuardar.UseVisualStyleBackColor = false;
            buttonGuardar.Click += buttonGuardar_Click;
            // 
            // buttonCancelar
            // 
            buttonCancelar.BackColor = Color.LightGray;
            buttonCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonCancelar.Location = new Point(360, 386);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(120, 40);
            buttonCancelar.TabIndex = 7;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = false;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // textBoxTelefono
            // 
            textBoxTelefono.Location = new Point(180, 52);
            textBoxTelefono.Name = "textBoxTelefono";
            textBoxTelefono.PlaceholderText = "Teléfono";
            textBoxTelefono.Size = new Size(300, 23);
            textBoxTelefono.TabIndex = 8;
            // 
            // textBoxRazon
            // 
            textBoxRazon.Location = new Point(180, 292);
            textBoxRazon.Name = "textBoxRazon";
            textBoxRazon.PlaceholderText = "Razón Social";
            textBoxRazon.Size = new Size(300, 23);
            textBoxRazon.TabIndex = 9;
            // 
            // textBoxCuit
            // 
            textBoxCuit.Location = new Point(180, 333);
            textBoxCuit.Name = "textBoxCuit";
            textBoxCuit.PlaceholderText = "CUIT";
            textBoxCuit.Size = new Size(300, 23);
            textBoxCuit.TabIndex = 10;
            // 
            // labelNombre
            // 
            labelNombre.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelNombre.Location = new Point(44, 12);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(130, 23);
            labelNombre.TabIndex = 0;
            labelNombre.Text = "Apellido y Nombre:";
            labelNombre.Click += labelNombre_Click;
            // 
            // labelTelefono
            // 
            labelTelefono.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold | FontStyle.Italic);
            labelTelefono.Location = new Point(103, 53);
            labelTelefono.Name = "labelTelefono";
            labelTelefono.Size = new Size(67, 23);
            labelTelefono.TabIndex = 1;
            labelTelefono.Text = "Teléfono:";
            // 
            // labelEstado
            // 
            labelEstado.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold | FontStyle.Italic);
            labelEstado.Location = new Point(117, 93);
            labelEstado.Name = "labelEstado";
            labelEstado.Size = new Size(53, 23);
            labelEstado.TabIndex = 2;
            labelEstado.Text = "Estado:";
            // 
            // labelLocalidad
            // 
            labelLocalidad.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold | FontStyle.Italic);
            labelLocalidad.Location = new Point(99, 132);
            labelLocalidad.Name = "labelLocalidad";
            labelLocalidad.Size = new Size(75, 23);
            labelLocalidad.TabIndex = 3;
            labelLocalidad.Text = "Localidad:";
            // 
            // labelProvincia
            // 
            labelProvincia.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold | FontStyle.Italic);
            labelProvincia.Location = new Point(103, 173);
            labelProvincia.Name = "labelProvincia";
            labelProvincia.Size = new Size(75, 23);
            labelProvincia.TabIndex = 4;
            labelProvincia.Text = "Provincia:";
            // 
            // labelDocumento
            // 
            labelDocumento.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold | FontStyle.Italic);
            labelDocumento.Location = new Point(137, 212);
            labelDocumento.Name = "labelDocumento";
            labelDocumento.Size = new Size(37, 23);
            labelDocumento.TabIndex = 5;
            labelDocumento.Text = "DNI:";
            // 
            // labelCorreo
            // 
            labelCorreo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold | FontStyle.Italic);
            labelCorreo.Location = new Point(121, 254);
            labelCorreo.Name = "labelCorreo";
            labelCorreo.Size = new Size(53, 23);
            labelCorreo.TabIndex = 6;
            labelCorreo.Text = "Correo:";
            // 
            // labelRazon
            // 
            labelRazon.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold | FontStyle.Italic);
            labelRazon.Location = new Point(84, 293);
            labelRazon.Name = "labelRazon";
            labelRazon.Size = new Size(90, 23);
            labelRazon.TabIndex = 7;
            labelRazon.Text = "Razón Social:";
            // 
            // labelCuit
            // 
            labelCuit.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold | FontStyle.Italic);
            labelCuit.Location = new Point(133, 332);
            labelCuit.Name = "labelCuit";
            labelCuit.Size = new Size(41, 23);
            labelCuit.TabIndex = 8;
            labelCuit.Text = "CUIT:";
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = SystemColors.Control;
            iconPictureBox1.ForeColor = Color.IndianRed;
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.LockOpen;
            iconPictureBox1.IconColor = Color.IndianRed;
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 36;
            iconPictureBox1.Location = new Point(501, 12);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(36, 37);
            iconPictureBox1.TabIndex = 11;
            iconPictureBox1.TabStop = false;
            // 
            // FormEditarCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(553, 438);
            Controls.Add(iconPictureBox1);
            Controls.Add(labelNombre);
            Controls.Add(labelTelefono);
            Controls.Add(labelEstado);
            Controls.Add(labelLocalidad);
            Controls.Add(labelProvincia);
            Controls.Add(labelDocumento);
            Controls.Add(labelCorreo);
            Controls.Add(labelRazon);
            Controls.Add(labelCuit);
            Controls.Add(textBoxCuit);
            Controls.Add(textBoxRazon);
            Controls.Add(textBoxTelefono);
            Controls.Add(textBoxNombre);
            Controls.Add(textBoxCorreo);
            Controls.Add(comboBoxEstado);
            Controls.Add(textBoxLocalidad);
            Controls.Add(textBoxProvincia);
            Controls.Add(textBoxDocumento);
            Controls.Add(buttonGuardar);
            Controls.Add(buttonCancelar);
            Name = "FormEditarCliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editar Cliente";
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxCorreo;
        private System.Windows.Forms.ComboBox comboBoxEstado;
        private System.Windows.Forms.TextBox textBoxLocalidad;
        private System.Windows.Forms.TextBox textBoxProvincia;
        private System.Windows.Forms.TextBox textBoxDocumento;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonCancelar;
        private TextBox textBoxTelefono;
        private TextBox textBoxRazon;
        private TextBox textBoxCuit;
        private Label labelNombre;
        private Label labelTelefono;
        private Label labelEstado;
        private Label labelLocalidad;
        private Label labelProvincia;
        private Label labelDocumento;
        private Label labelCorreo;
        private Label labelRazon;
        private Label labelCuit;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
    }
}
