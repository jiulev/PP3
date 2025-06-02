using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using System.Globalization;
using CapaDatos;


namespace FotoRoman
{
    public partial class FormEditarPagoSeleccionado : Form
    {
        private readonly int idPedido;
        private decimal totalImporte;
        private List<Pago> pagosExistentes;

        public FormEditarPagoSeleccionado(int idPedido)
        {
            InitializeComponent();
            this.idPedido = idPedido;
        }

        private void FormEditarPagoSeleccionado_Load(object sender, EventArgs e)
        {
            try
            {
                var culturaPeso = new CultureInfo("es-AR"); // ✅ formato pesos argentinos

                var pedido = CNPago.ObtenerPedidoPorId(idPedido);

                if (pedido == null)
                {
                    MessageBox.Show("No se encontró el pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Setear los datos del pedido
                textNum.Text = pedido.IDPEDIDO.ToString();
                textNombre.Text = pedido.oCliente?.NOMBRE ?? "";
                textImporte.Text = pedido.TOTAL.ToString("C", culturaPeso); // ✅ muestra $ total
                totalImporte = pedido.TOTAL;

                // Obtener pagos existentes
                pagosExistentes = CNPago.ObtenerPagosDelPedido(idPedido);
                for (int i = 0; i < pagosExistentes.Count && i < 7; i++)
                {
                    textMetodos[i].Text = pagosExistentes[i].METODOPAGO;
                    textSubtotales[i].Text = pagosExistentes[i].MONTOPAGO.ToString("C", culturaPeso); // ✅ $ subtotales
                }

                CalcularSumaSubtotal(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los pagos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularSumaSubtotal(object sender, EventArgs e)
        {
            decimal suma = 0;
            var culturaPeso = new CultureInfo("es-AR"); // ✅ pesos argentinos

            for (int i = 0; i < 7; i++)
            {
                string texto = textSubtotales[i].Text.Replace("$", "").Trim(); // limpia el símbolo si ya estaba
                if (decimal.TryParse(texto, out decimal monto))
                    suma += monto;
            }

            sumasubtotal.Text = suma.ToString("C", culturaPeso); // ✅ total con signo $
        }


        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Pago> nuevosPagos = new List<Pago>();
                decimal sumaTotal = 0;

                for (int i = 0; i < 7; i++)
                {
                    string metodo = textMetodos[i].Text.Trim();
                    string strSubtotal = textSubtotales[i].Text.Replace("$", "").Trim();

                    if (!string.IsNullOrWhiteSpace(metodo) && decimal.TryParse(strSubtotal, out decimal subtotal))
                    {
                        if (subtotal <= 0)
                        {
                            MessageBox.Show($"El subtotal en el campo {i + 1} debe ser mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        nuevosPagos.Add(new Pago
                        {
                            IDPEDIDO = idPedido,
                            METODOPAGO = metodo,
                            MONTOPAGO = subtotal,
                            FECHAPAGO = DateTime.Now
                        });

                        sumaTotal += subtotal;
                    }
                }

                if (nuevosPagos.Count == 0)
                {
                    MessageBox.Show("Debe ingresar al menos un método de pago válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (sumaTotal > totalImporte)
                {
                    MessageBox.Show("La suma de los pagos no puede superar el monto total del pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string mensaje;
                bool resultado = CNPago.ReemplazarPagosDelPedidoManteniendoExistentes(idPedido, nuevosPagos, out mensaje);


                if (resultado)
                {
                    MessageBox.Show("Pago actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
