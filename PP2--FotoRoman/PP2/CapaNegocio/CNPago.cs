using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CNPago
    {
        // Método para insertar una lista de pagos
        public static bool InsertarPagos(List<Pago> detallesPago, out string mensaje)
        {
            mensaje = string.Empty;

            try
            {
                // Recorrer cada pago y llamarlo a la capa de datos
                foreach (var pago in detallesPago)
                {
                    // Llamar al método de la capa de datos para insertar el pago
                    CD_Pago.InsertarPago(pago);
                }

                mensaje = "Pagos insertados exitosamente.";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = $"Error al insertar los pagos: {ex.Message}";
                return false;
            }
        }

        // CapaNegocio ▸ CNPago.cs
        public static bool EditarPago(Pago pagoEditado,
                                      decimal montoAnterior,
                                      out string mensaje)
        {
            // validaciones (rol, fecha, etcc.)
            return new CD_Pago().ActualizarPago(pagoEditado, montoAnterior, out mensaje);
        }

        public static Pedido ObtenerPedidoPorId(int idPedido)
        {
            return CD_Pago.ObtenerPedidoPorId(idPedido);
        }

        public static List<Pedido> ObtenerPedidosConImporteYEstado(int idCliente)
        {
            return CD_Pago.ObtenerPedidosConImporteYEstado(idCliente);
        }

        // Método para obtener los pedidos con pagos de un cliente
        public static List<int> ObtenerPedidosConPagos(int idCliente)
        {
            return CD_Pago.ObtenerPedidosConPagos(idCliente);
        }

        // Método para obtener los pagos de un pedido específico
        public static List<Pago> ObtenerPagosDelPedido(int idPedido)
        {
            return CD_Pago.ObtenerPagosDelPedido(idPedido);
        }
        public static bool ReemplazarPagosDelPedido(int idPedido, List<Pago> nuevosPagos, out string mensaje)
        {
            return CD_Pago.ReemplazarPagosDelPedido(idPedido, nuevosPagos, out mensaje);
        }
        public static bool ReemplazarPagosDelPedidoManteniendoExistentes(int idPedido, List<Pago> nuevosPagos, out string mensaje)
        {
            return CD_Pago.ReemplazarPagosDelPedidoManteniendoExistentes(idPedido, nuevosPagos, out mensaje);
        }

        public static List<Pedido> ObtenerPedidosPorCliente(int idCliente)
        {
            return CD_Pago.ObtenerPedidosPorCliente(idCliente); // Lo hacemos ahora en la capa de datos
        }

    }
}
