namespace FotoRoman
{
    partial class FormCrearProducto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCrearProducto));
            txtNombreProducto = new TextBox();
            comboBoxCategoria = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtPrecioProducto = new TextBox();
            btnRegistrarProducto = new Button();
            btnCancelarProducto = new Button();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            label5 = new Label();
            pictureBoxLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // txtNombreProducto
            // 
            txtNombreProducto.Font = new Font("Segoe UI", 10F);
            txtNombreProducto.Location = new Point(188, 105);
            txtNombreProducto.Name = "txtNombreProducto";
            txtNombreProducto.Size = new Size(300, 25);
            txtNombreProducto.TabIndex = 0;
            // 
            // comboBoxCategoria
            // 
            comboBoxCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCategoria.Font = new Font("Segoe UI", 10F);
            comboBoxCategoria.Location = new Point(188, 65);
            comboBoxCategoria.Name = "comboBoxCategoria";
            comboBoxCategoria.Size = new Size(300, 25);
            comboBoxCategoria.TabIndex = 1;
            comboBoxCategoria.SelectedIndexChanged += comboBoxCategoria_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            label1.Location = new Point(21, 111);
            label1.Name = "label1";
            label1.Size = new Size(148, 17);
            label1.TabIndex = 7;
            label1.Text = "Nombre del producto:";
            // 
            // label2
            // 
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            label3.Location = new Point(34, 148);
            label3.Name = "label3";
            label3.Size = new Size(138, 17);
            label3.TabIndex = 6;
            label3.Text = "Precio del producto:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            label4.Location = new Point(12, 68);
            label4.Name = "label4";
            label4.Size = new Size(160, 17);
            label4.TabIndex = 8;
            label4.Text = "Categoría del producto:";
            // 
            // txtPrecioProducto
            // 
            txtPrecioProducto.Font = new Font("Segoe UI", 10F);
            txtPrecioProducto.Location = new Point(188, 145);
            txtPrecioProducto.Name = "txtPrecioProducto";
            txtPrecioProducto.Size = new Size(300, 25);
            txtPrecioProducto.TabIndex = 2;
            // 
            // btnRegistrarProducto
            // 
            btnRegistrarProducto.BackColor = Color.LightGray;
            btnRegistrarProducto.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRegistrarProducto.Location = new Point(188, 200);
            btnRegistrarProducto.Name = "btnRegistrarProducto";
            btnRegistrarProducto.Size = new Size(120, 40);
            btnRegistrarProducto.TabIndex = 3;
            btnRegistrarProducto.Text = "Registrar";
            btnRegistrarProducto.UseVisualStyleBackColor = false;
            btnRegistrarProducto.Click += btnRegistrarProducto_Click;
            // 
            // btnCancelarProducto
            // 
            btnCancelarProducto.BackColor = Color.LightGray;
            btnCancelarProducto.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancelarProducto.Location = new Point(368, 200);
            btnCancelarProducto.Name = "btnCancelarProducto";
            btnCancelarProducto.Size = new Size(120, 40);
            btnCancelarProducto.TabIndex = 4;
            btnCancelarProducto.Text = "Cancelar";
            btnCancelarProducto.UseVisualStyleBackColor = false;
            btnCancelarProducto.Click += btnCancelarProducto_Click;
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = SystemColors.Control;
            iconPictureBox1.ForeColor = SystemColors.ControlText;
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Box;
            iconPictureBox1.IconColor = SystemColors.ControlText;
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 28;
            iconPictureBox1.Location = new Point(20, 15);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(28, 28);
            iconPictureBox1.TabIndex = 5;
            iconPictureBox1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic", 11.25F, FontStyle.Bold);
            label5.ForeColor = Color.Brown;
            label5.Location = new Point(55, 17);
            label5.Name = "label5";
            label5.Size = new Size(146, 19);
            label5.TabIndex = 0;
            label5.Text = "Registrar Producto";
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackColor = Color.Transparent;
            pictureBoxLogo.Image = (Image)resources.GetObject("pictureBoxLogo.Image");
            pictureBoxLogo.Location = new Point(506, 12);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(73, 65);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxLogo.TabIndex = 9;
            pictureBoxLogo.TabStop = false;
            // 
            // FormCrearProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 280);
            Controls.Add(label5);
            Controls.Add(iconPictureBox1);
            Controls.Add(btnCancelarProducto);
            Controls.Add(btnRegistrarProducto);
            Controls.Add(txtPrecioProducto);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(txtNombreProducto);
            Controls.Add(label4);
            Controls.Add(comboBoxCategoria);
            Controls.Add(pictureBoxLogo);
            Name = "FormCrearProducto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registrar un Nuevo Producto";
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private TextBox txtNombreProducto;
        private ComboBox comboBoxCategoria;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtPrecioProducto;
        private Button btnRegistrarProducto;
        private Button btnCancelarProducto;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private Label label5;
        private PictureBox pictureBoxLogo;

    }
}