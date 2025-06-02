using System;

namespace CapaEntidad
{
    public class Categoria
    {
        public string ACTIVO { get; set; } = "A";
        public int IDCATEGORIA { get; set; }
        public string DESCRIPCION { get; set; } = string.Empty;
        public DateTime FECHACREACION { get; set; }

        public override string ToString()
        {
            return DESCRIPCION;
        }
    }
}
