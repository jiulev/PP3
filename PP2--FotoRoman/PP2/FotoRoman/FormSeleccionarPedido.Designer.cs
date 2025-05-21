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
            // FormSeleccionarPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 400);
            Controls.Add(buttonSeleccionar);
            Controls.Add(dataGridViewPedidos);
            Name = "FormSeleccionarPedido";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Seleccionar un Pedido";
            ((System.ComponentModel.ISupportInitialize)dataGridViewPedidos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPedidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPedido;
        private System.Windows.Forms.Button buttonSeleccionar;
    }
}
