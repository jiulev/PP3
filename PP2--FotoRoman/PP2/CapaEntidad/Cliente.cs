using System;

namespace CapaEntidad
{
    public class Cliente
    {
        public int IDCliente { get; set; }
        public int DOCUMENTO { get; set; }
        public string NOMBRE { get; set; } = string.Empty;
        public string CORREO { get; set; } = string.Empty;
        public string ESTADO { get; set; } = "Activo";
        public string LOCALIDAD { get; set; } = string.Empty;
        public string PROVINCIA { get; set; } = string.Empty;
        public DateTime? FECHACREACION { get; set; }
        public string TELEFONO { get; set; } = string.Empty;
        public string? CUIT { get; set; }
        public string? RAZONSOCIAL { get; set; }

        // ✅ Sobrescribir ToString para evitar errores en ComboBox
        public override string ToString()
        {
            return this.NOMBRE;
        }
    }
}
