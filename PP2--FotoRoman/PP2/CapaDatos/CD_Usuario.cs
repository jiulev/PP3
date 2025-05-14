using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Usuario
    {
        // Método para listar los usuarios desde la tabla "Usuario"
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    oconexion.Open();

                    string query = @"
           SELECT 
        U.IDUSUARIO, 
        U.NOMBRE, 
        U.DOCUMENTO, 
        U.EMAIL, 
        U.PASSWORD, 
        U.FECHACREACION,
        U.IDROL,
        U.ESTADO,
        R.DESCRIPCION AS ROL_DESCRIPCION
    FROM Usuario U
    INNER JOIN Rol R ON U.IDROL = R.IDROL
    WHERE U.ESTADO = 'Activo'";

                    using (SqlCommand command = new SqlCommand(query, oconexion))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Usuario usuario = new Usuario
                            {
                                IDUSUARIO = reader["IDUSUARIO"] != DBNull.Value ? Convert.ToInt32(reader["IDUSUARIO"]) : 0,
                                NOMBRE = reader["NOMBRE"].ToString() ?? string.Empty,
                                DOCUMENTO = reader["DOCUMENTO"].ToString() ?? string.Empty,
                                EMAIL = reader["EMAIL"].ToString() ?? string.Empty,
                                PASSWORD = reader["PASSWORD"].ToString() ?? string.Empty,
                                FECHACREACION = reader["FECHACREACION"] != DBNull.Value ? Convert.ToDateTime(reader["FECHACREACION"]) : (DateTime?)null,
                                oRol = new Rol
                                {
                                    IDROL = reader["IDROL"] != DBNull.Value ? Convert.ToInt32(reader["IDROL"]) : 0, // Asignamos el IDROL
                                    DESCRIPCION = reader["ROL_DESCRIPCION"].ToString() ?? string.Empty
                                }
                            };

                            lista.Add(usuario);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al listar los usuarios: " + ex.Message);
                }
            }

            return lista;
        }

        public void Bloquear(int idUsuario)
        {
            using (SqlConnection oconexion = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    oconexion.Open();

                    string query = "UPDATE Usuario SET Estado = 'Bloqueado' WHERE IDUSUARIO = @IDUsuario";

                    using (SqlCommand command = new SqlCommand(query, oconexion))
                    {
                        command.Parameters.AddWithValue("@IDUsuario", idUsuario);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al bloquear el usuario", ex);
                }
            }
        }


        //listar eb reporte
        public List<string> ListarNombres()
        {
            List<string> nombres = new List<string>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    oconexion.Open();

                    string query = "SELECT NOMBRE FROM Usuario";

                    using (SqlCommand command = new SqlCommand(query, oconexion))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            string nombre = reader["NOMBRE"].ToString();
                            if (!string.IsNullOrEmpty(nombre))
                            {
                                nombres.Add(nombre);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al listar los nombres de usuarios: " + ex.Message);
                }
            }

            return nombres;
        }


        // Método para insertar un usuario en la base de datos
        public void Insertar(Usuario usuario)
        {
            using (SqlConnection oconexion = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    oconexion.Open();

                    string query = @"
                INSERT INTO Usuario (NOMBRE, EMAIL, PASSWORD, IDROL, FECHACREACION, DOCUMENTO, ESTADO) 
                VALUES (@Nombre, @Email, @Password, @IDROL, GETDATE(), @Documento, 'Activo')";

                    using (SqlCommand command = new SqlCommand(query, oconexion))
                    {
                        command.Parameters.AddWithValue("@Nombre", usuario.NOMBRE ?? string.Empty);
                        command.Parameters.AddWithValue("@Email", usuario.EMAIL ?? string.Empty);
                        command.Parameters.AddWithValue("@Password", usuario.PASSWORD ?? string.Empty);
                        command.Parameters.AddWithValue("@IDROL", usuario.oRol?.IDROL ?? 0);
                        command.Parameters.AddWithValue("@Documento", usuario.DOCUMENTO ?? string.Empty);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar el usuario", ex);
                }
            }
        }


        // Método para editar un usuario existente
        public void Editar(Usuario usuario)
        {
            using (SqlConnection oconexion = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    oconexion.Open();

                    string query = @"
                UPDATE Usuario
                SET 
                    NOMBRE = @Nombre, 
                    EMAIL = @Email, 
                    PASSWORD = @Password, 
                    IDROL = @IDRol
                WHERE IDUSUARIO = @IDUsuario";

                    using (SqlCommand command = new SqlCommand(query, oconexion))
                    {
                        command.Parameters.AddWithValue("@Nombre", usuario.NOMBRE ?? string.Empty);
                        command.Parameters.AddWithValue("@Email", usuario.EMAIL ?? string.Empty);
                        command.Parameters.AddWithValue("@Password", usuario.PASSWORD ?? string.Empty);

                        // Permitir que el campo IDROL sea NULL
                        if (usuario.oRol?.IDROL > 0)
                        {
                            command.Parameters.AddWithValue("@IDRol", usuario.oRol.IDROL);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@IDRol", DBNull.Value);
                        }

                        command.Parameters.AddWithValue("@IDUsuario", usuario.IDUSUARIO);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            throw new Exception("No se encontró el usuario a actualizar.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al editar el usuario en la capa de datos", ex);
                }
            }
        }


        // Método para eliminar un usuario de la base de datos
        public void Eliminar(int idUsuario)
        {
            using (SqlConnection oconexion = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    oconexion.Open();

                    string query = "DELETE FROM Usuario WHERE IDUSUARIO = @IDUsuario";

                    using (SqlCommand command = new SqlCommand(query, oconexion))
                    {
                        command.Parameters.AddWithValue("@IDUsuario", idUsuario);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar el usuario", ex);
                }
            }
        }
    }
}
