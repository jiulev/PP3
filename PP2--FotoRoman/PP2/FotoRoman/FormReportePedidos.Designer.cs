namespace CapaPresentacion
{
    partial class FormReportePedidos
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboCliente;
        private System.Windows.Forms.ComboBox comboEstado;
        private System.Windows.Forms.ComboBox comboPago;
        private System.Windows.Forms.DateTimePicker dateDesde;
        private System.Windows.Forms.DateTimePicker dateHasta;
        private System.Windows.Forms.CheckBox checkDesde;
        private System.Windows.Forms.CheckBox checkHasta;
        private System.Windows.Forms.Button btnGenerarReporte;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblPago;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label lblHasta;

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
            this.comboCliente = new System.Windows.Forms.ComboBox();
            this.comboEstado = new System.Windows.Forms.ComboBox();
            this.comboPago = new System.Windows.Forms.ComboBox();
            this.dateDesde = new System.Windows.Forms.DateTimePicker();
            this.dateHasta = new System.Windows.Forms.DateTimePicker();
            this.checkDesde = new System.Windows.Forms.CheckBox();
            this.checkHasta = new System.Windows.Forms.CheckBox();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblPago = new System.Windows.Forms.Label();
            this.lblDesde = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // comboCliente
            this.comboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCliente.FormattingEnabled = true;
            this.comboCliente.Location = new System.Drawing.Point(120, 30);
            this.comboCliente.Name = "comboCliente";
            this.comboCliente.Size = new System.Drawing.Size(220, 24);

            // comboEstado
            this.comboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEstado.FormattingEnabled = true;
            this.comboEstado.Items.AddRange(new object[] { "Todos", "Pendiente", "En proceso", "Finalizado" });
            this.comboEstado.Location = new System.Drawing.Point(120, 70);
            this.comboEstado.Name = "comboEstado";
            this.comboEstado.Size = new System.Drawing.Size(220, 24);

            // comboPago
            this.comboPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPago.FormattingEnabled = true;
            this.comboPago.Items.AddRange(new object[] { "Todos", "Sin cobros", "Parcial", "Total" });
            this.comboPago.Location = new System.Drawing.Point(120, 110);
            this.comboPago.Name = "comboPago";
            this.comboPago.Size = new System.Drawing.Size(220, 24);

            // checkDesde
            this.checkDesde.AutoSize = true;
            this.checkDesde.Location = new System.Drawing.Point(30, 155);
            this.checkDesde.Name = "checkDesde";
            this.checkDesde.Size = new System.Drawing.Size(70, 20);
            this.checkDesde.Text = "Desde";
            this.checkDesde.CheckedChanged += new System.EventHandler(this.CheckDesde_CheckedChanged);

            // dateDesde
            this.dateDesde.Location = new System.Drawing.Point(120, 150);
            this.dateDesde.Name = "dateDesde";
            this.dateDesde.Size = new System.Drawing.Size(220, 22);
            this.dateDesde.Enabled = false;

            // checkHasta
            this.checkHasta.AutoSize = true;
            this.checkHasta.Location = new System.Drawing.Point(30, 195);
            this.checkHasta.Name = "checkHasta";
            this.checkHasta.Size = new System.Drawing.Size(65, 20);
            this.checkHasta.Text = "Hasta";
            this.checkHasta.CheckedChanged += new System.EventHandler(this.CheckHasta_CheckedChanged);

            // dateHasta
            this.dateHasta.Location = new System.Drawing.Point(120, 190);
            this.dateHasta.Name = "dateHasta";
            this.dateHasta.Size = new System.Drawing.Size(220, 22);
            this.dateHasta.Enabled = false;

            // btnGenerarReporte
            this.btnGenerarReporte.Location = new System.Drawing.Point(120, 230);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(220, 30);
            this.btnGenerarReporte.Text = "Generar Reporte";
            this.btnGenerarReporte.UseVisualStyleBackColor = true;
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);

            // Labels
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(30, 33);
            this.lblCliente.Text = "Cliente:";

            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(30, 73);
            this.lblEstado.Text = "Estado:";

            this.lblPago.AutoSize = true;
            this.lblPago.Location = new System.Drawing.Point(30, 113);
            this.lblPago.Text = "Pago:";

            // FormReportePedidos
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 280);
            this.Controls.Add(this.comboCliente);
            this.Controls.Add(this.comboEstado);
            this.Controls.Add(this.comboPago);
            this.Controls.Add(this.checkDesde);
            this.Controls.Add(this.dateDesde);
            this.Controls.Add(this.checkHasta);
            this.Controls.Add(this.dateHasta);
            this.Controls.Add(this.btnGenerarReporte);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblPago);
            this.Name = "FormReportePedidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Pedidos";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
