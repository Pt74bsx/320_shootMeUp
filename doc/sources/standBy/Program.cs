namespace ShootMeUp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            using NavigationBoutons navigation = new NavigationBoutons();

            // Initialisation des fenêtres
            SpaceManager.Initialize();

            // Démarrage
            Application.Run(new HomeSpace());
        }
    }
}