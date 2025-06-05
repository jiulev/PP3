using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Pedido
    {
        // Método para insertar un pedido y sus detalles
        public static bool InsertarPedido(int idCliente, int idUsuario, decimal total, DateTime fechaPedido, string estado, string observaciones, List<DetallePedido> detalles)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                SqlTransaction? transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    // Insertar el pedido
                    using (SqlCommand cmdPedido = new SqlCommand("InsertarPedido", connection, transaction))
                    {
                        cmdPedido.CommandType = CommandType.StoredProcedure;
                        cmdPedido.Parameters.AddWithValue("@IDCLIENTE", idCliente);
                        cmdPedido.Parameters.AddWithValue("@IDUSUARIO", idUsuario);
                        cmdPedido.Parameters.AddWithValue("@TOTAL", total);
                        cmdPedido.Parameters.AddWithValue("@FECHAPEDIDO", fechaPedido);
                        cmdPedido.Parameters.AddWithValue("@ESTADO", estado);
                        cmdPedido.Parameters.AddWithValue("@OBSERVACIONES", observaciones); // ✅ Nuevo parámetro

                        int idPedido = Convert.ToInt32(cmdPedido.ExecuteScalar());

                        // Insertar los detalles del pedido
                        foreach (DetallePedido detalle in detalles)
                        {
                            using (SqlCommand cmdDetalle = new SqlCommand("InsertarDetallePedido", connection, transaction))
                            {
                                cmdDetalle.CommandType = CommandType.StoredProcedure;
                                cmdDetalle.Parameters.AddWithValue("@IDPEDIDO", idPedido);
                                cmdDetalle.Parameters.AddWithValue("@IDPRODUCTO", detalle.oProducto.IdProducto);
                                cmdDetalle.Parameters.AddWithValue("@CANTIDAD", detalle.CANTIDAD);
                                cmdDetalle.Parameters.AddWithValue("@PRECIOUNITARIO", detalle.PRECIOUNITARIO);
                                cmdDetalle.ExecuteNonQuery();
                            }
                        }
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    throw new Exception("Error al insertar el pedido y sus detalles: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }


        // Método para obtener el último ID de pedido
        public static int ObtenerUltimoIdPedido()
        {
            using (SqlConnection connection = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT ISNULL(MAX(IDPEDIDO), 0) FROM PEDIDO";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el último ID de pedido: " + ex.Message);
                }
            }
        }
        

        // Método para buscar un pedido por ID
        public static Pedido? BuscarPedidoPorId(int idPedido)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    connection.Open();
                    string query = @"
                    SELECT p.IDPEDIDO, p.TOTAL, p.FECHAPEDIDO, p.ESTADO, p.OBSERVACIONES,
                           c.IDCLIENTE, c.NOMBRE, c.CORREO, c.LOCALIDAD, c.PROVINCIA
                    FROM PEDIDO p
                    INNER JOIN CLIENTE c ON p.IDCLIENTE = c.IDCLIENTE
                    WHERE p.IDPEDIDO = @IDPEDIDO";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IDPEDIDO", idPedido);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Pedido
                                {
                                    IDPEDIDO = Convert.ToInt32(reader["IDPEDIDO"]),
                                    IDCliente = Convert.ToInt32(reader["IDCLIENTE"]), // ✅ AGREGALO
                                    oCliente = new Cliente
                                    {
                                        IDCliente = Convert.ToInt32(reader["IDCLIENTE"]),
                                        NOMBRE = reader["NOMBRE"]?.ToString() ?? string.Empty,
                                        CORREO = reader["CORREO"]?.ToString() ?? string.Empty,
                                        LOCALIDAD = reader["LOCALIDAD"]?.ToString() ?? string.Empty,
                                        PROVINCIA = reader["PROVINCIA"]?.ToString() ?? string.Empty
                                    },
                                    TOTAL = Convert.ToDecimal(reader["TOTAL"]),
                                    FECHAPEDIDO = reader["FECHAPEDIDO"] != DBNull.Value ? Convert.ToDateTime(reader["FECHAPEDIDO"]) : DateTime.MinValue,
                                    ESTADO = reader["ESTADO"]?.ToString() ?? string.Empty,
                                    OBSERVACIONES = reader["OBSERVACIONES"]?.ToString() ?? string.Empty
                                };

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar el pedido por ID: " + ex.Message);
                }
            }

            return null;
        }

        // Método para buscar pedidos por nombre del cliente
        public static List<Pedido> BuscarPedidosPorNombreCliente(string nombreCliente)
        {
            List<Pedido> pedidos = new List<Pedido>();

            using (SqlConnection connection = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    connection.Open();
                    string query = @"
                    SELECT p.IDPEDIDO, p.TOTAL, p.FECHAPEDIDO, p.ESTADO,
                           c.IDCLIENTE, c.NOMBRE, c.CORREO, c.LOCALIDAD, c.PROVINCIA
                    FROM PEDIDO p
                    INNER JOIN CLIENTE c ON p.IDCLIENTE = c.IDCLIENTE
                    WHERE c.NOMBRE LIKE '%' + @NOMBRE + '%'";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NOMBRE", nombreCliente);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                pedidos.Add(new Pedido
                                {
                                    IDPEDIDO = Convert.ToInt32(reader["IDPEDIDO"]),
                                    oCliente = new Cliente
                                    {
                                        IDCliente = Convert.ToInt32(reader["IDCLIENTE"]),
                                        NOMBRE = reader["NOMBRE"]?.ToString() ?? string.Empty
                                    },
                                    TOTAL = Convert.ToDecimal(reader["TOTAL"]),
                                    FECHAPEDIDO = reader["FECHAPEDIDO"] != DBNull.Value ? Convert.ToDateTime(reader["FECHAPEDIDO"]) : DateTime.MinValue,

                                    ESTADO = reader["ESTADO"]?.ToString() ?? string.Empty
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar pedidos por nombre del cliente: " + ex.Message);
                }
            }

            return pedidos;
        }


        public static List<Pedido> BuscarPedidosPorIdCliente(int idCliente)
        {
            List<Pedido> lista = new List<Pedido>();

            using (SqlConnection connection = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT IDPEDIDO, FECHAPEDIDO FROM PEDIDO WHERE IDCLIENTE = @IDCLIENTE", connection))
                    {
                        cmd.Parameters.AddWithValue("@IDCLIENTE", idCliente);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new Pedido
                                {
                                    IDPEDIDO = reader.GetInt32(0),
                                    FECHAPEDIDO = reader.GetDateTime(1),
                                    IDCliente = idCliente 
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar pedidos por ID de cliente: " + ex.Message);
                }
            }

            return lista;
        }




        // Método para listar todos los pedidos
        public static List<Pedido> ListarTodosLosPedidos()
        {
            List<Pedido> listaPedidos = new List<Pedido>();

            using (SqlConnection connection = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    connection.Open();
                    string query = @"
                SELECT p.IDPEDIDO, p.IDCLIENTE, p.IDUSUARIO, p.TOTAL, p.FECHAPEDIDO, p.ESTADO,
                       c.NOMBRE AS NombreCliente, u.NOMBRE AS NombreUsuario
                FROM PEDIDO p
                INNER JOIN CLIENTE c ON p.IDCLIENTE = c.IDCLIENTE
                INNER JOIN USUARIO u ON p.IDUSUARIO = u.IDUSUARIO";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Pedido pedido = new Pedido
                                {
                                    IDPEDIDO = Convert.ToInt32(reader["IDPEDIDO"]),
                                    IDCliente = Convert.ToInt32(reader["IDCLIENTE"]),
                                    IDUsuario = Convert.ToInt32(reader["IDUSUARIO"]),
                                    TOTAL = Convert.ToDecimal(reader["TOTAL"]),
                                    FECHAPEDIDO = reader["FECHAPEDIDO"] != DBNull.Value
    ? Convert.ToDateTime(reader["FECHAPEDIDO"])
    : DateTime.MinValue,
                                    ESTADO = reader["ESTADO"].ToString() ?? string.Empty,
                                    oCliente = new Cliente { NOMBRE = reader["NombreCliente"].ToString() ?? string.Empty },
                                    oUsuario = new Usuario { NOMBRE = reader["NombreUsuario"].ToString() ?? string.Empty }
                                };

                                listaPedidos.Add(pedido);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar todos los pedidos: " + ex.Message);
                }
            }

            return listaPedidos;
        }


        // Método para obtener los detalles de un pedido por su ID

        public static List<DetallePedido> ObtenerDetallesDelPedido(int idPedido)
        {
            List<DetallePedido> listaDetalles = new List<DetallePedido>();

            using (SqlConnection connection = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    connection.Open();
                    string query = @"
                SELECT d.IDDETALLE, d.IDPEDIDO, d.IDPRODUCTO, d.CANTIDAD, d.PRECIOUNITARIO, 
                       p.NOMBRE AS NombreProducto
                FROM DETALLE_PEDIDO d
                INNER JOIN PRODUCTO p ON d.IDPRODUCTO = p.IDPRODUCTO
                WHERE d.IDPEDIDO = @IDPEDIDO";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IDPEDIDO", idPedido);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DetallePedido detalle = new DetallePedido
                                {
                                    IDDETALLE = Convert.ToInt32(reader["IDDETALLE"]),
                                    oPedido = new Pedido { IDPEDIDO = Convert.ToInt32(reader["IDPEDIDO"]) },
                                    oProducto = new Producto
                                    {
                                        IdProducto = Convert.ToInt32(reader["IDPRODUCTO"]),
                                        Nombre = reader["NombreProducto"].ToString() ?? string.Empty
                                    },
                                    CANTIDAD = Convert.ToInt32(reader["CANTIDAD"]),
                                    PRECIOUNITARIO = Convert.ToDecimal(reader["PRECIOUNITARIO"]),
                                    SUBTOTAL = Convert.ToInt32(reader["CANTIDAD"]) * Convert.ToDecimal(reader["PRECIOUNITARIO"])
                                };

                                listaDetalles.Add(detalle);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los detalles del pedido: " + ex.Message);
                }
            }

            return listaDetalles;
        }



        // Método para listar todos los clientes desde la base de datos
        public static List<Cliente> ListarTodosLosClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();

            try
            {
                using (SqlConnection connection = new SqlConnection(Conexion.ObtenerCadenaConexion()))
                {
                    connection.Open();
                    string query = "SELECT IDCLIENTE, NOMBRE FROM CLIENTE WHERE ESTADO = 'Activo'";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Cliente cliente = new Cliente
                        {
                            IDCliente = Convert.ToInt32(reader["IDCLIENTE"]),
                            NOMBRE = reader["NOMBRE"]?.ToString() ?? string.Empty
                        };
                        listaClientes.Add(cliente);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de clientes: " + ex.Message);
            }

            return listaClientes;
        }



        public static List<Pago> ObtenerPagosDelPedido(int idPedido)
        {
            List<Pago> listaPagos = new List<Pago>();

            using (SqlConnection connection = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    connection.Open();
                    string query = @"
                SELECT IDPAGO, IDPEDIDO, MONTOPAGO, FECHAPAGO, METODOPAGO
                FROM PAGO
                WHERE IDPEDIDO = @IDPEDIDO";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IDPEDIDO", idPedido);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Pago pago = new Pago
                                {
                                    IDPAGO = Convert.ToInt32(reader["IDPAGO"]),
                                    IDPEDIDO = Convert.ToInt32(reader["IDPEDIDO"]),
                                    MONTOPAGO = Convert.ToDecimal(reader["MONTOPAGO"]),
                                    FECHAPAGO = Convert.ToDateTime(reader["FECHAPAGO"]),
                                    METODOPAGO = reader["METODOPAGO"]?.ToString() ?? string.Empty
                                };
                                listaPagos.Add(pago);
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

        public List<Pedido> ObtenerPedidosPorUsuarioYFechas(int idUsuario, DateTime fechaDesde, DateTime fechaHasta)
        {
            List<Pedido> listaPedidos = new List<Pedido>();

            using (SqlConnection conexion = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    conexion.Open();

                    // Log de las fechas antes de ejecutar el query
                    string logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "log.txt");
                   
                    File.AppendAllText(logPath, $"IDUsuario: {idUsuario}, Fecha Desde: {fechaDesde:yyyy-MM-dd HH:mm:ss}, Fecha Hasta: {fechaHasta:yyyy-MM-dd HH:mm:ss}{Environment.NewLine}");


                    string query = @"
            SELECT IDPEDIDO, TOTAL, FECHAPEDIDO
            FROM PEDIDO
            WHERE IDUSUARIO = @IDUsuario
              AND CAST(FECHAPEDIDO AS DATE) >= CAST(@FechaDesde AS DATE)
              AND CAST(FECHAPEDIDO AS DATE) <= CAST(@FechaHasta AS DATE)";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@IDUsuario", idUsuario);
                        comando.Parameters.AddWithValue("@FechaDesde", fechaDesde);
                        comando.Parameters.AddWithValue("@FechaHasta", fechaHasta);

                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listaPedidos.Add(new Pedido
                                {
                                    IDPEDIDO = reader.GetInt32(0),
                                    TOTAL = reader.GetDecimal(1),
                                    FECHAPEDIDO = reader.GetDateTime(2)
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener pedidos: " + ex.Message);
                }
            }

            return listaPedidos;
        }

        // Método para obtener el Top 10 de productos más vendidos por mes
        public static List<Producto> ObtenerTop10ProductosPorMes()
        {
            var listaProductos = new List<Producto>();

            using (SqlConnection connection = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            FORMAT(P.FECHAPEDIDO, 'yyyy-MM') AS Mes,
                            PR.NOMBRE AS Producto,
                            SUM(DP.CANTIDAD) AS CantidadVendida
                        FROM 
                            DETALLE_PEDIDO DP
                        INNER JOIN 
                            PRODUCTO PR ON DP.IDPRODUCTO = PR.IDPRODUCTO
                        INNER JOIN 
                            PEDIDO P ON DP.IDPEDIDO = P.IDPEDIDO
                        GROUP BY 
                            FORMAT(P.FECHAPEDIDO, 'yyyy-MM'), PR.NOMBRE
                        ORDER BY 
                            FORMAT(P.FECHAPEDIDO, 'yyyy-MM'), CantidadVendida DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listaProductos.Add(new Producto
                                {
                                    Mes = reader["Mes"].ToString(),
                                    Nombre = reader["Producto"].ToString(),
                                    CantidadVendida = Convert.ToInt32(reader["CantidadVendida"])
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los productos más vendidos: " + ex.Message);
                }
            }

            return listaProductos;
        }
        public static decimal ObtenerTotalVentasPorFechas(DateTime fechaDesde, DateTime fechaHasta)
        {
            decimal totalVentas = 0;

            using (SqlConnection conexion = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    conexion.Open();

                    string query = @"
                SELECT SUM(TOTAL) AS TotalVentas
                FROM PEDIDO
                WHERE CAST(FECHAPEDIDO AS DATE) >= CAST(@FechaDesde AS DATE)
                  AND CAST(FECHAPEDIDO AS DATE) <= CAST(@FechaHasta AS DATE)";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@FechaDesde", fechaDesde);
                        comando.Parameters.AddWithValue("@FechaHasta", fechaHasta);

                        object result = comando.ExecuteScalar();
                        totalVentas = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el total de ventas: " + ex.Message);
                }
            }

            return totalVentas;
        }

        public static bool ActualizarPedido(Pedido pedido, List<DetallePedido> nuevosDetalles)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                SqlTransaction? transaction = null;

                try
                {
                    var pedidoAnterior = BuscarPedidoPorId(pedido.IDPEDIDO);

                    connection.Open();
                    transaction = connection.BeginTransaction();

                    // Actualizar cabecera del pedido
                    using (SqlCommand cmdUpdate = new SqlCommand(@"
                UPDATE PEDIDO
                SET IDCLIENTE = @IDCLIENTE,
                    TOTAL = @TOTAL,
                    ESTADO = @ESTADO,
  OBSERVACIONES = @OBSERVACIONES
                WHERE IDPEDIDO = @IDPEDIDO", connection, transaction))
                    {
                        cmdUpdate.Parameters.AddWithValue("@IDPEDIDO", pedido.IDPEDIDO);
                        cmdUpdate.Parameters.AddWithValue("@IDCLIENTE", pedido.IDCliente);
                        cmdUpdate.Parameters.AddWithValue("@TOTAL", pedido.TOTAL);
                        cmdUpdate.Parameters.AddWithValue("@ESTADO", pedido.ESTADO);
                        cmdUpdate.Parameters.AddWithValue("@OBSERVACIONES", string.IsNullOrWhiteSpace(pedido.OBSERVACIONES) ? DBNull.Value : pedido.OBSERVACIONES);

                        cmdUpdate.ExecuteNonQuery();
                    }

                    // Eliminar los detalles anteriores
                    using (SqlCommand cmdDeleteDetalles = new SqlCommand(
                        "DELETE FROM DETALLE_PEDIDO WHERE IDPEDIDO = @IDPEDIDO", connection, transaction))
                    {
                        cmdDeleteDetalles.Parameters.AddWithValue("@IDPEDIDO", pedido.IDPEDIDO);
                        cmdDeleteDetalles.ExecuteNonQuery();
                    }

                    // Insertar nuevos detalles
                    foreach (var detalle in nuevosDetalles)
                    {
                        using (SqlCommand cmdInsertDetalle = new SqlCommand("InsertarDetallePedido", connection, transaction))
                        {
                            cmdInsertDetalle.CommandType = CommandType.StoredProcedure;
                            cmdInsertDetalle.Parameters.AddWithValue("@IDPEDIDO", pedido.IDPEDIDO);
                            cmdInsertDetalle.Parameters.AddWithValue("@IDPRODUCTO", detalle.oProducto.IdProducto);
                            cmdInsertDetalle.Parameters.AddWithValue("@CANTIDAD", detalle.CANTIDAD);
                            cmdInsertDetalle.Parameters.AddWithValue("@PRECIOUNITARIO", detalle.PRECIOUNITARIO);

                            cmdInsertDetalle.ExecuteNonQuery();
                        }
                    }
                    // Registrar cambio de estado
                    if (pedido.ESTADO != pedidoAnterior.ESTADO)
                    {
                        using (SqlCommand cmdAudit = new SqlCommand("INSERT INTO AUDITORIA_PEDIDO (IDPEDIDO, IDUSUARIO, CAMPO_MODIFICADO, VALOR_ANTERIOR, VALOR_NUEVO) VALUES (@IDPEDIDO, @IDUSUARIO, @CAMPO, @ANTERIOR, @NUEVO)", connection, transaction))
                        {
                            cmdAudit.Parameters.AddWithValue("@IDPEDIDO", pedido.IDPEDIDO);
                            cmdAudit.Parameters.AddWithValue("@IDUSUARIO", pedido.IDUsuario);
                            cmdAudit.Parameters.AddWithValue("@CAMPO", "Estado");
                            cmdAudit.Parameters.AddWithValue("@ANTERIOR", pedidoAnterior.ESTADO ?? (object)DBNull.Value);
                            cmdAudit.Parameters.AddWithValue("@NUEVO", pedido.ESTADO ?? (object)DBNull.Value);
                            cmdAudit.ExecuteNonQuery();
                        }
                    }

                    // Registrar cambio de observaciones
                    if ((pedido.OBSERVACIONES ?? "") != (pedidoAnterior.OBSERVACIONES ?? ""))
                    {
                        using (SqlCommand cmdAudit = new SqlCommand("INSERT INTO AUDITORIA_PEDIDO (IDPEDIDO, IDUSUARIO, CAMPO_MODIFICADO, VALOR_ANTERIOR, VALOR_NUEVO) VALUES (@IDPEDIDO, @IDUSUARIO, @CAMPO, @ANTERIOR, @NUEVO)", connection, transaction))
                        {
                            cmdAudit.Parameters.AddWithValue("@IDPEDIDO", pedido.IDPEDIDO);
                            cmdAudit.Parameters.AddWithValue("@IDUSUARIO", pedido.IDUsuario);
                            cmdAudit.Parameters.AddWithValue("@CAMPO", "Observaciones");
                            cmdAudit.Parameters.AddWithValue("@ANTERIOR", pedidoAnterior.OBSERVACIONES ?? (object)DBNull.Value);
                            cmdAudit.Parameters.AddWithValue("@NUEVO", pedido.OBSERVACIONES ?? (object)DBNull.Value);
                            cmdAudit.ExecuteNonQuery();
                        }
                    }

                    // También se puede agregar lógica similar para los ítems si querés registrar los cambios en detalle
                    // Registrar cambio de ítems si hubo cambios (se agregaron o eliminaron productos)
                    if (nuevosDetalles.Count > 0)
                    {
                        using (SqlCommand cmdAudit = new SqlCommand("INSERT INTO AUDITORIA_PEDIDO (IDPEDIDO, IDUSUARIO, CAMPO_MODIFICADO, VALOR_ANTERIOR, VALOR_NUEVO) VALUES (@IDPEDIDO, @IDUSUARIO, @CAMPO, @ANTERIOR, @NUEVO)", connection, transaction))
                        {
                            cmdAudit.Parameters.AddWithValue("@IDPEDIDO", pedido.IDPEDIDO);
                            cmdAudit.Parameters.AddWithValue("@IDUSUARIO", pedido.IDUsuario);
                            cmdAudit.Parameters.AddWithValue("@CAMPO", "Ítems");
                            cmdAudit.Parameters.AddWithValue("@ANTERIOR", "Detalle modificado");
                            cmdAudit.Parameters.AddWithValue("@NUEVO", "Detalle modificado");
                            cmdAudit.ExecuteNonQuery();
                        }
                    }


                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    throw new Exception("Error al actualizar el pedido: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }


        public static bool EliminarPedido(int idPedido, out string mensaje)
        {
            mensaje = "";
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.ObtenerCadenaConexion()))
                {
                    conexion.Open();
                    SqlTransaction transaccion = conexion.BeginTransaction();

                    try
                    {
                        // Primero eliminamos los detalles
                        using (SqlCommand cmdDetalles = new SqlCommand("DELETE FROM DETALLE_PEDIDO WHERE IDPEDIDO = @idPedido", conexion, transaccion))
                        {
                            cmdDetalles.Parameters.AddWithValue("@idPedido", idPedido);
                            cmdDetalles.ExecuteNonQuery();
                        }

                        // Luego eliminamos el pedido
                        using (SqlCommand cmdPedido = new SqlCommand("DELETE FROM PEDIDO WHERE IDPEDIDO = @idPedido", conexion, transaccion))
                        {
                            cmdPedido.Parameters.AddWithValue("@idPedido", idPedido);
                            cmdPedido.ExecuteNonQuery();
                        }

                        transaccion.Commit();
                        mensaje = "Pedido eliminado correctamente.";
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                        mensaje = "Error al eliminar el pedido: " + ex.Message;
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error general: " + ex.Message;
                return false;
            }
        }

        public static List<Pedido> FiltrarPedidosParaReporte(int idCliente, string estado, string filtroPago, DateTime fechaDesde, DateTime fechaHasta)
        {
            List<Pedido> lista = new List<Pedido>();

            using (SqlConnection connection = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    connection.Open();
                    string query = @"
                SELECT p.IDPEDIDO, p.IDCLIENTE, p.TOTAL, p.FECHAPEDIDO, p.ESTADO
                FROM PEDIDO p
                WHERE CAST(p.FECHAPEDIDO AS DATE) BETWEEN @Desde AND @Hasta";

                    if (idCliente > 0)
                        query += " AND p.IDCLIENTE = @IDCLIENTE";

                    if (!string.Equals(estado, "Todos", StringComparison.OrdinalIgnoreCase))
                        query += " AND p.ESTADO = @ESTADO";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Desde", fechaDesde.Date);
                        cmd.Parameters.AddWithValue("@Hasta", fechaHasta.Date);

                        if (idCliente > 0)
                            cmd.Parameters.AddWithValue("@IDCLIENTE", idCliente);

                        if (!string.Equals(estado, "Todos", StringComparison.OrdinalIgnoreCase))
                            cmd.Parameters.AddWithValue("@ESTADO", estado);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Pedido p = new Pedido
                                {
                                    IDPEDIDO = Convert.ToInt32(reader["IDPEDIDO"]),
                                    IDCliente = Convert.ToInt32(reader["IDCLIENTE"]),
                                    TOTAL = Convert.ToDecimal(reader["TOTAL"]),
                                    FECHAPEDIDO = Convert.ToDateTime(reader["FECHAPEDIDO"]),
                                    ESTADO = reader["ESTADO"].ToString(),
                                    oCliente = CD_Cliente.ObtenerClientePorId(Convert.ToInt32(reader["IDCLIENTE"])) // ✅ cliente completo
                                };

                                lista.Add(p);
                            }
                        }
                    }

                    // Calcular estado de pago por cada pedido
                    foreach (var pedido in lista.ToList())
                    {
                        var pagos = CD_Pago.ObtenerPagosDelPedido(pedido.IDPEDIDO);
                        decimal totalPagado = pagos.Sum(p => p.MONTOPAGO);

                        if (totalPagado == 0)
                            pedido.EstadoPago = "Sin pagos";
                        else if (totalPagado < pedido.TOTAL)
                            pedido.EstadoPago = "Pagado parcial";
                        else
                            pedido.EstadoPago = "Pagado total";

                        if (!string.Equals(filtroPago, "Todos", StringComparison.OrdinalIgnoreCase) &&
                            !string.Equals(pedido.EstadoPago, filtroPago, StringComparison.OrdinalIgnoreCase))
                        {
                            lista.Remove(pedido);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al filtrar pedidos para el reporte: " + ex.Message);
                }
            }

            return lista;
        }

        public static int ContarTodosLosPedidos()
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand("SELECT COUNT(*) FROM PEDIDO", conexion))
                {
                    return (int)comando.ExecuteScalar();
                }
            }
        }



    }
}
