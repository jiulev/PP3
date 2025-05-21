namespace FotoRoman
{
    partial class FormVerPago
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelIdPedido;
        private System.Windows.Forms.TextBox textBoxIdPedido;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.ComboBox comboBoxClientes;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Button buttonImprimir;
        private System.Windows.Forms.Button buttonCerrar;
        private System.Windows.Forms.GroupBox groupBoxPagos;
        private System.Windows.Forms.DataGridView dataGridViewPagos;
        private System.Windows.Forms.GroupBox groupBoxCliente;
        private System.Windows.Forms.TextBox textBoxDatosCliente;

        private void InitializeComponent()
        {
            labelIdPedido = new Label();
            textBoxIdPedido = new TextBox();
            labelCliente = new Label();
            comboBoxClientes = new ComboBox();
            buttonBuscar = new Button();
            buttonLimpiar = new Button();
            buttonImprimir = new Button();
            buttonCerrar = new Button();
            groupBoxCliente = new GroupBox();
            textBox1 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBoxLocalidad = new TextBox();
            textBoxCorreo = new TextBox();
            textBoxDatosCliente = new TextBox();
            groupBoxPagos = new GroupBox();
            dataGridViewPagos = new DataGridView();
            label5 = new Label();
            groupBoxCliente.SuspendLayout();
            groupBoxPagos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPagos).BeginInit();
            SuspendLayout();
            // 
            // labelIdPedido
            // 
            labelIdPedido.Font = new Font("Yu Gothic", 9F, FontStyle.Bold);
            labelIdPedido.Location = new Point(12, 20);
            labelIdPedido.Name = "labelIdPedido";
            labelIdPedido.Size = new Size(162, 23);
            labelIdPedido.TabIndex = 0;
            labelIdPedido.Text = "Buscar por ID de Pedido:";
            // 
            // textBoxIdPedido
            // 
            textBoxIdPedido.Location = new Point(180, 20);
            textBoxIdPedido.Name = "textBoxIdPedido";
            textBoxIdPedido.Size = new Size(200, 23);
            textBoxIdPedido.TabIndex = 1;
            // 
            // labelCliente
            // 
            labelCliente.Font = new Font("Yu Gothic", 9F, FontStyle.Bold);
            labelCliente.Location = new Point(20, 60);
            labelCliente.Name = "labelCliente";
            labelCliente.Size = new Size(150, 23);
            labelCliente.TabIndex = 2;
            labelCliente.Text = "Buscar por Cliente:";
            // 
            // comboBoxClientes
            // 
            comboBoxClientes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxClientes.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxClientes.DropDownHeight = 300;
            comboBoxClientes.IntegralHeight = false;
            comboBoxClientes.Location = new Point(180, 60);
            comboBoxClientes.Name = "comboBoxClientes";
            comboBoxClientes.Size = new Size(200, 23);
            comboBoxClientes.TabIndex = 3;
            comboBoxClientes.SelectedIndexChanged += comboBoxClientes_SelectedIndexChanged;
            // 
            // buttonBuscar
            // 
            buttonBuscar.BackColor = Color.LightGray;
            buttonBuscar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonBuscar.Location = new Point(400, 12);
            buttonBuscar.Name = "buttonBuscar";
            buttonBuscar.Size = new Size(100, 35);
            buttonBuscar.TabIndex = 4;
            buttonBuscar.Text = "Buscar";
            buttonBuscar.UseVisualStyleBackColor = false;
            buttonBuscar.Click += buttonBuscar_Click;
            // 
            // buttonLimpiar
            // 
            buttonLimpiar.BackColor = Color.LightGray;
            buttonLimpiar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonLimpiar.Location = new Point(400, 60);
            buttonLimpiar.Name = "buttonLimpiar";
            buttonLimpiar.Size = new Size(100, 35);
            buttonLimpiar.TabIndex = 5;
            buttonLimpiar.Text = "Limpiar";
            buttonLimpiar.UseVisualStyleBackColor = false;
            buttonLimpiar.Click += buttonLimpiar_Click;
            // 
            // buttonImprimir
            // 
            buttonImprimir.BackColor = Color.LightGray;
            buttonImprimir.Font = new Font("Yu Gothic", 11.25F, FontStyle.Bold);
            buttonImprimir.Location = new Point(120, 639);
            buttonImprimir.Name = "buttonImprimir";
            buttonImprimir.Size = new Size(110, 40);
            buttonImprimir.TabIndex = 6;
            buttonImprimir.Text = "Imprimir";
            buttonImprimir.UseVisualStyleBackColor = false;
            buttonImprimir.Click += buttonImprimir_Click;
            // 
            // buttonCerrar
            // 
            buttonCerrar.BackColor = Color.LightGray;
            buttonCerrar.Font = new Font("Yu Gothic", 11.25F, FontStyle.Bold);
            buttonCerrar.Location = new Point(275, 639);
            buttonCerrar.Name = "buttonCerrar";
            buttonCerrar.Size = new Size(110, 40);
            buttonCerrar.TabIndex = 7;
            buttonCerrar.Text = "Cerrar";
            buttonCerrar.UseVisualStyleBackColor = false;
            buttonCerrar.Click += buttonCerrar_Click;
            // 
            // groupBoxCliente
            // 
            groupBoxCliente.Controls.Add(textBox1);
            groupBoxCliente.Controls.Add(label4);
            groupBoxCliente.Controls.Add(label3);
            groupBoxCliente.Controls.Add(label2);
            groupBoxCliente.Controls.Add(label1);
            groupBoxCliente.Controls.Add(textBoxLocalidad);
            groupBoxCliente.Controls.Add(textBoxCorreo);
            groupBoxCliente.Controls.Add(textBoxDatosCliente);
            groupBoxCliente.Font = new Font("Yu Gothic", 9F, FontStyle.Bold);
            groupBoxCliente.Location = new Point(20, 100);
            groupBoxCliente.Name = "groupBoxCliente";
            groupBoxCliente.Size = new Size(594, 179);
            groupBoxCliente.TabIndex = 8;
            groupBoxCliente.TabStop = false;
            groupBoxCliente.Text = "Datos del Cliente";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(217, 140);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(238, 24);
            textBox1.TabIndex = 7;
            // 
            // label4
            // 
            label4.Font = new Font("Yu Gothic", 9F, FontStyle.Bold);
            label4.Location = new Point(86, 137);
            label4.Name = "label4";
            label4.Size = new Size(68, 23);
            label4.TabIndex = 6;
            label4.Text = "Provincia";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.Font = new Font("Yu Gothic", 9F, FontStyle.Bold);
            label3.Location = new Point(86, 99);
            label3.Name = "label3";
            label3.Size = new Size(68, 23);
            label3.TabIndex = 5;
            label3.Text = "Localidad ";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.Font = new Font("Yu Gothic", 9F, FontStyle.Bold);
            label2.Location = new Point(86, 61);
            label2.Name = "label2";
            label2.Size = new Size(51, 23);
            label2.TabIndex = 4;
            label2.Text = "Correo";
            // 
            // label1
            // 
            label1.Font = new Font("Yu Gothic", 9F, FontStyle.Bold);
            label1.Location = new Point(86, 23);
            label1.Name = "label1";
            label1.Size = new Size(125, 23);
            label1.TabIndex = 3;
            label1.Text = "Apellido y Nombre";
            // 
            // textBoxLocalidad
            // 
            textBoxLocalidad.Location = new Point(217, 108);
            textBoxLocalidad.Multiline = true;
            textBoxLocalidad.Name = "textBoxLocalidad";
            textBoxLocalidad.ReadOnly = true;
            textBoxLocalidad.ScrollBars = ScrollBars.Vertical;
            textBoxLocalidad.Size = new Size(238, 24);
            textBoxLocalidad.TabIndex = 2;
            // 
            // textBoxCorreo
            // 
            textBoxCorreo.Location = new Point(217, 65);
            textBoxCorreo.Multiline = true;
            textBoxCorreo.Name = "textBoxCorreo";
            textBoxCorreo.ReadOnly = true;
            textBoxCorreo.ScrollBars = ScrollBars.Vertical;
            textBoxCorreo.Size = new Size(238, 24);
            textBoxCorreo.TabIndex = 1;
            // 
            // textBoxDatosCliente
            // 
            textBoxDatosCliente.Location = new Point(217, 22);
            textBoxDatosCliente.Multiline = true;
            textBoxDatosCliente.Name = "textBoxDatosCliente";
            textBoxDatosCliente.ReadOnly = true;
            textBoxDatosCliente.ScrollBars = ScrollBars.Vertical;
            textBoxDatosCliente.Size = new Size(238, 24);
            textBoxDatosCliente.TabIndex = 0;
            // 
            // groupBoxPagos
            // 
            groupBoxPagos.Controls.Add(dataGridViewPagos);
            groupBoxPagos.Font = new Font("Yu Gothic", 9F, FontStyle.Bold);
            groupBoxPagos.Location = new Point(20, 285);
            groupBoxPagos.Name = "groupBoxPagos";
            groupBoxPagos.Size = new Size(594, 318);
            groupBoxPagos.TabIndex = 10;
            groupBoxPagos.TabStop = false;
            groupBoxPagos.Text = "Pagos Realizados";
            // 
            // dataGridViewPagos
            // 
            dataGridViewPagos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPagos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewPagos.BackgroundColor = SystemColors.Control;
            dataGridViewPagos.Location = new Point(6, 22);
            dataGridViewPagos.Name = "dataGridViewPagos";
            dataGridViewPagos.Size = new Size(564, 280);
            dataGridViewPagos.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(521, 53);
            label5.Name = "label5";
            label5.Size = new Size(61, 15);
            label5.TabIndex = 11;
            label5.Text = "no va mas";
            // 
            // FormVerPago
            // 
            ClientSize = new Size(647, 710);
            Controls.Add(label5);
            Controls.Add(labelIdPedido);
            Controls.Add(textBoxIdPedido);
            Controls.Add(labelCliente);
            Controls.Add(comboBoxClientes);
            Controls.Add(buttonBuscar);
            Controls.Add(buttonLimpiar);
            Controls.Add(buttonImprimir);
            Controls.Add(buttonCerrar);
            Controls.Add(groupBoxCliente);
            Controls.Add(groupBoxPagos);
            Name = "FormVerPago";
            Text = "Consultar Pedido";
            groupBoxCliente.ResumeLayout(false);
            groupBoxCliente.PerformLayout();
            groupBoxPagos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewPagos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label2;
        private Label label1;
        private TextBox textBoxLocalidad;
        private TextBox textBoxCorreo;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private Label label5;
    }
}
