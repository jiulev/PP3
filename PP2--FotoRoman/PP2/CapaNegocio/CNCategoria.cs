using CapaDatos;
using CapaEntidad;
using System;

namespace CapaNegocio
{
    public class CNCategoria
    {
        public static void InsertarCategoria(Categoria categoria)  // Método marcado como static
        {
            CD_Categoria.Insertar(categoria);  // Llamada a método estático en CD_Categoria
        }


        public static List<Categoria> ListarDescripciones()
        {
            return CD_Categoria.ListarDescripciones();
        }

        public static List<Categoria> ListarCategoriasActivas()
        {
            return CD_Categoria.ListarCategoriasActivas();
        }
        public static void EditarCategoria(Categoria categoria)
        {
            CD_Categoria.EditarCategoria(categoria);
        }
        public static void EliminarCategoria(int idCategoria)
        {
            CD_Categoria.EliminarCategoria(idCategoria);
        }



    }
}
