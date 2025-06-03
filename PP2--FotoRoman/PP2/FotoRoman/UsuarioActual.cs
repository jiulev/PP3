using CapaEntidad;

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
}
