using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Windows.Forms.VisualStyles;


namespace FotoRoman
{
    public partial class FormEditarPedido : Form
    {
        private Pedido pedidoActual;
        private readonly List<DetallePedido> detallesOriginalesOriginal;
        private int cantidadOriginalDeItems;
        private bool estadoEditable = true;



        private List<DetallePedido> detallesOriginales;

        public FormEditarPedido(Pedido pedido, List<DetallePedido> detalles)
        {
            InitializeComponent();
            pedidoActual = pedido;

            // Copia editable
            detallesOriginales = new List<DetallePedido>(detalles);

            // 🔁 Clon profundo para que los cambios no afecten la original
            detallesOriginalesOriginal = detalles.Select(d => new DetallePedido
            {
                oProducto = new Producto
                {
                    IdProducto = d.oProducto.IdProducto,
                    Nombre = d.oProducto.Nombre
                },
                CANTIDAD = d.CANTIDAD,
                PRECIOUNITARIO = d.PRECIOUNITARIO,
                SUBTOTAL = d.SUBTOTAL
            }).ToList();

            cantidadOriginalDeItems = detalles.Count;
        }



        private void FormEditarPedido_Load(object sender, EventArgs e)
        {
            textBoxObservaciones.Text = pedidoActual.OBSERVACIONES ?? string.Empty;

            // Habilitar edición solo si el estado es Pendiente
            textBoxObservaciones.ReadOnly = !pedidoActual.ESTADO.Equals("Pendiente", StringComparison.OrdinalIgnoreCase);

            // Cargar datos (cliente, estado)
            CargarDatosPedido();

            // Asociar eventos
            comboBoxEstado.SelectedIndexChanged += comboBoxEstado_SelectedIndexChanged;
            buttonEliminarItem.Click += buttonEliminarItem_Click;
            dataGridViewDetallePedido.CellClick += dataGridViewDetallePedido_CellClick;

            // Cargar detalles
            RefrescarDataGrid();

            // Quitar columnas si ya estaban
            if (dataGridViewDetallePedido.Columns.Contains("Editar"))
                dataGridViewDetallePedido.Columns.Remove("Editar");
            if (dataGridViewDetallePedido.Columns.Contains("Eliminar"))
                dataGridViewDetallePedido.Columns.Remove("Eliminar");

            // Agregar columna Editar
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

            // Aplicar estilo visual
            dataGridViewDetallePedido.DefaultCellStyle.Font = new Font("Yu Gothic", 10);
            dataGridViewDetallePedido.ColumnHeadersDefaultCellStyle.Font = new Font("Yu Gothic", 10, FontStyle.Bold);
            dataGridViewDetallePedido.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridViewDetallePedido.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridViewDetallePedido.EnableHeadersVisualStyles = false;
            dataGridViewDetallePedido.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewDetallePedido.RowTemplate.Height = 28;

            // Estado original del pedido (para bloquear si ya está Finalizado)
            if (pedidoActual.ESTADO.Equals("Finalizado", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Este pedido está finalizado. Solo se permite visualizarlo. Si querés cambiar su estado, hacelo manualmente y luego presioná Guardar.", "Pedido finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                buttonAgregarItem.Enabled = false;
                buttonEliminarItem.Enabled = false;

                dataGridViewDetallePedido.ReadOnly = true;

                // ❗ NO BLOQUEAMOS comboBoxEstado NI Guardar Cambios aquí
                // Permitimos que se modifique el estado (ej. En proceso ➡ Finalizado) y se pueda guardar
            }

            else if (pedidoActual.ESTADO.Equals("En proceso", StringComparison.OrdinalIgnoreCase))
            {
                // Solo se podrá editar precio unitario
                buttonAgregarItem.Enabled = false;
                buttonEliminarItem.Enabled = false;

                buttonAgregarItem.BackColor = Color.LightGray;
                buttonEliminarItem.BackColor = Color.LightGray;

                dataGridViewDetallePedido.ReadOnly = false;

                MessageBox.Show("El pedido está en proceso. Solo se permite modificar el precio unitario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Estado Pendiente
                buttonAgregarItem.Enabled = true;
                buttonEliminarItem.Enabled = true;

                buttonAgregarItem.BackColor = SystemColors.Control;
                buttonEliminarItem.BackColor = SystemColors.Control;

                dataGridViewDetallePedido.ReadOnly = false;
            }

            // Combo cliente solo lectura
            comboBoxClientes.Enabled = false;
            comboBoxClientes.BackColor = SystemColors.Control;
        }



        private void AgregarColumnasDeAcciones()
        {
            // Eliminar si ya existen
            if (dataGridViewDetallePedido.Columns.Contains("Editar"))
                dataGridViewDetallePedido.Columns.Remove("Editar");
            if (dataGridViewDetallePedido.Columns.Contains("Eliminar"))
                dataGridViewDetallePedido.Columns.Remove("Eliminar");

            // Botón Editar
            var btnEditar = new DataGridViewButtonColumn
            {
                Name = "Editar",
                HeaderText = "Editar",
                Text = "✏️",
                UseColumnTextForButtonValue = true,
                Width = 60,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };
            dataGridViewDetallePedido.Columns.Add(btnEditar);   }
        // Botón Eliminar
        //var btnEliminar = new DataGridViewDisableButtonColumn
        //{
        //  Name = "Eliminar",
        // HeaderText = "Eliminar",
        // Text = "🗑️",
        // UseColumnTextForButtonValue = true,
        //  Width = 70,
        // DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
        // };
        // dataGridViewDetallePedido.Columns.Add(btnEliminar);
        //  }

        public class DataGridViewDisableButtonColumn : DataGridViewButtonColumn
        {
            public override DataGridViewCell CellTemplate
            {
                get => base.CellTemplate;
                set
                {
                    if (value != null &&
                        !value.GetType().IsAssignableFrom(typeof(DataGridViewDisableButtonCell)))
                    {
                        throw new InvalidCastException("Debe ser una celda de tipo DataGridViewDisableButtonCell");
                    }
                    base.CellTemplate = value;
                }
            }

            public DataGridViewDisableButtonColumn()
            {
                this.CellTemplate = new DataGridViewDisableButtonCell();
            }
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

            AgregarColumnasDeAcciones(); // 🔁 Reagrega los botones al final

            CalcularTotal();
        }
        private void comboBoxEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nuevoEstado = comboBoxEstado.SelectedItem?.ToString() ?? "";

            if (pedidoActual.ESTADO == "Finalizado")
            {
                // Si el pedido original ya era Finalizado, no se puede editar nada
                buttonAgregarItem.Enabled = false;
                buttonEliminarItem.Enabled = false;
                buttonGuardarCambios.Enabled = false;
                dataGridViewDetallePedido.ReadOnly = true;
                MessageBox.Show("Este pedido está finalizado. No se puede modificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Si el usuario cambia el estado a Finalizado, no bloqueamos el Guardar
            if (nuevoEstado == "Pendiente")
            {
                buttonAgregarItem.Enabled = true;
                buttonEliminarItem.Enabled = true;
                buttonGuardarCambios.Enabled = true;

                buttonAgregarItem.BackColor = SystemColors.Control;
                buttonEliminarItem.BackColor = SystemColors.Control;

                dataGridViewDetallePedido.ReadOnly = false;
            }
            else if (nuevoEstado == "En proceso")
            {
                buttonAgregarItem.Enabled = false;
                buttonEliminarItem.Enabled = false;
                buttonGuardarCambios.Enabled = true;

                buttonAgregarItem.BackColor = Color.LightGray;
                buttonEliminarItem.BackColor = Color.LightGray;

                dataGridViewDetallePedido.ReadOnly = false;

                MessageBox.Show("El pedido está en proceso. Solo se permite modificar el precio unitario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (nuevoEstado == "Finalizado")
            {
                buttonAgregarItem.Enabled = false;
                buttonEliminarItem.Enabled = false;
                buttonGuardarCambios.Enabled = true; // ✅ Te permite guardar el cambio de estado

                buttonAgregarItem.BackColor = Color.LightGray;
                buttonEliminarItem.BackColor = Color.LightGray;

                dataGridViewDetallePedido.ReadOnly = true;

                MessageBox.Show("Al finalizar el pedido, no se podrán realizar más modificaciones.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void dataGridViewDetallePedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string estadoActual = comboBoxEstado.SelectedItem?.ToString() ?? "";

            if (dataGridViewDetallePedido.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                if (estadoActual == "Pendiente")
                {
                    detallesOriginales.RemoveAt(e.RowIndex);
                    RefrescarDataGrid();
                    comboBoxEstado.Enabled = false;
                    estadoEditable = false;
                    MessageBox.Show("Se eliminó un ítem. Ya no se puede cambiar el estado del pedido.", "Estado bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pueden eliminar ítems en un pedido en proceso o finalizado.", "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            if (dataGridViewDetallePedido.Columns[e.ColumnIndex].Name == "Editar")
            {
                if (estadoActual == "Finalizado")
                {
                    MessageBox.Show("No se pueden editar ítems en un pedido finalizado.", "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var detalle = detallesOriginales[e.RowIndex];

                DialogResult resultado = MessageBox.Show(
                    "Usted podrá modificar únicamente el precio unitario de este producto.",
                    "Modificar precio",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information
                );

                if (resultado == DialogResult.OK)
                {
                    string inputPrecio = Interaction.InputBox(
                        "Ingrese el nuevo precio unitario:",
                        "Editar Precio",
                        detalle.PRECIOUNITARIO.ToString("F2")
                    );

                    if (decimal.TryParse(inputPrecio, out decimal nuevoPrecio))
                    {
                        detalle.PRECIOUNITARIO = nuevoPrecio;
                        detalle.SUBTOTAL = detalle.CANTIDAD * nuevoPrecio;
                        RefrescarDataGrid();
                    }
                    else
                    {
                        MessageBox.Show("El precio ingresado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            // Habilitar botón eliminar si está en pendiente y se seleccionó una fila
            buttonEliminarItem.Enabled = (estadoActual == "Pendiente") && dataGridViewDetallePedido.Rows[e.RowIndex].Selected;
        }



        private void buttonEliminarItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewDetallePedido.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccioná una fila para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var filaSeleccionada = dataGridViewDetallePedido.SelectedRows[0];
            int index = filaSeleccionada.Index;

            if (index >= 0 && index < detallesOriginales.Count)
            {
                detallesOriginales.RemoveAt(index);
                RefrescarDataGrid();

                comboBoxEstado.Enabled = false;
                estadoEditable = false;

                MessageBox.Show("Se eliminó un ítem. Ya no se puede cambiar el estado del pedido.", "Estado bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CargarDatosPedido()
        {
            try
            {
                var clientes = CNPedido.ListarTodosLosClientes();

                // Si el cliente del pedido no está en la lista, agregarlo
                if (!clientes.Any(c => c.IDCliente == pedidoActual.IDCliente))
                {
                    clientes.Add(pedidoActual.oCliente);
                }


                comboBoxClientes.DataSource = null;
                comboBoxClientes.DisplayMember = "NOMBRE";
                comboBoxClientes.ValueMember = "IDCliente";
                comboBoxClientes.DataSource = clientes;
               


                // ✅ Buscar cliente por ID y setear SelectedIndex
                int index = clientes.FindIndex(c => c.IDCliente == pedidoActual.IDCliente);
                if (index >= 0)
                {
                    comboBoxClientes.SelectedIndex = index;
                }
                else
                {
                    MessageBox.Show("Cliente del pedido no encontrado en la lista actual.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Estado del pedido
                comboBoxEstado.Items.Clear();
                comboBoxEstado.Items.AddRange(new string[] { "Pendiente", "En proceso", "Finalizado" });
                comboBoxEstado.SelectedItem = pedidoActual.ESTADO;

                CalcularTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del pedido: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                string observacionesOriginales = pedidoActual.OBSERVACIONES ?? "";

                if (!textBoxObservaciones.ReadOnly)
                    pedidoActual.OBSERVACIONES = textBoxObservaciones.Text;

                if (comboBoxClientes.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBoxClientes.SelectedItem is Cliente clienteSeleccionado)
                {
                    pedidoActual.IDCliente = clienteSeleccionado.IDCliente;
                }

                string estadoAnterior = pedidoActual.ESTADO;
                string estadoNuevo = comboBoxEstado.SelectedItem?.ToString() ?? "";

                // Validación: no se puede pasar de Pendiente a En proceso si se agregaron/eliminaron ítems
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
                if (estadoNuevo == "Finalizado" && estadoAnterior != "En proceso")
                {
                    MessageBox.Show("Solo se puede finalizar un pedido que está en proceso.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!estadoEditable && estadoNuevo != estadoAnterior)
                {
                    MessageBox.Show("No se puede cambiar el estado del pedido porque se modificaron los ítems.", "Cambio de estado no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Verificar que haya al menos un ítem
                if (dataGridViewDetallePedido.Rows.Count == 0 ||
                    dataGridViewDetallePedido.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow))
                {
                    MessageBox.Show("El pedido debe tener al menos un ítem para poder guardarlo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Actualizar datos del pedido
                pedidoActual.ESTADO = estadoNuevo;
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

                // Detectar si hubo cambios reales
                bool sinCambios = estadoAnterior == estadoNuevo &&
                     observacionesOriginales == (textBoxObservaciones.Text ?? "") &&
                     detallesOriginales.Count == detallesOriginalesOriginal.Count;

                if (sinCambios)
                {
                    for (int i = 0; i < detallesOriginales.Count; i++)
                    {
                        var nuevo = detallesOriginales[i];
                        var original = detallesOriginalesOriginal[i];

                        if (nuevo.oProducto.IdProducto != original.oProducto.IdProducto ||
                            nuevo.CANTIDAD != original.CANTIDAD ||
                            nuevo.PRECIOUNITARIO != original.PRECIOUNITARIO)
                        {
                            sinCambios = false;
                            break;
                        }
                    }
                }

                // ✅ Permitir guardar si el estado fue modificado
                if (estadoAnterior != estadoNuevo)
                {
                    sinCambios = false;
                }

                if (sinCambios)
                {
                    MessageBox.Show("No se detectaron cambios para guardar.", "Sin cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                pedidoActual.IDUsuario = 3; // ⚠️ Ajustar según el usuario logueado

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
                    detallesOriginales.Add(nuevoDetalle);

                    RefrescarDataGrid();

                    // Deshabilitar cambio de estado
                    comboBoxEstado.Enabled = false;
                    estadoEditable = false;
                    MessageBox.Show("Se agregó un ítem. Ya no se puede cambiar el estado del pedido.", "Estado bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public class DataGridViewDisableButtonCell : DataGridViewButtonCell
        {
            public bool Enabled { get; set; } = true;

            public override object Clone()
            {
                var cell = (DataGridViewDisableButtonCell)base.Clone();
                cell.Enabled = this.Enabled;
                return cell;
            }

            protected override void Paint(Graphics graphics,
                Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
                DataGridViewElementStates cellState, object value,
                object formattedValue, string errorText,
                DataGridViewCellStyle cellStyle,
                DataGridViewAdvancedBorderStyle advancedBorderStyle,
                DataGridViewPaintParts paintParts)
            {
                if (!this.Enabled)
                {
                    ButtonRenderer.DrawButton(graphics, cellBounds, PushButtonState.Disabled);
                    TextRenderer.DrawText(graphics, formattedValue?.ToString(), cellStyle.Font, cellBounds, Color.Gray);
                }
                else
                {
                    base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                        cellState, value, formattedValue, errorText,
                        cellStyle, advancedBorderStyle, paintParts);
                }
            }
        }




        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}