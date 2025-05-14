using CapaEntidad;
using System;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Categoria
    {
        public static void Insertar(Categoria categoria)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("InsertarCategoriaUnica", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Descripcion", categoria.DESCRIPCION);
                        command.Parameters.AddWithValue("@FechaCreacion", DateTime.Now);

                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 50000)
                    {
                        throw new Exception("Error: " + ex.Message);
                    }
                    else
                    {
                        throw new Exception("Error al insertar la categoría", ex);
                    }
                }
            }
        }


        public static List<Categoria> ListarCategoriasActivas()
        {
            List<Categoria> lista = new List<Categoria>();

            using (SqlConnection conexion = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT IDCATEGORIA, DESCRIPCION FROM CATEGORIA WHERE ACTIVO = 'A'";
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Categoria
                            {
                                IDCATEGORIA = Convert.ToInt32(reader["IDCATEGORIA"]),
                                DESCRIPCION = reader["DESCRIPCION"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar categorías activas: " + ex.Message);
                }
            }

            return lista;
        }
        public static List<Categoria> ListarDescripciones()
        {
            List<Categoria> lista = new List<Categoria>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    oconexion.Open();
                    string query = "SELECT IDCATEGORIA, DESCRIPCION, ACTIVO FROM CATEGORIA ORDER BY DESCRIPCION";

                    using (SqlCommand command = new SqlCommand(query, oconexion))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Categoria categoria = new Categoria
                            {
                                IDCATEGORIA = Convert.ToInt32(reader["IDCATEGORIA"]),
                                DESCRIPCION = reader["DESCRIPCION"]?.ToString() ?? string.Empty,
                                ACTIVO = reader["ACTIVO"]?.ToString() ?? "A"
                            };
                            lista.Add(categoria);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar las descripciones de categorías: " + ex.Message);
                }
            }

            return lista;
        }

        public static void EditarCategoria(Categoria categoria)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE CATEGORIA SET DESCRIPCION = @Descripcion, ACTIVO = @Estado WHERE IDCATEGORIA = @IdCategoria";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Descripcion", categoria.DESCRIPCION);
                        command.Parameters.AddWithValue("@Estado", categoria.ACTIVO);
                        command.Parameters.AddWithValue("@IdCategoria", categoria.IDCATEGORIA);

                        command.ExecuteNonQuery();
                    }

                    if (categoria.ACTIVO == "I" || categoria.ACTIVO == "D")
                    {
                        string queryInactivarProductos = "UPDATE PRODUCTO SET ACTIVO = @Estado WHERE IDCATEGORIA = @IdCategoria";

                        using (SqlCommand cmd = new SqlCommand(queryInactivarProductos, connection))
                        {
                            cmd.Parameters.AddWithValue("@Estado", categoria.ACTIVO);
                            cmd.Parameters.AddWithValue("@IdCategoria", categoria.IDCATEGORIA);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al editar la categoría: " + ex.Message);
                }
            }
        }



        public static void EliminarCategoria(int idCategoria)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.ObtenerCadenaConexion()))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM CATEGORIA WHERE IDCATEGORIA = @IdCategoria";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdCategoria", idCategoria);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar la categoría: " + ex.Message);
                }
            }
        }
    }
}
