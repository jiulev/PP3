// CapaEntidad ▸ CobroAuditoria.cs
namespace CapaEntidad
{
    public class CobroAuditoria
    {
        public int IDAUDITORIA { get; set; }
        public int IDPAGO { get; set; }
        public int IDPEDIDO { get; set; }
        public decimal MONTO_ANTERIOR { get; set; }
        public decimal MONTO_NUEVO { get; set; }
        public DateTime FECHA_CAMBIO { get; set; }
        public int IDUSUARIO { get; set; }
        public string USUARIO_NOMBRE { get; set; } = "";
    }
}
