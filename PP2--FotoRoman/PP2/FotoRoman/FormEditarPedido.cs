using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;


namespace FotoRoman
{
    public partial class FormEditarPedido : Form
    {
        private Pedido pedidoActual;
        private List<DetallePedido> detallesOriginales;

        public FormEditarPedido(Pedido pedido, List<DetallePedido> detalles)
        {
            InitializeComponent();
            pedidoActual = pedido;
            detallesOriginales = detalles;
        }

        private void FormEditarPedido_Load(object sender, EventArgs e)
        {
            dataGridViewDetallePedido.CellClick += dataGridViewDetallePedido_CellClick;

            // Cargar datos del pedido (cliente, estado)
            CargarDatosPedido();

            // Cargar detalles en el DataGridView
            RefrescarDataGrid();

            // Agrega botones si no están
            if (!dataGridViewDetallePedido.Columns.Contains("Editar"))
            {
                var btnEditar = new DataGridViewButtonColumn
                {
                    Name = "Editar",
                    HeaderText = "Editar",
                    Text = "✏️",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewDetallePedido.Columns.Add(btnEditar);
            }

            if (!dataGridViewDetallePedido.Columns.Contains("Eliminar"))
            {
                var btnEliminar = new DataGridViewButtonColumn
                {
                    Name = "Eliminar",
                    HeaderText = "Eliminar",
                    Text = "🗑️",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewDetallePedido.Columns.Add(btnEliminar);
            }

            // Deshabilitar combo de cliente para que no se edite
            comboBoxClientes.Enabled = false;
            comboBoxClientes.BackColor = SystemColors.Control; // Fondo gris claro
        }


        private void RefrescarDataGrid()
        {
            dataGridViewDetallePedido.DataSource = null;
            dataGridViewDetallePedido.DataSource = detallesOriginales.Select(d => new
            {
                IdProducto = d.oProducto.IdProducto,
                Producto = d.oProducto.Nombre,
                Cantidad = d.CANTIDAD,
                PrecioUnitario = d.PRECIOUNITARIO,
                Subtotal = d.SUBTOTAL
            }).ToList();

            CalcularTotal();
        }


        private void dataGridViewDetallePedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridViewDetallePedido.Columns[e.ColumnIndex].Name == "Eliminar")
                {
                    detallesOriginales.RemoveAt(e.RowIndex);
                    RefrescarDataGrid();
                }
                else if (dataGridViewDetallePedido.Columns[e.ColumnIndex].Name == "Editar")
                {
                    var detalle = detallesOriginales[e.RowIndex];

                    string inputCantidad = Interaction.InputBox("Editar cantidad:", "Cantidad", detalle.CANTIDAD.ToString());
                    string inputPrecio = Interaction.InputBox("Editar precio unitario:", "Precio", detalle.PRECIOUNITARIO.ToString("F2"));

                    if (int.TryParse(inputCantidad, out int nuevaCantidad) &&
                        decimal.TryParse(inputPrecio, out decimal nuevoPrecio))
                    {
                        detalle.CANTIDAD = nuevaCantidad;
                        detalle.PRECIOUNITARIO = nuevoPrecio;
                        detalle.SUBTOTAL = nuevaCantidad * nuevoPrecio;

                        RefrescarDataGrid();
                    }
                }
            }
        }



        private void CargarDatosPedido()
        {
            var clientes = CNPedido.ListarTodosLosClientes();

            comboBoxClientes.Enabled = false;
            comboBoxClientes.BackColor = SystemColors.Control;

            comboBoxClientes.DataSource = null; // importante para resetear
            comboBoxClientes.DisplayMember = "NOMBRE";
            comboBoxClientes.ValueMember = "IDCliente";
            comboBoxClientes.DataSource = clientes;

            // Buscar el índice del cliente y setearlo
            int index = clientes.FindIndex(c => c.IDCliente == pedidoActual.IDCliente);

            // Solo seteamos si lo encuentra, sin mostrar cartel
            if (index >= 0)
            {
                comboBoxClientes.SelectedIndex = index;
            }


            // Estado
            comboBoxEstado.Items.Clear();
            comboBoxEstado.Items.AddRange(new string[] { "Pendiente", "En proceso", "Finalizado" });
            comboBoxEstado.SelectedItem = pedidoActual.ESTADO;

            CalcularTotal();
        }





        private decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow fila in dataGridViewDetallePedido.Rows)
            {
                if (fila.IsNewRow) continue;
                total += Convert.ToDecimal(fila.Cells["Subtotal"].Value);
            }

            labelTotal.Text = $"Total: ${total:F2}";
            return total;
        }

        private void buttonGuardarCambios_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxClientes.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBoxClientes.SelectedIndex != -1 && comboBoxClientes.SelectedItem is Cliente clienteSeleccionado)
                {
                    pedidoActual.IDCliente = clienteSeleccionado.IDCliente;
                }
                else
                {
                    // Si no se seleccionó un cliente distinto, conservar el cliente original
                    // No hacer nada, se mantiene pedidoActual.IDCliente
                }



                if (comboBoxEstado.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un estado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                pedidoActual.ESTADO = comboBoxEstado.SelectedItem.ToString();
                pedidoActual.FECHAPEDIDO = DateTime.Now;
                pedidoActual.TOTAL = CalcularTotal();

                List<DetallePedido> nuevosDetalles = new List<DetallePedido>();

                foreach (DataGridViewRow fila in dataGridViewDetallePedido.Rows)
                {
                    if (fila.IsNewRow) continue;

                    DetallePedido detalle = new DetallePedido
                    {
                        oProducto = new Producto
                        {
                            IdProducto = Convert.ToInt32(fila.Cells["IdProducto"].Value),
                            Nombre = fila.Cells["Producto"].Value.ToString()
                        },
                        CANTIDAD = Convert.ToInt32(fila.Cells["Cantidad"].Value),
                        PRECIOUNITARIO = Convert.ToDecimal(fila.Cells["PrecioUnitario"].Value)
                    };
                    detalle.SUBTOTAL = detalle.CANTIDAD * detalle.PRECIOUNITARIO;

                    nuevosDetalles.Add(detalle);
                }
                MessageBox.Show($"IDPedido: {pedidoActual.IDPEDIDO}\nCliente: {pedidoActual.IDCliente}\nEstado: {pedidoActual.ESTADO}\nTotal: {pedidoActual.TOTAL}");

             


                if (CNPedido.ActualizarPedido(pedidoActual, nuevosDetalles, out string mensaje))
                {
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show($"Error al guardar cambios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void buttonAgregarItem_Click(object sender, EventArgs e)
        {
            using (FormAgregarItem formAgregar = new FormAgregarItem())
            {
                if (formAgregar.ShowDialog() == DialogResult.OK)
                {
                    var nuevoDetalle = formAgregar.DetalleAgregado;

                    // Agregar directamente a la lista original
                    detallesOriginales.Add(nuevoDetalle);

                    // Refrescar el DataGridView con todos los detalles actuales
                    dataGridViewDetallePedido.DataSource = null;
                    dataGridViewDetallePedido.DataSource = detallesOriginales.Select(d => new
                    {
                        IdProducto = d.oProducto.IdProducto,
                        Producto = d.oProducto.Nombre,
                        Cantidad = d.CANTIDAD,
                        PrecioUnitario = d.PRECIOUNITARIO,
                        Subtotal = d.SUBTOTAL
                    }).ToList();

                    CalcularTotal();
                }
            }
        }




        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}