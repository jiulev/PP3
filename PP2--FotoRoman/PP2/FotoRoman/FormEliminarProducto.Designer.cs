namespace FotoRoman
{
    partial class FormEliminarProducto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label labelProducto;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
        /// Método requerido para el diseñador.
        /// </summary>
        private void InitializeComponent()
        {
            labelProducto = new Label();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // labelProducto
            // 
            labelProducto.AutoSize = true;
            labelProducto.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelProducto.Location = new Point(5, 24);
            labelProducto.Name = "labelProducto";
            labelProducto.Size = new Size(293, 17);
            labelProducto.TabIndex = 0;
            labelProducto.Text = "¿Deseás eliminar el producto seleccionado?";
            // 
            // btnConfirmar
            // 
            btnConfirmar.BackColor = Color.LightGray;
            btnConfirmar.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            btnConfirmar.Location = new Point(40, 60);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(100, 30);
            btnConfirmar.TabIndex = 1;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = false;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.LightGray;
            btnCancelar.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            btnCancelar.Location = new Point(160, 60);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 30);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormEliminarProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(310, 119);
            Controls.Add(labelProducto);
            Controls.Add(btnConfirmar);
            Controls.Add(btnCancelar);
            Name = "FormEliminarProducto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Eliminar Producto";
            Load += FormEliminarProducto_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
