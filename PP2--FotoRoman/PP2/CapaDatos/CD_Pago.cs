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

                    // Obtener pagos anteriores
                    List<Pago> pagosAnteriores = new List<Pago>();
                    using (SqlCommand cmdOld = new SqlCommand(@"SELECT IDPAGO, IDPEDIDO, MONTOPAGO, FECHAPAGO, METODOPAGO FROM PAGO WHERE IDPEDIDO = @IDPEDIDO", connection, transaction))
                    {
                        cmdOld.Parameters.AddWithValue("@IDPEDIDO", idPedido);
                        using (SqlDataReader reader = cmdOld.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                pagosAnteriores.Add(new Pago
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

                    // MARCAR los pagos existentes que fueron actualizados
                    HashSet<int> pagosYaProcesados = new HashSet<int>();

                    foreach (var nuevo in nuevosPagos)
                    {
                        var anterior = pagosAnteriores.FirstOrDefault(p => p.METODOPAGO.Equals(nuevo.METODOPAGO, StringComparison.OrdinalIgnoreCase));

                        if (anterior != null)
                        {
                            pagosYaProcesados.Add(anterior.IDPAGO);

                            if (anterior.MONTOPAGO != nuevo.MONTOPAGO)
                            {
                                // UPDATE + Auditoría
                                using (SqlCommand cmdUpdate = new SqlCommand(@"UPDATE PAGO SET MONTOPAGO = @Monto, FECHAPAGO = @Fecha WHERE IDPAGO = @ID", connection, transaction))
                                {
                                    cmdUpdate.Parameters.AddWithValue("@Monto", nuevo.MONTOPAGO);
                                    cmdUpdate.Parameters.AddWithValue("@Fecha", DateTime.Now);
                                    cmdUpdate.Parameters.AddWithValue("@ID", anterior.IDPAGO);
                                    cmdUpdate.ExecuteNonQuery();
                                }

                                // Auditoría por cambio
                                string sqlAudit = @"INSERT INTO cobro_auditoria (IDPAGO, IDPEDIDO, MONTO_ANTERIOR, MONTO_NUEVO, FECHA_CAMBIO, IDUSUARIO, USUARIO_NOMBRE)
                                           VALUES (@IdPago, @IdPedido, @MontoAnterior, @MontoNuevo, GETDATE(), @IdUsuario, @UsuarioNombre)";

                                using (SqlCommand auditCmd = new SqlCommand(sqlAudit, connection, transaction))
                                {
                                    auditCmd.Parameters.AddWithValue("@IdPago", anterior.IDPAGO);
                                    auditCmd.Parameters.AddWithValue("@IdPedido", anterior.IDPEDIDO);
                                    auditCmd.Parameters.AddWithValue("@MontoAnterior", anterior.MONTOPAGO);
                                    auditCmd.Parameters.AddWithValue("@MontoNuevo", nuevo.MONTOPAGO);
                                    auditCmd.Parameters.AddWithValue("@IdUsuario", UsuarioActual.Usuario.IDUSUARIO);
                                    auditCmd.Parameters.AddWithValue("@UsuarioNombre", UsuarioActual.Usuario.NOMBRE);
                                    auditCmd.ExecuteNonQuery();
                                }
                            }
                            // Si el monto no cambia, no hacemos nada
                        }
                        else
                        {
                            // Nuevo pago → INSERT + Auditoría con anterior = 0
                            using (SqlCommand insertCmd = new SqlCommand("InsertarPago", connection, transaction))
                            {
                                insertCmd.CommandType = CommandType.StoredProcedure;
                                insertCmd.Parameters.AddWithValue("@IDPEDIDO", nuevo.IDPEDIDO);
                                insertCmd.Parameters.AddWithValue("@MONTOPAGO", nuevo.MONTOPAGO);
                                insertCmd.Parameters.AddWithValue("@METODOPAGO", nuevo.METODOPAGO ?? (object)DBNull.Value);
                                insertCmd.ExecuteNonQuery();
                            }

                            // Auditoría por alta
                            string sqlAudit = @"INSERT INTO cobro_auditoria (IDPAGO, IDPEDIDO, MONTO_ANTERIOR, MONTO_NUEVO, FECHA_CAMBIO, IDUSUARIO, USUARIO_NOMBRE)
                                       VALUES (0, @IdPedido, 0, @MontoNuevo, GETDATE(), @IdUsuario, @UsuarioNombre)";

                            using (SqlCommand auditCmd = new SqlCommand(sqlAudit, connection, transaction))
                            {
                                auditCmd.Parameters.AddWithValue("@IdPedido", nuevo.IDPEDIDO);
                                auditCmd.Parameters.AddWithValue("@MontoNuevo", nuevo.MONTOPAGO);
                                auditCmd.Parameters.AddWithValue("@IdUsuario", UsuarioActual.Usuario.IDUSUARIO);
                                auditCmd.Parameters.AddWithValue("@UsuarioNombre", UsuarioActual.Usuario.NOMBRE);
                                auditCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    // Borrar pagos antiguos que no están en la lista nueva
                    foreach (var anterior in pagosAnteriores)
                    {
                        if (!pagosYaProcesados.Contains(anterior.IDPAGO))
                        {
                            using (SqlCommand deleteCmd = new SqlCommand("DELETE FROM PAGO WHERE IDPAGO = @ID", connection, transaction))
                            {
                                deleteCmd.Parameters.AddWithValue("@ID", anterior.IDPAGO);
                                deleteCmd.ExecuteNonQuery();
                            }

                            // Auditoría por baja
                            string sqlAudit = @"INSERT INTO cobro_auditoria (IDPAGO, IDPEDIDO, MONTO_ANTERIOR, MONTO_NUEVO, FECHA_CAMBIO, IDUSUARIO, USUARIO_NOMBRE)
                                       VALUES (@IdPago, @IdPedido, @MontoAnterior, 0, GETDATE(), @IdUsuario, @UsuarioNombre)";

                            using (SqlCommand auditCmd = new SqlCommand(sqlAudit, connection, transaction))
                            {
                                auditCmd.Parameters.AddWithValue("@IdPago", anterior.IDPAGO);
                                auditCmd.Parameters.AddWithValue("@IdPedido", anterior.IDPEDIDO);
                                auditCmd.Parameters.AddWithValue("@MontoAnterior", anterior.MONTOPAGO);
                                auditCmd.Parameters.AddWithValue("@IdUsuario", UsuarioActual.Usuario.IDUSUARIO);
                                auditCmd.Parameters.AddWithValue("@UsuarioNombre", UsuarioActual.Usuario.NOMBRE);
                                auditCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    transaction.Commit();
                    mensaje = "Pagos modificados correctamente con auditoría.";
                    return true;
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    mensaje = "Error: " + ex.Message;
                    return false;
                }
            }
        }
        // En CD_Pago.cs

        public static bool ReemplazarPagosDelPedidoManteniendoExistentes(int idPedido, List<Pago> nuevosPagos, out string mensaje)
        {
            mensaje = string.Empty;

            using (SqlConnection connection = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                SqlTransaction transaction = null;

                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    // 1️⃣ Obtener pagos existentes
                    List<Pago> pagosAnteriores = new List<Pago>();
                    using (SqlCommand cmdOld = new SqlCommand(@"
                SELECT IDPAGO, IDPEDIDO, MONTOPAGO, FECHAPAGO, METODOPAGO
                FROM PAGO
                WHERE IDPEDIDO = @IDPEDIDO", connection, transaction))
                    {
                        cmdOld.Parameters.AddWithValue("@IDPEDIDO", idPedido);
                        using (SqlDataReader reader = cmdOld.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                pagosAnteriores.Add(new Pago
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

                    // 2️⃣ Actualizar o auditar los pagos existentes
                    for (int i = 0; i < nuevosPagos.Count; i++)
                    {
                        var nuevo = nuevosPagos[i];

                        if (i < pagosAnteriores.Count)
                        {
                            var anterior = pagosAnteriores[i];

                            // Si cambió el monto o el método, lo actualizamos y auditamos
                            if (anterior.MONTOPAGO != nuevo.MONTOPAGO || anterior.METODOPAGO != nuevo.METODOPAGO)
                            {
                                string updateSql = @"UPDATE PAGO
                            SET MONTOPAGO = @Monto, METODOPAGO = @Metodo, FECHAPAGO = @Fecha
                            WHERE IDPAGO = @IdPago";

                                using (SqlCommand cmd = new SqlCommand(updateSql, connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@Monto", nuevo.MONTOPAGO);
                                    cmd.Parameters.AddWithValue("@Metodo", nuevo.METODOPAGO);
                                    cmd.Parameters.AddWithValue("@Fecha", DateTime.Now);
                                    cmd.Parameters.AddWithValue("@IdPago", anterior.IDPAGO);
                                    cmd.ExecuteNonQuery();
                                }

                                string auditSql = @"INSERT INTO cobro_auditoria
                            (IDPAGO, IDPEDIDO, MONTO_ANTERIOR, MONTO_NUEVO, FECHA_CAMBIO, IDUSUARIO, USUARIO_NOMBRE)
                            VALUES (@IdPago, @IdPedido, @MontoAnterior, @MontoNuevo, GETDATE(), @IdUsuario, @UsuarioNombre)";

                                using (SqlCommand cmd = new SqlCommand(auditSql, connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@IdPago", anterior.IDPAGO);
                                    cmd.Parameters.AddWithValue("@IdPedido", anterior.IDPEDIDO);
                                    cmd.Parameters.AddWithValue("@MontoAnterior", anterior.MONTOPAGO);
                                    cmd.Parameters.AddWithValue("@MontoNuevo", nuevo.MONTOPAGO);
                                    cmd.Parameters.AddWithValue("@IdUsuario", UsuarioActual.Usuario.IDUSUARIO);
                                    cmd.Parameters.AddWithValue("@UsuarioNombre", UsuarioActual.Usuario.NOMBRE);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            // Si no cambió, no hacemos nada (ni update ni auditoría)
                        }
                        else
                        {
                            // 3️⃣ Es un pago nuevo → insertar
                            using (SqlCommand insertCmd = new SqlCommand("InsertarPago", connection, transaction))
                            {
                                insertCmd.CommandType = CommandType.StoredProcedure;
                                insertCmd.Parameters.AddWithValue("@IDPEDIDO", nuevo.IDPEDIDO);
                                insertCmd.Parameters.AddWithValue("@MONTOPAGO", nuevo.MONTOPAGO);
                                insertCmd.Parameters.AddWithValue("@METODOPAGO", nuevo.METODOPAGO ?? (object)DBNull.Value);
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    // 4️⃣ Si hay pagos antiguos que no están en nuevos → eliminarlos
                    if (pagosAnteriores.Count > nuevosPagos.Count)
                    {
                        for (int i = nuevosPagos.Count; i < pagosAnteriores.Count; i++)
                        {
                            int idPagoAEliminar = pagosAnteriores[i].IDPAGO;
                            using (SqlCommand deleteCmd = new SqlCommand("DELETE FROM PAGO WHERE IDPAGO = @IDPAGO", connection, transaction))
                            {
                                deleteCmd.Parameters.AddWithValue("@IDPAGO", idPagoAEliminar);
                                deleteCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    transaction.Commit();
                    mensaje = "Pagos actualizados correctamente.";
                    return true;
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    mensaje = "Error al procesar pagos: " + ex.Message;
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
        // CapaDatos ▸ CD_Pago.cs  (agrega al final de la clase)
        private void RegistrarAuditoria(SqlConnection cn, SqlTransaction trx, CobroAuditoria audit)
        {
            string sql = @"INSERT INTO cobro_auditoria
                   (IDPAGO, IDPEDIDO, MONTO_ANTERIOR, MONTO_NUEVO,
                    FECHA_CAMBIO, IDUSUARIO, USUARIO_NOMBRE)
                   VALUES (@IdPago,@IdPedido,@MontoAnterior,@MontoNuevo,
                           GETDATE(),@IdUsuario,@UsuarioNombre);";

            using (SqlCommand cmd = new SqlCommand(sql, cn, trx))
            {
                cmd.Parameters.AddWithValue("@IdPago", audit.IDPAGO);
                cmd.Parameters.AddWithValue("@IdPedido", audit.IDPEDIDO);
                cmd.Parameters.AddWithValue("@MontoAnterior", audit.MONTO_ANTERIOR);
                cmd.Parameters.AddWithValue("@MontoNuevo", audit.MONTO_NUEVO);
                cmd.Parameters.AddWithValue("@IdUsuario", audit.IDUSUARIO);
                cmd.Parameters.AddWithValue("@UsuarioNombre", audit.USUARIO_NOMBRE);
                cmd.ExecuteNonQuery();
            }
        }
        // dentro de CD_Pago
        public bool ActualizarPago(Pago pagoEditado,
                                   decimal montoAnterior,
                                   out string mensaje)
        {
            mensaje = "";
            bool ok = false;

            using (SqlConnection cn = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                cn.Open();
                SqlTransaction trx = cn.BeginTransaction();

                try
                {
                    // 1) UPDATE del pago
                    string sqlUp = @"UPDATE Pago
                             SET MONTOPAGO = @MontoNuevo,
                                 MEDIOPAGO = @MedioPago,
                                 FECHAPAGO = @FechaPago
                             WHERE IDPAGO = @IdPago";

                    using (SqlCommand cmdUp = new SqlCommand(sqlUp, cn, trx))
                    {
                        cmdUp.Parameters.AddWithValue("@MontoNuevo", pagoEditado.MONTOPAGO);
                        cmdUp.Parameters.AddWithValue("@MedioPago", pagoEditado.MONTOPAGO);
                        cmdUp.Parameters.AddWithValue("@FechaPago", pagoEditado.FECHAPAGO);
                        cmdUp.Parameters.AddWithValue("@IdPago", pagoEditado.IDPAGO);
                        cmdUp.ExecuteNonQuery();
                    }

                    // 2) Auditoría
                    var audit = new CobroAuditoria
                    {
                        IDPAGO = pagoEditado.IDPAGO,
                        IDPEDIDO = pagoEditado.IDPEDIDO,
                        MONTO_ANTERIOR = montoAnterior,
                        MONTO_NUEVO = pagoEditado.MONTOPAGO,
                        IDUSUARIO = UsuarioActual.Usuario.IDUSUARIO,
                        USUARIO_NOMBRE = UsuarioActual.Usuario.NOMBRE
                    };
                    RegistrarAuditoria(cn, trx, audit);

                    trx.Commit();
                    ok = true;
                    mensaje = "Cobro actualizado y auditado correctamente.";
                }
                catch (Exception ex)
                {
                    trx.Rollback();
                    mensaje = "Error al actualizar cobro: " + ex.Message;
                }
            }

            return ok;
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
