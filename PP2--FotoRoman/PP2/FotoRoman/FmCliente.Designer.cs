namespace FotoRoman
{
    partial class FmCliente
    {
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmCliente));
            groupBoxCliente = new GroupBox();
            pictureBoxLogo = new PictureBox();
            labelNombre = new Label();
            textNombre = new TextBox();
            labelDocumento = new Label();
            textDocumento = new TextBox();
            labelCorreo = new Label();
            textCorreo = new TextBox();
            label1 = new Label();
            textBox1 = new TextBox();
            labelProvincia = new Label();
            comboBoxProvincia = new ComboBox();
            labelLocalidad = new Label();
            comboBoxLocalidad = new ComboBox();
            checkBoxFiscal = new CheckBox();
            label2 = new Label();
            razonSocial = new TextBox();
            label3 = new Label();
            cuit = new TextBox();
            RegistrarCliente = new Button();
            CancelarCliente = new Button();
            groupBoxCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // groupBoxCliente
            // 
            groupBoxCliente.BackColor = Color.Transparent;
            groupBoxCliente.Controls.Add(pictureBoxLogo);
            groupBoxCliente.Controls.Add(labelNombre);
            groupBoxCliente.Controls.Add(textNombre);
            groupBoxCliente.Controls.Add(labelDocumento);
            groupBoxCliente.Controls.Add(textDocumento);
            groupBoxCliente.Controls.Add(labelCorreo);
            groupBoxCliente.Controls.Add(textCorreo);
            groupBoxCliente.Controls.Add(label1);
            groupBoxCliente.Controls.Add(textBox1);
            groupBoxCliente.Controls.Add(labelProvincia);
            groupBoxCliente.Controls.Add(comboBoxProvincia);
            groupBoxCliente.Controls.Add(labelLocalidad);
            groupBoxCliente.Controls.Add(comboBoxLocalidad);
            groupBoxCliente.Controls.Add(checkBoxFiscal);
            groupBoxCliente.Controls.Add(label2);
            groupBoxCliente.Controls.Add(razonSocial);
            groupBoxCliente.Controls.Add(label3);
            groupBoxCliente.Controls.Add(cuit);
            groupBoxCliente.Controls.Add(RegistrarCliente);
            groupBoxCliente.Controls.Add(CancelarCliente);
            groupBoxCliente.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            groupBoxCliente.Location = new Point(12, 12);
            groupBoxCliente.Name = "groupBoxCliente";
            groupBoxCliente.Size = new Size(558, 460);
            groupBoxCliente.TabIndex = 0;
            groupBoxCliente.TabStop = false;
            groupBoxCliente.Text = "Datos del Cliente";
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackColor = Color.Transparent;
            pictureBoxLogo.Image = (Image)resources.GetObject("pictureBoxLogo.Image");
            pictureBoxLogo.Location = new Point(462, 30);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(76, 65);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // labelNombre
            // 
            labelNombre.Font = new Font("Segoe UI", 10F);
            labelNombre.Location = new Point(30, 30);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(140, 25);
            labelNombre.TabIndex = 0;
            labelNombre.Text = "Apellido y Nombre:";
            // 
            // textNombre
            // 
            textNombre.BackColor = SystemColors.InactiveBorder;
            textNombre.Font = new Font("Segoe UI", 10F);
            textNombre.Location = new Point(176, 30);
            textNombre.Name = "textNombre";
            textNombre.Size = new Size(280, 25);
            textNombre.TabIndex = 1;
            // 
            // labelDocumento
            // 
            labelDocumento.Font = new Font("Segoe UI", 10F);
            labelDocumento.Location = new Point(30, 70);
            labelDocumento.Name = "labelDocumento";
            labelDocumento.Size = new Size(100, 25);
            labelDocumento.TabIndex = 2;
            labelDocumento.Text = "Documento:";
            // 
            // textDocumento
            // 
            textDocumento.Font = new Font("Segoe UI", 10F);
            textDocumento.Location = new Point(176, 70);
            textDocumento.Name = "textDocumento";
            textDocumento.Size = new Size(280, 25);
            textDocumento.TabIndex = 3;
            // 
            // labelCorreo
            // 
            labelCorreo.Font = new Font("Segoe UI", 10F);
            labelCorreo.Location = new Point(30, 150);
            labelCorreo.Name = "labelCorreo";
            labelCorreo.Size = new Size(140, 25);
            labelCorreo.TabIndex = 4;
            labelCorreo.Text = "Correo Electrónico:";
            // 
            // textCorreo
            // 
            textCorreo.Font = new Font("Segoe UI", 10F);
            textCorreo.Location = new Point(176, 150);
            textCorreo.Name = "textCorreo";
            textCorreo.Size = new Size(280, 25);
            textCorreo.TabIndex = 5;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(30, 110);
            label1.Name = "label1";
            label1.Size = new Size(100, 25);
            label1.TabIndex = 6;
            label1.Text = "Teléfono:";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 10F);
            textBox1.Location = new Point(176, 110);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(280, 25);
            textBox1.TabIndex = 7;
            // 
            // labelProvincia
            // 
            labelProvincia.Font = new Font("Segoe UI", 10F);
            labelProvincia.Location = new Point(30, 190);
            labelProvincia.Name = "labelProvincia";
            labelProvincia.Size = new Size(100, 25);
            labelProvincia.TabIndex = 8;
            labelProvincia.Text = "Provincia:";
            // 
            // comboBoxProvincia
            // 
            comboBoxProvincia.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProvincia.FlatStyle = FlatStyle.Popup;
            comboBoxProvincia.Font = new Font("Segoe UI", 10F);
            comboBoxProvincia.Location = new Point(176, 190);
            comboBoxProvincia.Name = "comboBoxProvincia";
            comboBoxProvincia.Size = new Size(280, 25);
            comboBoxProvincia.TabIndex = 9;
            comboBoxProvincia.SelectedIndexChanged += comboBoxProvincia_SelectedIndexChanged;
            // 
            // labelLocalidad
            // 
            labelLocalidad.Font = new Font("Segoe UI", 10F);
            labelLocalidad.Location = new Point(30, 230);
            labelLocalidad.Name = "labelLocalidad";
            labelLocalidad.Size = new Size(100, 25);
            labelLocalidad.TabIndex = 10;
            labelLocalidad.Text = "Localidad:";
            // 
            // comboBoxLocalidad
            // 
            comboBoxLocalidad.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLocalidad.FlatStyle = FlatStyle.Popup;
            comboBoxLocalidad.Font = new Font("Segoe UI", 10F);
            comboBoxLocalidad.Location = new Point(176, 230);
            comboBoxLocalidad.Name = "comboBoxLocalidad";
            comboBoxLocalidad.Size = new Size(280, 25);
            comboBoxLocalidad.TabIndex = 11;
            comboBoxLocalidad.SelectedIndexChanged += comboBoxLocalidad_SelectedIndexChanged;
            // 
            // checkBoxFiscal
            // 
            checkBoxFiscal.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic);
            checkBoxFiscal.Location = new Point(30, 270);
            checkBoxFiscal.Name = "checkBoxFiscal";
            checkBoxFiscal.Size = new Size(104, 24);
            checkBoxFiscal.TabIndex = 12;
            checkBoxFiscal.Text = "Completar Datos Fiscales";
            checkBoxFiscal.CheckedChanged += checkBoxFiscal_CheckedChanged;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(30, 310);
            label2.Name = "label2";
            label2.Size = new Size(100, 25);
            label2.TabIndex = 13;
            label2.Text = "Razón Social:";
            // 
            // razonSocial
            // 
            razonSocial.Font = new Font("Segoe UI", 10F);
            razonSocial.Location = new Point(176, 310);
            razonSocial.Name = "razonSocial";
            razonSocial.Size = new Size(280, 25);
            razonSocial.TabIndex = 14;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(30, 350);
            label3.Name = "label3";
            label3.Size = new Size(100, 25);
            label3.TabIndex = 15;
            label3.Text = "CUIT:";
            // 
            // cuit
            // 
            cuit.Font = new Font("Segoe UI", 10F);
            cuit.Location = new Point(176, 350);
            cuit.Name = "cuit";
            cuit.Size = new Size(280, 25);
            cuit.TabIndex = 16;
            // 
            // RegistrarCliente
            // 
            RegistrarCliente.BackColor = Color.LightGray;
            RegistrarCliente.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            RegistrarCliente.Location = new Point(176, 397);
            RegistrarCliente.Name = "RegistrarCliente";
            RegistrarCliente.Size = new Size(111, 40);
            RegistrarCliente.TabIndex = 17;
            RegistrarCliente.Text = "Registrar";
            RegistrarCliente.UseVisualStyleBackColor = false;
            RegistrarCliente.Click += button1_Click;
            // 
            // CancelarCliente
            // 
            CancelarCliente.BackColor = Color.LightGray;
            CancelarCliente.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            CancelarCliente.Location = new Point(345, 397);
            CancelarCliente.Name = "CancelarCliente";
            CancelarCliente.Size = new Size(111, 40);
            CancelarCliente.TabIndex = 18;
            CancelarCliente.Text = "Limpiar";
            CancelarCliente.UseVisualStyleBackColor = false;
            CancelarCliente.Click += CancelarCliente_Click;
            // 
            // FmCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(582, 495);
            Controls.Add(groupBoxCliente);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "FmCliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registrar Nuevo Cliente";
            Load += FmCliente_Load;
            groupBoxCliente.ResumeLayout(false);
            groupBoxCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textNombre;
        private TextBox textDocumento;
        private TextBox textCorreo;
        private Button RegistrarCliente;
        private Button CancelarCliente;
        private GroupBox groupBoxCliente;
        private Label labelNombre;
        private Label labelDocumento;
        private Label labelCorreo;
        private Label labelLocalidad;
        private Label labelProvincia;
        private ComboBox comboBoxLocalidad;
        private ComboBox comboBoxProvincia;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private CheckBox checkBoxFiscal;
        private Label label3;
        private TextBox cuit;
        private TextBox razonSocial;
        private PictureBox pictureBoxLogo;
    }
}
