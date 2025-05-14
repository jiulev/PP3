



namespace FotoRoman
{
    partial class FormVerProducto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dataGridViewProductos;
        private System.Windows.Forms.TextBox txtBuscarProducto;
        private System.Windows.Forms.ComboBox comboBoxCategoria;
        private System.Windows.Forms.ComboBox comboBoxEstado;
        private System.Windows.Forms.Button btnEditarProducto;
        private System.Windows.Forms.Button btnEliminarProducto;
        private System.Windows.Forms.Label labelCategoria;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.Button btnAumentoPrecios;
        private System.Windows.Forms.Label labelCantidadProductos;


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
            dataGridViewProductos = new DataGridView();
            txtBuscarProducto = new TextBox();
            comboBoxCategoria = new ComboBox();
            comboBoxEstado = new ComboBox();
            btnEditarProducto = new Button();
            btnEliminarProducto = new Button();
            labelCategoria = new Label();
            labelEstado = new Label();
            btnAumentoPrecios = new Button();
            toolTip = new ToolTip(components);
            labelCantidadProductos = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductos).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewProductos
            // 
            dataGridViewProductos.AllowUserToAddRows = false;
            dataGridViewProductos.AllowUserToDeleteRows = false;
            dataGridViewProductos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProductos.BackgroundColor = SystemColors.Control;
            dataGridViewProductos.BorderStyle = BorderStyle.None;
            dataGridViewProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProductos.Location = new Point(10, 10);
            dataGridViewProductos.Name = "dataGridViewProductos";
            dataGridViewProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProductos.Size = new Size(780, 297);
            dataGridViewProductos.TabIndex = 0;
            // 
            // txtBuscarProducto
            // 
            txtBuscarProducto.Location = new Point(10, 330);
            txtBuscarProducto.Name = "txtBuscarProducto";
            txtBuscarProducto.PlaceholderText = "Buscar por nombre";
            txtBuscarProducto.Size = new Size(200, 23);
            txtBuscarProducto.TabIndex = 1;
            txtBuscarProducto.TextChanged += txtBuscarProducto_TextChanged;
            // 
            // comboBoxCategoria
            // 
            comboBoxCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCategoria.FormattingEnabled = true;
            comboBoxCategoria.Location = new Point(230, 330);
            comboBoxCategoria.Name = "comboBoxCategoria";
            comboBoxCategoria.Size = new Size(150, 23);
            comboBoxCategoria.TabIndex = 2;
            comboBoxCategoria.SelectedIndexChanged += comboBoxCategoria_SelectedIndexChanged;
            // 
            // comboBoxEstado
            // 
            comboBoxEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEstado.FormattingEnabled = true;
            comboBoxEstado.Items.AddRange(new object[] { "Todos", "Activos", "Inactivos" });
            comboBoxEstado.Location = new Point(400, 330);
            comboBoxEstado.Name = "comboBoxEstado";
            comboBoxEstado.Size = new Size(120, 23);
            comboBoxEstado.TabIndex = 3;
            comboBoxEstado.SelectedIndexChanged += comboBoxEstado_SelectedIndexChanged;
            // 
            // btnEditarProducto
            // 
            btnEditarProducto.BackColor = Color.LightGray;
            btnEditarProducto.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEditarProducto.Location = new Point(518, 370);
            btnEditarProducto.Name = "btnEditarProducto";
            btnEditarProducto.Size = new Size(132, 30);
            btnEditarProducto.TabIndex = 5;
            btnEditarProducto.Text = "Editar";
            toolTip.SetToolTip(btnEditarProducto, "Edita los datos del producto seleccionado.");
            btnEditarProducto.UseVisualStyleBackColor = true;
            btnEditarProducto.Click += btnEditarProducto_Click;
            // 
            // btnEliminarProducto
            // 
            btnEliminarProducto.BackColor = Color.LightGray;
            btnEliminarProducto.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEliminarProducto.Location = new Point(656, 370);
            btnEliminarProducto.Name = "btnEliminarProducto";
            btnEliminarProducto.Size = new Size(132, 30);
            btnEliminarProducto.TabIndex = 6;
            btnEliminarProducto.Text = "Eliminar";
            toolTip.SetToolTip(btnEliminarProducto, "Elimina o desactiva el producto seleccionado.");
            btnEliminarProducto.UseVisualStyleBackColor = true;
            btnEliminarProducto.Click += btnEliminarProducto_Click;
            // 
            // labelCategoria
            // 
            labelCategoria.AutoSize = true;
            labelCategoria.Location = new Point(230, 310);
            labelCategoria.Name = "labelCategoria";
            labelCategoria.Size = new Size(61, 15);
            labelCategoria.TabIndex = 2;
            labelCategoria.Text = "Categoría:";
            // 
            // labelEstado
            // 
            labelEstado.AutoSize = true;
            labelEstado.Location = new Point(400, 310);
            labelEstado.Name = "labelEstado";
            labelEstado.Size = new Size(45, 15);
            labelEstado.TabIndex = 3;
            labelEstado.Text = "Estado:";
            // 
            // btnAumentoPrecios
            // 
            btnAumentoPrecios.BackColor = Color.LightGray;
            btnAumentoPrecios.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAumentoPrecios.Location = new Point(10, 370);
            btnAumentoPrecios.Name = "btnAumentoPrecios";
            btnAumentoPrecios.Size = new Size(132, 30);
            btnAumentoPrecios.TabIndex = 4;
            btnAumentoPrecios.Text = "Aumentar Precios (%)";
            toolTip.SetToolTip(btnAumentoPrecios, "Aplica un porcentaje de aumento a todos los productos activos.");
            btnAumentoPrecios.UseVisualStyleBackColor = true;
            btnAumentoPrecios.Click += btnAumentoPrecios_Click;
            // 
            // labelCantidadProductos
            // 
            labelCantidadProductos.AutoSize = true;
            labelCantidadProductos.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelCantidadProductos.Location = new Point(599, 330);
            labelCantidadProductos.Name = "labelCantidadProductos";
            labelCantidadProductos.Size = new Size(141, 15);
            labelCantidadProductos.TabIndex = 0;
            labelCantidadProductos.Text = "0 productos encontrados";
            // 
            // FormVerProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 420);
            Controls.Add(labelCantidadProductos);
            Controls.Add(dataGridViewProductos);
            Controls.Add(txtBuscarProducto);
            Controls.Add(labelCategoria);
            Controls.Add(comboBoxCategoria);
            Controls.Add(labelEstado);
            Controls.Add(comboBoxEstado);
            Controls.Add(btnAumentoPrecios);
            Controls.Add(btnEditarProducto);
            Controls.Add(btnEliminarProducto);
            Name = "FormVerProducto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Productos";
            Load += FormVerProducto_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private ToolTip toolTip;
    }
}
