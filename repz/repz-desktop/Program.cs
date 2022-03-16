using repz_core;

namespace repz_desktop
{
    internal static class Program
    {

        static string dbConnection = "Server=localhost;Uid=root;Database=repz;Pwd=123456";

        static repz_core.mysql.UserStore uStore = new repz_core.mysql.UserStore(dbConnection);
        static repz_core.mysql.RoleStore rStore = new repz_core.mysql.RoleStore(dbConnection);
        static repz_core.services.User.UserService uService = new repz_core.services.User.UserService(uStore, rStore);

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Login(uService));
        }
    }
}