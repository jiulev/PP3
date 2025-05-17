using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Cliente
    {
        // Método para listar todos los clientes desde la base de datos
        public static List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    oconexion.Open();

                    string query = @"
                SELECT 
                   IDCLIENTE,
                   FECHACREACION,
                   DOCUMENTO,
                   NOMBRE,
                   CORREO,
                   ESTADO,
                   LOCALIDAD,
   
                   PROVINCIA,
                 TELEFONO,      
                    CUIT,        
                    RAZONSOCIAL  
                FROM CLIENTE
                WHERE ESTADO = 'Activo'"; // Filtro para clientes activos

                    using (SqlCommand command = new SqlCommand(query, oconexion))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Cliente cliente = new Cliente
                            {
                                IDCliente = reader["IDCLIENTE"] != DBNull.Value ? Convert.ToInt32(reader["IDCLIENTE"]) : 0,
                                DOCUMENTO = reader["DOCUMENTO"] != DBNull.Value ? Convert.ToInt32(reader["DOCUMENTO"]) : 0,
                                NOMBRE = reader["NOMBRE"].ToString() ?? string.Empty,
                                CORREO = reader["CORREO"].ToString() ?? string.Empty,
                                ESTADO = reader["ESTADO"].ToString() ?? string.Empty,
                                LOCALIDAD = reader["LOCALIDAD"].ToString() ?? string.Empty,
                                PROVINCIA = reader["PROVINCIA"].ToString() ?? string.Empty,
                                TELEFONO = reader["TELEFONO"].ToString() ?? string.Empty,         // nuevo
                                CUIT = reader["CUIT"].ToString() ?? string.Empty,                 // nuevo
                                RAZONSOCIAL = reader["RAZONSOCIAL"].ToString() ?? string.Empty,   // nuevo
                                FECHACREACION = reader["FECHACREACION"] != DBNull.Value ? Convert.ToDateTime(reader["FECHACREACION"]) : (DateTime?)null
                            };


                            lista.Add(cliente);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar los clientes: " + ex.Message);
                }
            }

            return lista;
        }
        public static Cliente ObtenerClientePorId(int idCliente)
        {
            Cliente cliente = null;

            using (SqlConnection oconexion = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    oconexion.Open();

                    string query = @"SELECT IDCLIENTE, DOCUMENTO, NOMBRE, CORREO, ESTADO, LOCALIDAD, PROVINCIA,
                                    TELEFONO, CUIT, RAZONSOCIAL, FECHACREACION
                             FROM CLIENTE
                             WHERE IDCLIENTE = @IDCLIENTE";

                    using (SqlCommand command = new SqlCommand(query, oconexion))
                    {
                        command.Parameters.AddWithValue("@IDCLIENTE", idCliente);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                cliente = new Cliente
                                {
                                    IDCliente = reader["IDCLIENTE"] != DBNull.Value ? Convert.ToInt32(reader["IDCLIENTE"]) : 0,
                                    DOCUMENTO = reader["DOCUMENTO"] != DBNull.Value ? Convert.ToInt32(reader["DOCUMENTO"]) : 0,
                                    NOMBRE = reader["NOMBRE"]?.ToString() ?? "",
                                    CORREO = reader["CORREO"]?.ToString() ?? "",
                                    ESTADO = reader["ESTADO"]?.ToString() ?? "",
                                    LOCALIDAD = reader["LOCALIDAD"]?.ToString() ?? "",
                                    PROVINCIA = reader["PROVINCIA"]?.ToString() ?? "",
                                    TELEFONO = reader["TELEFONO"]?.ToString() ?? "",
                                    CUIT = reader["CUIT"]?.ToString(),
                                    RAZONSOCIAL = reader["RAZONSOCIAL"]?.ToString(),
                                    FECHACREACION = reader["FECHACREACION"] != DBNull.Value
                                        ? Convert.ToDateTime(reader["FECHACREACION"])
                                        : (DateTime?)null
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el cliente por ID: " + ex.Message);
                }
            }

            return cliente;
        }


        // Método para insertar un nuevo cliente usando el procedimiento almacenado
        public static void Insertar(Cliente cliente)
        {
            using (SqlConnection oconexion = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    oconexion.Open();

                    using (SqlCommand command = new SqlCommand("dbo.InsertarCliente", oconexion))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Parámetros obligatorios
                        command.Parameters.AddWithValue("@NOMBRE", cliente.NOMBRE ?? string.Empty);
                        command.Parameters.AddWithValue("@DOCUMENTO", cliente.DOCUMENTO);
                        command.Parameters.AddWithValue("@CORREO", cliente.CORREO ?? string.Empty);
                        command.Parameters.AddWithValue("@ESTADO", cliente.ESTADO ?? "Activo");
                        command.Parameters.AddWithValue("@LOCALIDAD", cliente.LOCALIDAD ?? string.Empty);
                        command.Parameters.AddWithValue("@PROVINCIA", cliente.PROVINCIA ?? string.Empty);
                        command.Parameters.AddWithValue("@TELEFONO", cliente.TELEFONO ?? string.Empty);

                        // Parámetros opcionales
                        command.Parameters.AddWithValue("@CUIT", (object?)cliente.CUIT ?? DBNull.Value);
                        command.Parameters.AddWithValue("@RAZONSOCIAL", (object?)cliente.RAZONSOCIAL ?? DBNull.Value);

                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            cliente.IDCliente = Convert.ToInt32(result);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 50000)
                    {
                        throw new Exception("Error al insertar el cliente: " + ex.Message);
                    }
                    else
                    {
                        throw new Exception("Error al insertar el cliente", ex);
                    }
                }
            }
        }


        // Método para obtener los nombres de los clientes para el ComboBox
        public static List<string> ObtenerNombresClientes()
        {
            List<string> nombres = new List<string>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    oconexion.Open();
                    string query = "SELECT NOMBRE FROM CLIENTE";

                    using (SqlCommand command = new SqlCommand(query, oconexion))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            string nombre = reader["NOMBRE"]?.ToString() ?? string.Empty;
                            nombres.Add(nombre);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener nombres de clientes: " + ex.Message);
                }
            }

            return nombres;
        }


        public static void Actualizar(Cliente cliente)
        {
            using (SqlConnection oconexion = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    oconexion.Open();

                    string query = @"
                UPDATE CLIENTE
                SET NOMBRE = @NOMBRE,
                    CORREO = @CORREO,
                    ESTADO = @ESTADO,
                    LOCALIDAD = @LOCALIDAD,
                    PROVINCIA = @PROVINCIA,
                    TELEFONO = @TELEFONO,
                    CUIT = @CUIT,
                    RAZONSOCIAL = @RAZONSOCIAL
                WHERE IDCLIENTE = @IDCLIENTE";

                    using (SqlCommand command = new SqlCommand(query, oconexion))
                    {
                        command.Parameters.AddWithValue("@NOMBRE", cliente.NOMBRE ?? string.Empty);
                        command.Parameters.AddWithValue("@CORREO", cliente.CORREO ?? string.Empty);
                        command.Parameters.AddWithValue("@ESTADO", cliente.ESTADO ?? "Activo");
                        command.Parameters.AddWithValue("@LOCALIDAD", cliente.LOCALIDAD ?? string.Empty);
                        command.Parameters.AddWithValue("@PROVINCIA", cliente.PROVINCIA ?? string.Empty);
                        command.Parameters.AddWithValue("@TELEFONO", cliente.TELEFONO ?? string.Empty);
                        command.Parameters.AddWithValue("@CUIT", (object?)cliente.CUIT ?? DBNull.Value);
                        command.Parameters.AddWithValue("@RAZONSOCIAL", (object?)cliente.RAZONSOCIAL ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IDCLIENTE", cliente.IDCliente);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar el cliente: " + ex.Message);
                }
            }
        }

        public static void Eliminar(int idCliente)
        {
            using (SqlConnection oconexion = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    oconexion.Open();

                    // Cambiar la consulta para actualizar el estado a 'Bloqueado'
                    string query = "UPDATE CLIENTE SET ESTADO = 'Bloqueado' WHERE IDCLIENTE = @IDCLIENTE";

                    using (SqlCommand command = new SqlCommand(query, oconexion))
                    {
                        command.Parameters.AddWithValue("@IDCLIENTE", idCliente);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al bloquear el cliente: " + ex.Message);
                }
            }
        }


        public static int ObtenerIdClientePorNombre(string nombreCompleto)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT IDCLIENTE FROM CLIENTE WHERE NOMBRE = @NOMBRE";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@NOMBRE", nombreCompleto);

                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el ID del cliente: " + ex.Message);
                }
            }

            return 0; // si no encontró nada
        }


    }
}
