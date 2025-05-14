using System.Drawing;


namespace FotoRoman
{
    partial class FrmVerCliente
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
            dataGridViewClientes = new DataGridView();
            txtBuscar = new TextBox();
            btnEliminar = new Button();
            button1 = new Button();
            labelCantidadClientes = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewClientes).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewClientes
            // 
            dataGridViewClientes.AllowUserToAddRows = false;
            dataGridViewClientes.AllowUserToDeleteRows = false;
            dataGridViewClientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewClientes.BackgroundColor = SystemColors.Control;
            dataGridViewClientes.BorderStyle = BorderStyle.None;
            dataGridViewClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewClientes.Location = new Point(10, 10);
            dataGridViewClientes.Name = "dataGridViewClientes";
            dataGridViewClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewClientes.Size = new Size(780, 300);
            dataGridViewClientes.TabIndex = 0;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(10, 330);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar por nombre";
            txtBuscar.Size = new Size(200, 23);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.LightGray;
            btnEliminar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEliminar.Location = new Point(274, 330);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(120, 40);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.LightGray;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button1.Location = new Point(413, 330);
            button1.Name = "button1";
            button1.Size = new Size(120, 40);
            button1.TabIndex = 3;
            button1.Text = "Editar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += buttonEditar_click;
            // 
            // labelCantidadClientes
            // 
            labelCantidadClientes.AutoSize = true;
            labelCantidadClientes.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCantidadClientes.Location = new Point(605, 338);
            labelCantidadClientes.Name = "labelCantidadClientes";
            labelCantidadClientes.Size = new Size(132, 15);
            labelCantidadClientes.TabIndex = 0;
            labelCantidadClientes.Text = "0 clientes encontrados";
            // 
            // FrmVerCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 400);
            Controls.Add(labelCantidadClientes);
            Controls.Add(button1);
            Controls.Add(dataGridViewClientes);
            Controls.Add(txtBuscar);
            Controls.Add(btnEliminar);
            Name = "FrmVerCliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Clientes";
            ((System.ComponentModel.ISupportInitialize)dataGridViewClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewClientes;
        private TextBox txtBuscar;
        private Button btnEliminar;
        private Button button1;
        private Label labelCantidadClientes;

    }
}
