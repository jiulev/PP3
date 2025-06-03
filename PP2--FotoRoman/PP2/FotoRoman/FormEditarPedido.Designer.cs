namespace FotoRoman
{
    partial class FormEditarPedido
    {
        private System.ComponentModel.IContainer components = null;

        // 👇 Aca van las declaraciones de los controles
        private System.Windows.Forms.ComboBox comboBoxClientes;
        private System.Windows.Forms.ComboBox comboBoxEstado;
        private System.Windows.Forms.TextBox textBoxObservaciones;

        private System.Windows.Forms.DataGridView dataGridViewDetallePedido;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Button buttonGuardarCambios;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAgregarItem;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            comboBoxClientes = new ComboBox();
            comboBoxEstado = new ComboBox();
            dataGridViewDetallePedido = new DataGridView();
            labelTotal = new Label();
            buttonGuardarCambios = new Button();
            buttonCancelar = new Button();
            label1 = new Label();
            label2 = new Label();
            buttonAgregarItem = new Button();
            textBoxObservaciones = new TextBox();
            buttonEliminarItem = new Button();
            buttonEliminarPedido = new Button();
            toolTip = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)dataGridViewDetallePedido).BeginInit();
            SuspendLayout();
            // 
            // comboBoxClientes
            // 
            comboBoxClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxClientes.Font = new Font("Yu Gothic Medium", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboBoxClientes.FormattingEnabled = true;
            comboBoxClientes.Location = new Point(120, 25);
            comboBoxClientes.Name = "comboBoxClientes";
            comboBoxClientes.Size = new Size(250, 25);
            comboBoxClientes.TabIndex = 1;
            // 
            // comboBoxEstado
            // 
            comboBoxEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEstado.Font = new Font("Yu Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxEstado.Items.AddRange(new object[] { "Pendiente", "En proceso", "Finalizado" });
            comboBoxEstado.Location = new Point(120, 60);
            comboBoxEstado.Name = "comboBoxEstado";
            comboBoxEstado.Size = new Size(250, 25);
            comboBoxEstado.TabIndex = 0;
            // 
            // dataGridViewDetallePedido
            // 
            dataGridViewDetallePedido.BackgroundColor = SystemColors.Control;
            dataGridViewDetallePedido.BorderStyle = BorderStyle.None;
            dataGridViewDetallePedido.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewDetallePedido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDetallePedido.Location = new Point(30, 100);
            dataGridViewDetallePedido.Name = "dataGridViewDetallePedido";
            dataGridViewDetallePedido.RowTemplate.Height = 24;
            dataGridViewDetallePedido.Size = new Size(740, 230);
            dataGridViewDetallePedido.TabIndex = 4;
            // 
            // labelTotal
            // 
            labelTotal.AutoSize = true;
            labelTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelTotal.Location = new Point(585, 347);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(86, 19);
            labelTotal.TabIndex = 5;
            labelTotal.Text = "Total: $0.00";
            labelTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // buttonGuardarCambios
            // 
            buttonGuardarCambios.BackColor = Color.LightGray;
            buttonGuardarCambios.Font = new Font("Yu Gothic", 9F, FontStyle.Bold);
            buttonGuardarCambios.Location = new Point(251, 380);
            buttonGuardarCambios.Name = "buttonGuardarCambios";
            buttonGuardarCambios.Size = new Size(119, 32);
            buttonGuardarCambios.TabIndex = 7;
            buttonGuardarCambios.Text = "Guardar Cambios";
            buttonGuardarCambios.UseVisualStyleBackColor = false;
            buttonGuardarCambios.Click += buttonGuardarCambios_Click;
            // 
            // buttonCancelar
            // 
            buttonCancelar.BackColor = Color.LightGray;
            buttonCancelar.Font = new Font("Yu Gothic", 9F, FontStyle.Bold);
            buttonCancelar.Location = new Point(614, 380);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(111, 32);
            buttonCancelar.TabIndex = 8;
            buttonCancelar.Text = "Salir";
            buttonCancelar.UseVisualStyleBackColor = false;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic", 9F, FontStyle.Bold);
            label1.Location = new Point(30, 28);
            label1.Name = "label1";
            label1.Size = new Size(52, 16);
            label1.TabIndex = 2;
            label1.Text = "Cliente:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic", 9F, FontStyle.Bold);
            label2.Location = new Point(30, 63);
            label2.Name = "label2";
            label2.Size = new Size(51, 16);
            label2.TabIndex = 3;
            label2.Text = "Estado:";
            // 
            // buttonAgregarItem
            // 
            buttonAgregarItem.BackColor = Color.LightGray;
            buttonAgregarItem.Font = new Font("Yu Gothic", 9F, FontStyle.Bold);
            buttonAgregarItem.Location = new Point(30, 380);
            buttonAgregarItem.Name = "buttonAgregarItem";
            buttonAgregarItem.Size = new Size(100, 32);
            buttonAgregarItem.TabIndex = 6;
            buttonAgregarItem.Text = "Agregar Ítem";
            buttonAgregarItem.UseVisualStyleBackColor = false;
            buttonAgregarItem.Click += buttonAgregarItem_Click;
            // 
            // textBoxObservaciones
            // 
            textBoxObservaciones.Font = new Font("Yu Gothic", 9.75F);
            textBoxObservaciones.Location = new Point(391, 24);
            textBoxObservaciones.Multiline = true;
            textBoxObservaciones.Name = "textBoxObservaciones";
            textBoxObservaciones.ScrollBars = ScrollBars.Vertical;
            textBoxObservaciones.Size = new Size(325, 60);
            textBoxObservaciones.TabIndex = 9;
            // 
            // buttonEliminarItem
            // 
            buttonEliminarItem.BackColor = Color.LightGray;
            buttonEliminarItem.Font = new Font("Yu Gothic", 9F, FontStyle.Bold);
            buttonEliminarItem.Location = new Point(136, 380);
            buttonEliminarItem.Name = "buttonEliminarItem";
            buttonEliminarItem.Size = new Size(100, 32);
            buttonEliminarItem.TabIndex = 10;
            buttonEliminarItem.Text = "Eliminar  Ítem";
            buttonEliminarItem.UseVisualStyleBackColor = false;
            // 
            // buttonEliminarPedido
            // 
            buttonEliminarPedido.BackColor = Color.LightGray;
            buttonEliminarPedido.Font = new Font("Yu Gothic", 9F, FontStyle.Bold);
            buttonEliminarPedido.Location = new Point(480, 380);
            buttonEliminarPedido.Name = "buttonEliminarPedido";
            buttonEliminarPedido.Size = new Size(111, 32);
            buttonEliminarPedido.TabIndex = 11;
            buttonEliminarPedido.Text = "Eliminar Pedido";
            toolTip.SetToolTip(buttonEliminarPedido, "Este botón elimina el pedido definitivamente");
            buttonEliminarPedido.UseVisualStyleBackColor = false;
            buttonEliminarPedido.Click += buttonEliminarPedido_Click;
            // 
            // FormEditarPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(745, 440);
            Controls.Add(buttonEliminarPedido);
            Controls.Add(buttonEliminarItem);
            Controls.Add(textBoxObservaciones);
            Controls.Add(comboBoxClientes);
            Controls.Add(comboBoxEstado);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(dataGridViewDetallePedido);
            Controls.Add(labelTotal);
            Controls.Add(buttonAgregarItem);
            Controls.Add(buttonGuardarCambios);
            Controls.Add(buttonCancelar);
            Name = "FormEditarPedido";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editar Pedido";
            Load += FormEditarPedido_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewDetallePedido).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Button buttonEliminarItem;
        private Button buttonEliminarPedido;
        private ToolTip toolTip;
    }
}
