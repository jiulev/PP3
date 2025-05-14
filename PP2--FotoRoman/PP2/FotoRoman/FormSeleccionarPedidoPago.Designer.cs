namespace FotoRoman
{
    partial class FormSeleccionarPedidoPago
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewPedidos;
        private System.Windows.Forms.Button buttonSeleccionar;
        private System.Windows.Forms.Button buttonCancelar;

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
            dataGridViewPedidos = new DataGridView();
            buttonSeleccionar = new Button();
            buttonCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPedidos).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewPedidos
            // 
            dataGridViewPedidos.BackgroundColor = SystemColors.Control;
            dataGridViewPedidos.BorderStyle = BorderStyle.None;
            dataGridViewPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPedidos.Location = new Point(20, 20);
            dataGridViewPedidos.Name = "dataGridViewPedidos";
            dataGridViewPedidos.Size = new Size(300, 200);
            dataGridViewPedidos.TabIndex = 0;
            // 
            // buttonSeleccionar
            // 
            buttonSeleccionar.BackColor = Color.LightGray;
            buttonSeleccionar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonSeleccionar.Location = new Point(20, 230);
            buttonSeleccionar.Name = "buttonSeleccionar";
            buttonSeleccionar.Size = new Size(120, 30);
            buttonSeleccionar.TabIndex = 1;
            buttonSeleccionar.Text = "Seleccionar";
            buttonSeleccionar.UseVisualStyleBackColor = true;
            buttonSeleccionar.Click += buttonSeleccionar_Click;
            // 
            // buttonCancelar
            // 
            buttonCancelar.BackColor = Color.LightGray;
            buttonCancelar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonCancelar.Location = new Point(200, 230);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(120, 30);
            buttonCancelar.TabIndex = 2;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // FormSeleccionarPedidoPago
            // 
            ClientSize = new Size(350, 280);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonSeleccionar);
            Controls.Add(dataGridViewPedidos);
            Name = "FormSeleccionarPedidoPago";
            Text = "Seleccionar Pedido";
            ((System.ComponentModel.ISupportInitialize)dataGridViewPedidos).EndInit();
            ResumeLayout(false);
        }
    }
}
