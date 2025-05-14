using CapaDatos;  
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CNRol
    {
        private CD_Rol objcd_rol = new CD_Rol();

        // Método para insertar un rol
        public void Insertar(Rol rol)
        {
            objcd_rol.Insertar(rol);
        }
    }
}
