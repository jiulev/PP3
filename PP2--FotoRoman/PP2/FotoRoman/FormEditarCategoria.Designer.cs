namespace FotoRoman
{
    partial class FormEditarCategoria
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxDescripcion;
        private System.Windows.Forms.CheckBox checkBoxInactiva;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Label labelDescripcion;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            textBoxDescripcion = new TextBox();
            checkBoxInactiva = new CheckBox();
            buttonGuardar = new Button();
            labelDescripcion = new Label();
            SuspendLayout();
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.Location = new Point(30, 40);
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.Size = new Size(300, 23);
            textBoxDescripcion.TabIndex = 0;
            // 
            // checkBoxInactiva
            // 
            checkBoxInactiva.AutoSize = true;
            checkBoxInactiva.Location = new Point(30, 80);
            checkBoxInactiva.Name = "checkBoxInactiva";
            checkBoxInactiva.Size = new Size(123, 19);
            checkBoxInactiva.TabIndex = 2;
            checkBoxInactiva.Text = "Inactivar categoría";
            // 
            // buttonGuardar
            // 
            buttonGuardar.BackColor = Color.LightGray;
            buttonGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonGuardar.Location = new Point(30, 120);
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.Size = new Size(300, 30);
            buttonGuardar.TabIndex = 3;
            buttonGuardar.Text = "Guardar";
            buttonGuardar.UseVisualStyleBackColor = false;
            buttonGuardar.Click += buttonGuardar_Click;
            // 
            // labelDescripcion
            // 
            labelDescripcion.AutoSize = true;
            labelDescripcion.Location = new Point(30, 20);
            labelDescripcion.Name = "labelDescripcion";
            labelDescripcion.Size = new Size(72, 15);
            labelDescripcion.TabIndex = 1;
            labelDescripcion.Text = "Descripción:";
            // 
            // FormEditarCategoria
            // 
            ClientSize = new Size(370, 180);
            Controls.Add(textBoxDescripcion);
            Controls.Add(labelDescripcion);
            Controls.Add(checkBoxInactiva);
            Controls.Add(buttonGuardar);
            Name = "FormEditarCategoria";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Editar Categoría";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
