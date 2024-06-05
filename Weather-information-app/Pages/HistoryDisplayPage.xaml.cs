using Weather_information_app.Data;
using Weather_information_app.ViewModel;

namespace Weather_information_app.Pages;

public partial class HistoryDisplayPage : ContentPage
{
	public HistoryDisplayPage()
	{
		InitializeComponent();
		//Task.Run(async () => WeatherInformationList.ItemsSource = await App.localDBService.GetWeatherInformations());
		BindingContext = new HistoryDisplayViewModel();
	}

	
}