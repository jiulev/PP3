using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class DetallePedido
    {

        public int IDDETALLE { get; set; }
        public Pedido oPedido { get; set; } = new Pedido();
        public Producto oProducto { get; set; } = new Producto(); // Inicializar aquí

        public int CANTIDAD { get; set; }

        public decimal PRECIOUNITARIO { get; set; }
        public decimal SUBTOTAL { get; set; }
    }
}
