namespace FotoRoman
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configuración de la aplicación
            ApplicationConfiguration.Initialize();
            Application.Run(new Login()); // Cambiado de nuevo a Login
        }
    }
}
