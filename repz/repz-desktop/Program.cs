using repz_core.mysql;
using repz_core.services.recipes;
using repz_core.services.user;

namespace repz_desktop
{
    internal static class Program
    {

        static string dbConnection = "Server=localhost;Uid=root;Database=repz;Pwd=123456";

        static UserStore uStore = new UserStore(dbConnection);
        static ProductStore pStore = new ProductStore(dbConnection);
        static RoleStore rStore = new RoleStore(dbConnection);
        static RecipeStore repzStore = new RecipeStore(dbConnection);
        static UserService uService = new UserService(uStore, rStore);
        static RecipeService rService = new RecipeService(repzStore, pStore);

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Login(uService, rService));
        }
    }
}