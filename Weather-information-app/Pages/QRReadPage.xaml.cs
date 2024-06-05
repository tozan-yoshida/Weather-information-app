using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Weather_information_app.Data;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace Weather_information_app.Pages;

public partial class QRReadPage : ContentPage
{

	private bool busy = false;

	private CameraBarcodeReaderView? _cameraBarcodeReader;

	public QRReadPage()
	{
		InitializeComponent();
	}

	/// <summary>
	/// 画面読み込み時
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void QRReadPage_Loaded(object sender, EventArgs e)
	{
		caution.Text = "";
		_cameraBarcodeReader = new CameraBarcodeReaderView();
		_cameraBarcodeReader.Options = new BarcodeReaderOptions
		{
			Formats = BarcodeFormats.TwoDimensional,
		};
		_cameraBarcodeReader.BarcodesDetected += cameraBarcodeReader_BarcodesDetected!;
		qrGrid.Add(_cameraBarcodeReader, row: 0);
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
				try
				{
					CityAndCountry? caa = JsonSerializer.Deserialize<CityAndCountry>(barcodeResult.Value);
					getWeatherInformation(caa!.city!, caa.country!);
				}
                catch
                {
                    caution.Text = "天気情報取得に失敗しました。";
                }
            }
		});
		
	}

	/// <summary>
	/// 画面読み込み終了時
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void QRReadPage_Unloaded(object sender, EventArgs e)
	{
		if (_cameraBarcodeReader == null)
			return;
		_cameraBarcodeReader.IsDetecting = false;
		qrGrid.Remove(_cameraBarcodeReader);
	}

	private async void getWeatherInformation(string city, string country)
	{
		if (!busy)
		{
			busy = true;

			WeatherInformationAll weatherInformation = await RestService.GetAll(city, country);
			if (weatherInformation != null)
			{
				var forDB = WeatherInformationAllToDB.Convert(weatherInformation);
				await App.localDBService!.Add(forDB);

				var navigationParameter = new Dictionary<string, object>
				{
					{"WeatherInformationData", forDB }
				};

				await Shell.Current.GoToAsync("weatherInformationPage", navigationParameter);

				await deleteWeatherInformationOver20();
			}
			else
			{
				caution.Text = "天気情報取得に失敗しました。";
            }
			busy = false;
		}
    }

	/// <summary>
	/// データが20個を超える場合、古いデータを削除する
	/// </summary>
	/// <returns></returns>
	private async Task deleteWeatherInformationOver20()
	{
		var allData = await App.localDBService!.GetWeatherInformations();
		// データが20個を超えるか
		if(allData.Count > 20 ){
			// 21個目以降のデータをリスト化
			var deleteData = allData.GetRange(20, allData.Count-20);
			// リストのデータを削除
			foreach (var forDB in deleteData)
			{
				await App.localDBService.Delete(forDB);
			}
		}
		
	}

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
		if (_cameraBarcodeReader == null)
			return;
		_cameraBarcodeReader.IsDetecting = false;
    }

    protected override void OnAppearing()
    {
		caution.Text = "";
        base.OnAppearing();
		if (_cameraBarcodeReader == null)
			return;
		_cameraBarcodeReader.IsDetecting = true;
    }
}

public class CityAndCountry
{
	public string? city { get; set; }

	public string? country { get; set; }
}