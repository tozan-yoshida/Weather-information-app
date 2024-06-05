using Weather_information_app.Pages;

namespace Weather_information_app
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("weatherInformationPage", typeof(WeatherInformationPage));
        }

    }
}
