namespace FotoRoman
{
    partial class FormRegistrarLocalidad
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
            labelTitulo = new Label();
            textBoxLocalidad = new TextBox();
            btnRegistrar = new Button();
            labelProvincia = new Label();
            comboBoxProvincia = new ComboBox();
            SuspendLayout();
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelTitulo.Location = new Point(50, 20);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(210, 21);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = "Registrar Nueva Localidad";
            // 
            // textBoxLocalidad
            // 
            textBoxLocalidad.Font = new Font("Segoe UI", 10F);
            textBoxLocalidad.Location = new Point(50, 100);
            textBoxLocalidad.Name = "textBoxLocalidad";
            textBoxLocalidad.Size = new Size(300, 25);
            textBoxLocalidad.TabIndex = 1;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.LightGray;
            btnRegistrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRegistrar.Location = new Point(150, 150);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(100, 30);
            btnRegistrar.TabIndex = 2;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // labelProvincia
            // 
            labelProvincia.AutoSize = true;
            labelProvincia.Font = new Font("Segoe UI", 10F);
            labelProvincia.Location = new Point(50, 50);
            labelProvincia.Name = "labelProvincia";
            labelProvincia.Size = new Size(67, 19);
            labelProvincia.TabIndex = 3;
            labelProvincia.Text = "Provincia:";
            // 
            // comboBoxProvincia
            // 
            comboBoxProvincia.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProvincia.Font = new Font("Segoe UI", 10F);
            comboBoxProvincia.FormattingEnabled = true;
            comboBoxProvincia.Location = new Point(50, 70);
            comboBoxProvincia.Name = "comboBoxProvincia";
            comboBoxProvincia.Size = new Size(300, 25);
            comboBoxProvincia.TabIndex = 4;
            // 
            // FormRegistrarLocalidad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 200);
            Controls.Add(comboBoxProvincia);
            Controls.Add(labelProvincia);
            Controls.Add(btnRegistrar);
            Controls.Add(textBoxLocalidad);
            Controls.Add(labelTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormRegistrarLocalidad";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registrar Localidad";
            Load += FormRegistrarLocalidad_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.TextBox textBoxLocalidad;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label labelProvincia;
        private System.Windows.Forms.ComboBox comboBoxProvincia;
    }
}
