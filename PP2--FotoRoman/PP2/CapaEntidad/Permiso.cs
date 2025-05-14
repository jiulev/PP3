using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Permiso
    {
        public int IDPERMISO { get; set; }
        public Rol oRol { get; set; }
        public string NOMBREMENU { get; set; }
        public string FECHACREACION { get; set; }
    }
}
