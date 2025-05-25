namespace FotoRoman
{
    partial class FormCrearPedido
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCrearPedido));
            label1 = new Label();
            numero = new Label();
            num = new Label();
            cliente = new Label();
            label3 = new Label();
            categoria = new Label();
            producto = new Label();
            comboCliente = new ComboBox();
            comboCategoria = new ComboBox();
            comboProducto = new ComboBox();
            label2 = new Label();
            textDni = new TextBox();
            textLocalidad = new TextBox();
            dni4 = new Label();
            localidad5 = new Label();
            textCantidad1 = new TextBox();
            textPrecio1 = new TextBox();
            precio4 = new Label();
            buttonAgregar = new Button();
            dataGridView1 = new DataGridView();
            productos1 = new DataGridViewTextBoxColumn();
            Precio1 = new DataGridViewTextBoxColumn();
            Subtotal1 = new DataGridViewTextBoxColumn();
            total = new Label();
            eliminar1 = new Button();
            crear1 = new Button();
            toolStripContainer1 = new ToolStripContainer();
            pictureBox1 = new PictureBox();
            label7 = new Label();
            toolStripContainer2 = new ToolStripContainer();
            label5 = new Label();
            toolStripContainer3 = new ToolStripContainer();
            label6 = new Label();
            label4 = new Label();
            labelObservaciones = new Label();
            textBoxObservaciones = new TextBox();
            labelCaracteresRestantes = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            toolStripContainer1.ContentPanel.SuspendLayout();
            toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            toolStripContainer2.ContentPanel.SuspendLayout();
            toolStripContainer2.SuspendLayout();
            toolStripContainer3.ContentPanel.SuspendLayout();
            toolStripContainer3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic", 11.25F, FontStyle.Bold);
            label1.Location = new Point(12, 187);
            label1.Name = "label1";
            label1.Size = new Size(122, 19);
            label1.TabIndex = 0;
            label1.Text = "Numero Pedido";
            // 
            // numero
            // 
            numero.AutoSize = true;
            numero.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numero.Location = new Point(638, 35);
            numero.Name = "numero";
            numero.Size = new Size(0, 21);
            numero.TabIndex = 1;
            // 
            // num
            // 
            num.AutoSize = true;
            num.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            num.Location = new Point(137, 187);
            num.Name = "num";
            num.Size = new Size(22, 21);
            num.TabIndex = 2;
            num.Text = "--";
            // 
            // cliente
            // 
            cliente.AutoSize = true;
            cliente.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            cliente.Location = new Point(8, 66);
            cliente.Name = "cliente";
            cliente.Size = new Size(54, 17);
            cliente.TabIndex = 3;
            cliente.Text = "Cliente";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(150, 111);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 4;
            // 
            // categoria
            // 
            categoria.AutoSize = true;
            categoria.Font = new Font("Yu Gothic", 11.25F, FontStyle.Bold);
            categoria.Location = new Point(57, 69);
            categoria.Name = "categoria";
            categoria.Size = new Size(81, 19);
            categoria.TabIndex = 5;
            categoria.Text = "Categoria";
            // 
            // producto
            // 
            producto.AutoSize = true;
            producto.Font = new Font("Yu Gothic", 11.25F, FontStyle.Bold);
            producto.Location = new Point(64, 108);
            producto.Name = "producto";
            producto.Size = new Size(75, 19);
            producto.TabIndex = 6;
            producto.Text = "Producto";
            // 
            // comboCliente
            // 
            comboCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboCliente.Font = new Font("Yu Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboCliente.ForeColor = SystemColors.ActiveCaptionText;
            comboCliente.FormattingEnabled = true;
            comboCliente.Location = new Point(80, 57);
            comboCliente.Name = "comboCliente";
            comboCliente.Size = new Size(197, 29);
            comboCliente.TabIndex = 7;
            comboCliente.SelectedIndexChanged += comboCliente_SelectedIndexChanged;
            // 
            // comboCategoria
            // 
            comboCategoria.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboCategoria.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboCategoria.Font = new Font("Yu Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboCategoria.ForeColor = SystemColors.ActiveCaptionText;
            comboCategoria.FormattingEnabled = true;
            comboCategoria.Location = new Point(145, 59);
            comboCategoria.Name = "comboCategoria";
            comboCategoria.Size = new Size(271, 29);
            comboCategoria.TabIndex = 8;
            // 
            // comboProducto
            // 
            comboProducto.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboProducto.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboProducto.Font = new Font("Yu Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboProducto.ForeColor = SystemColors.ActiveCaptionText;
            comboProducto.FormattingEnabled = true;
            comboProducto.Location = new Point(145, 98);
            comboProducto.Name = "comboProducto";
            comboProducto.Size = new Size(271, 29);
            comboProducto.TabIndex = 9;
            comboProducto.SelectedIndexChanged += comboProducto_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic", 11.25F, FontStyle.Bold);
            label2.Location = new Point(8, 153);
            label2.Name = "label2";
            label2.Size = new Size(134, 19);
            label2.TabIndex = 10;
            label2.Text = "Ingrese Cantidad";
            label2.Click += label2_Click;
            // 
            // textDni
            // 
            textDni.Font = new Font("Yu Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textDni.Location = new Point(394, 9);
            textDni.Name = "textDni";
            textDni.Size = new Size(202, 33);
            textDni.TabIndex = 12;
            // 
            // textLocalidad
            // 
            textLocalidad.Font = new Font("Yu Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textLocalidad.Location = new Point(394, 60);
            textLocalidad.Name = "textLocalidad";
            textLocalidad.Size = new Size(202, 33);
            textLocalidad.TabIndex = 13;
            // 
            // dni4
            // 
            dni4.AutoSize = true;
            dni4.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            dni4.Location = new Point(335, 14);
            dni4.Name = "dni4";
            dni4.Size = new Size(32, 17);
            dni4.TabIndex = 14;
            dni4.Text = "DNI";
            // 
            // localidad5
            // 
            localidad5.AutoSize = true;
            localidad5.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            localidad5.Location = new Point(296, 65);
            localidad5.Name = "localidad5";
            localidad5.Size = new Size(71, 17);
            localidad5.TabIndex = 15;
            localidad5.Text = "Localidad";
            // 
            // textCantidad1
            // 
            textCantidad1.BorderStyle = BorderStyle.FixedSingle;
            textCantidad1.Font = new Font("Yu Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textCantidad1.ForeColor = SystemColors.ActiveCaptionText;
            textCantidad1.Location = new Point(145, 145);
            textCantidad1.Name = "textCantidad1";
            textCantidad1.Size = new Size(271, 33);
            textCantidad1.TabIndex = 16;
            // 
            // textPrecio1
            // 
            textPrecio1.BorderStyle = BorderStyle.FixedSingle;
            textPrecio1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textPrecio1.Location = new Point(661, 71);
            textPrecio1.Name = "textPrecio1";
            textPrecio1.Size = new Size(135, 33);
            textPrecio1.TabIndex = 17;
            // 
            // precio4
            // 
            precio4.AutoSize = true;
            precio4.Font = new Font("Yu Gothic", 11.25F, FontStyle.Bold);
            precio4.Location = new Point(601, 81);
            precio4.Name = "precio4";
            precio4.Size = new Size(55, 19);
            precio4.TabIndex = 18;
            precio4.Text = "Precio";
            precio4.Click += precio4_Click;
            // 
            // buttonAgregar
            // 
            buttonAgregar.BackColor = Color.LightGray;
            buttonAgregar.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonAgregar.Location = new Point(664, 120);
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.Size = new Size(135, 29);
            buttonAgregar.TabIndex = 19;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.UseVisualStyleBackColor = false;
            buttonAgregar.Click += buttonAgregar_Click_1;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { productos1, Precio1, Subtotal1 });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Yu Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.GrayText;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.GridColor = SystemColors.ButtonHighlight;
            dataGridView1.Location = new Point(3, 30);
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Size = new Size(639, 89);
            dataGridView1.TabIndex = 20;
            // 
            // productos1
            // 
            productos1.HeaderText = "Producto";
            productos1.Name = "productos1";
            // 
            // Precio1
            // 
            Precio1.HeaderText = "Precio";
            Precio1.Name = "Precio1";
            // 
            // Subtotal1
            // 
            Subtotal1.HeaderText = "Subtotal";
            Subtotal1.Name = "Subtotal1";
            // 
            // total
            // 
            total.AutoSize = true;
            total.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            total.Location = new Point(598, 598);
            total.Name = "total";
            total.Size = new Size(49, 21);
            total.TabIndex = 21;
            total.Text = "$0.00";
            // 
            // eliminar1
            // 
            eliminar1.BackColor = Color.LightGray;
            eliminar1.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            eliminar1.Location = new Point(664, 53);
            eliminar1.Name = "eliminar1";
            eliminar1.Size = new Size(135, 29);
            eliminar1.TabIndex = 22;
            eliminar1.Text = "Eliminar Ítem";
            eliminar1.UseVisualStyleBackColor = false;
            eliminar1.Click += eliminar1_Click;
            // 
            // crear1
            // 
            crear1.BackColor = Color.LightGray;
            crear1.FlatAppearance.BorderColor = Color.Black;
            crear1.FlatAppearance.MouseDownBackColor = Color.IndianRed;
            crear1.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            crear1.ForeColor = Color.Black;
            crear1.Location = new Point(666, 643);
            crear1.Name = "crear1";
            crear1.Size = new Size(135, 41);
            crear1.TabIndex = 23;
            crear1.Text = "Crear Pedido";
            crear1.UseVisualStyleBackColor = false;
            crear1.Click += crear1_Click;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            toolStripContainer1.ContentPanel.BorderStyle = BorderStyle.FixedSingle;
            toolStripContainer1.ContentPanel.Controls.Add(pictureBox1);
            toolStripContainer1.ContentPanel.Controls.Add(label7);
            toolStripContainer1.ContentPanel.Controls.Add(comboCliente);
            toolStripContainer1.ContentPanel.Controls.Add(cliente);
            toolStripContainer1.ContentPanel.Size = new Size(804, 125);
            toolStripContainer1.Location = new Point(4, 1);
            toolStripContainer1.Name = "toolStripContainer1";
            toolStripContainer1.Size = new Size(804, 125);
            toolStripContainer1.TabIndex = 26;
            toolStripContainer1.Text = "toolStripContainer1";
            toolStripContainer1.TopToolStripPanelVisible = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(639, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(131, 113);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 30;
            pictureBox1.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Brown;
            label7.Location = new Point(8, 8);
            label7.Name = "label7";
            label7.Size = new Size(144, 21);
            label7.TabIndex = 29;
            label7.Text = "Datos del Cliente";
            // 
            // toolStripContainer2
            // 
            // 
            // toolStripContainer2.ContentPanel
            // 
            toolStripContainer2.ContentPanel.BorderStyle = BorderStyle.FixedSingle;
            toolStripContainer2.ContentPanel.Controls.Add(buttonAgregar);
            toolStripContainer2.ContentPanel.Controls.Add(textCantidad1);
            toolStripContainer2.ContentPanel.Controls.Add(comboProducto);
            toolStripContainer2.ContentPanel.Controls.Add(producto);
            toolStripContainer2.ContentPanel.Controls.Add(precio4);
            toolStripContainer2.ContentPanel.Controls.Add(label2);
            toolStripContainer2.ContentPanel.Controls.Add(textPrecio1);
            toolStripContainer2.ContentPanel.Controls.Add(categoria);
            toolStripContainer2.ContentPanel.Controls.Add(comboCategoria);
            toolStripContainer2.ContentPanel.Size = new Size(804, 191);
            toolStripContainer2.Enabled = false;
            toolStripContainer2.Location = new Point(4, 166);
            toolStripContainer2.Name = "toolStripContainer2";
            toolStripContainer2.Size = new Size(804, 191);
            toolStripContainer2.TabIndex = 27;
            toolStripContainer2.Text = "toolStripContainer2";
            toolStripContainer2.TopToolStripPanelVisible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Brown;
            label5.Location = new Point(4, 152);
            label5.Name = "label5";
            label5.Size = new Size(189, 21);
            label5.TabIndex = 28;
            label5.Text = "Agregue sus productos";
            label5.Click += label5_Click;
            // 
            // toolStripContainer3
            // 
            // 
            // toolStripContainer3.BottomToolStripPanel
            // 
            toolStripContainer3.BottomToolStripPanel.Click += toolStripContainer3_BottomToolStripPanel_Click;
            // 
            // toolStripContainer3.ContentPanel
            // 
            toolStripContainer3.ContentPanel.BorderStyle = BorderStyle.FixedSingle;
            toolStripContainer3.ContentPanel.Controls.Add(label6);
            toolStripContainer3.ContentPanel.Controls.Add(eliminar1);
            toolStripContainer3.ContentPanel.Controls.Add(dataGridView1);
            toolStripContainer3.ContentPanel.Size = new Size(804, 186);
            toolStripContainer3.Location = new Point(4, 370);
            toolStripContainer3.Name = "toolStripContainer3";
            toolStripContainer3.Size = new Size(804, 186);
            toolStripContainer3.TabIndex = 29;
            toolStripContainer3.Text = "toolStripContainer3";
            toolStripContainer3.TopToolStripPanelVisible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Maroon;
            label6.Location = new Point(4, -1);
            label6.Name = "label6";
            label6.Size = new Size(135, 21);
            label6.TabIndex = 30;
            label6.Text = "Item Del Pedido";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(660, 591);
            label4.Name = "label4";
            label4.Size = new Size(50, 22);
            label4.TabIndex = 25;
            label4.Text = "Total";
            // 
            // labelObservaciones
            // 
            labelObservaciones.AutoSize = true;
            labelObservaciones.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            labelObservaciones.Location = new Point(12, 568);
            labelObservaciones.Name = "labelObservaciones";
            labelObservaciones.Size = new Size(107, 17);
            labelObservaciones.TabIndex = 30;
            labelObservaciones.Text = "Observaciones:";
            // 
            // textBoxObservaciones
            // 
            textBoxObservaciones.Font = new Font("Segoe UI", 10F);
            textBoxObservaciones.Location = new Point(4, 598);
            textBoxObservaciones.Multiline = true;
            textBoxObservaciones.Name = "textBoxObservaciones";
            textBoxObservaciones.ScrollBars = ScrollBars.Vertical;
            textBoxObservaciones.Size = new Size(500, 60);
            textBoxObservaciones.TabIndex = 31;
            // 
            // labelCaracteresRestantes
            // 
            labelCaracteresRestantes.AutoSize = true;
            labelCaracteresRestantes.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            labelCaracteresRestantes.Location = new Point(12, 667);
            labelCaracteresRestantes.Name = "labelCaracteresRestantes";
            labelCaracteresRestantes.Size = new Size(105, 17);
            labelCaracteresRestantes.TabIndex = 0;
            labelCaracteresRestantes.Text = "100 caracteres.";
            // 
            // FormCrearPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(830, 749);
            Controls.Add(labelCaracteresRestantes);
            Controls.Add(label5);
            Controls.Add(crear1);
            Controls.Add(total);
            Controls.Add(localidad5);
            Controls.Add(dni4);
            Controls.Add(textLocalidad);
            Controls.Add(textDni);
            Controls.Add(label3);
            Controls.Add(num);
            Controls.Add(numero);
            Controls.Add(label1);
            Controls.Add(toolStripContainer1);
            Controls.Add(toolStripContainer2);
            Controls.Add(toolStripContainer3);
            Controls.Add(labelObservaciones);
            Controls.Add(textBoxObservaciones);
            Name = "FormCrearPedido";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Crear pedido";
            Load += FormCrearPedido_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            toolStripContainer1.ContentPanel.ResumeLayout(false);
            toolStripContainer1.ContentPanel.PerformLayout();
            toolStripContainer1.ResumeLayout(false);
            toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            toolStripContainer2.ContentPanel.ResumeLayout(false);
            toolStripContainer2.ContentPanel.PerformLayout();
            toolStripContainer2.ResumeLayout(false);
            toolStripContainer2.PerformLayout();
            toolStripContainer3.ContentPanel.ResumeLayout(false);
            toolStripContainer3.ContentPanel.PerformLayout();
            toolStripContainer3.ResumeLayout(false);
            toolStripContainer3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label numero;
        private Label num;
        private Label cliente;
        private Label label3;
        private Label categoria;
        private Label producto;
        private ComboBox comboCliente;
        private ComboBox comboCategoria;
        private ComboBox comboProducto;
        private Label label2;
        private TextBox textDni;
        private TextBox textLocalidad;
        private Label dni4;
        private Label localidad5;
        private TextBox textCantidad1;
        private TextBox textPrecio1;
        private Label precio4;
        private Button buttonAgregar;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn productos1;
        private DataGridViewTextBoxColumn Precio1;
        private DataGridViewTextBoxColumn Subtotal1;
        private Label total;
        private Button eliminar1;
        private Button crear1;
        private ToolStripContainer toolStripContainer1;
        private ToolStripContainer toolStripContainer2;
        private Label label5;
        private ToolStripContainer toolStripContainer3;
        private Label label6;
        private Label label7;
        private PictureBox pictureBox1;
        private Label labelObservaciones;
        private TextBox textBoxObservaciones;
        private Label labelCaracteresRestantes;
        private Label label4;




    }
}