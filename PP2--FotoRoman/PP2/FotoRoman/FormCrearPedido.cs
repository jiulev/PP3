using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace FotoRoman
{
    public partial class FormCrearPedido : Form
    {
        private bool formularioCargado = false;
        private List<DetallePedido> detallesPedido = new List<DetallePedido>();
        private List<Cliente> listaClientes = new List<Cliente>();
        private List<Categoria> listaCategorias = new List<Categoria>();
        private List<Producto> listaProductos = new List<Producto>();
        private int idPedidoGenerado;
        private List<string> nombresClientes = new List<string>();
    









        public FormCrearPedido()
        {
            InitializeComponent();
        }

        private void FormCrearPedido_Load(object sender, EventArgs e)
        {
            try
            {
                CargarClientes();
                CargarCategorias();
                textBoxObservaciones.MaxLength = 100;
                textBoxObservaciones.TextChanged += textBoxObservaciones_TextChanged;
                comboCliente.DropDownStyle = ComboBoxStyle.DropDown;
                comboCliente.AutoCompleteMode = AutoCompleteMode.None;
                comboCliente.TextChanged += comboCliente_TextChanged;
                comboCliente.DropDown += comboCliente_DropDown;
                textCantidad1.TextChanged += textCantidad1_TextChanged;
                textCantidad1.MaxLength = 4;


                formularioCargado = true;


                // Mostrar el próximo número de pedido
                int proximoNumeroPedido = CNPedido.ObtenerProximoNumeroPedido();
                num.Text = proximoNumeroPedido.ToString();

                // Configurar el DataGridView para mostrar 5 filas por defecto
                ConfigurarDataGridView();

               


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textCantidad1_TextChanged(object sender, EventArgs e)
        {
            labelCantidadObligatoria.Visible = string.IsNullOrWhiteSpace(textCantidad1.Text);
        }

        private void comboCliente_TextChanged(object sender, EventArgs e)
        {
            if (!formularioCargado) return;

            try
            {
                string texto = comboCliente.Text;

                // Si el texto coincide exactamente con un cliente, no tocar nada
                if (nombresClientes.Any(n => n.Equals(texto, StringComparison.OrdinalIgnoreCase)))
                    return;

                comboCliente.TextChanged -= comboCliente_TextChanged;

                // Guardar posición del cursor
                int cursorPos = comboCliente.SelectionStart;

                var resultados = nombresClientes
                    .Where(n => n.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();

                comboCliente.BeginUpdate();
                comboCliente.Items.Clear();
                comboCliente.Items.AddRange(resultados.ToArray());
                comboCliente.EndUpdate();

                // Solo abrir DropDown si hay resultados y el usuario está escribiendo
                if (!string.IsNullOrWhiteSpace(texto) && resultados.Count > 0)
                {
                    comboCliente.DroppedDown = true;
                    int itemHeight = Math.Max(comboCliente.ItemHeight, 16);
                    comboCliente.DropDownHeight = itemHeight * Math.Min(resultados.Count, 10);

                }
                else
                {
                    comboCliente.DroppedDown = false;
                }

                // Restaurar texto y posición
                comboCliente.Text = texto;
                comboCliente.SelectionStart = cursorPos;
                comboCliente.SelectionLength = 0;

                comboCliente.TextChanged += comboCliente_TextChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al filtrar clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        private void comboCliente_DropDown(object sender, EventArgs e)
        {
            if (!formularioCargado)
                return;

            try
            {
                if (string.IsNullOrWhiteSpace(comboCliente.Text))
                {
                    comboCliente.BeginUpdate();
                    comboCliente.Items.Clear();
                    comboCliente.Items.AddRange(nombresClientes.ToArray());

                    int itemHeight = Math.Max(comboCliente.ItemHeight, 16); // ✅ Altura segura
                    comboCliente.DropDownHeight = itemHeight * Math.Min(nombresClientes.Count, 10);

                    comboCliente.EndUpdate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar el ComboBox: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void ConfigurarDataGridView()
        {
            // Establecer fuente y estilo visual
            Font fuente = new Font("Yu Gothic UI", 9, FontStyle.Regular);
            dataGridView1.Font = fuente;
            dataGridView1.RowTemplate.Height = 28; // Altura de las filas

            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Yu Gothic", 9, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Habilitar barra de desplazamiento vertical
            dataGridView1.ScrollBars = ScrollBars.Vertical;

            // Ajustar altura inicial
            ActualizarAlturaDataGridView();
        }

        private void ActualizarAlturaDataGridView()
        {
            // Calcular la altura del DataGridView según la cantidad de filas, con un máximo de 5 filas visibles
            int filasVisibles = Math.Min(dataGridView1.Rows.Count, 5); // Mostrar máximo 5 filas
            int alturaFila = dataGridView1.RowTemplate.Height;
            int alturaCabecera = dataGridView1.ColumnHeadersHeight;

            // Ajustar la altura del DataGridView
            dataGridView1.Height = (alturaFila * filasVisibles) + alturaCabecera;
        }
        // Método para calcular el total del pedido
        private void CalcularTotal()
        {
            decimal totalSum = detallesPedido.Sum(d => d.SUBTOTAL);
            total.Text = $"Total: ${totalSum:F2}";
        }


        //contar caracteres en observaciones
        private void textBoxObservaciones_TextChanged(object sender, EventArgs e)
        {
            int restantes = 100 - textBoxObservaciones.Text.Length;
            labelCaracteresRestantes.Text = $"Te quedan {restantes} caracteres.";
        }

        // Evento para agregar un producto al pedido
        private void buttonAgregar_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Validar que haya un cliente seleccionado
                if (comboCliente.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar un cliente antes de agregar productos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que haya una categoría seleccionada
                if (comboCategoria.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar una categoría antes de agregar productos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que haya un producto seleccionado
                if (comboProducto.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar un producto para agregar al pedido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que el precio sea válido
                if (!decimal.TryParse(textPrecio1.Text.Trim(), out decimal precio) || precio <= 0)
                {
                    MessageBox.Show("El precio debe ser un número válido mayor a cero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Validar cantidad: debe ser entero y mayor a cero
                if (!int.TryParse(textCantidad1.Text.Trim(), out int cantidad) || cantidad <= 0 || cantidad > 9999)
                {
                    labelCantidadObligatoria.Visible = true; // ✅ muestra el asterisco
                    MessageBox.Show("Ingrese una cantidad válida entre 1 y 9999.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    labelCantidadObligatoria.Visible = false; // ✅ lo oculta si está todo bien
                }




                // Obtener nombre del producto
                string productoNombre = comboProducto.SelectedItem is Producto producto ? producto.Nombre : "Sin nombre";

                // Validar que exista en la lista
                var productoSeleccionado = listaProductos.FirstOrDefault(p => p.Nombre == productoNombre);
                if (productoSeleccionado == null)
                {
                    MessageBox.Show("Seleccione un producto válido de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Calcular subtotal y agregar
                decimal subtotal = precio * cantidad;

                DetallePedido detalle = new DetallePedido
                {
                    oProducto = productoSeleccionado,
                    CANTIDAD = cantidad,
                    PRECIOUNITARIO = precio,
                    SUBTOTAL = subtotal
                };

                detallesPedido.Add(detalle);
                dataGridView1.Rows.Add(productoNombre, $"${precio:F2}", $"${subtotal:F2}");

                CalcularTotal();
                ActualizarAlturaDataGridView();

                // Limpiar campos
                comboProducto.SelectedIndex = -1;
                textPrecio1.Clear();
                textCantidad1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Evento para eliminar un ítem del pedido
        private void eliminar1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];

                // ⚠️ Validar que no sea la fila nueva (de inserción)
                if (!filaSeleccionada.IsNewRow)
                {
                    int index = filaSeleccionada.Index;

                    if (index >= 0 && index < detallesPedido.Count)
                    {
                        detallesPedido.RemoveAt(index);
                    }

                    if (index >= 0 && index < dataGridView1.Rows.Count)
                    {
                        dataGridView1.Rows.RemoveAt(index);
                    }

                    CalcularTotal();
                    ActualizarAlturaDataGridView();
                }
                else
                {
                    MessageBox.Show("No se puede eliminar una fila vacía o sin confirmar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila válida para eliminar.", "Eliminar ítem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }




        private void RegistrarPago()
        {
            if (idPedidoGenerado > 0)
            {
                FormRegistrarPago formPago = new FormRegistrarPago
                {
                    TextNombre = comboCliente.Text,
                    TextImporte = total.Text.Replace("Total: $", ""),
                    TextNum = idPedidoGenerado.ToString()
                };

                formPago.ShowDialog();
                LimpiarCampos();
                RefrescarNumeroPedido();
            }
        }


        // Evento para crear el pedido
        private void crear1_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar cliente
                if (comboCliente.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar un cliente antes de crear el pedido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar si hay ítems agregados
                if (detallesPedido.Count == 0)
                {
                    MessageBox.Show("No hay ítems agregados al pedido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener datos
                int idCliente = listaClientes[comboCliente.SelectedIndex].IDCliente;
                int idUsuario = UsuarioActual.Usuario.IDUSUARIO;
                decimal totalPedido = detallesPedido.Sum(d => d.SUBTOTAL);
                string estado = "Pendiente";
                DateTime fechaPedido = DateTime.Now;
                string observaciones = textBoxObservaciones.Text.Trim();

                // Insertar pedido
                string mensaje;
                bool resultado = CNPedido.InsertarPedido(idCliente, idUsuario, totalPedido, fechaPedido, estado, observaciones, detallesPedido, out mensaje);

                if (resultado)
                {
                    idPedidoGenerado = CNPedido.ObtenerUltimoIdPedido();
                    var respuesta = MessageBox.Show("Pedido creado exitosamente. ¿Desea registrar el pago?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Yes)
                    {
                        RegistrarPago();
                    }
                    else
                    {
                        LimpiarCampos();
                    }
                }
                else
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el pedido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LimpiarCampos()
        {
            comboCliente.SelectedIndex = -1;
            comboCategoria.SelectedIndex = -1;
            comboProducto.SelectedIndex = -1;
            textDni.Clear();
            textLocalidad.Clear();
            textCantidad1.Clear();
            textPrecio1.Clear();
            total.Text = "$0.00";
            textBoxObservaciones.Clear();
            labelCaracteresRestantes.Text = "100 caracteres.";

            detallesPedido.Clear();
            dataGridView1.Rows.Clear();

            // 🔒 Deshabilitar controles de productos hasta seleccionar cliente de nuevo
            comboCategoria.Enabled = false;
            comboProducto.Enabled = false;
            textCantidad1.Enabled = false;
            textPrecio1.Enabled = false;
            buttonAgregar.Enabled = false;

            // 🔁 Refrescar número del pedido en pantalla
            int proximoNumeroPedido = CNPedido.ObtenerProximoNumeroPedido();
            num.Text = proximoNumeroPedido.ToString();
        }



        private void RefrescarNumeroPedido()
        {
            int proximoNumeroPedido = CNPedido.ObtenerProximoNumeroPedido();
            num.Text = proximoNumeroPedido.ToString();
        }

        // Evento para registrar el pago
        private void buttonRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idPedidoGenerado > 0)
                {
                    RegistrarPago();
                }
                else
                {
                    MessageBox.Show("Primero debe crear un pedido antes de registrar el pago.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el formulario de registro de pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Cargar la lista de clientes
        private void CargarClientes()
        {
            try
            {
                listaClientes = CNCliente.ListarClientes();
                nombresClientes = listaClientes.Select(c => c.NOMBRE).ToList();

                comboCliente.Items.Clear();
                comboCliente.Items.AddRange(nombresClientes.ToArray());
                comboCliente.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        // Cargar la lista de categorías
        private void CargarCategorias()
        {
            try
            {
                listaCategorias = CNCategoria.ListarDescripciones()
                                 .Where(c => c.ACTIVO == "A")
                                 .ToList();

                comboCategoria.Items.Clear();
                comboCategoria.DropDownStyle = ComboBoxStyle.DropDown;
                comboCategoria.AutoCompleteMode = AutoCompleteMode.None;

                if (listaCategorias.Count == 0)
                {
                    MessageBox.Show("No hay categorías activas disponibles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                comboCategoria.Items.AddRange(listaCategorias.ToArray());
                comboCategoria.DisplayMember = "DESCRIPCION";
                comboCategoria.ValueMember = "IDCATEGORIA";
                comboCategoria.SelectedIndex = -1;

                comboCategoria.TextChanged += comboCategoria_TextChanged;
                comboCategoria.DropDown += comboCategoria_DropDown;
                comboCategoria.SelectedIndexChanged += comboCategoria_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboCategoria_TextChanged(object sender, EventArgs e)
        {
            if (!formularioCargado) return;

            try
            {
                string texto = comboCategoria.Text;

                comboCategoria.TextChanged -= comboCategoria_TextChanged;

                int cursorPos = comboCategoria.SelectionStart;

                var resultados = listaCategorias
                    .Where(c => c.DESCRIPCION.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();

                comboCategoria.BeginUpdate();
                comboCategoria.Items.Clear();
                comboCategoria.Items.AddRange(resultados.ToArray());

                // Reestablecer DisplayMember y ValueMember
                comboCategoria.DisplayMember = "DESCRIPCION";
                comboCategoria.ValueMember = "IDCATEGORIA";

                // Ajustar ancho del DropDown con base en los resultados visibles, sin exceder el ancho del ComboBox
                // Ajustar ancho y alto del DropDown según resultados visibles
                int maxWidth = comboCategoria.Width;
                int itemHeight = comboCategoria.ItemHeight > 0 ? comboCategoria.ItemHeight : 20;
                int cantidad = Math.Min(resultados.Count, 10); // máximo 10 visibles

                using (Graphics g = comboCategoria.CreateGraphics())
                {
                    foreach (var item in comboCategoria.Items)
                    {
                        string itemTexto = item is Categoria cat ? cat.DESCRIPCION : item.ToString();
                        int itemWidth = (int)g.MeasureString(itemTexto, comboCategoria.Font).Width;
                        if (itemWidth > maxWidth)
                            maxWidth = itemWidth;
                    }
                }

                comboCategoria.DropDownWidth = Math.Min(maxWidth + 25, 400);
                comboCategoria.DropDownHeight = itemHeight * Math.Max(cantidad, 1);



                comboCategoria.EndUpdate();

                // ✅ Evitar duplicado en la lista desplegable
                var categoriaExacta = listaCategorias.FirstOrDefault(c => c.DESCRIPCION.Equals(texto, StringComparison.OrdinalIgnoreCase));
                if (categoriaExacta != null)
                {
                    comboCategoria.SelectedItem = categoriaExacta;
                    comboCategoria.DroppedDown = false;
                }
                else
                {
                    comboCategoria.DroppedDown = resultados.Count > 0;
                }

                comboCategoria.Text = texto;
                comboCategoria.SelectionStart = cursorPos;
                comboCategoria.SelectionLength = 0;

                comboCategoria.TextChanged += comboCategoria_TextChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar categorías: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void comboCategoria_DropDown(object sender, EventArgs e)
        {
            if (!formularioCargado) return;

            if (string.IsNullOrWhiteSpace(comboCategoria.Text))
            {
                comboCategoria.BeginUpdate();
                comboCategoria.Items.Clear();
                comboCategoria.Items.AddRange(listaCategorias.ToArray());

                int cantidad = Math.Max(1, Math.Min(listaCategorias.Count, 10));
                int itemHeight = comboCategoria.ItemHeight > 0 ? comboCategoria.ItemHeight : 15;
                comboCategoria.DropDownHeight = itemHeight * cantidad;

                comboCategoria.EndUpdate();
            }
        }



        // Evento para seleccionar una categoría y cargar productos
        private void comboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboCategoria.SelectedItem is Categoria categoriaSeleccionada)
                {
                    int idCategoria = categoriaSeleccionada.IDCATEGORIA;
                    CargarProductos(idCategoria);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Método para cargar productos según la categoría seleccionada
        private void CargarProductos(int idCategoria)
        {
            try
            {
                listaProductos = CNProducto.ListarPorCategoria(idCategoria);
                comboProducto.Items.Clear();

                foreach (var producto in listaProductos)
                {
                    comboProducto.Items.Add(producto);
                }

                comboProducto.DisplayMember = "Nombre";
                comboProducto.ValueMember = "IdProducto";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para seleccionar un cliente
        private void comboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!formularioCargado || comboCliente.SelectedItem == null)
                    return;

                string clienteSeleccionado = comboCliente.SelectedItem.ToString();

                if (clienteSeleccionado == "Sin resultados")
                    return;

                var cliente = listaClientes.FirstOrDefault(c => c.NOMBRE.Equals(clienteSeleccionado, StringComparison.OrdinalIgnoreCase));

                if (cliente != null)
                {
                    textDni.Text = cliente.DOCUMENTO.ToString();
                    textLocalidad.Text = cliente.LOCALIDAD;
                }
                else
                {
                    textDni.Clear();
                    textLocalidad.Clear();
                }

                LimpiarProductosYDetalles();

                if (cliente != null)
                {
                    // ✅ Habilita contenedor de sección de productos
                    toolStripContainer2.Enabled = true;

                    // ✅ Habilita controles individuales de productos
                    comboCategoria.Enabled = true;
                    comboProducto.Enabled = true;
                    textCantidad1.Enabled = true;
                    textPrecio1.Enabled = true;
                    buttonAgregar.Enabled = true;
                }
                else
                {
                    toolStripContainer2.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LimpiarProductosYDetalles()
        {
            // Limpiar la lista de detalles del pedido
            detallesPedido.Clear();

            // Limpiar el contenido del DataGridView
            dataGridView1.Rows.Clear();

            // Restablecer el total a cero
            CalcularTotal();

            // Restablecer los campos relacionados con productos
            comboCategoria.SelectedIndex = -1;
            comboProducto.SelectedIndex = -1;
            textCantidad1.Clear();
            textPrecio1.Clear();

            // Actualizar la altura del DataGridView
            ActualizarAlturaDataGridView();
        }



        // Evento para seleccionar un producto y mostrar su precio
        private void comboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboProducto.SelectedItem != null)
                {
                    var productoSeleccionado = (Producto)comboProducto.SelectedItem;
                    textPrecio1.Text = productoSeleccionado.Precio.ToString("F2");
                }
                if (string.IsNullOrWhiteSpace(textCantidad1.Text))
                {
                    labelCantidadObligatoria.Visible = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void precio4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripContainer3_BottomToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void toolStripContainer2_BottomToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void textPrecio1_TextChanged(object sender, EventArgs e)
        {

        }




    }



}
