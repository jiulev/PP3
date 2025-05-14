using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Rol
    {
        public int IDROL { get; set; }  // ID del rol (PK), no acepta null
        public string? DESCRIPCION { get; set; }  // Permitir null
        public DateTime? FECHACREACION { get; set; }  // Permitir null
    }
}
