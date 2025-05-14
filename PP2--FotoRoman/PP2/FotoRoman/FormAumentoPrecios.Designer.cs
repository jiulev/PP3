// FormAumentoPrecios.Designer.cs
namespace FotoRoman
{
    partial class FormAumentoPrecios
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPorcentaje;
        private System.Windows.Forms.Button btnAplicar;

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
            label1 = new Label();
            txtPorcentaje = new TextBox();
            btnAplicar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(195, 15);
            label1.TabIndex = 0;
            label1.Text = "Ingrese porcentaje de aumento (%):";
            // 
            // txtPorcentaje
            // 
            txtPorcentaje.Location = new Point(20, 50);
            txtPorcentaje.Name = "txtPorcentaje";
            txtPorcentaje.Size = new Size(200, 23);
            txtPorcentaje.TabIndex = 1;
            // 
            // btnAplicar
            // 
            btnAplicar.BackColor = Color.LightGray;
            btnAplicar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAplicar.Location = new Point(70, 90);
            btnAplicar.Name = "btnAplicar";
            btnAplicar.Size = new Size(100, 30);
            btnAplicar.TabIndex = 2;
            btnAplicar.Text = "Aplicar";
            btnAplicar.UseVisualStyleBackColor = false;
            btnAplicar.Click += btnAplicar_Click;
            // 
            // FormAumentoPrecios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(250, 150);
            Controls.Add(label1);
            Controls.Add(txtPorcentaje);
            Controls.Add(btnAplicar);
            Name = "FormAumentoPrecios";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Aumento de Precios";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}