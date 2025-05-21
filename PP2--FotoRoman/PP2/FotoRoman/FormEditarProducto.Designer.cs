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
            labelTitulo.Font = new Font("Yu Gothic", 11.25F, FontStyle.Bold);
            labelTitulo.ForeColor = Color.Brown;
            labelTitulo.Location = new Point(20, 20);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(123, 19);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = "Editar Producto";
            // 
            // labelNombre
            // 
            labelNombre.AutoSize = true;
            labelNombre.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            labelNombre.ForeColor = Color.Black;
            labelNombre.Location = new Point(20, 65);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(63, 17);
            labelNombre.TabIndex = 1;
            labelNombre.Text = "Nombre:";
            // 
            // labelPrecio
            // 
            labelPrecio.AutoSize = true;
            labelPrecio.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            labelPrecio.ForeColor = Color.Black;
            labelPrecio.Location = new Point(30, 105);
            labelPrecio.Name = "labelPrecio";
            labelPrecio.Size = new Size(53, 17);
            labelPrecio.TabIndex = 3;
            labelPrecio.Text = "Precio:";
            // 
            // labelCategoria
            // 
            labelCategoria.AutoSize = true;
            labelCategoria.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            labelCategoria.ForeColor = Color.Black;
            labelCategoria.Location = new Point(8, 145);
            labelCategoria.Name = "labelCategoria";
            labelCategoria.Size = new Size(75, 17);
            labelCategoria.TabIndex = 5;
            labelCategoria.Text = "Categoría:";
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(100, 60);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(200, 32);
            textBoxNombre.TabIndex = 2;
            // 
            // textBoxPrecio
            // 
            textBoxPrecio.Location = new Point(100, 100);
            textBoxPrecio.Name = "textBoxPrecio";
            textBoxPrecio.Size = new Size(200, 32);
            textBoxPrecio.TabIndex = 4;
            // 
            // comboBoxCategoria
            // 
            comboBoxCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCategoria.Location = new Point(100, 140);
            comboBoxCategoria.Name = "comboBoxCategoria";
            comboBoxCategoria.Size = new Size(200, 27);
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
            label1.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(27, 187);
            label1.Name = "label1";
            label1.Size = new Size(56, 17);
            label1.TabIndex = 8;
            label1.Text = "Estado:";
            // 
            // comboBoxEstado
            // 
            comboBoxEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEstado.Location = new Point(100, 179);
            comboBoxEstado.Name = "comboBoxEstado";
            comboBoxEstado.Size = new Size(200, 27);
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
            Font = new Font("Yu Gothic", 11.25F, FontStyle.Bold);
            ForeColor = Color.Brown;
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
