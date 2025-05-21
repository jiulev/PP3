namespace FotoRoman
{
    partial class FormRegistrar
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
            textBoxProvincia = new TextBox();
            btnRegistrar = new Button();
            SuspendLayout();
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Yu Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitulo.Location = new Point(50, 35);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(198, 19);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = "Registrar Nueva Provincia";
            // 
            // textBoxProvincia
            // 
            textBoxProvincia.Font = new Font("Segoe UI", 10F);
            textBoxProvincia.Location = new Point(50, 70);
            textBoxProvincia.Name = "textBoxProvincia";
            textBoxProvincia.Size = new Size(300, 25);
            textBoxProvincia.TabIndex = 1;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.LightGray;
            btnRegistrar.Font = new Font("Yu Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistrar.Location = new Point(150, 120);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(100, 30);
            btnRegistrar.TabIndex = 2;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // FormRegistrar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 200);
            Controls.Add(btnRegistrar);
            Controls.Add(textBoxProvincia);
            Controls.Add(labelTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormRegistrar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registrar Provincia";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.TextBox textBoxProvincia;
        private System.Windows.Forms.Button btnRegistrar;
    }
}
