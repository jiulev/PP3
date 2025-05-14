using System;
using System.Configuration;

namespace CapaDatos
{
    public class Conexion
    {
        // Método estático para obtener la cadena de conexión desde el App.config
        public static string ObtenerCadenaConexion()
        {
            // Obtiene la cadena de conexión llamada "cadena_conexion" desde el App.config
            string connectionString = ConfigurationManager.ConnectionStrings["cadena_conexion"].ConnectionString;
            return connectionString;
        }
    }
}
