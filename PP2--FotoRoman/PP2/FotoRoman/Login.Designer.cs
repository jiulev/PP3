namespace FotoRoman
{
    partial class Login
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
            label1 = new Label();
            label2 = new Label();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            txtdocumento = new TextBox();
            txtclave = new TextBox();
            label3 = new Label();
            label4 = new Label();
            Btn_ingresar = new FontAwesome.Sharp.IconButton();
            Btncancelar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.Firebrick;
            label1.Dock = DockStyle.Left;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(334, 280);
            label1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Firebrick;
            label2.Font = new Font("Yu Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(44, 217);
            label2.Name = "label2";
            label2.Size = new Size(241, 25);
            label2.TabIndex = 1;
            label2.Text = "Sistema Gestión Pedidos";
            label2.Click += label2_Click;
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = Color.Firebrick;
            iconPictureBox1.BorderStyle = BorderStyle.Fixed3D;
            iconPictureBox1.ForeColor = SystemColors.ControlLight;
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Stackpath;
            iconPictureBox1.IconColor = SystemColors.ControlLight;
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 165;
            iconPictureBox1.Location = new Point(63, 33);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(165, 167);
            iconPictureBox1.TabIndex = 2;
            iconPictureBox1.TabStop = false;
            // 
            // txtdocumento
            // 
            txtdocumento.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            txtdocumento.Location = new Point(370, 77);
            txtdocumento.Name = "txtdocumento";
            txtdocumento.Size = new Size(235, 25);
            txtdocumento.TabIndex = 3;
            txtdocumento.TextChanged += textBox1_TextChanged;
            // 
            // txtclave
            // 
            txtclave.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            txtclave.Location = new Point(370, 144);
            txtclave.Name = "txtclave";
            txtclave.PasswordChar = '*';
            txtclave.Size = new Size(235, 25);
            txtclave.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic", 11.25F, FontStyle.Bold);
            label3.Location = new Point(370, 55);
            label3.Name = "label3";
            label3.Size = new Size(38, 19);
            label3.TabIndex = 5;
            label3.Text = "DNI";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic", 11.25F, FontStyle.Bold);
            label4.Location = new Point(370, 122);
            label4.Name = "label4";
            label4.Size = new Size(94, 19);
            label4.TabIndex = 6;
            label4.Text = "Contraseña";
            label4.Click += label4_Click;
            // 
            // Btn_ingresar
            // 
            Btn_ingresar.BackColor = Color.DimGray;
            Btn_ingresar.FlatAppearance.BorderColor = Color.Black;
            Btn_ingresar.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            Btn_ingresar.ForeColor = SystemColors.Info;
            Btn_ingresar.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            Btn_ingresar.IconColor = Color.White;
            Btn_ingresar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            Btn_ingresar.IconSize = 30;
            Btn_ingresar.Location = new Point(367, 192);
            Btn_ingresar.Name = "Btn_ingresar";
            Btn_ingresar.Size = new Size(108, 50);
            Btn_ingresar.TabIndex = 7;
            Btn_ingresar.Text = "Ingresar";
            Btn_ingresar.TextAlign = ContentAlignment.MiddleRight;
            Btn_ingresar.TextImageRelation = TextImageRelation.ImageBeforeText;
            Btn_ingresar.UseVisualStyleBackColor = false;
            Btn_ingresar.Click += iconButton1_Click;
            // 
            // Btncancelar
            // 
            Btncancelar.BackColor = Color.IndianRed;
            Btncancelar.FlatAppearance.BorderColor = Color.Black;
            Btncancelar.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            Btncancelar.ForeColor = SystemColors.ControlLightLight;
            Btncancelar.IconChar = FontAwesome.Sharp.IconChar.DoorClosed;
            Btncancelar.IconColor = Color.White;
            Btncancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            Btncancelar.IconSize = 30;
            Btncancelar.Location = new Point(497, 192);
            Btncancelar.Name = "Btncancelar";
            Btncancelar.Size = new Size(108, 50);
            Btncancelar.TabIndex = 8;
            Btncancelar.Text = "Cancelar";
            Btncancelar.TextAlign = ContentAlignment.MiddleRight;
            Btncancelar.TextImageRelation = TextImageRelation.ImageBeforeText;
            Btncancelar.UseVisualStyleBackColor = false;
            Btncancelar.Click += Btncancelar_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(652, 280);
            Controls.Add(Btncancelar);
            Controls.Add(Btn_ingresar);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtclave);
            Controls.Add(txtdocumento);
            Controls.Add(iconPictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private TextBox txtdocumento;
        private TextBox txtclave;
        private Label label3;
        private Label label4;
        private FontAwesome.Sharp.IconButton Btn_ingresar;
        private FontAwesome.Sharp.IconButton Btncancelar;
    }
}