using System;

namespace CapaEntidad
{
    public class Cliente
    {
        public int IDCliente { get; set; }  // ID autogenerado por la base de datos
        public int DOCUMENTO { get; set; }  // Documento del cliente (usado también como identificación única)
        public string NOMBRE { get; set; } = string.Empty;  // Nombre del cliente
        public string CORREO { get; set; } = string.Empty;  // Correo electrónico del cliente
        public string ESTADO { get; set; } = "Activo";  // Estado del cliente (ej: activo, inactivo), valor por defecto "Activo"
        public string LOCALIDAD { get; set; } = string.Empty;  // Localidad del cliente
        public string PROVINCIA { get; set; } = string.Empty;  // Provincia del cliente
        public DateTime? FECHACREACION { get; set; }  // Fecha de creación (opcional, se establece automáticamente en la base de datos)
        public string TELEFONO { get; set; } = string.Empty;
        public string? CUIT { get; set; }
        public string? RAZONSOCIAL { get; set; }



    }


}




