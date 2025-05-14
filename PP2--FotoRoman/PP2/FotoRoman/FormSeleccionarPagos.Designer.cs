namespace FotoRoman
{
    partial class FormSeleccionarPagos
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewPedidos;
        private System.Windows.Forms.Button buttonSeleccionar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGridViewPedidos = new DataGridView();
            buttonSeleccionar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPedidos).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewPedidos
            // 
            dataGridViewPedidos.AllowUserToAddRows = false;
            dataGridViewPedidos.AllowUserToDeleteRows = false;
            dataGridViewPedidos.BackgroundColor = SystemColors.Control;
            dataGridViewPedidos.Location = new Point(12, 12);
            dataGridViewPedidos.Name = "dataGridViewPedidos";
            dataGridViewPedidos.Size = new Size(360, 200);
            dataGridViewPedidos.TabIndex = 0;
            // 
            // buttonSeleccionar
            // 
            buttonSeleccionar.BackColor = Color.LightGray;
            buttonSeleccionar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSeleccionar.Location = new Point(140, 225);
            buttonSeleccionar.Name = "buttonSeleccionar";
            buttonSeleccionar.Size = new Size(100, 30);
            buttonSeleccionar.TabIndex = 1;
            buttonSeleccionar.Text = "Seleccionar";
            buttonSeleccionar.UseVisualStyleBackColor = false;
            buttonSeleccionar.Click += buttonSeleccionar_Click;
            // 
            // FormSeleccionarPagos
            // 
            ClientSize = new Size(384, 271);
            Controls.Add(buttonSeleccionar);
            Controls.Add(dataGridViewPedidos);
            Name = "FormSeleccionarPagos";
            Text = "Seleccionar un Pedido";
            Load += FormSeleccionarPagos_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewPedidos).EndInit();
            ResumeLayout(false);
        }
    }
}

