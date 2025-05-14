namespace FotoRoman
{
    partial class FormEditarProducto
    {
        private System.ComponentModel.IContainer components = null;

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
            labelTitulo = new Label();
            labelNombre = new Label();
            labelPrecio = new Label();
            labelCategoria = new Label();
            textBoxNombre = new TextBox();
            textBoxPrecio = new TextBox();
            comboBoxCategoria = new ComboBox();
            btnGuardar = new Button();
            label1 = new Label();
            comboBoxEstado = new ComboBox();
            SuspendLayout();
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelTitulo.Location = new Point(20, 20);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(129, 21);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = "Editar Producto";
            // 
            // labelNombre
            // 
            labelNombre.AutoSize = true;
            labelNombre.Location = new Point(20, 60);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(54, 15);
            labelNombre.TabIndex = 1;
            labelNombre.Text = "Nombre:";
            // 
            // labelPrecio
            // 
            labelPrecio.AutoSize = true;
            labelPrecio.Location = new Point(20, 100);
            labelPrecio.Name = "labelPrecio";
            labelPrecio.Size = new Size(43, 15);
            labelPrecio.TabIndex = 3;
            labelPrecio.Text = "Precio:";
            // 
            // labelCategoria
            // 
            labelCategoria.AutoSize = true;
            labelCategoria.Location = new Point(20, 140);
            labelCategoria.Name = "labelCategoria";
            labelCategoria.Size = new Size(61, 15);
            labelCategoria.TabIndex = 5;
            labelCategoria.Text = "Categoría:";
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(100, 60);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(200, 23);
            textBoxNombre.TabIndex = 2;
            // 
            // textBoxPrecio
            // 
            textBoxPrecio.Location = new Point(100, 100);
            textBoxPrecio.Name = "textBoxPrecio";
            textBoxPrecio.Size = new Size(200, 23);
            textBoxPrecio.TabIndex = 4;
            // 
            // comboBoxCategoria
            // 
            comboBoxCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCategoria.Location = new Point(100, 140);
            comboBoxCategoria.Name = "comboBoxCategoria";
            comboBoxCategoria.Size = new Size(200, 23);
            comboBoxCategoria.TabIndex = 6;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.LightGray;
            btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(140, 208);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 30);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 182);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 8;
            label1.Text = "Estado:";
            // 
            // comboBoxEstado
            // 
            comboBoxEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEstado.Location = new Point(100, 179);
            comboBoxEstado.Name = "comboBoxEstado";
            comboBoxEstado.Size = new Size(200, 23);
            comboBoxEstado.TabIndex = 9;
            // 
            // FormEditarProducto
            // 
            ClientSize = new Size(350, 250);
            Controls.Add(comboBoxEstado);
            Controls.Add(label1);
            Controls.Add(labelTitulo);
            Controls.Add(labelNombre);
            Controls.Add(textBoxNombre);
            Controls.Add(labelPrecio);
            Controls.Add(textBoxPrecio);
            Controls.Add(labelCategoria);
            Controls.Add(comboBoxCategoria);
            Controls.Add(btnGuardar);
            Name = "FormEditarProducto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editar Producto";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelPrecio;
        private System.Windows.Forms.Label labelCategoria;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxPrecio;
        private System.Windows.Forms.ComboBox comboBoxCategoria;
        private System.Windows.Forms.Button btnGuardar;

        private Label label1;
        private ComboBox comboBoxEstado;

       // private Label label1;
       // private ComboBox comboBoxEstado;

    }
}
