using SI.Controllers;

namespace SI
{
    public partial class App : Application
    {
        static Controllers.EmpleadosControllers database;

        public static Controllers.EmpleadosControllers Database
        {
            get
            {
                if (database == null)
                {
                    database = new Controllers.EmpleadosControllers();
                }

                return database;
            }

        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.Home());
        }
    }
}