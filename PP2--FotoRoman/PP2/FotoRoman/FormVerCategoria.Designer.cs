using System.Drawing;


namespace FotoRoman
{
    partial class FormVerCategoria
    {
        private System.ComponentModel.IContainer components = null;

        // Declaración de controles
        private System.Windows.Forms.TextBox textBoxBuscar;
        private System.Windows.Forms.DataGridView dataGridViewCategorias;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.Label labelBuscar;

        /// <summary>
        /// Limpia los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método requerido para el soporte del Diseñador.
        /// No modifique el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxBuscar = new TextBox();
            dataGridViewCategorias = new DataGridView();
            buttonEditar = new Button();
            labelBuscar = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCategorias).BeginInit();
            SuspendLayout();
            // 
            // textBoxBuscar
            // 
            textBoxBuscar.Font = new Font("Segoe UI", 12F);
            textBoxBuscar.Location = new Point(120, 20);
            textBoxBuscar.Name = "textBoxBuscar";
            textBoxBuscar.Size = new Size(400, 29);
            textBoxBuscar.TabIndex = 0;
            textBoxBuscar.TextChanged += textBoxBuscar_TextChanged;
            // 
            // dataGridViewCategorias
            // 
            dataGridViewCategorias.AllowUserToAddRows = false;
            dataGridViewCategorias.AllowUserToDeleteRows = false;
            dataGridViewCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCategorias.BackgroundColor = SystemColors.Control;
            dataGridViewCategorias.BorderStyle = BorderStyle.None;
            dataGridViewCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCategorias.Location = new Point(20, 70);
            dataGridViewCategorias.MultiSelect = false;
            dataGridViewCategorias.Name = "dataGridViewCategorias";
            dataGridViewCategorias.ReadOnly = true;
            dataGridViewCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCategorias.Size = new Size(600, 250);
            dataGridViewCategorias.TabIndex = 1;
            // 
            // buttonEditar
            // 
            buttonEditar.BackColor = Color.LightGray;
            buttonEditar.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonEditar.Location = new Point(470, 339);
            buttonEditar.Name = "buttonEditar";
            buttonEditar.Size = new Size(132, 40);
            buttonEditar.TabIndex = 2;
            buttonEditar.Text = "Editar";
            buttonEditar.UseVisualStyleBackColor = false;
            buttonEditar.Click += buttonEditar_Click;
            // 
            // labelBuscar
            // 
            labelBuscar.AutoSize = true;
            labelBuscar.Font = new Font("Yu Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelBuscar.Location = new Point(20, 23);
            labelBuscar.Name = "labelBuscar";
            labelBuscar.Size = new Size(66, 21);
            labelBuscar.TabIndex = 4;
            labelBuscar.Text = "Buscar:";
            // 
            // FormVerCategoria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 400);
            Controls.Add(labelBuscar);
            Controls.Add(buttonEditar);
            Controls.Add(dataGridViewCategorias);
            Controls.Add(textBoxBuscar);
            Name = "FormVerCategoria";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Categorías";
            Load += FormVerCategoria_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewCategorias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
