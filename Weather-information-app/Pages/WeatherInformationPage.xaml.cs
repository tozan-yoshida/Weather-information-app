using Weather_information_app.Data;
using Weather_information_app.ViewModel;
using static System.Net.Mime.MediaTypeNames;

namespace Weather_information_app.Pages;

[QueryProperty(nameof(AddWeatherInformation), "WeatherInformationData")]
public partial class WeatherInformationPage : ContentPage
{
	public WeatherInformationPage()
	{
		InitializeComponent();

	}

	public WeatherInformationForDB AddWeatherInformation
	{
		set
		{
			var weatherData = value as WeatherInformationForDB;
			if (weatherData != null)
			{
				dateTime.Text = $@"{weatherData.DateTime} {weatherData.City}";
				weather.Text = weatherData.Weather;
				temp.Text = $@"{weatherData.Temp}Åé";
				maxTemp.Text = $@"{weatherData.MaxTemp}Åé";
				minTemp.Text = $@"{weatherData.MinTemp}Åé";
				string imageId = weatherData.ImageId!;
				image.Source = $"https://openweathermap.org/img/wn/{imageId}@2x.png";

			}
		}
	}
}
