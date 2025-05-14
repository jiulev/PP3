namespace CapaEntidad
{
    public class Pago
    {
        public int IDPAGO { get; set; }
        public int IDPEDIDO { get; set; }
        public decimal MONTOPAGO { get; set; }
        public DateTime FECHAPAGO { get; set; }
        public string METODOPAGO { get; set; } = string.Empty;
    }
}

