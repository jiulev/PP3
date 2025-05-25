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
        private readonly List<DetallePedido> detallesOriginalesOriginal;
        private int cantidadOriginalDeItems;

        private List<DetallePedido> detallesOriginales;

        public FormEditarPedido(Pedido pedido, List<DetallePedido> detalles)
        {
            InitializeComponent();
            pedidoActual = pedido;
            detallesOriginales = new List<DetallePedido>(detalles); // Copia editable
            detallesOriginalesOriginal = new List<DetallePedido>(detalles); // Copia original para comparación
            cantidadOriginalDeItems = detalles.Count;

        }


        private void FormEditarPedido_Load(object sender, EventArgs e)
        {
            textBoxObservaciones.Text = pedidoActual.OBSERVACIONES ?? string.Empty;

            // Habilitar solo si el estado es Pendiente
            textBoxObservaciones.ReadOnly = !pedidoActual.ESTADO.Equals("Pendiente", StringComparison.OrdinalIgnoreCase);




            // Cargar datos del pedido (cliente, estado)
            CargarDatosPedido();

            // Cargar detalles en el DataGridView
            RefrescarDataGrid();

            // Eliminar las columnas si ya existen para evitar duplicados
            if (dataGridViewDetallePedido.Columns.Contains("Editar"))
                dataGridViewDetallePedido.Columns.Remove("Editar");

            if (dataGridViewDetallePedido.Columns.Contains("Eliminar"))
                dataGridViewDetallePedido.Columns.Remove("Eliminar");

            // Agregar botones Editar y Eliminar (al final)
            var btnEditar = new DataGridViewButtonColumn
            {
                Name = "Editar",
                HeaderText = "Editar",
                Text = "✏️",
                UseColumnTextForButtonValue = true,
                Width = 60,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };
            dataGridViewDetallePedido.Columns.Add(btnEditar);

            var btnEliminar = new DataGridViewButtonColumn
            {
                Name = "Eliminar",
                HeaderText = "Eliminar",
                Text = "🗑️",
                UseColumnTextForButtonValue = true,
                Width = 70,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };
            dataGridViewDetallePedido.Columns.Add(btnEliminar);

            // 🎨 Estética general del DataGridView
            dataGridViewDetallePedido.DefaultCellStyle.Font = new Font("Yu Gothic", 10);
            dataGridViewDetallePedido.ColumnHeadersDefaultCellStyle.Font = new Font("Yu Gothic", 10, FontStyle.Bold);
            dataGridViewDetallePedido.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridViewDetallePedido.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridViewDetallePedido.EnableHeadersVisualStyles = false;
            dataGridViewDetallePedido.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewDetallePedido.RowTemplate.Height = 28;

            // Validar estado para habilitar o no agregar ítem
            if (pedidoActual.ESTADO.Equals("En proceso", StringComparison.OrdinalIgnoreCase))
            {
                buttonAgregarItem.Enabled = false;
            }

            if (pedidoActual.ESTADO.Equals("Finalizado", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Este pedido está finalizado y no puede ser editado.", "Pedido finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonAgregarItem.Enabled = false;
                buttonGuardarCambios.Enabled = false;
                dataGridViewDetallePedido.ReadOnly = true;
                comboBoxEstado.Enabled = false;
            }

            // Deshabilitar combo de cliente para que no se edite
            comboBoxClientes.Enabled = false;
            comboBoxClientes.BackColor = SystemColors.Control;
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
            // Tomar el estado actual seleccionado en el combo
            string estadoActual = comboBoxEstado.SelectedItem?.ToString() ?? "";

            if (estadoActual == "En proceso" || estadoActual == "Finalizado")
            {
                MessageBox.Show("No se pueden eliminar o editar ítems en un pedido en proceso o finalizado.", "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // El resto sigue igual
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
                if (!textBoxObservaciones.ReadOnly)
                    pedidoActual.OBSERVACIONES = textBoxObservaciones.Text;

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
                string estadoAnterior = pedidoActual.ESTADO;
                string estadoNuevo = comboBoxEstado.SelectedItem.ToString();

                // Validación: no se puede cambiar a "En proceso" si se agregaron o eliminaron ítems
                if (estadoAnterior == "Pendiente" && estadoNuevo == "En proceso")
                {
                    if (detallesOriginales.Count != cantidadOriginalDeItems)
                    {
                        MessageBox.Show("No se puede cambiar el estado a 'En proceso' si se agregaron o eliminaron ítems del pedido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }





                if (comboBoxEstado.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un estado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Validar que solo se puede pasar a Finalizado si antes estaba En proceso
                if (comboBoxEstado.SelectedItem.ToString() == "Finalizado" &&
                    pedidoActual.ESTADO != "En proceso")
                {
                    MessageBox.Show("Solo se puede finalizar un pedido que está en proceso.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                pedidoActual.IDUsuario = 3; // 👈 setear el ID del usuario que está editando



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