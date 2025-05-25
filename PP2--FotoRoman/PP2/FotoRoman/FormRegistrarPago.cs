using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace FotoRoman
{
    public partial class FormRegistrarPago : Form
    {
        public string TextNombre { get; set; } = string.Empty;
        public string TextImporte { get; set; } = string.Empty;
        public string TextNum { get; set; } = string.Empty;

        public FormRegistrarPago()
        {
            InitializeComponent();
            this.Load += FormRegistrarPago_Load;
            textSubtotal1.TextChanged += (s, e) => CalcularSumaSubtotal();
            textSubtotal2.TextChanged += (s, e) => CalcularSumaSubtotal();
            textSubtotal3.TextChanged += (s, e) => CalcularSumaSubtotal();
            textSubtotal4.TextChanged += (s, e) => CalcularSumaSubtotal();
            textSubtotal5.TextChanged += (s, e) => CalcularSumaSubtotal();
            textSubtotal6.TextChanged += (s, e) => CalcularSumaSubtotal();
            textSubtotal7.TextChanged += (s, e) => CalcularSumaSubtotal();

        }
        private void CalcularSumaSubtotal()
        {
            decimal suma = 0;

            for (int i = 1; i <= 7; i++)
            {
                // Obtén el TextBox correspondiente
                TextBox? subtotalTextBox = this.Controls[$"textSubtotal{i}"] as TextBox;

                if (subtotalTextBox != null && decimal.TryParse(subtotalTextBox.Text, out decimal valor))
                {
                    suma += valor;
                }
            }

            // Actualiza el label con la suma
            sumasubtotal.Text = suma > 0 ? suma.ToString("0.00") : "0.00";

        }
        // Método para cargar el formulario de registrar pago
        private void FormRegistrarPago_Load(object? sender, EventArgs e)
        {
            try
            {
                textNombre.Text = TextNombre ?? string.Empty;
                textImporte.Text = TextImporte ?? string.Empty;
                textNum.Text = TextNum ?? string.Empty;

                // Inicializar la suma al abrir el formulario
                CalcularSumaSubtotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario de pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Evento para registrar los pagos
        private void RegistrarPago1_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que el importe total sea un número válido
                if (!decimal.TryParse(textImporte.Text, out decimal totalImporte))
                {
                    MessageBox.Show("El importe total es inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal sumaSubtotales = 0;
                List<Pago> detallesPago = new List<Pago>();

                // Recorrer los métodos de pago y subtotales (hasta 7 métodos)
                for (int i = 1; i <= 7; i++)
                {
                    // Obtener los textboxes dinámicamente
                    TextBox? metodoPagoTextBox = this.Controls[$"textMetodoPago{i}"] as TextBox;
                    TextBox? subtotalTextBox = this.Controls[$"textSubtotal{i}"] as TextBox;

                    // Verificar que los textboxes existen y no están vacíos
                    if (metodoPagoTextBox != null && subtotalTextBox != null &&
                        !string.IsNullOrWhiteSpace(metodoPagoTextBox.Text) &&
                        !string.IsNullOrWhiteSpace(subtotalTextBox.Text))
                    {
                        // Validar que el subtotal sea un número válido
                        if (!decimal.TryParse(subtotalTextBox.Text, out decimal subtotal))
                        {
                            MessageBox.Show($"El subtotal en el campo {i} es inválido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        sumaSubtotales += subtotal;

                        // Crear el objeto Pago y agregarlo a la lista
                        detallesPago.Add(new Pago
                        {
                            IDPEDIDO = Convert.ToInt32(textNum.Text),
                            METODOPAGO = metodoPagoTextBox.Text,
                            MONTOPAGO = subtotal,
                        });
                    }
                }

                // Verificar que se haya ingresado al menos un método de pago
                if (detallesPago.Count == 0)
                {
                    MessageBox.Show("Debe ingresar al menos un método de pago válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Verificar que la suma de los subtotales no exceda el importe total
                if (sumaSubtotales > totalImporte)
                {
                    MessageBox.Show("La suma de los subtotales excede el importe total del pedido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Insertar los pagos en la base de datos
                string mensaje;
                bool resultado = CNPago.InsertarPagos(detallesPago, out mensaje);

                if (resultado)
                {
                    MessageBox.Show("Pago registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    LimpiarCampos(); // Método para limpiar campos
                }
                else
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para cancelar y cerrar el formulario
        private void buttonCancelar1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarCampos()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Clear();
                }
            }
        }

        private void textNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
