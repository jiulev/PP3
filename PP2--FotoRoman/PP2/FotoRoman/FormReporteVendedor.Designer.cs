namespace FotoRoman
{
    partial class FormReporteVendedor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxUsuarios;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.Windows.Forms.DataGridView dataGridViewPedidos;
        private System.Windows.Forms.Button buttonGenerar;
        private System.Windows.Forms.Button buttonImprimir;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Label lblTotal;

        /// <summary>
        /// Limpiar recursos.
        /// </summary>
        /// <param name="disposing">true si se deben liberar recursos.</param>
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
        /// Método requerido para el soporte del diseñador.
        /// </summary>
        private void InitializeComponent()
        {
            comboBoxUsuarios = new ComboBox();
            dtpFechaDesde = new DateTimePicker();
            dtpFechaHasta = new DateTimePicker();
            lblFechaDesde = new Label();
            lblFechaHasta = new Label();
            dataGridViewPedidos = new DataGridView();
            buttonGenerar = new Button();
            buttonImprimir = new Button();
            buttonCancelar = new Button();
            lblTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPedidos).BeginInit();
            SuspendLayout();
            // 
            // comboBoxUsuarios
            // 
            comboBoxUsuarios.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUsuarios.FormattingEnabled = true;
            comboBoxUsuarios.Location = new Point(120, 30);
            comboBoxUsuarios.Name = "comboBoxUsuarios";
            comboBoxUsuarios.Size = new Size(250, 23);
            comboBoxUsuarios.TabIndex = 0;
            comboBoxUsuarios.SelectedIndexChanged += comboBoxUsuarios_SelectedIndexChanged;
            // 
            // dtpFechaDesde
            // 
            dtpFechaDesde.Font = new Font("Yu Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFechaDesde.Format = DateTimePickerFormat.Short;
            dtpFechaDesde.Location = new Point(120, 70);
            dtpFechaDesde.Name = "dtpFechaDesde";
            dtpFechaDesde.Size = new Size(100, 28);
            dtpFechaDesde.TabIndex = 1;
            // 
            // dtpFechaHasta
            // 
            dtpFechaHasta.Font = new Font("Yu Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFechaHasta.Format = DateTimePickerFormat.Short;
            dtpFechaHasta.Location = new Point(120, 110);
            dtpFechaHasta.Name = "dtpFechaHasta";
            dtpFechaHasta.Size = new Size(100, 28);
            dtpFechaHasta.TabIndex = 2;
            // 
            // lblFechaDesde
            // 
            lblFechaDesde.AutoSize = true;
            lblFechaDesde.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            lblFechaDesde.Location = new Point(19, 75);
            lblFechaDesde.Name = "lblFechaDesde";
            lblFechaDesde.Size = new Size(95, 17);
            lblFechaDesde.TabIndex = 3;
            lblFechaDesde.Text = "Fecha Desde:";
            // 
            // lblFechaHasta
            // 
            lblFechaHasta.AutoSize = true;
            lblFechaHasta.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            lblFechaHasta.Location = new Point(22, 115);
            lblFechaHasta.Name = "lblFechaHasta";
            lblFechaHasta.Size = new Size(92, 17);
            lblFechaHasta.TabIndex = 4;
            lblFechaHasta.Text = "Fecha Hasta:";
            // 
            // dataGridViewPedidos
            // 
            dataGridViewPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPedidos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewPedidos.BackgroundColor = SystemColors.Control;
            dataGridViewPedidos.BorderStyle = BorderStyle.None;
            dataGridViewPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPedidos.Location = new Point(72, 151);
            dataGridViewPedidos.Name = "dataGridViewPedidos";
            dataGridViewPedidos.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewPedidos.Size = new Size(306, 200);
            dataGridViewPedidos.TabIndex = 5;
            // 
            // buttonGenerar
            // 
            buttonGenerar.BackColor = Color.LightGray;
            buttonGenerar.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            buttonGenerar.Location = new Point(47, 374);
            buttonGenerar.Name = "buttonGenerar";
            buttonGenerar.Size = new Size(98, 36);
            buttonGenerar.TabIndex = 6;
            buttonGenerar.Text = "Consultar";
            buttonGenerar.UseVisualStyleBackColor = false;
            buttonGenerar.Click += buttonGenerar_Click;
            // 
            // buttonImprimir
            // 
            buttonImprimir.BackColor = Color.LightGray;
            buttonImprimir.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            buttonImprimir.Location = new Point(160, 374);
            buttonImprimir.Name = "buttonImprimir";
            buttonImprimir.Size = new Size(98, 36);
            buttonImprimir.TabIndex = 7;
            buttonImprimir.Text = "Imprimir";
            buttonImprimir.UseVisualStyleBackColor = false;
            buttonImprimir.Click += buttonImprimir_Click;
            // 
            // buttonCancelar
            // 
            buttonCancelar.BackColor = Color.LightGray;
            buttonCancelar.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            buttonCancelar.Location = new Point(272, 374);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(98, 36);
            buttonCancelar.TabIndex = 8;
            buttonCancelar.Text = "Salir";
            buttonCancelar.UseVisualStyleBackColor = false;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotal.ForeColor = Color.Black;
            lblTotal.Location = new Point(350, 425);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(86, 19);
            lblTotal.TabIndex = 9;
            lblTotal.Text = "Total: $0.00";
            // 
            // FormReporteVendedor
            // 
            ClientSize = new Size(500, 420);
            Controls.Add(lblTotal);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonImprimir);
            Controls.Add(buttonGenerar);
            Controls.Add(dataGridViewPedidos);
            Controls.Add(lblFechaHasta);
            Controls.Add(lblFechaDesde);
            Controls.Add(dtpFechaHasta);
            Controls.Add(dtpFechaDesde);
            Controls.Add(comboBoxUsuarios);
            Name = "FormReporteVendedor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reporte por Vendedor";
            Load += FormReporteVendedor_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewPedidos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
