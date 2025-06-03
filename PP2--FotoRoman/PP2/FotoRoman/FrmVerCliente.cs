using System;
using System.Windows.Forms;
using CapaNegocio;
using System.Linq;

namespace FotoRoman
{
    public partial class FrmVerCliente : Form
    {
        public FrmVerCliente()
        {
            InitializeComponent();
            CargarClientes();
        }

        // Método para cargar los clientes
        private void CargarClientes()
        {
            var clientes = CNCliente.ListarClientes().Select(c => new
            {
                IDCliente = c.IDCliente,
                Documento = c.DOCUMENTO,
                Nombre = c.NOMBRE,
                Correo = c.CORREO,
                Estado = c.ESTADO,
                Localidad = c.LOCALIDAD,
                Provincia = c.PROVINCIA,
                FechaCreacion = c.FECHACREACION
            }).ToList();

            dataGridViewClientes.DataSource = clientes;
            dataGridViewClientes.DefaultCellStyle.Font = new Font("Yu Gothic", 10);
            dataGridViewClientes.ColumnHeadersDefaultCellStyle.Font = new Font("Yu Gothic", 10, FontStyle.Bold);

            labelCantidadClientes.Text = $"{clientes.Count} cliente{(clientes.Count == 1 ? "" : "s")} encontrado{(clientes.Count == 1 ? "" : "s")}";
        }

        // Método para buscar clientes por nombre
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.ToLower();

            var clientesFiltrados = CNCliente.ListarClientes()
                .Where(c => c.NOMBRE.ToLower().Contains(filtro))
                .Select(c => new
                {
                    IDCliente = c.IDCliente,
                    Documento = c.DOCUMENTO,
                    Nombre = c.NOMBRE,
                    Correo = c.CORREO,
                    Estado = c.ESTADO,
                    Localidad = c.LOCALIDAD,
                    Provincia = c.PROVINCIA,
                    FechaCreacion = c.FECHACREACION
                })
                .ToList();


            dataGridViewClientes.DataSource = clientesFiltrados;
            dataGridViewClientes.DefaultCellStyle.Font = new Font("Yu Gothic", 10);
            dataGridViewClientes.ColumnHeadersDefaultCellStyle.Font = new Font("Yu Gothic", 10, FontStyle.Bold);

            labelCantidadClientes.Text = $"{clientesFiltrados.Count} cliente{(clientesFiltrados.Count == 1 ? "" : "s")} encontrado{(clientesFiltrados.Count == 1 ? "" : "s")}";
        }

        // Método para eliminar un cliente
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un cliente para Eliminar.");
                return;
            }

            int idCliente = Convert.ToInt32(dataGridViewClientes.SelectedRows[0].Cells["IDCliente"].Value);

            if (MessageBox.Show("¿Estás seguro de Eliminar este cliente?", "Confirmar Eliminación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string mensaje;

                if (CNCliente.EliminarCliente(idCliente, out mensaje)) // Reutiliza EliminarCliente
                {
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarClientes(); // Refresca el DataGridView
                }
                else
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void dataGridViewClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Manejo de eventos para clics en celdas, si es necesario
        }

        private void buttonEditar_click(object sender, EventArgs e)
        {
            // Verificar que se haya seleccionado un cliente en el DataGridView
            if (dataGridViewClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un cliente para editar.");
                return;
            }

            // Obtener el ID del cliente seleccionado
            int idCliente = Convert.ToInt32(dataGridViewClientes.SelectedRows[0].Cells["IDCliente"].Value);

            // Buscar el cliente por su ID (opcional, para obtener todos los datos)
            var cliente = CNCliente.ObtenerClientePorId(idCliente);


            if (cliente == null)
            {
                MessageBox.Show("No se encontró el cliente seleccionado.");
                return;
            }

            // Crear una instancia del formulario de edición y pasarle los datos del cliente
            FormEditarCliente formEditarCliente = new FormEditarCliente(cliente);

            // Mostrar el formulario como un cuadro de diálogo
            if (formEditarCliente.ShowDialog() == DialogResult.OK)
            {
                // Refrescar los datos en el DataGridView después de la edición
                CargarClientes();
            }
        }
    }
}
