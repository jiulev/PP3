using CapaEntidad;

namespace FotoRoman
{
    partial class FormVerPedido
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
        private System.Windows.Forms.GroupBox groupBoxDetallePedido;
        private System.Windows.Forms.DataGridView dataGridViewDetallePedido;
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
            label2 = new Label();
            textBoxProvincia = new TextBox();
            textBoxLocalidad = new TextBox();
            textBoxCorreo = new TextBox();
            textBoxDatosCliente = new TextBox();
            groupBoxDetallePedido = new GroupBox();
            dataGridViewDetallePedido = new DataGridView();
            groupBoxPagos = new GroupBox();
            dataGridViewPagos = new DataGridView();
            textBoxEstado = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            buttonEditar = new Button();
            groupBoxCliente.SuspendLayout();
            groupBoxDetallePedido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDetallePedido).BeginInit();
            groupBoxPagos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPagos).BeginInit();
            SuspendLayout();
            // 
            // labelIdPedido
            // 
            labelIdPedido.Font = new Font("Yu Gothic", 9F, FontStyle.Bold);
            labelIdPedido.Location = new Point(20, 20);
            labelIdPedido.Name = "labelIdPedido";
            labelIdPedido.Size = new Size(150, 23);
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
            comboBoxClientes.Font = new Font("Yu Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxClientes.Location = new Point(180, 60);
            comboBoxClientes.Name = "comboBoxClientes";
            comboBoxClientes.Size = new Size(200, 25);
            comboBoxClientes.TabIndex = 3;
            // 
            // buttonBuscar
            // 
            buttonBuscar.BackColor = Color.LightGray;
            buttonBuscar.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            buttonBuscar.Location = new Point(400, 9);
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
            buttonLimpiar.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            buttonLimpiar.Location = new Point(400, 51);
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
            buttonImprimir.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            buttonImprimir.Location = new Point(634, 624);
            buttonImprimir.Name = "buttonImprimir";
            buttonImprimir.Size = new Size(100, 35);
            buttonImprimir.TabIndex = 7;
            buttonImprimir.Text = "Imprimir";
            buttonImprimir.UseVisualStyleBackColor = false;
            buttonImprimir.Click += buttonImprimir_Click;
            // 
            // buttonCerrar
            // 
            buttonCerrar.BackColor = Color.LightGray;
            buttonCerrar.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            buttonCerrar.Location = new Point(739, 624);
            buttonCerrar.Name = "buttonCerrar";
            buttonCerrar.Size = new Size(100, 35);
            buttonCerrar.TabIndex = 8;
            buttonCerrar.Text = "Cerrar";
            buttonCerrar.UseVisualStyleBackColor = false;
            buttonCerrar.Click += buttonCerrar_Click;
            // 
            // groupBoxCliente
            // 
            groupBoxCliente.Controls.Add(label2);
            groupBoxCliente.Controls.Add(textBoxProvincia);
            groupBoxCliente.Controls.Add(textBoxLocalidad);
            groupBoxCliente.Controls.Add(textBoxCorreo);
            groupBoxCliente.Controls.Add(textBoxDatosCliente);
            groupBoxCliente.Font = new Font("Yu Gothic", 9F, FontStyle.Bold);
            groupBoxCliente.Location = new Point(20, 100);
            groupBoxCliente.Name = "groupBoxCliente";
            groupBoxCliente.Size = new Size(830, 150);
            groupBoxCliente.TabIndex = 8;
            groupBoxCliente.TabStop = false;
            groupBoxCliente.Text = "Datos del Cliente";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(220, 200, 210);
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Yu Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DarkRed;
            label2.Location = new Point(506, 29);
            label2.MaximumSize = new Size(300, 0);
            label2.Name = "label2";
            label2.Padding = new Padding(5);
            label2.Size = new Size(183, 28);
            label2.TabIndex = 4;
            label2.Text = "⚠️ Observaciones del pedido:";
            // 
            // textBoxProvincia
            // 
            textBoxProvincia.Location = new Point(116, 116);
            textBoxProvincia.Multiline = true;
            textBoxProvincia.Name = "textBoxProvincia";
            textBoxProvincia.ReadOnly = true;
            textBoxProvincia.ScrollBars = ScrollBars.Vertical;
            textBoxProvincia.Size = new Size(261, 25);
            textBoxProvincia.TabIndex = 3;
            // 
            // textBoxLocalidad
            // 
            textBoxLocalidad.Location = new Point(116, 81);
            textBoxLocalidad.Multiline = true;
            textBoxLocalidad.Name = "textBoxLocalidad";
            textBoxLocalidad.ReadOnly = true;
            textBoxLocalidad.ScrollBars = ScrollBars.Vertical;
            textBoxLocalidad.Size = new Size(261, 25);
            textBoxLocalidad.TabIndex = 2;
            // 
            // textBoxCorreo
            // 
            textBoxCorreo.Location = new Point(116, 50);
            textBoxCorreo.Multiline = true;
            textBoxCorreo.Name = "textBoxCorreo";
            textBoxCorreo.ReadOnly = true;
            textBoxCorreo.ScrollBars = ScrollBars.Vertical;
            textBoxCorreo.Size = new Size(261, 25);
            textBoxCorreo.TabIndex = 1;
            // 
            // textBoxDatosCliente
            // 
            textBoxDatosCliente.Location = new Point(116, 19);
            textBoxDatosCliente.Multiline = true;
            textBoxDatosCliente.Name = "textBoxDatosCliente";
            textBoxDatosCliente.ReadOnly = true;
            textBoxDatosCliente.ScrollBars = ScrollBars.Vertical;
            textBoxDatosCliente.Size = new Size(261, 25);
            textBoxDatosCliente.TabIndex = 0;
            // 
            // groupBoxDetallePedido
            // 
            groupBoxDetallePedido.Controls.Add(dataGridViewDetallePedido);
            groupBoxDetallePedido.Font = new Font("Yu Gothic", 9F, FontStyle.Bold);
            groupBoxDetallePedido.ForeColor = Color.Brown;
            groupBoxDetallePedido.Location = new Point(20, 270);
            groupBoxDetallePedido.Name = "groupBoxDetallePedido";
            groupBoxDetallePedido.Size = new Size(830, 150);
            groupBoxDetallePedido.TabIndex = 9;
            groupBoxDetallePedido.TabStop = false;
            groupBoxDetallePedido.Text = "Detalle del Pedido";
            // 
            // dataGridViewDetallePedido
            // 
            dataGridViewDetallePedido.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewDetallePedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewDetallePedido.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewDetallePedido.BackgroundColor = SystemColors.Control;
            dataGridViewDetallePedido.Location = new Point(10, 20);
            dataGridViewDetallePedido.Name = "dataGridViewDetallePedido";
            dataGridViewDetallePedido.Size = new Size(800, 120);
            dataGridViewDetallePedido.TabIndex = 0;
            // 
            // groupBoxPagos
            // 
            groupBoxPagos.Controls.Add(dataGridViewPagos);
            groupBoxPagos.Font = new Font("Yu Gothic", 9F, FontStyle.Bold);
            groupBoxPagos.ForeColor = Color.Brown;
            groupBoxPagos.Location = new Point(20, 440);
            groupBoxPagos.Name = "groupBoxPagos";
            groupBoxPagos.Size = new Size(830, 165);
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
            dataGridViewPagos.Location = new Point(10, 20);
            dataGridViewPagos.Name = "dataGridViewPagos";
            dataGridViewPagos.Size = new Size(800, 127);
            dataGridViewPagos.TabIndex = 0;
            // 
            // textBoxEstado
            // 
            textBoxEstado.Location = new Point(677, 71);
            textBoxEstado.Name = "textBoxEstado";
            textBoxEstado.ReadOnly = true;
            textBoxEstado.Size = new Size(100, 23);
            textBoxEstado.TabIndex = 11;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(891, 100);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(328, 131);
            flowLayoutPanel1.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(556, 77);
            label1.Name = "label1";
            label1.Size = new Size(125, 17);
            label1.TabIndex = 13;
            label1.Text = "Estado del Pedido";
            // 
            // buttonEditar
            // 
            buttonEditar.BackColor = Color.DarkSalmon;
            buttonEditar.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            buttonEditar.Location = new Point(526, 624);
            buttonEditar.Name = "buttonEditar";
            buttonEditar.Size = new Size(83, 34);
            buttonEditar.TabIndex = 4;
            buttonEditar.Text = "Editar";
            buttonEditar.UseVisualStyleBackColor = false;
            buttonEditar.Click += buttonEditar_Click;
            // 
            // FormVerPedido
            // 
            ClientSize = new Size(900, 670);
            Controls.Add(buttonEditar);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(textBoxEstado);
            Controls.Add(labelIdPedido);
            Controls.Add(textBoxIdPedido);
            Controls.Add(labelCliente);
            Controls.Add(comboBoxClientes);
            Controls.Add(buttonBuscar);
            Controls.Add(buttonLimpiar);
            Controls.Add(buttonImprimir);
            Controls.Add(buttonCerrar);
            Controls.Add(groupBoxCliente);
            Controls.Add(groupBoxDetallePedido);
            Controls.Add(groupBoxPagos);
            Name = "FormVerPedido";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consultar Pedido";
            Load += FormVerPedido_Load;
            groupBoxCliente.ResumeLayout(false);
            groupBoxCliente.PerformLayout();
            groupBoxDetallePedido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewDetallePedido).EndInit();
            groupBoxPagos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewPagos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox textBoxLocalidad;
        private TextBox textBoxCorreo;
        private TextBox textBoxProvincia;
        private TextBox textBoxEstado;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;

        private Button buttonEditar;
        private Label label2;
    }
}
