namespace Weather_information_app
{
    public partial class App : Application
    {
        public static LocalDBService? localDBService { get; private set; }

        public App(LocalDBService dBService)
        {
            InitializeComponent();
            localDBService = dBService;
            MainPage = new AppShell();
        }
    }
}
