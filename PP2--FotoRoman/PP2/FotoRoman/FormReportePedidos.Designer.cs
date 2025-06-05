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
            comboCliente = new ComboBox();
            comboEstado = new ComboBox();
            comboPago = new ComboBox();
            dateDesde = new DateTimePicker();
            dateHasta = new DateTimePicker();
            checkDesde = new CheckBox();
            checkHasta = new CheckBox();
            btnGenerarReporte = new Button();
            lblCliente = new Label();
            lblEstado = new Label();
            lblPago = new Label();
            lblDesde = new Label();
            lblHasta = new Label();
            SuspendLayout();
            // 
            // comboCliente
            // 
            comboCliente.BackColor = Color.White;
            comboCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCliente.FlatStyle = FlatStyle.Flat;
            comboCliente.Font = new Font("Yu Gothic UI", 10F);
            comboCliente.FormattingEnabled = true;
            comboCliente.Location = new Point(105, 32);
            comboCliente.Name = "comboCliente";
            comboCliente.Size = new Size(193, 25);
            comboCliente.TabIndex = 0;
            // 
            // comboEstado
            // 
            comboEstado.BackColor = Color.White;
            comboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            comboEstado.FlatStyle = FlatStyle.Flat;
            comboEstado.Font = new Font("Yu Gothic UI", 10F);
            comboEstado.FormattingEnabled = true;
            comboEstado.Items.AddRange(new object[] { "Todos", "Pendiente", "En proceso", "Finalizado" });
            comboEstado.Location = new Point(105, 74);
            comboEstado.Name = "comboEstado";
            comboEstado.Size = new Size(193, 25);
            comboEstado.TabIndex = 1;
            // 
            // comboPago
            // 
            comboPago.BackColor = Color.White;
            comboPago.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPago.FlatStyle = FlatStyle.Flat;
            comboPago.Font = new Font("Yu Gothic UI", 10F);
            comboPago.FormattingEnabled = true;
            comboPago.Items.AddRange(new object[] { "Todos", "Sin cobros", "Parcial", "Total" });
            comboPago.Location = new Point(105, 117);
            comboPago.Name = "comboPago";
            comboPago.Size = new Size(193, 25);
            comboPago.TabIndex = 2;
            // 
            // dateDesde
            // 
            dateDesde.CalendarForeColor = Color.Black;
            dateDesde.CalendarMonthBackground = Color.White;
            dateDesde.Enabled = false;
            dateDesde.Font = new Font("Yu Gothic UI", 10F);
            dateDesde.Location = new Point(105, 159);
            dateDesde.Name = "dateDesde";
            dateDesde.Size = new Size(193, 25);
            dateDesde.TabIndex = 4;
            // 
            // dateHasta
            // 
            dateHasta.CalendarForeColor = Color.Black;
            dateHasta.CalendarMonthBackground = Color.White;
            dateHasta.Enabled = false;
            dateHasta.Font = new Font("Yu Gothic UI", 10F);
            dateHasta.Location = new Point(105, 202);
            dateHasta.Name = "dateHasta";
            dateHasta.Size = new Size(193, 25);
            dateHasta.TabIndex = 6;
            // 
            // checkDesde
            // 
            checkDesde.AutoSize = true;
            checkDesde.Font = new Font("Yu Gothic UI", 10F);
            checkDesde.Location = new Point(26, 165);
            checkDesde.Name = "checkDesde";
            checkDesde.Size = new Size(66, 23);
            checkDesde.TabIndex = 3;
            checkDesde.Text = "Desde";
            checkDesde.CheckedChanged += CheckDesde_CheckedChanged;
            // 
            // checkHasta
            // 
            checkHasta.AutoSize = true;
            checkHasta.Font = new Font("Yu Gothic UI", 10F);
            checkHasta.Location = new Point(26, 207);
            checkHasta.Name = "checkHasta";
            checkHasta.Size = new Size(63, 23);
            checkHasta.TabIndex = 5;
            checkHasta.Text = "Hasta";
            checkHasta.CheckedChanged += CheckHasta_CheckedChanged;
            // 
            // btnGenerarReporte
            // 
            btnGenerarReporte.BackColor = Color.Silver;
            btnGenerarReporte.Cursor = Cursors.Hand;
            btnGenerarReporte.FlatAppearance.BorderSize = 0;
            btnGenerarReporte.Font = new Font("Yu Gothic UI Semibold", 10F, FontStyle.Bold);
            btnGenerarReporte.ForeColor = Color.Black;
            btnGenerarReporte.Location = new Point(105, 244);
            btnGenerarReporte.Name = "btnGenerarReporte";
            btnGenerarReporte.Size = new Size(192, 37);
            btnGenerarReporte.TabIndex = 7;
            btnGenerarReporte.Text = "Generar Reporte";
            btnGenerarReporte.UseVisualStyleBackColor = false;
            btnGenerarReporte.Click += btnGenerarReporte_Click;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Yu Gothic UI", 10F);
            lblCliente.Location = new Point(26, 35);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(54, 19);
            lblCliente.TabIndex = 8;
            lblCliente.Text = "Cliente:";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Yu Gothic UI", 10F);
            lblEstado.Location = new Point(26, 78);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(53, 19);
            lblEstado.TabIndex = 9;
            lblEstado.Text = "Estado:";
            // 
            // lblPago
            // 
            lblPago.AutoSize = true;
            lblPago.Font = new Font("Yu Gothic UI", 10F);
            lblPago.Location = new Point(26, 120);
            lblPago.Name = "lblPago";
            lblPago.Size = new Size(43, 19);
            lblPago.TabIndex = 10;
            lblPago.Text = "Pago:";
            // 
            // lblDesde
            // 
            lblDesde.Location = new Point(0, 0);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(100, 23);
            lblDesde.TabIndex = 0;
            // 
            // lblHasta
            // 
            lblHasta.Location = new Point(0, 0);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(100, 23);
            lblHasta.TabIndex = 0;
            // 
            // FormReportePedidos
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(350, 308);
            Controls.Add(comboCliente);
            Controls.Add(comboEstado);
            Controls.Add(comboPago);
            Controls.Add(checkDesde);
            Controls.Add(dateDesde);
            Controls.Add(checkHasta);
            Controls.Add(dateHasta);
            Controls.Add(btnGenerarReporte);
            Controls.Add(lblCliente);
            Controls.Add(lblEstado);
            Controls.Add(lblPago);
            Font = new Font("Yu Gothic UI", 10F);
            ForeColor = Color.FromArgb(30, 30, 30);
            Name = "FormReportePedidos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reporte de Pedidos";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
