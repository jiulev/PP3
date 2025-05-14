namespace FotoRoman
{
    partial class FormEditarPagoSeleccionado
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.TextBox textNum;
        private System.Windows.Forms.TextBox textImporte;
        private System.Windows.Forms.TextBox[] textMetodos;
        private System.Windows.Forms.TextBox[] textSubtotales;
        private System.Windows.Forms.Label sumasubtotal;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonCancelar;

        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelNum;
        private System.Windows.Forms.Label labelImporte;
        private System.Windows.Forms.Label labelDetalle;

        private System.Windows.Forms.TextBox textMetodoPago1;
        private System.Windows.Forms.TextBox textSubtotal1;
        private System.Windows.Forms.TextBox textMetodoPago2;
        private System.Windows.Forms.TextBox textSubtotal2;
        private System.Windows.Forms.TextBox textMetodoPago3;
        private System.Windows.Forms.TextBox textSubtotal3;
        private System.Windows.Forms.TextBox textMetodoPago4;
        private System.Windows.Forms.TextBox textSubtotal4;
        private System.Windows.Forms.TextBox textMetodoPago5;
        private System.Windows.Forms.TextBox textSubtotal5;
        private System.Windows.Forms.TextBox textMetodoPago6;
        private System.Windows.Forms.TextBox textSubtotal6;
        private System.Windows.Forms.TextBox textMetodoPago7;
        private System.Windows.Forms.TextBox textSubtotal7;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Labels
            this.labelNombre = new Label() { Text = "Nombre del Cliente:", Location = new System.Drawing.Point(20, 20), AutoSize = true };
            this.labelNum = new Label() { Text = "ID del Pedido:", Location = new System.Drawing.Point(20, 60), AutoSize = true };
            this.labelImporte = new Label() { Text = "Monto del Pedido:", Location = new System.Drawing.Point(20, 100), AutoSize = true };
            this.labelDetalle = new Label() { Text = "Detalle de pagos del pedido:", Location = new System.Drawing.Point(20, 140), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };

            // TextBoxes principales
            this.textNombre = new TextBox() { Location = new System.Drawing.Point(160, 20), Width = 250, ReadOnly = true };
            this.textNum = new TextBox() { Location = new System.Drawing.Point(160, 60), Width = 250, ReadOnly = true };
            this.textImporte = new TextBox() { Location = new System.Drawing.Point(160, 100), Width = 250, ReadOnly = true };

            // Subtotales
            this.textMetodoPago1 = new TextBox();
            this.textSubtotal1 = new TextBox();
            this.textMetodoPago2 = new TextBox();
            this.textSubtotal2 = new TextBox();
            this.textMetodoPago3 = new TextBox();
            this.textSubtotal3 = new TextBox();
            this.textMetodoPago4 = new TextBox();
            this.textSubtotal4 = new TextBox();
            this.textMetodoPago5 = new TextBox();
            this.textSubtotal5 = new TextBox();
            this.textMetodoPago6 = new TextBox();
            this.textSubtotal6 = new TextBox();
            this.textMetodoPago7 = new TextBox();
            this.textSubtotal7 = new TextBox();

            // Agrupar en arrays para manejarlos después
            this.textMetodos = new TextBox[]
            {
                textMetodoPago1, textMetodoPago2, textMetodoPago3, textMetodoPago4,
                textMetodoPago5, textMetodoPago6, textMetodoPago7
            };
            this.textSubtotales = new TextBox[]
            {
                textSubtotal1, textSubtotal2, textSubtotal3, textSubtotal4,
                textSubtotal5, textSubtotal6, textSubtotal7
            };

            for (int i = 0; i < 7; i++)
            {
                this.textMetodos[i].Location = new System.Drawing.Point(20, 170 + i * 30);
                this.textMetodos[i].Size = new System.Drawing.Size(200, 25);
                this.textSubtotales[i].Location = new System.Drawing.Point(230, 170 + i * 30);
                this.textSubtotales[i].Size = new System.Drawing.Size(180, 25);
                this.textSubtotales[i].TextChanged += CalcularSumaSubtotal;
            }

            // Suma Total
            this.sumasubtotal = new Label()
            {
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new System.Drawing.Point(230, 400),
                AutoSize = true,
                Text = "0,00"
            };

            // Botones
            this.buttonGuardar = new Button()
            {
                Text = "Guardar Cambios",
                Location = new System.Drawing.Point(130, 440),
                Size = new System.Drawing.Size(140, 30),
                BackColor = Color.LightGray
            };
            this.buttonGuardar.Click += buttonGuardar_Click;

            this.buttonCancelar = new Button()
            {
                Text = "Cancelar",
                Location = new System.Drawing.Point(290, 440),
                Size = new System.Drawing.Size(100, 30),
                BackColor = Color.LightGray
            };
            this.buttonCancelar.Click += buttonCancelar_Click;

            // Form
            this.ClientSize = new System.Drawing.Size(440, 500);
            this.Controls.Add(labelNombre);
            this.Controls.Add(labelNum);
            this.Controls.Add(labelImporte);
            this.Controls.Add(labelDetalle);
            this.Controls.Add(textNombre);
            this.Controls.Add(textNum);
            this.Controls.Add(textImporte);
            this.Controls.Add(sumasubtotal);
            this.Controls.Add(buttonGuardar);
            this.Controls.Add(buttonCancelar);

            for (int i = 0; i < 7; i++)
            {
                this.Controls.Add(textMetodos[i]);
                this.Controls.Add(textSubtotales[i]);
            }

            this.Name = "FormEditarPagoSeleccionado";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Editar Pago del Pedido";
            this.Load += FormEditarPagoSeleccionado_Load;
        }
    }
}
