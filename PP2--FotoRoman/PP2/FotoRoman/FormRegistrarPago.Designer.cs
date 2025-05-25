namespace FotoRoman
{
    partial class FormRegistrarPago
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
            textNombre = new TextBox();
            textNum = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textImporte = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            textSubtotal1 = new TextBox();
            textMetodoPago1 = new TextBox();
            textMetodoPago2 = new TextBox();
            textMetodoPago3 = new TextBox();
            textMetodoPago4 = new TextBox();
            textMetodoPago5 = new TextBox();
            textMetodoPago6 = new TextBox();
            textMetodoPago7 = new TextBox();
            textSubtotal2 = new TextBox();
            textSubtotal3 = new TextBox();
            textSubtotal4 = new TextBox();
            textSubtotal5 = new TextBox();
            textSubtotal6 = new TextBox();
            textSubtotal7 = new TextBox();
            sumasubtotal = new Label();
            RegistrarPago1 = new Button();
            buttonCancelar1 = new Button();
            SuspendLayout();
            // 
            // textNombre
            // 
            textNombre.Font = new Font("Yu Gothic", 11F);
            textNombre.Location = new Point(160, 19);
            textNombre.Name = "textNombre";
            textNombre.Size = new Size(189, 31);
            textNombre.TabIndex = 1;
            textNombre.TextChanged += textNombre_TextChanged;
            // 
            // textNum
            // 
            textNum.Font = new Font("Yu Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textNum.Location = new Point(160, 79);
            textNum.Name = "textNum";
            textNum.Size = new Size(189, 31);
            textNum.TabIndex = 2;
            //textNum.TextChanged += this.textNum_TextChanged;
            textNum.ReadOnly = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            label1.Location = new Point(27, 26);
            label1.Name = "label1";
            label1.Size = new Size(127, 17);
            label1.TabIndex = 3;
            label1.Text = "Apellido y Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            label2.Location = new Point(46, 86);
            label2.Name = "label2";
            label2.Size = new Size(108, 17);
            label2.TabIndex = 4;
            label2.Text = "Numero Pedido";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            label3.Location = new Point(47, 146);
            label3.Name = "label3";
            label3.Size = new Size(107, 17);
            label3.TabIndex = 5;
            label3.Text = "Importe Pedido";
            // 
            // textImporte
            // 
            textImporte.Font = new Font("Yu Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textImporte.Location = new Point(160, 138);
            textImporte.Name = "textImporte";
            textImporte.Size = new Size(189, 33);
            textImporte.TabIndex = 6;
            //textImporte.TextChanged += this.textImporte_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic", 12F, FontStyle.Bold);
            label4.ForeColor = Color.Brown;
            label4.Location = new Point(59, 218);
            label4.Name = "label4";
            label4.Size = new Size(132, 21);
            label4.TabIndex = 7;
            label4.Text = "Forma de Cobro";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic", 12F, FontStyle.Bold);
            label5.ForeColor = Color.Brown;
            label5.Location = new Point(280, 218);
            label5.Name = "label5";
            label5.Size = new Size(76, 21);
            label5.TabIndex = 8;
            label5.Text = "Subtotal";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic", 9F, FontStyle.Bold);
            label6.Location = new Point(84, 440);
            label6.Name = "label6";
            label6.Size = new Size(88, 16);
            label6.TabIndex = 9;
            label6.Text = "Total Recibido";
            // 
            // textSubtotal1
            // 
            textSubtotal1.Font = new Font("Yu Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textSubtotal1.Location = new Point(245, 246);
            textSubtotal1.Name = "textSubtotal1";
            textSubtotal1.Size = new Size(172, 31);
            textSubtotal1.TabIndex = 11;
            // 
            // textMetodoPago1
            // 
            textMetodoPago1.Font = new Font("Yu Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textMetodoPago1.Location = new Point(27, 246);
            textMetodoPago1.Name = "textMetodoPago1";
            textMetodoPago1.Size = new Size(212, 31);
            textMetodoPago1.TabIndex = 12;
            // 
            // textMetodoPago2
            // 
            textMetodoPago2.Font = new Font("Yu Gothic UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textMetodoPago2.Location = new Point(27, 272);
            textMetodoPago2.Name = "textMetodoPago2";
            textMetodoPago2.Size = new Size(212, 27);
            textMetodoPago2.TabIndex = 13;
            // 
            // textMetodoPago3
            // 
            textMetodoPago3.Font = new Font("Yu Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textMetodoPago3.Location = new Point(27, 297);
            textMetodoPago3.Name = "textMetodoPago3";
            textMetodoPago3.Size = new Size(212, 31);
            textMetodoPago3.TabIndex = 14;
            // 
            // textMetodoPago4
            // 
            textMetodoPago4.Font = new Font("Yu Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textMetodoPago4.Location = new Point(27, 322);
            textMetodoPago4.Name = "textMetodoPago4";
            textMetodoPago4.Size = new Size(212, 31);
            textMetodoPago4.TabIndex = 15;
            // 
            // textMetodoPago5
            // 
            textMetodoPago5.Font = new Font("Yu Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textMetodoPago5.Location = new Point(27, 348);
            textMetodoPago5.Name = "textMetodoPago5";
            textMetodoPago5.Size = new Size(212, 31);
            textMetodoPago5.TabIndex = 16;
            // 
            // textMetodoPago6
            // 
            textMetodoPago6.Font = new Font("Yu Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textMetodoPago6.Location = new Point(27, 374);
            textMetodoPago6.Name = "textMetodoPago6";
            textMetodoPago6.Size = new Size(212, 31);
            textMetodoPago6.TabIndex = 17;
            // 
            // textMetodoPago7
            // 
            textMetodoPago7.Font = new Font("Yu Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textMetodoPago7.Location = new Point(27, 399);
            textMetodoPago7.Name = "textMetodoPago7";
            textMetodoPago7.Size = new Size(212, 31);
            textMetodoPago7.TabIndex = 18;
            // 
            // textSubtotal2
            // 
            textSubtotal2.Font = new Font("Yu Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textSubtotal2.Location = new Point(245, 272);
            textSubtotal2.Name = "textSubtotal2";
            textSubtotal2.Size = new Size(172, 33);
            textSubtotal2.TabIndex = 19;
            // 
            // textSubtotal3
            // 
            textSubtotal3.Font = new Font("Yu Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textSubtotal3.Location = new Point(245, 297);
            textSubtotal3.Name = "textSubtotal3";
            textSubtotal3.Size = new Size(172, 33);
            textSubtotal3.TabIndex = 20;
            // 
            // textSubtotal4
            // 
            textSubtotal4.Font = new Font("Yu Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textSubtotal4.Location = new Point(245, 322);
            textSubtotal4.Name = "textSubtotal4";
            textSubtotal4.Size = new Size(172, 33);
            textSubtotal4.TabIndex = 21;
            // 
            // textSubtotal5
            // 
            textSubtotal5.Font = new Font("Yu Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textSubtotal5.Location = new Point(245, 348);
            textSubtotal5.Name = "textSubtotal5";
            textSubtotal5.Size = new Size(172, 31);
            textSubtotal5.TabIndex = 22;
            // 
            // textSubtotal6
            // 
            textSubtotal6.Font = new Font("Yu Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textSubtotal6.Location = new Point(245, 374);
            textSubtotal6.Name = "textSubtotal6";
            textSubtotal6.Size = new Size(172, 31);
            textSubtotal6.TabIndex = 23;
            // 
            // textSubtotal7
            // 
            textSubtotal7.Font = new Font("Yu Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textSubtotal7.Location = new Point(245, 399);
            textSubtotal7.Name = "textSubtotal7";
            textSubtotal7.Size = new Size(172, 31);
            textSubtotal7.TabIndex = 24;
            // 
            // sumasubtotal
            // 
            sumasubtotal.AutoSize = true;
            sumasubtotal.Font = new Font("Yu Gothic", 9F, FontStyle.Bold);
            sumasubtotal.Location = new Point(304, 440);
            sumasubtotal.Name = "sumasubtotal";
            sumasubtotal.Size = new Size(31, 16);
            sumasubtotal.TabIndex = 25;
            sumasubtotal.Text = "0,00";
            // 
            // RegistrarPago1
            // 
            RegistrarPago1.BackColor = Color.LightGray;
            RegistrarPago1.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            RegistrarPago1.Location = new Point(233, 484);
            RegistrarPago1.Name = "RegistrarPago1";
            RegistrarPago1.Size = new Size(91, 32);
            RegistrarPago1.TabIndex = 26;
            RegistrarPago1.Text = "Registrar";
            RegistrarPago1.UseVisualStyleBackColor = false;
            RegistrarPago1.Click += RegistrarPago1_Click;
            // 
            // buttonCancelar1
            // 
            buttonCancelar1.BackColor = Color.LightGray;
            buttonCancelar1.Font = new Font("Yu Gothic", 9.75F, FontStyle.Bold);
            buttonCancelar1.Location = new Point(332, 484);
            buttonCancelar1.Name = "buttonCancelar1";
            buttonCancelar1.Size = new Size(91, 32);
            buttonCancelar1.TabIndex = 27;
            buttonCancelar1.Text = "Cancelar";
            buttonCancelar1.UseVisualStyleBackColor = false;
            buttonCancelar1.Click += buttonCancelar1_Click;
            // 
            // FormRegistrarPago
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(449, 528);
            Controls.Add(buttonCancelar1);
            Controls.Add(RegistrarPago1);
            Controls.Add(sumasubtotal);
            Controls.Add(textSubtotal7);
            Controls.Add(textSubtotal6);
            Controls.Add(textSubtotal5);
            Controls.Add(textSubtotal4);
            Controls.Add(textSubtotal3);
            Controls.Add(textSubtotal2);
            Controls.Add(textMetodoPago7);
            Controls.Add(textMetodoPago6);
            Controls.Add(textMetodoPago5);
            Controls.Add(textMetodoPago4);
            Controls.Add(textMetodoPago3);
            Controls.Add(textMetodoPago2);
            Controls.Add(textMetodoPago1);
            Controls.Add(textSubtotal1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(textImporte);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textNum);
            Controls.Add(textNombre);
            Name = "FormRegistrarPago";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registrar Cobros";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textNombre;
        private TextBox textNum;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textImporte;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textSubtotal1;
        private TextBox textMetodoPago1;
        private TextBox textMetodoPago2;
        private TextBox textMetodoPago3;
        private TextBox textMetodoPago4;
        private TextBox textMetodoPago5;
        private TextBox textMetodoPago6;
        private TextBox textMetodoPago7;
        private TextBox textSubtotal2;
        private TextBox textSubtotal3;
        private TextBox textSubtotal4;
        private TextBox textSubtotal5;
        private TextBox textSubtotal6;
        private TextBox textSubtotal7;
        private Label sumasubtotal;
        private Button RegistrarPago1;
        private Button buttonCancelar1;
    }
}