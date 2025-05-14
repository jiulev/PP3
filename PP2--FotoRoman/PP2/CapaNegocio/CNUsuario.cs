using System.Collections.Generic;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CNUsuario
    {
        // Instancia de la capa de datos
        private readonly CD_Usuario objcd_usuario = new CD_Usuario();

        // Método para listar los usuarios
        public List<Usuario> Listar()
        {
            CD_Usuario objcd_usuario = new CD_Usuario();
            return objcd_usuario.Listar();
        }
    


        private CD_Usuario cdUsuario = new CD_Usuario();

        // Método para obtener solo los nombres de los usuarios
        public List<string> ListarNombres()
        {
            // Aquí puedes agregar cualquier lógica adicional si es necesaria.
            return cdUsuario.ListarNombres();
        }

        public void Bloquear(int idUsuario)
        {
            if (idUsuario <= 0)
            {
                throw new ArgumentException("ID de usuario inválido.");
            }

            objcd_usuario.Bloquear(idUsuario); // Llama al método de la capa de datos
        }

        // Método para insertar un usuario
        public void Insertar(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.NOMBRE))
            {
                throw new ArgumentException("El nombre del usuario no puede estar vacío.");
            }

            objcd_usuario.Insertar(usuario);
        }

        // Método para editar un usuario
        public void Editar(Usuario usuario)
        {
            try
            {
                if (usuario.IDUSUARIO <= 0)
                {
                    throw new System.ArgumentException("ID de usuario inválido.");
                }

                objcd_usuario.Editar(usuario);
            }
            catch (Exception ex)
            {
                throw new System.Exception("Error al editar el usuario en la capa de negocio", ex);
            }
        }

        // Método para eliminar un usuario
        public void Eliminar(int idUsuario)
        {
            // Validaciones antes de eliminar (opcional)
            if (idUsuario <= 0)
            {
                throw new System.ArgumentException("ID de usuario inválido.");
            }

            objcd_usuario.Eliminar(idUsuario);
        }
    }
}
