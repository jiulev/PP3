using System;
using System.Collections.Generic;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CNPedido
    {
        // Método para insertar un pedido y sus detalles
        public static bool InsertarPedido(int idCliente, int idUsuario, decimal total, DateTime fechaPedido, string estado, string observaciones, List<DetallePedido> detalles, out string mensaje)
        {
            mensaje = string.Empty;

            if (idCliente <= 0)
            {
                mensaje = "El ID del cliente es inválido.";
                return false;
            }
            if (idUsuario <= 0)
            {
                mensaje = "El ID del usuario es inválido.";
                return false;
            }
            if (detalles == null || detalles.Count == 0)
            {
                mensaje = "El pedido no tiene detalles.";
                return false;
            }

            try
            {
                bool resultado = CD_Pedido.InsertarPedido(idCliente, idUsuario, total, fechaPedido, estado, observaciones, detalles); // ✅ pasa observaciones

                if (resultado)
                {
                    mensaje = "Pedido insertado exitosamente.";
                    return true;
                }
                else
                {
                    mensaje = "Error al insertar el pedido en la base de datos.";
                    return false;
                }
            }
            catch (Exception ex)
            {
                mensaje = $"Error al insertar el pedido: {ex.Message}";
                return false;
            }
        }

        // Método para obtener el próximo número de pedido
        public static int ObtenerProximoNumeroPedido()
        {
            try
            {
                return CD_Pedido.ObtenerUltimoIdPedido() + 1;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el próximo número de pedido: {ex.Message}");
            }
        }
     

        // Método para obtener el último ID de pedido
        public static int ObtenerUltimoIdPedido()
        {
            try
            {
                return CD_Pedido.ObtenerUltimoIdPedido();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el último ID de pedido: {ex.Message}");
            }
        }

        // Método para buscar un pedido por ID
        public static Pedido? BuscarPedidoPorId(int idPedido)
        {
            try
            {
                return CD_Pedido.BuscarPedidoPorId(idPedido);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de negocio al buscar el pedido: " + ex.Message);
            }
        }

        // Método para buscar pedidos por nombre del cliente
        public static List<Pedido> BuscarPedidosPorNombreCliente(string nombreCliente)
        {
            try
            {
                return CD_Pedido.BuscarPedidosPorNombreCliente(nombreCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de negocio al buscar pedidos por nombre del cliente: " + ex.Message);
            }
        }

        // Método para listar todos los pedidos
        public static List<Pedido> ListarTodosLosPedidos()
        {
            try
            {
                return CD_Pedido.ListarTodosLosPedidos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar todos los pedidos: " + ex.Message);
            }
        }

        // Método para obtener detalles del pedido
        public static List<DetallePedido> ObtenerDetallesDelPedido(int idPedido)
        {
            try
            {
                var detalles = CD_Pedido.ObtenerDetallesDelPedido(idPedido);
                foreach (var detalle in detalles)
                {
                    detalle.SUBTOTAL = detalle.CANTIDAD * detalle.PRECIOUNITARIO;
                }
                return detalles;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener detalles del pedido: " + ex.Message);
            }
        }


        // Método para obtener los pagos del pedido
        public static List<Pago> ObtenerPagosDelPedido(int idPedido)
        {
            try
            {
                return CD_Pedido.ObtenerPagosDelPedido(idPedido);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los pagos del pedido: " + ex.Message);
            }
        }

        public static int ObtenerIdClientePorNombre(string nombreCompleto)
        {
            return CD_Cliente.ObtenerIdClientePorNombre(nombreCompleto);
        }



        // Método para listar todos los clientes
        public static List<Cliente> ListarTodosLosClientes()
        {
            try
            {
                return CD_Pedido.ListarTodosLosClientes();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar todos los clientes: " + ex.Message);
            }
        }



        public static List<Pedido> ObtenerPedidosPorUsuarioYFechas(int idUsuario, DateTime fechaDesde, DateTime fechaHasta)
        {
            return new CD_Pedido().ObtenerPedidosPorUsuarioYFechas(idUsuario, fechaDesde, fechaHasta);
        }






        public static (decimal TotalVentas, decimal VentasUsuario, decimal Porcentaje) CalcularEstadisticas(int idUsuario, DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                // Obtener las ventas del usuario
                var pedidosUsuario = new CD_Pedido().ObtenerPedidosPorUsuarioYFechas(idUsuario, fechaDesde, fechaHasta);
                decimal ventasUsuario = pedidosUsuario.Sum(p => p.TOTAL);

                // Obtener el total de ventas en el rango
                decimal totalVentas = CD_Pedido.ObtenerTotalVentasPorFechas(fechaDesde, fechaHasta);

                // Calcular el porcentaje
                decimal porcentaje = totalVentas > 0 ? (ventasUsuario / totalVentas) * 100 : 0;

                return (totalVentas, ventasUsuario, porcentaje);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al calcular estadísticas: " + ex.Message);
            }
        }
        public static List<Pedido> BuscarPedidosPorIdCliente(int idCliente)
        {
            try
            {
                return CD_Pedido.BuscarPedidosPorIdCliente(idCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar pedidos por ID de cliente: " + ex.Message);
            }
        }




        public static bool ActualizarPedido(Pedido pedido, List<DetallePedido> nuevosDetalles, out string mensaje)
        {
            mensaje = string.Empty;

            if (pedido == null || pedido.IDPEDIDO <= 0)
            {
                mensaje = "El pedido no es válido.";
                return false;
            }

            if (nuevosDetalles == null || nuevosDetalles.Count == 0)
            {
                mensaje = "El pedido debe tener al menos un detalle.";
                return false;
            }

            try
            {
                // Llamar a la capa de datos
                bool actualizado = CD_Pedido.ActualizarPedido(pedido, nuevosDetalles);

                if (actualizado)
                {
                    mensaje = "Pedido actualizado exitosamente.";
                    return true;
                }
                else
                {
                    mensaje = "No se pudo actualizar el pedido.";
                    return false;
                }
            }
            catch (Exception ex)
            {
                mensaje = $"Error al actualizar el pedido: {ex.Message}";
                return false;
            }
        }

        public static bool EliminarPedido(int idPedido, out string mensaje)
        {
            return CD_Pedido.EliminarPedido(idPedido, out mensaje);
        }




    }
}
