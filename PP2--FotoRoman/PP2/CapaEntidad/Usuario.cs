using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaEntidad
{
    public class Usuario
    {
        public int IDUSUARIO { get; set; }
        public string NOMBRE { get; set; } = string.Empty;
        public string DOCUMENTO { get; set; } = string.Empty;
        public string EMAIL { get; set; } = string.Empty;
        public string PASSWORD { get; set; } = string.Empty;
        public Rol oRol { get; set; } = new Rol();
        public DateTime? FECHACREACION { get; set; } = null;
        public string ESTADO { get; set; } = "Activo"; // Nueva propiedad con valor por defecto
    }




    public static class UsuarioActual
    {
        public static Usuario Usuario { get; private set; }

        public static void IniciarSesion(Usuario usuario)
        {
            Usuario = usuario;
        }

        public static void CerrarSesion()
        {
            Usuario = null;
        }

        public static bool SesionIniciada => Usuario != null;
    }

}