using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

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
                textImporte.Text = pedido.TOTAL.ToString("0.00");
                totalImporte = pedido.TOTAL;

                // Obtener pagos existentes
                pagosExistentes = CNPago.ObtenerPagosDelPedido(idPedido);
                for (int i = 0; i < pagosExistentes.Count && i < 7; i++)
                {
                    textMetodos[i].Text = pagosExistentes[i].METODOPAGO;
                    textSubtotales[i].Text = pagosExistentes[i].MONTOPAGO.ToString("0.00");
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
            for (int i = 0; i < 7; i++)
            {
                if (decimal.TryParse(textSubtotales[i].Text, out decimal monto))
                    suma += monto;
            }
            sumasubtotal.Text = suma.ToString("0.00");
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
                    string strSubtotal = textSubtotales[i].Text.Trim();

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
                            MONTOPAGO = subtotal
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
                    MessageBox.Show("La suma de los subtotales no puede superar el importe total del pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Aquí podrías borrar los pagos anteriores (DELETE) e insertar los nuevos.
                string mensaje;
                bool resultado = CNPago.ReemplazarPagosDelPedido(idPedido, nuevosPagos, out mensaje); // nuevo método

                if (resultado)
                {
                    MessageBox.Show("Pago editado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
