using System;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Rol
    {
        public void Insertar(Rol rol)
        {
            using (SqlConnection oconexion = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    oconexion.Open();

                    // Consulta SQL para insertar un nuevo rol
                    string query = "INSERT INTO ROL (DESCRIPCION) VALUES (@DESCRIPCION)";

                    using (SqlCommand command = new SqlCommand(query, oconexion))
                    {
                        command.Parameters.AddWithValue("@DESCRIPCION", rol.DESCRIPCION ?? string.Empty); // Aseguramos que la descripción no sea nula

                        // Ejecutar la consulta
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar el rol", ex);
                }
            }
        }
    }
}


