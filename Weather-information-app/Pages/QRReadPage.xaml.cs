using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Weather_information_app.Data;
using ZXing.Net.Maui;

namespace Weather_information_app.Pages;

public partial class QRReadPage : ContentPage
{
	public QRReadPage()
	{
		InitializeComponent();

		cameraBarcodeReader.Options = new BarcodeReaderOptions
		{
			Formats = BarcodeFormats.TwoDimensional,
		};
	}

	/// <summary>
	/// バーコード読み取りの処理
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void cameraBarcodeReader_BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
	{
		// スレッドが異なるためエラーになる
		// そのエラーを回避するために「this.Dispatcher.Dispatch()」を利用する
		this.Dispatcher.Dispatch(() =>
		{
			foreach (BarcodeResult barcodeResult in e.Results)
			{
				CityAndCountry? caa = JsonSerializer.Deserialize<CityAndCountry>(barcodeResult.Value);
				getWeatherInformation(caa.city, caa.country);
			}
		});
	}

	private async void getWeatherInformation(string city, string country)
	{
		WeatherInformation weatherInformation = await RestService.GetAll(city, country);
		this.city.Text = weatherInformation.weather[0]["description"].ToString();
	}
}

public class CityAndCountry
{
	public string? city { get; set; }

	public string? country { get; set; }
}