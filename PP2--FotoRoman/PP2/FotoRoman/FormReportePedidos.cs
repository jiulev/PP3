using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using System.IO;
using System.Diagnostics;
using CapaDatos;
using System.Threading.Tasks; // ✅ agregado para await

namespace CapaPresentacion
{
    public partial class FormReportePedidos : Form
    {
        private List<Cliente> listaClientes;

        public FormReportePedidos()
        {
            InitializeComponent();
            CargarClientes();
            comboEstado.SelectedIndex = 0;
            comboPago.SelectedIndex = 0;
        }

        private void CargarClientes()
        {
            listaClientes = CNCliente.ListarClientes();

            comboCliente.Items.Clear();
            comboCliente.Items.Add("Todos");
            foreach (var cliente in listaClientes)
            {
                comboCliente.Items.Add(cliente);
            }
            comboCliente.SelectedIndex = 0;
        }

        private void CheckDesde_CheckedChanged(object sender, EventArgs e)
        {
            dateDesde.Enabled = checkDesde.Checked;
        }

        private void CheckHasta_CheckedChanged(object sender, EventArgs e)
        {
            dateHasta.Enabled = checkHasta.Checked;
        }

        private async void btnGenerarReporte_Click(object sender, EventArgs e) // ✅ async agregado
        {
            if (checkHasta.Checked && dateHasta.Value.Date > DateTime.Today)
            {
                MessageBox.Show("La fecha 'Hasta' no puede ser posterior al día de hoy.", "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (checkDesde.Checked && checkHasta.Checked && dateDesde.Value.Date > dateHasta.Value.Date)
            {
                MessageBox.Show("La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'.", "Rango inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? idCliente = null;
            if (comboCliente.SelectedItem is Cliente clienteSeleccionado)
                idCliente = clienteSeleccionado.IDCliente;

            string estado = comboEstado.SelectedItem.ToString();
            if (estado == "Todos") estado = null;

            string filtroPago = comboPago.SelectedItem.ToString();
            DateTime? fechaDesde = checkDesde.Checked ? dateDesde.Value.Date : null;
            DateTime? fechaHasta = checkHasta.Checked ? dateHasta.Value.Date : null;

            var pedidos = CNPedido.ObtenerPedidosFiltradosParaReporte(
                idCliente ?? 0,
                estado ?? "Todos",
                filtroPago,
                fechaDesde ?? DateTime.MinValue,
                fechaHasta ?? DateTime.MaxValue
            );

            string html = await GenerarHTML(pedidos); // ✅ await
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "reporte_pedidos.html");
            File.WriteAllText(path, html);
            Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
        }

        private async Task<string> GenerarHTML(List<Pedido> pedidos) // ✅ async Task
        {
            int pendientes = pedidos.Count(p => p.ESTADO == "Pendiente");
            int enProceso = pedidos.Count(p => p.ESTADO.Equals("En proceso", StringComparison.OrdinalIgnoreCase));
            int finalizados = pedidos.Count(p => p.ESTADO == "Finalizado");

            int sinPago = pedidos.Count(p => p.EstadoPago.Equals("Sin pagos", StringComparison.OrdinalIgnoreCase));
            int parcial = pedidos.Count(p => p.EstadoPago.Equals("Pagado parcial", StringComparison.OrdinalIgnoreCase));
            int totalPago = pedidos.Count(p => p.EstadoPago.Equals("Pagado total", StringComparison.OrdinalIgnoreCase));

            int totalPedidosSistema = CNPedido.ContarTodosLosPedidos();

            string rows = "";
            foreach (var p in pedidos)
            {
                string telefono = p.oCliente.TELEFONO?.Replace("+", "").Replace(" ", "").Trim();

                var pagos = CNPedido.ObtenerPagosDelPedido(p.IDPEDIDO);
                decimal montoPagado = pagos.Sum(pg => pg.MONTOPAGO);
                decimal pendiente = p.TOTAL - montoPagado;

                string linkPago = "";
                if (pendiente > 0)
                {
                    linkPago = await MercadoPagoService.GenerarLinkPago($"Pedido #{p.IDPEDIDO}", pendiente);
                }

                string mensaje = $"Hola {p.oCliente.NOMBRE}, te informamos el estado de tu pedido #{p.IDPEDIDO}.\n" +
                                 $"Estado: {p.ESTADO}\n" +
                                 $"Cobro: {p.EstadoPago}\n" +
                                 $"Total: ${p.TOTAL:F2}\n";

                if (pendiente > 0 && !string.IsNullOrEmpty(linkPago))
                {
                    mensaje += $"\n💳 Podés abonar tu pedido con este link:\n{linkPago}\n" +
                               $"📲 Una vez abonado, notificanos respondiendo este mensaje o escribiendo a info@fotoroman.com.ar\n";
                }

                mensaje += "\n¡Gracias por confiar en nosotros! 📸";

                string urlWhatsApp = !string.IsNullOrEmpty(telefono)
                    ? $"https://wa.me/{telefono}?text={Uri.EscapeDataString(mensaje)}"
                    : "#";

                string boton = !string.IsNullOrEmpty(telefono)
                    ? $"<a href='{urlWhatsApp}' target='_blank' style='color:#00f7ff;text-decoration:none;'>📲 Notificar</a>"
                    : "<span style='color:gray;'>Sin Teléfono</span>";

                rows += $"<tr><td>{p.IDPEDIDO}</td><td>{p.oCliente.NOMBRE}</td><td>{p.FECHAPEDIDO:dd/MM/yyyy}</td><td>{p.ESTADO}</td><td>{p.EstadoPago}</td><td>${p.TOTAL:F2}</td><td>{boton}</td></tr>";
            }

            // Resto del HTML se mantiene igual (desde string html = $@"...) sin cambios
            string html = $@"
<!DOCTYPE html>
<html lang='es'>
<head>
    <meta charset='UTF-8'>
    <title>Reporte de Pedidos</title>
    <script src='https://cdn.jsdelivr.net/npm/chart.js'></script>
    <style>
        body {{
            font-family: 'Segoe UI', sans-serif;
            background: #0f111a;
            color: #00f7ff;
            padding: 40px;
        }}
        h2 {{
            text-align: center;
            font-size: 36px;
            color: #00e6e6;
            text-shadow: 0 0 10px #00e6e6;
            margin-bottom: 40px;
        }}
        .container {{
            display: flex;
            flex-direction: column;
            align-items: center;
            gap: 40px;
        }}
        .table-container {{
            width: 90%;
            max-height: 300px;
            overflow-y: auto;
            background: #1c1e2e;
            border-radius: 15px;
            box-shadow: 0 0 20px rgba(0,255,255,0.2);
        }}
        table {{
            width: 100%;
            border-collapse: collapse;
            color: #ffffff;
        }}
        th, td {{
            padding: 14px;
            text-align: center;
            border-bottom: 1px solid #2d2f3d;
        }}
        th {{
            background-color: #00e6e6;
            color: #0f111a;
            text-shadow: none;
        }}
        tr:nth-child(even) {{
            background-color: #23263a;
        }}
        tr:hover {{
            background-color: #2d314a;
        }}
        .charts {{
            display: flex;
            flex-wrap: wrap;
            justify-content: center;
            gap: 40px;
        }}
        canvas {{
            width: 280px !important;
            height: 280px !important;
            background: #1c1e2e;
            border-radius: 15px;
            box-shadow: 0 0 15px rgba(0,255,255,0.15);
            padding: 20px;
        }}
    </style>
</head>
<body>
    <h2>📋 Reporte de Pedidos</h2>
    <div class='container'>
        <div class='table-container'>
            <table>
           <thead>
    <tr>
        <th>ID</th>
        <th>Cliente</th>
        <th>Fecha</th>
        <th>Estado</th>
        <th>Pago</th>
        <th>Total</th>
        <th>Notificar</th>
    </tr>
</thead>

                <tbody>
                    {rows}
                </tbody>
            </table>
        </div>
        <div class='charts'>
            <canvas id='chartEstado'></canvas>
            <canvas id='chartPago'></canvas>
            <canvas id='chartComparativo'></canvas>
        </div>
    </div>
    <script>
        const ctxEstado = document.getElementById('chartEstado').getContext('2d');
        new Chart(ctxEstado, {{
            type: 'doughnut',
            data: {{
                labels: ['Pendientes', 'En proceso', 'Finalizados'],
                datasets: [{{
                    data: [{pendientes}, {enProceso}, {finalizados}],
                    backgroundColor: ['#f1c40f', '#2980b9', '#27ae60'],
                    borderWidth: 2,
                    borderColor: '#0f111a',
                }}]
            }},
            options: {{
                plugins: {{
                    title: {{
                        display: true,
                        text: 'Estados del Pedido',
                        color: '#00f7ff',
                        font: {{
                            size: 16
                        }}
                    }},
                    legend: {{
                        labels: {{
                            color: '#00f7ff'
                        }},
                        position: 'bottom'
                    }}
                }}
            }}
        }});

        const ctxPago = document.getElementById('chartPago').getContext('2d');
        new Chart(ctxPago, {{
            type: 'doughnut',
            data: {{
                labels: ['Sin pagos', 'Parcial', 'Total'],
                datasets: [{{
                    data: [{sinPago}, {parcial}, {totalPago}],
                    backgroundColor: ['#e74c3c', '#f39c12', '#2ecc71'],
                    borderWidth: 2,
                    borderColor: '#0f111a',
                }}]
            }},
            options: {{
                plugins: {{
                    title: {{
                        display: true,
                        text: 'Estados del Pago',
                        color: '#00f7ff',
                        font: {{
                            size: 16
                        }}
                    }},
                    legend: {{
                        labels: {{
                            color: '#00f7ff'
                        }},
                        position: 'bottom'
                    }}
                }}
            }}
        }});

        const ctxComparativo = document.getElementById('chartComparativo').getContext('2d');
        new Chart(ctxComparativo, {{
            type: 'doughnut',
            data: {{
                labels: ['Pedidos del Filtro', 'Resto del Sistema'],
                datasets: [{{
                    data: [{pedidos.Count}, {Math.Max(0, totalPedidosSistema - pedidos.Count)}],
                    backgroundColor: ['#8e44ad', '#95a5a6'],
                    borderWidth: 2,
                    borderColor: '#0f111a',
                }}]
            }},
            options: {{
                plugins: {{
                    title: {{
                        display: true,
                        text: 'Filtro vs Total Sistema',
                        color: '#00f7ff',
                        font: {{
                            size: 16
                        }}
                    }},
                    legend: {{
                        labels: {{
                            color: '#00f7ff'
                        }},
                        position: 'bottom'
                    }}
                }}
            }}
        }});
    </script>
</body>
</html>";
            return html;
        }


    }
}