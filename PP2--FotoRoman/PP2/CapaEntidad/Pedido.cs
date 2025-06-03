using System;

namespace CapaEntidad
{
    public class Pedido
    {
        // Propiedades del pedido
        public int IDPEDIDO { get; set; }
        public int IDCliente { get; set; }
        public int IDUsuario { get; set; }
        public decimal TOTAL { get; set; }
        public DateTime FECHAPEDIDO { get; set; } = DateTime.Now;
        public string ESTADO { get; set; } = string.Empty;
        public string OBSERVACIONES { get; set; } = string.Empty;  // ✅ NUEVO CAMPO

        // Referencias a otras entidades
        public Cliente oCliente { get; set; } = new Cliente();
        public Usuario oUsuario { get; set; } = new Usuario();

        // Propiedad adicional para el reporte
        public string EstadoPago { get; set; } = "Sin pagos";
    }
}
