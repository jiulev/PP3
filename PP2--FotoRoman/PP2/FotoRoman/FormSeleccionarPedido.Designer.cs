namespace FotoRoman
{
    partial class FormSeleccionarPedido
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
            dataGridViewPedidos = new DataGridView();
            IDPedido = new DataGridViewTextBoxColumn();
            FechaPedido = new DataGridViewTextBoxColumn();
            buttonSeleccionar = new Button();
            comboBoxEstadoFiltro = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPedidos).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewPedidos
            // 
            dataGridViewPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPedidos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewPedidos.BackgroundColor = SystemColors.Control;
            dataGridViewPedidos.BorderStyle = BorderStyle.None;
            dataGridViewPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPedidos.Columns.AddRange(new DataGridViewColumn[] { IDPedido, FechaPedido });
            dataGridViewPedidos.Location = new Point(50, 50);
            dataGridViewPedidos.MultiSelect = false;
            dataGridViewPedidos.Name = "dataGridViewPedidos";
            dataGridViewPedidos.ReadOnly = true;
            dataGridViewPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPedidos.Size = new Size(400, 250);
            dataGridViewPedidos.TabIndex = 0;
            // 
            // IDPedido
            // 
            IDPedido.DataPropertyName = "IDPedido";
            IDPedido.HeaderText = "ID Pedido";
            IDPedido.Name = "IDPedido";
            IDPedido.ReadOnly = true;
            // 
            // FechaPedido
            // 
            FechaPedido.DataPropertyName = "FechaPedido";
            FechaPedido.HeaderText = "Fecha";
            FechaPedido.Name = "FechaPedido";
            FechaPedido.ReadOnly = true;
            // 
            // buttonSeleccionar
            // 
            buttonSeleccionar.BackColor = Color.LightGray;
            buttonSeleccionar.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSeleccionar.Location = new Point(362, 321);
            buttonSeleccionar.Name = "buttonSeleccionar";
            buttonSeleccionar.Size = new Size(98, 34);
            buttonSeleccionar.TabIndex = 1;
            buttonSeleccionar.Text = "Seleccionar";
            buttonSeleccionar.UseVisualStyleBackColor = false;
            buttonSeleccionar.Click += buttonSeleccionar_Click;
            // 
            // comboBoxEstadoFiltro
            // 
            comboBoxEstadoFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEstadoFiltro.Font = new Font("Yu Gothic", 9F);
            comboBoxEstadoFiltro.FormattingEnabled = true;
            comboBoxEstadoFiltro.Items.AddRange(new object[] { "Todos", "Pendiente", "En proceso", "Finalizado" });
            comboBoxEstadoFiltro.Location = new Point(300, 12);
            comboBoxEstadoFiltro.Name = "comboBoxEstadoFiltro";
            comboBoxEstadoFiltro.Size = new Size(150, 24);
            comboBoxEstadoFiltro.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Firebrick;
            label1.Location = new Point(178, 15);
            label1.Name = "label1";
            label1.Size = new Size(114, 16);
            label1.TabIndex = 3;
            label1.Text = "Filtrar por Estados";
            // 
            // FormSeleccionarPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 400);
            Controls.Add(label1);
            Controls.Add(comboBoxEstadoFiltro);
            Controls.Add(buttonSeleccionar);
            Controls.Add(dataGridViewPedidos);
            Name = "FormSeleccionarPedido";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Seleccionar un Pedido";
            ((System.ComponentModel.ISupportInitialize)dataGridViewPedidos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPedidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPedido;
        private System.Windows.Forms.Button buttonSeleccionar;
        private ComboBox comboBoxEstadoFiltro;
        private Label label1;
    }
}
