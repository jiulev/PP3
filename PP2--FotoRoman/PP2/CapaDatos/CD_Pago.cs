using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Pago
    {
        // Método para insertar un pago en la base de datos
        public static void InsertarPago(Pago pago)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("InsertarPago", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Parámetros del procedimiento almacenado
                        cmd.Parameters.AddWithValue("@IDPEDIDO", pago.IDPEDIDO);
                        cmd.Parameters.AddWithValue("@MONTOPAGO", pago.MONTOPAGO);
                        cmd.Parameters.AddWithValue("@METODOPAGO", pago.METODOPAGO ?? (object)DBNull.Value);

                        // Ejecutar la consulta
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar el pago: " + ex.Message);
                }
                finally
                {
                    // Cerrar la conexión explícitamente
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }

        // Método para obtener los pedidos con pagos según el ID del cliente
        public static List<int> ObtenerPedidosConPagos(int idCliente)
        {
            List<int> listaPedidos = new List<int>();

            using (SqlConnection connection = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT DISTINCT P.IDPEDIDO
                        FROM PEDIDO P
                        JOIN PAGO PA ON P.IDPEDIDO = PA.IDPEDIDO
                        WHERE P.IDCLIENTE = @IDCLIENTE", connection))
                    {
                        cmd.Parameters.AddWithValue("@IDCLIENTE", idCliente);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listaPedidos.Add(reader.GetInt32(0));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los pedidos con pagos: " + ex.Message);
                }
            }

            return listaPedidos;
        }
        public static bool ReemplazarPagosDelPedido(int idPedido, List<Pago> nuevosPagos, out string mensaje)
        {
            mensaje = string.Empty;

            using (SqlConnection connection = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                SqlTransaction transaction = null;

                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    // Eliminar pagos existentes
                    using (SqlCommand deleteCmd = new SqlCommand("DELETE FROM PAGO WHERE IDPEDIDO = @IDPEDIDO", connection, transaction))
                    {
                        deleteCmd.Parameters.AddWithValue("@IDPEDIDO", idPedido);
                        deleteCmd.ExecuteNonQuery();
                    }

                    // Insertar los nuevos pagos
                    foreach (var pago in nuevosPagos)
                    {
                        using (SqlCommand insertCmd = new SqlCommand("InsertarPago", connection, transaction))
                        {
                            insertCmd.CommandType = CommandType.StoredProcedure;
                            insertCmd.Parameters.AddWithValue("@IDPEDIDO", pago.IDPEDIDO);
                            insertCmd.Parameters.AddWithValue("@MONTOPAGO", pago.MONTOPAGO);
                            insertCmd.Parameters.AddWithValue("@METODOPAGO", pago.METODOPAGO ?? (object)DBNull.Value);
                            insertCmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    mensaje = "Pagos actualizados correctamente.";
                    return true;
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    mensaje = "Error al actualizar los pagos: " + ex.Message;
                    return false;
                }
            }
        }
        public static Pedido ObtenerPedidoPorId(int idPedido)
        {
            Pedido pedido = null;

            using (SqlConnection connection = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(@"
                SELECT P.IDPEDIDO, P.IDCLIENTE, P.IDUSUARIO, P.TOTAL, P.FECHAPEDIDO, P.ESTADO, P.OBSERVACIONES,
                       C.NOMBRE AS NOMBRECLIENTE
                FROM PEDIDO P
                INNER JOIN CLIENTE C ON P.IDCLIENTE = C.IDCLIENTE
                WHERE P.IDPEDIDO = @IDPEDIDO", connection))
                    {
                        cmd.Parameters.AddWithValue("@IDPEDIDO", idPedido);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                pedido = new Pedido
                                {
                                    IDPEDIDO = reader.GetInt32(reader.GetOrdinal("IDPEDIDO")),
                                    IDCliente = reader.GetInt32(reader.GetOrdinal("IDCLIENTE")),
                                    IDUsuario = reader.GetInt32(reader.GetOrdinal("IDUSUARIO")),
                                    TOTAL = reader.GetDecimal(reader.GetOrdinal("TOTAL")),
                                    FECHAPEDIDO = reader.GetDateTime(reader.GetOrdinal("FECHAPEDIDO")),
                                    ESTADO = reader.GetString(reader.GetOrdinal("ESTADO")),
                                    OBSERVACIONES = reader.IsDBNull(reader.GetOrdinal("OBSERVACIONES")) ? "" : reader.GetString(reader.GetOrdinal("OBSERVACIONES")),
                                    oCliente = new Cliente
                                    {
                                        NOMBRE = reader.GetString(reader.GetOrdinal("NOMBRECLIENTE"))
                                    }
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el pedido por ID: " + ex.Message);
                }
            }

            return pedido;
        }




        public static List<Pedido> ObtenerPedidosConImporteYEstado(int idCliente)
        {
            List<Pedido> pedidos = new List<Pedido>();

            using (SqlConnection connection = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(@"
                SELECT IDPEDIDO, FECHAPEDIDO, TOTAL, ESTADO
                FROM PEDIDO
                WHERE IDCLIENTE = @IDCLIENTE
                ORDER BY FECHAPEDIDO DESC", connection))
                    {
                        cmd.Parameters.AddWithValue("@IDCLIENTE", idCliente);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                pedidos.Add(new Pedido
                                {
                                    IDPEDIDO = reader.GetInt32(0),
                                    FECHAPEDIDO = reader.GetDateTime(1),
                                    TOTAL = reader.GetDecimal(2),
                                    ESTADO = reader.GetString(3)
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los pedidos del cliente con total y estado: " + ex.Message);
                }
            }

            return pedidos;
        }

        public static List<Pedido> ObtenerPedidosPorCliente(int idCliente)
        {
            List<Pedido> pedidos = new List<Pedido>();

            using (SqlConnection connection = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(@"
                SELECT IDPEDIDO, FECHAPEDIDO
                FROM PEDIDO
                WHERE IDCLIENTE = @IDCLIENTE
                ORDER BY FECHAPEDIDO DESC", connection))
                    {
                        cmd.Parameters.AddWithValue("@IDCLIENTE", idCliente);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                pedidos.Add(new Pedido
                                {
                                    IDPEDIDO = reader.GetInt32(0),
                                    FECHAPEDIDO = reader.GetDateTime(1)
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los pedidos del cliente: " + ex.Message);
                }
            }

            return pedidos;
        }


        // Método para obtener los pagos de un pedido específico
        public static List<Pago> ObtenerPagosDelPedido(int idPedido)
        {
            List<Pago> listaPagos = new List<Pago>();

            using (SqlConnection connection = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT IDPAGO, IDPEDIDO, MONTOPAGO, FECHAPAGO, METODOPAGO
                        FROM PAGO
                        WHERE IDPEDIDO = @IDPEDIDO", connection))
                    {
                        cmd.Parameters.AddWithValue("@IDPEDIDO", idPedido);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listaPagos.Add(new Pago
                                {
                                    IDPAGO = reader.GetInt32(0),
                                    IDPEDIDO = reader.GetInt32(1),
                                    MONTOPAGO = reader.GetDecimal(2),
                                    FECHAPAGO = reader.GetDateTime(3),
                                    METODOPAGO = reader.GetString(4)
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los pagos del pedido: " + ex.Message);
                }
            }

            return listaPagos;
        }
    }
}
