namespace FotoRoman



{
    partial class FormVerReporte
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        DateTimePicker dtpFechaDesde;
        DateTimePicker dtpFechaHasta;
        Label lblFechaDesde;
        Label lblFechaHasta;
        DataGridView dataGridViewPedidos;
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            textBox1 = new TextBox();
            label1 = new Label();
            fechaHoy = new DateTimePicker();
            timer1 = new System.Windows.Forms.Timer(components);
            timer2 = new System.Windows.Forms.Timer(components);
            buttonGenerar = new Button();
            buttonCancelar = new Button();
            lblFechaDesde = new Label();
            lblFechaHasta = new Label();
            dtpFechaDesde = new DateTimePicker();
            dtpFechaHasta = new DateTimePicker();
            dataGridViewPedidos = new DataGridView();
            buttonImprimir = new Button();
            lblTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPedidos).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(183, 120);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(300, 29);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Brown;
            label1.Location = new Point(10, 125);
            label1.Name = "label1";
            label1.Size = new Size(156, 19);
            label1.TabIndex = 1;
            label1.Text = "Usuario del Sistema";
            // 
            // fechaHoy
            // 
            fechaHoy.Font = new Font("Yu Gothic", 9F, FontStyle.Bold);
            fechaHoy.Location = new Point(273, 42);
            fechaHoy.Name = "fechaHoy";
            fechaHoy.Size = new Size(247, 27);
            fechaHoy.TabIndex = 2;
            // 
            // buttonGenerar
            // 
            buttonGenerar.BackColor = Color.LightGray;
            buttonGenerar.Font = new Font("Yu Gothic", 11.25F, FontStyle.Bold);
            buttonGenerar.Location = new Point(273, 489);
            buttonGenerar.Name = "buttonGenerar";
            buttonGenerar.Size = new Size(103, 43);
            buttonGenerar.TabIndex = 4;
            buttonGenerar.Text = "Consultar";
            buttonGenerar.UseVisualStyleBackColor = false;
            buttonGenerar.Click += buttonGenerar_Click;
            // 
            // buttonCancelar
            // 
            buttonCancelar.BackColor = Color.LightGray;
            buttonCancelar.Font = new Font("Yu Gothic", 11.25F, FontStyle.Bold);
            buttonCancelar.Location = new Point(427, 596);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(103, 43);
            buttonCancelar.TabIndex = 5;
            buttonCancelar.Text = "Salir";
            buttonCancelar.UseVisualStyleBackColor = false;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // lblFechaDesde
            // 
            lblFechaDesde.AutoSize = true;
            lblFechaDesde.Font = new Font("Yu Gothic", 9F, FontStyle.Bold);
            lblFechaDesde.Location = new Point(10, 180);
            lblFechaDesde.Name = "lblFechaDesde";
            lblFechaDesde.Size = new Size(86, 16);
            lblFechaDesde.TabIndex = 0;
            lblFechaDesde.Text = "Fecha Desde:";
            // 
            // lblFechaHasta
            // 
            lblFechaHasta.AutoSize = true;
            lblFechaHasta.Font = new Font("Yu Gothic", 9F, FontStyle.Bold);
            lblFechaHasta.Location = new Point(10, 220);
            lblFechaHasta.Name = "lblFechaHasta";
            lblFechaHasta.Size = new Size(84, 16);
            lblFechaHasta.TabIndex = 2;
            lblFechaHasta.Text = "Fecha Hasta:";
            // 
            // dtpFechaDesde
            // 
            dtpFechaDesde.Font = new Font("Yu Gothic", 9F, FontStyle.Bold);
            dtpFechaDesde.Format = DateTimePickerFormat.Short;
            dtpFechaDesde.Location = new Point(120, 180);
            dtpFechaDesde.Name = "dtpFechaDesde";
            dtpFechaDesde.Size = new Size(200, 27);
            dtpFechaDesde.TabIndex = 1;
            // 
            // dtpFechaHasta
            // 
            dtpFechaHasta.Font = new Font("Yu Gothic", 9F, FontStyle.Bold);
            dtpFechaHasta.Format = DateTimePickerFormat.Short;
            dtpFechaHasta.Location = new Point(120, 220);
            dtpFechaHasta.Name = "dtpFechaHasta";
            dtpFechaHasta.Size = new Size(200, 27);
            dtpFechaHasta.TabIndex = 3;
            // 
            // dataGridViewPedidos
            // 
            dataGridViewPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPedidos.BackgroundColor = SystemColors.Control;
            dataGridViewPedidos.Location = new Point(10, 261);
            dataGridViewPedidos.Name = "dataGridViewPedidos";
            dataGridViewPedidos.Size = new Size(530, 150);
            dataGridViewPedidos.TabIndex = 0;
            // 
            // buttonImprimir
            // 
            buttonImprimir.BackColor = Color.LightGray;
            buttonImprimir.Font = new Font("Yu Gothic", 11.25F, FontStyle.Bold);
            buttonImprimir.Location = new Point(427, 489);
            buttonImprimir.Name = "buttonImprimir";
            buttonImprimir.Size = new Size(103, 43);
            buttonImprimir.TabIndex = 6;
            buttonImprimir.Text = "Imprimir";
            buttonImprimir.UseVisualStyleBackColor = false;
            buttonImprimir.Click += buttonImprimir_Click;
            // 
            // lblTotal
            // 
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotal.Location = new Point(437, 381);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(103, 30);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "Total: $0.00";
            // 
            // FormVerReporte
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(565, 651);
            Controls.Add(buttonImprimir);
            Controls.Add(lblFechaDesde);
            Controls.Add(dtpFechaDesde);
            Controls.Add(lblFechaHasta);
            Controls.Add(dtpFechaHasta);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonGenerar);
            Controls.Add(fechaHoy);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(dataGridViewPedidos);
            Controls.Add(lblTotal);
            Name = "FormVerReporte";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GenerarReporte";
            ((System.ComponentModel.ISupportInitialize)dataGridViewPedidos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private DateTimePicker fechaHoy;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private Button buttonGenerar;
        private Button buttonCancelar;
        private Button buttonImprimir;
        private Label lblTotal;
    }
}
