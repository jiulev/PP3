using CapaDatos;
using CapaEntidad;
using System;

namespace CapaNegocio
{
    public class CNProducto
    {
        public bool InsertarProducto(Producto producto, out string mensaje)
        {
            mensaje = string.Empty;

            // Validaciones de negocio
            if (string.IsNullOrWhiteSpace(producto.Nombre))
            {
                mensaje = "El nombre del producto es obligatorio.";
                return false;
            }
            if (producto.Precio <= 0)
            {
                mensaje = "El precio debe ser un valor positivo.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(producto.DescripcionCategoria))
            {
                mensaje = "Debe seleccionar una categoría válida.";
                return false;
            }

            try
            {
                // Llamada al método estático Insertar de CD_Producto
                CD_Producto.Insertar(producto);
                mensaje = "Producto registrado exitosamente.";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = $"Error al registrar el producto: {ex.Message}";
                return false;
            }
        }
        public static bool EstaEnPedidos(int idProducto)
        {
            return CD_Producto.EstaEnPedidos(idProducto);

        }
        public static List<Producto> ListarProductosActivos()
        {
            return CD_Producto.ListarProductosActivos();

        }
        public static List<(string NombreProducto, int CantidadVendida)> ObtenerTop10ProductosPorMes(int mes, int anio)
        {
            return CD_Producto.ObtenerTop10ProductosPorMes(mes, anio); // Pasa ambos parámetros a la capa de datos
        }


        // Método para obtener las descripciones de categorías
        public List<string> ObtenerDescripcionesCategorias()
        {
            return CD_Producto.ObtenerDescripcionesCategorias();
        }

        // Método para listar productos por categoría
        public static List<Producto> ListarPorCategoria(int idCategoria)
        {
            return CD_Producto.ListarPorCategoria(idCategoria);
        }


        public static List<Producto> ListarTodos()
        {
            return CD_Producto.ListarTodos();
        }

        public static bool DesactivarProducto(int idProducto, out string mensaje)
        {
            mensaje = "";

            if (CD_Producto.EstaEnPedidos(idProducto))
                mensaje = "Producto desactivado (está en pedidos previos).";
            else
                mensaje = "Producto eliminado lógicamente.";

            try
            {
                CD_Producto.CambiarEstado(idProducto, "I");
                return true;
            }
            catch (Exception ex)
            {
                mensaje = "Error al desactivar: " + ex.Message;
                return false;
            }
        }
        public static bool EditarProducto(Producto producto, out string mensaje)
        {
            mensaje = string.Empty;

            // Validaciones de negocio
            if (string.IsNullOrWhiteSpace(producto.Nombre))
            {
                mensaje = "El nombre del producto no puede estar vacío.";
                return false;
            }

            if (producto.Precio <= 0)
            {
                mensaje = "El precio debe ser mayor a cero.";
                return false;
            }

            if (producto.IDCATEGORIA <= 0)
            {
                mensaje = "Debe seleccionar una categoría válida.";
                return false;
            }

            try
            {
                CD_Producto.Editar(producto);
                mensaje = "Producto editado correctamente.";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = $"Error al editar el producto: {ex.Message}";
                return false;
            }
        }


    }
}
