using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CapaNegocio
{
    public class CNCliente
    {
        // Obtener lista completa de clientes
        public static List<Cliente> ListarClientes()
        {
            return CD_Cliente.Listar();
        }

        // Insertar un nuevo cliente
        public static bool InsertarCliente(Cliente cliente, out string mensaje)
        {
            mensaje = string.Empty;

            // Validación del documento
            if (cliente.DOCUMENTO <= 0)
            {
                mensaje = "El documento debe ser un número válido.";
                return false;
            }

            // Validación del nombre
            if (string.IsNullOrWhiteSpace(cliente.NOMBRE))
            {
                mensaje = "El nombre es obligatorio.";
                return false;
            }

            // Validación del teléfono
            if (string.IsNullOrWhiteSpace(cliente.TELEFONO))
            {
                mensaje = "El teléfono es obligatorio.";
                return false;
            }


            // Validación del correo
            if (string.IsNullOrWhiteSpace(cliente.CORREO))
            {
                mensaje = "El correo es obligatorio.";
                return false;
            }
            else if (!EsCorreoValido(cliente.CORREO))
            {
                mensaje = "El correo no tiene un formato válido.";
                return false;
            }

            try
            {
                CD_Cliente.Insertar(cliente);
                mensaje = "Cliente registrado exitosamente.";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = "Error al insertar el cliente: " + ex.Message;
                return false;
            }
        }

        public static bool ActualizarCliente(Cliente cliente, out string mensaje)
        {
            mensaje = string.Empty;

            // Validación del nombre
            if (string.IsNullOrWhiteSpace(cliente.NOMBRE))
            {
                mensaje = "El nombre es obligatorio.";
                return false;
            }

            // Validación del correo
            if (string.IsNullOrWhiteSpace(cliente.CORREO))
            {
                mensaje = "El correo es obligatorio.";
                return false;
            }
            else if (!EsCorreoValido(cliente.CORREO))
            {
                mensaje = "El correo no tiene un formato válido.";
                return false;
            }

            // Validación de la localidad
            if (string.IsNullOrWhiteSpace(cliente.LOCALIDAD))
            {
                mensaje = "La localidad es obligatoria.";
                return false;
            }

            // Validación de la provincia
            if (string.IsNullOrWhiteSpace(cliente.PROVINCIA))
            {
                mensaje = "La provincia es obligatoria.";
                return false;
            }

            try
            {
                CD_Cliente.Actualizar(cliente); // Llama al método de la capa de datos
                mensaje = "Cliente actualizado correctamente.";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = "Error al actualizar el cliente: " + ex.Message;
                return false;
            }
        }


        // Método auxiliar para validar correos
        private static bool EsCorreoValido(string correo)
        {
            string patronCorreo = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return System.Text.RegularExpressions.Regex.IsMatch(correo, patronCorreo);
        }



        // Método para eliminar un cliente
        public static bool EliminarCliente(int idCliente, out string mensaje)
        {
            mensaje = string.Empty;

            try
            {
                CD_Cliente.Eliminar(idCliente); // Ahora bloquea el cliente
                mensaje = "Cliente bloqueado correctamente.";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = "Error al bloquear el cliente: " + ex.Message;
                return false;
            }
        }


        // Método auxiliar para validar formato de correo


        // Obtener nombres de clientes para autocompletado
        public static List<string> ObtenerNombresClientes()
        {
            return CD_Cliente.ObtenerNombresClientes();
        }
    }
}
