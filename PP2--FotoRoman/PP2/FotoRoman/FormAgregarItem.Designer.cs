// FormAgregarItem.Designer.cs
namespace FotoRoman
{
    partial class FormAgregarItem
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

        private void InitializeComponent()
        {
            comboBoxCategoria = new ComboBox();
            comboBoxProducto = new ComboBox();
            numericCantidad = new NumericUpDown();
            textBoxPrecio = new TextBox();
            labelSubtotal = new Label();
            buttonAgregar = new Button();
            buttonCancelar = new Button();
            labelCategoria = new Label();
            labelProducto = new Label();
            labelCantidad = new Label();
            labelPrecio = new Label();
            ((System.ComponentModel.ISupportInitialize)numericCantidad).BeginInit();
            SuspendLayout();
            // 
            // comboBoxCategoria
            // 
            comboBoxCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCategoria.Location = new Point(120, 20);
            comboBoxCategoria.Name = "comboBoxCategoria";
            comboBoxCategoria.Size = new Size(200, 24);
            comboBoxCategoria.TabIndex = 0;
            comboBoxCategoria.SelectedIndexChanged += comboBoxCategoria_SelectedIndexChanged;
            // 
            // comboBoxProducto
            // 
            comboBoxProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProducto.Location = new Point(120, 60);
            comboBoxProducto.Name = "comboBoxProducto";
            comboBoxProducto.Size = new Size(200, 24);
            comboBoxProducto.TabIndex = 1;
            comboBoxProducto.SelectedIndexChanged += comboBoxProducto_SelectedIndexChanged;
            // 
            // numericCantidad
            // 
            numericCantidad.Location = new Point(120, 100);
            numericCantidad.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericCantidad.Name = "numericCantidad";
            numericCantidad.Size = new Size(100, 27);
            numericCantidad.TabIndex = 2;
            numericCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericCantidad.ValueChanged += numericCantidad_ValueChanged;
            // 
            // textBoxPrecio
            // 
            textBoxPrecio.Location = new Point(120, 140);
            textBoxPrecio.Name = "textBoxPrecio";
            textBoxPrecio.ReadOnly = true;
            textBoxPrecio.Size = new Size(100, 27);
            textBoxPrecio.TabIndex = 3;
            // 
            // labelSubtotal
            // 
            labelSubtotal.Location = new Point(120, 170);
            labelSubtotal.Name = "labelSubtotal";
            labelSubtotal.Size = new Size(150, 23);
            labelSubtotal.TabIndex = 4;
            labelSubtotal.Text = "Subtotal: $0.00";
            // 
            // buttonAgregar
            // 
            buttonAgregar.BackColor = Color.LightGray;
            buttonAgregar.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Bold);
            buttonAgregar.Location = new Point(120, 196);
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.Size = new Size(75, 30);
            buttonAgregar.TabIndex = 5;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.UseVisualStyleBackColor = false;
            buttonAgregar.Click += buttonAgregar_Click;
            // 
            // buttonCancelar
            // 
            buttonCancelar.BackColor = Color.LightGray;
            buttonCancelar.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Bold);
            buttonCancelar.Location = new Point(240, 196);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(75, 30);
            buttonCancelar.TabIndex = 6;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = false;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // labelCategoria
            // 
            labelCategoria.AutoSize = true;
            labelCategoria.Font = new Font("Yu Gothic", 9F, FontStyle.Bold);
            labelCategoria.Location = new Point(30, 20);
            labelCategoria.Name = "labelCategoria";
            labelCategoria.Size = new Size(68, 16);
            labelCategoria.TabIndex = 7;
            labelCategoria.Text = "Categoría:";
            // 
            // labelProducto
            // 
            labelProducto.AutoSize = true;
            labelProducto.Font = new Font("Yu Gothic", 9F, FontStyle.Bold);
            labelProducto.Location = new Point(30, 60);
            labelProducto.Name = "labelProducto";
            labelProducto.Size = new Size(64, 16);
            labelProducto.TabIndex = 8;
            labelProducto.Text = "Producto:";
            // 
            // labelCantidad
            // 
            labelCantidad.AutoSize = true;
            labelCantidad.Font = new Font("Yu Gothic", 9F, FontStyle.Bold);
            labelCantidad.Location = new Point(30, 100);
            labelCantidad.Name = "labelCantidad";
            labelCantidad.Size = new Size(63, 16);
            labelCantidad.TabIndex = 9;
            labelCantidad.Text = "Cantidad:";
            // 
            // labelPrecio
            // 
            labelPrecio.AutoSize = true;
            labelPrecio.Font = new Font("Yu Gothic", 9F, FontStyle.Bold);
            labelPrecio.Location = new Point(30, 140);
            labelPrecio.Name = "labelPrecio";
            labelPrecio.Size = new Size(97, 16);
            labelPrecio.TabIndex = 10;
            labelPrecio.Text = "Precio Unitario:";
            // 
            // FormAgregarItem
            // 
            ClientSize = new Size(350, 260);
            Controls.Add(comboBoxCategoria);
            Controls.Add(comboBoxProducto);
            Controls.Add(numericCantidad);
            Controls.Add(textBoxPrecio);
            Controls.Add(labelSubtotal);
            Controls.Add(buttonAgregar);
            Controls.Add(buttonCancelar);
            Controls.Add(labelCategoria);
            Controls.Add(labelProducto);
            Controls.Add(labelCantidad);
            Controls.Add(labelPrecio);
            Font = new Font("Yu Gothic", 9F, FontStyle.Bold);
            Name = "FormAgregarItem";
            Text = "Agregar Ítem";
            ((System.ComponentModel.ISupportInitialize)numericCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.ComboBox comboBoxCategoria;
        private System.Windows.Forms.ComboBox comboBoxProducto;
        private System.Windows.Forms.NumericUpDown numericCantidad;
        private System.Windows.Forms.TextBox textBoxPrecio;
        private System.Windows.Forms.Label labelSubtotal;
        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Label labelCategoria;
        private System.Windows.Forms.Label labelProducto;
        private System.Windows.Forms.Label labelCantidad;
        private System.Windows.Forms.Label labelPrecio;
    }
}