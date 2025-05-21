namespace FotoRoman
{
    partial class FormReporteProducto
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ComboBox cmbMeses; // ComboBox para seleccionar el mes
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblSeleccionarMes; // Etiqueta para el ComboBox

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
            btnCerrar = new Button();
            cmbMeses = new ComboBox();
            lblSeleccionarMes = new Label();
            comboBoxAnio = new ComboBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.LightGray;
            btnCerrar.Font = new Font("Yu Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrar.Location = new Point(394, 427);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(120, 40);
            btnCerrar.TabIndex = 1;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // cmbMeses
            // 
            cmbMeses.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMeses.FormattingEnabled = true;
            cmbMeses.Location = new Point(12, 31);
            cmbMeses.Name = "cmbMeses";
            cmbMeses.Size = new Size(132, 23);
            cmbMeses.TabIndex = 0;
            cmbMeses.SelectedIndexChanged += comboBoxMes_SelectedIndexChanged;
            // 
            // lblSeleccionarMes
            // 
            lblSeleccionarMes.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            lblSeleccionarMes.Location = new Point(12, 9);
            lblSeleccionarMes.Name = "lblSeleccionarMes";
            lblSeleccionarMes.Size = new Size(131, 19);
            lblSeleccionarMes.TabIndex = 1;
            lblSeleccionarMes.Text = "Seleccionar Mes:";
            // 
            // comboBoxAnio
            // 
            comboBoxAnio.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAnio.FormattingEnabled = true;
            comboBoxAnio.Location = new Point(160, 31);
            comboBoxAnio.Name = "comboBoxAnio";
            comboBoxAnio.Size = new Size(132, 23);
            comboBoxAnio.TabIndex = 2;
            comboBoxAnio.SelectedIndexChanged += comboBoxAnio_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            label1.Location = new Point(160, 9);
            label1.Name = "label1";
            label1.Size = new Size(121, 19);
            label1.TabIndex = 3;
            label1.Text = "Seleccionar Año";
            // 
            // FormReporteProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 479);
            Controls.Add(label1);
            Controls.Add(comboBoxAnio);
            Controls.Add(cmbMeses);
            Controls.Add(lblSeleccionarMes);
            Controls.Add(btnCerrar);
            Name = "FormReporteProducto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reporte de Productos Más Vendidos";
            Load += FormReporteProducto_Load;
            Paint += FormReporteProducto_Paint;
            ResumeLayout(false);
        }

        private ComboBox comboBoxAnio;
        private Label label1;
    }
}
