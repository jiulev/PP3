using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FotoRoman
{
    public partial class FormSeleccionarPedido : Form
    {
        private List<Pedido> pedidosOriginales; 
        public Pedido PedidoSeleccionado { get; private set; }

        public FormSeleccionarPedido(List<Pedido> pedidos)
        {
            InitializeComponent();

            // Guardamos la lista original
            pedidosOriginales = pedidos;

            // Mostrar todos al inicio
            MostrarPedidos(pedidosOriginales);

            // Estilo visual
            dataGridViewPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPedidos.MultiSelect = false;
            dataGridViewPedidos.DefaultCellStyle.Font = new Font("Yu Gothic", 9);
            dataGridViewPedidos.DefaultCellStyle.SelectionBackColor = Color.Silver;
            dataGridViewPedidos.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridViewPedidos.RowHeadersDefaultCellStyle.BackColor = Color.Gainsboro;


            dataGridViewPedidos.ColumnHeadersDefaultCellStyle.Font = new Font("Yu Gothic", 10, FontStyle.Bold);
            dataGridViewPedidos.EnableHeadersVisualStyles = false;
            dataGridViewPedidos.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Silver;
            dataGridViewPedidos.RowHeadersDefaultCellStyle.BackColor = Color.Gainsboro; // fondo normal
            dataGridViewPedidos.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Silver; // fondo al seleccionar

            dataGridViewPedidos.RowHeadersDefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridViewPedidos.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
            dataGridViewPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPedidos.RowPrePaint += DataGridViewPedidos_RowPrePaint;

            // ComboBox de filtro de estado
            comboBoxEstadoFiltro.Items.Clear(); // ✅ Evita duplicados
            comboBoxEstadoFiltro.Items.AddRange(new string[] { "Todos", "Pendiente", "En proceso", "Finalizado" });
            comboBoxEstadoFiltro.SelectedIndex = 0;

            comboBoxEstadoFiltro.SelectedIndexChanged += comboBoxEstadoFiltro_SelectedIndexChanged;
            dataGridViewPedidos.CurrentCell = null; // 👈 Quita la celda activa
            dataGridViewPedidos.CellStateChanged += (s, e) =>
            {
                dataGridViewPedidos.CurrentCell = null;
            };
            // Esto evita que se seleccione una celda activa automáticamente
            dataGridViewPedidos.CurrentCell = null;

            // Esto intercepta cuando se intenta activar una celda y la vuelve a desactivar
            dataGridViewPedidos.CellStateChanged += (s, e) =>
            {
                dataGridViewPedidos.CurrentCell = null;
            };

            // Esto también evita que quede activa una columna al hacer clic sobre el encabezado
            dataGridViewPedidos.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Gainsboro;
            dataGridViewPedidos.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;


        }
        private void MostrarPedidos(List<Pedido> lista)
        {
            // Limpiar columnas anteriores
            dataGridViewPedidos.Columns.Clear();

            // Asignar solo las columnas necesarias manualmente
            var datos = lista.Select(p => new
            {
                IDPedido = p.IDPEDIDO,
                Fecha = p.FECHAPEDIDO.ToString("dd/MM/yyyy"),
                Estado = p.ESTADO
            }).ToList();

            dataGridViewPedidos.DataSource = datos;
        }


        private void comboBoxEstadoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string estado = comboBoxEstadoFiltro.SelectedItem.ToString();

            var filtrados = estado == "Todos"
                ? pedidosOriginales
                : pedidosOriginales.Where(p => p.ESTADO.Equals(estado, StringComparison.OrdinalIgnoreCase)).ToList();

            MostrarPedidos(filtrados);
        }

        private void DataGridViewPedidos_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dataGridViewPedidos.Rows[e.RowIndex];
            var estado = row.Cells["Estado"].Value?.ToString();

            if (estado == "Finalizado")
            {
                row.DefaultCellStyle.BackColor = Color.LightCoral; // rojo suave
                row.DefaultCellStyle.ForeColor = Color.White;
            }
            else if (estado == "En proceso")
            {
                row.DefaultCellStyle.BackColor = Color.LightGreen;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
            else
            {
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void buttonSeleccionar_Click(object sender, EventArgs e)
        {
            if (dataGridViewPedidos.SelectedRows.Count > 0)
            {
                // Obtener el ID del pedido seleccionado
                int idPedido = (int)dataGridViewPedidos.SelectedRows[0].Cells["IDPedido"].Value;

                // Asignar el pedido seleccionado
                PedidoSeleccionado = CNPedido.BuscarPedidoPorId(idPedido);

                // Cerrar el formulario y devolver el resultado
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un pedido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
