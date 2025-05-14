namespace FotoRoman
{
    partial class FrmUsuario
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridViewUsuarios;
        private Button btnEditar;
        private Button btnEliminar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private TextBox txtBuscar;

        private void InitializeComponent()
        {
            dataGridViewUsuarios = new DataGridView();
            btnEditar = new Button();
            btnEliminar = new Button();
            txtBuscar = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsuarios).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewUsuarios
            // 
            dataGridViewUsuarios.AllowUserToAddRows = false;
            dataGridViewUsuarios.AllowUserToResizeRows = false;
            dataGridViewUsuarios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUsuarios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewUsuarios.BackgroundColor = Color.Gainsboro;
            dataGridViewUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsuarios.Location = new Point(10, 10);
            dataGridViewUsuarios.MultiSelect = false;
            dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            dataGridViewUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsuarios.Size = new Size(780, 320);
            dataGridViewUsuarios.TabIndex = 0;
            dataGridViewUsuarios.CellContentClick += dataGridViewUsuarios_CellContentClick;
            // 
            // btnEditar
            // 
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.LightGray;
            btnEditar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEditar.Location = new Point(250, 380);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(120, 40);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "Editar";
            btnEditar.TextAlign = ContentAlignment.MiddleCenter;
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.FlatStyle = FlatStyle.Standard;
            btnEditar.Click += btnEditar_Click;

            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.LightGray;
            btnEliminar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEliminar.Location = new Point(420, 380);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(120, 40);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar";
            btnEliminar.TextAlign = ContentAlignment.MiddleCenter;
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.FlatStyle = FlatStyle.Standard;
            btnEliminar.Click += btnBloquear_Click;

            // 
           
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(10, 350);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar por nombre";
            txtBuscar.Size = new Size(200, 23);
            txtBuscar.TabIndex = 3;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // FrmUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtBuscar);
            Controls.Add(btnEditar);
            Controls.Add(btnEliminar);
            Controls.Add(dataGridViewUsuarios);
            Name = "FrmUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Usuarios";
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
