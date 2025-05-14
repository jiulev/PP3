using System;

namespace CapaEntidad
{
    public class Producto
    {
        public int IdProducto { get; set; }  // ID autogenerado
        public string Nombre { get; set; } = string.Empty; // Nombre del producto
        public decimal Precio { get; set; }  // Precio del producto
        public string DescripcionCategoria { get; set; } = string.Empty; // Descripción de la categoría seleccionada por el usuario
        public DateTime FechaCreacion { get; set; }  // Fecha de creación, se define en la base de datos
                                                     // Propiedades para el reporte de productos más vendidos
        public string Mes { get; set; } = string.Empty; // Mes (yyyy-MM)
        public int CantidadVendida { get; set; } // Cantidad total vendida del producto
        public int IDCATEGORIA { get; set; } // FK real de la categoría
        public string EstadoActivo { get; set; } = "A"; // A: Activo, I: Inactivo

    }
}

