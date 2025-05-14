using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Localidades
    {
        // Método para listar provincias

        public static List<Provincia> ListarProvincias()
        {
            List<Provincia> provincias = new List<Provincia>();

            using (SqlConnection connection = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT IDPROVINCIA, NOMBRE FROM PROVINCIA";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            provincias.Add(new Provincia
                            {
                                IDProvincia = Convert.ToInt32(reader["IDPROVINCIA"]),
                                Nombre = reader["NOMBRE"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar las provincias: " + ex.Message);
                }
            }

            return provincias;
        }


        // Método para listar localidades por provincia
        public static List<Localidad> ListarLocalidadesPorProvincia(int idProvincia)
        {
            List<Localidad> localidades = new List<Localidad>();

            using (SqlConnection connection = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT IDLOCALIDAD, NOMBRE FROM LOCALIDAD WHERE IDPROVINCIA = @IDPROVINCIA";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IDPROVINCIA", idProvincia);

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            localidades.Add(new Localidad
                            {
                                IDLocalidad = Convert.ToInt32(reader["IDLOCALIDAD"]),
                                Nombre = reader["NOMBRE"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar las localidades: " + ex.Message);
                }
            }

            return localidades;
        }

        // Método para insertar una nueva provincia
        public static int InsertarProvincia(string nombreProvincia)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO PROVINCIA (NOMBRE) OUTPUT INSERTED.IDPROVINCIA VALUES (@NOMBRE)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NOMBRE", nombreProvincia);
                        return (int)command.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar la provincia: " + ex.Message);
                }
            }
        }

        // Método para insertar una nueva localidad
        public static int InsertarLocalidad(string nombreLocalidad, int idProvincia)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO LOCALIDAD (NOMBRE, IDPROVINCIA) OUTPUT INSERTED.IDLOCALIDAD VALUES (@NOMBRE, @IDPROVINCIA)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NOMBRE", nombreLocalidad);
                        command.Parameters.AddWithValue("@IDPROVINCIA", idProvincia);
                        return (int)command.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar la localidad: " + ex.Message);
                }
            }
        }
    }
}
