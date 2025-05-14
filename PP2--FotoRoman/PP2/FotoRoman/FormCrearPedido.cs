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
        private List<DetallePedido> detallesPedido = new List<DetallePedido>();
        private List<Cliente> listaClientes = new List<Cliente>();
        private List<Categoria> listaCategorias = new List<Categoria>();
        private List<Producto> listaProductos = new List<Producto>();
        private int idPedidoGenerado;

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


        private void ConfigurarDataGridView()
        {
            // Ajustar altura según las filas, con un máximo de 5 visibles
            ActualizarAlturaDataGridView();

            // Habilitar barra de desplazamiento vertical
            dataGridView1.ScrollBars = ScrollBars.Vertical;
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
                string productoNombre = comboProducto.SelectedItem is Producto producto ? producto.Nombre : "Sin nombre";
                decimal precio = Convert.ToDecimal(textPrecio1.Text);
                int cantidad = Convert.ToInt32(textCantidad1.Text);
                decimal subtotal = precio * cantidad;

                if (string.IsNullOrWhiteSpace(productoNombre) || precio <= 0 || cantidad <= 0)
                {
                    MessageBox.Show("Ingrese datos válidos para el producto, precio y cantidad.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var productoSeleccionado = listaProductos.FirstOrDefault(p => p.Nombre == productoNombre);
                if (productoSeleccionado == null)
                {
                    MessageBox.Show("Seleccione un producto válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DetallePedido detalle = new DetallePedido
                {
                    oProducto = productoSeleccionado,
                    CANTIDAD = cantidad,
                    PRECIOUNITARIO = precio,
                    SUBTOTAL = subtotal
                };

                detallesPedido.Add(detalle);
                dataGridView1.Rows.Add(productoNombre, precio, subtotal);
                CalcularTotal();

                // Actualizar la altura del DataGridView
                ActualizarAlturaDataGridView();

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
                int index = dataGridView1.SelectedRows[0].Index;
                detallesPedido.RemoveAt(index);
                dataGridView1.Rows.RemoveAt(index);
                CalcularTotal();

                // Actualizar la altura del DataGridView
                ActualizarAlturaDataGridView();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.", "Eliminar ítem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (detallesPedido.Count == 0)
                {
                    MessageBox.Show("No hay ítems agregados al pedido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboCliente.SelectedIndex < 0)
                {
                    MessageBox.Show("Seleccione un cliente válido antes de crear el pedido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idCliente = listaClientes[comboCliente.SelectedIndex].IDCliente; // Mapear correctamente el IDCLIENTE
                int idUsuario = UsuarioActual.Usuario.IDUSUARIO; // Usar el ID del usuario autenticado
                decimal totalPedido = detallesPedido.Sum(d => d.SUBTOTAL);
                string estado = "Pendiente";
                DateTime fechaPedido = DateTime.Now;

                string mensaje;
                string observaciones = textBoxObservaciones.Text.Trim();

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
            detallesPedido.Clear();
            dataGridView1.Rows.Clear();

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
                comboCliente.Items.Clear();

                foreach (var cliente in listaClientes)
                {
                    comboCliente.Items.Add(cliente.NOMBRE);
                }

                if (comboCliente.Items.Count > 0)
                {
                    comboCliente.SelectedIndex = 0; // Seleccionar el primer cliente por defecto
                }
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

                foreach (var categoria in listaCategorias)
                {
                    comboCategoria.Items.Add(new { Text = categoria.DESCRIPCION, Value = categoria.IDCATEGORIA });
                }

                comboCategoria.DisplayMember = "Text";
                comboCategoria.ValueMember = "Value";
                comboCategoria.SelectedIndexChanged += comboCategoria_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para seleccionar una categoría y cargar productos
        private void comboCategoria_SelectedIndexChanged(object? sender, EventArgs e)
        {
            try
            {
                if (comboCategoria.SelectedItem != null)
                {
                    var categoriaSeleccionada = (dynamic)comboCategoria.SelectedItem;
                    int idCategoria = categoriaSeleccionada.Value;
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
                // Limpiar los productos e ítems cargados al cambiar de cliente
                LimpiarProductosYDetalles();

                // Obtener el cliente seleccionado
                string clienteSeleccionado = comboCliente.Text;
                var cliente = listaClientes.FirstOrDefault(c => c.NOMBRE == clienteSeleccionado);

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
