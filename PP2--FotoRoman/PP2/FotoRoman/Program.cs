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
            // Configuraci�n de la aplicaci�n
            ApplicationConfiguration.Initialize();
            Application.Run(new Login()); // Cambiado de nuevo a Login
        }
    }
}
