namespace FotoRoman
{
    partial class FormEditarCobro
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ComboBox comboClientes;
        private System.Windows.Forms.DateTimePicker dateTimePickerDesde;
        private System.Windows.Forms.DateTimePicker dateTimePickerHasta;
        private System.Windows.Forms.DataGridView dataGridViewCobros;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.Button buttonCerrar;

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
            comboClientes = new ComboBox();
            dateTimePickerDesde = new DateTimePicker();
            dateTimePickerHasta = new DateTimePicker();
            dataGridViewCobros = new DataGridView();
            buttonBuscar = new Button();
            buttonEditar = new Button();
            buttonCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCobros).BeginInit();
            SuspendLayout();
            // 
            // comboClientes
            // 
            comboClientes.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboClientes.FormattingEnabled = true;
            comboClientes.Location = new Point(30, 20);
            comboClientes.Name = "comboClientes";
            comboClientes.Size = new Size(300, 25);
            comboClientes.TabIndex = 0;
            // 
            // dateTimePickerDesde
            // 
            dateTimePickerDesde.Location = new Point(30, 60);
            dateTimePickerDesde.Name = "dateTimePickerDesde";
            dateTimePickerDesde.Size = new Size(200, 23);
            dateTimePickerDesde.TabIndex = 1;
            // 
            // dateTimePickerHasta
            // 
            dateTimePickerHasta.Location = new Point(250, 60);
            dateTimePickerHasta.Name = "dateTimePickerHasta";
            dateTimePickerHasta.Size = new Size(200, 23);
            dateTimePickerHasta.TabIndex = 2;
            // 
            // dataGridViewCobros
            // 
            dataGridViewCobros.BackgroundColor = SystemColors.Control;
            dataGridViewCobros.BorderStyle = BorderStyle.None;
            dataGridViewCobros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCobros.Location = new Point(30, 100);
            dataGridViewCobros.Name = "dataGridViewCobros";
            dataGridViewCobros.Size = new Size(640, 250);
            dataGridViewCobros.TabIndex = 4;
            // 
            // buttonBuscar
            // 
            buttonBuscar.BackColor = Color.LightGray;
            buttonBuscar.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonBuscar.Location = new Point(470, 60);
            buttonBuscar.Name = "buttonBuscar";
            buttonBuscar.Size = new Size(105, 23);
            buttonBuscar.TabIndex = 3;
            buttonBuscar.Text = "Buscar";
            buttonBuscar.UseVisualStyleBackColor = false;
            buttonBuscar.Click += buttonBuscar_Click;
            // 
            // buttonEditar
            // 
            buttonEditar.BackColor = Color.LightGray;
            buttonEditar.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            buttonEditar.Location = new Point(490, 370);
            buttonEditar.Name = "buttonEditar";
            buttonEditar.Size = new Size(85, 30);
            buttonEditar.TabIndex = 5;
            buttonEditar.Text = "Editar";
            buttonEditar.UseVisualStyleBackColor = false;
            buttonEditar.Click += buttonEditar_Click;
            // 
            // buttonCerrar
            // 
            buttonCerrar.BackColor = Color.LightGray;
            buttonCerrar.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            buttonCerrar.Location = new Point(585, 370);
            buttonCerrar.Name = "buttonCerrar";
            buttonCerrar.Size = new Size(85, 30);
            buttonCerrar.TabIndex = 6;
            buttonCerrar.Text = "Cerrar";
            buttonCerrar.UseVisualStyleBackColor = false;
            buttonCerrar.Click += buttonCerrar_Click;
            // 
            // FormEditarCobro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 420);
            Controls.Add(comboClientes);
            Controls.Add(dateTimePickerDesde);
            Controls.Add(dateTimePickerHasta);
            Controls.Add(buttonBuscar);
            Controls.Add(dataGridViewCobros);
            Controls.Add(buttonEditar);
            Controls.Add(buttonCerrar);
            Name = "FormEditarCobro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editar Cobros";
            Load += FormEditarCobro_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewCobros).EndInit();
            ResumeLayout(false);
        }
    }
}
