using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
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

	private void cameraBarcodeReader_BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
	{
		// �X���b�h���قȂ邽�߃G���[�ɂȂ�
		// ���̃G���[��������邽�߂Ɂuthis.Dispatcher.Dispatch()�v�𗘗p����
		this.Dispatcher.Dispatch(() =>
		{
			foreach (BarcodeResult barcodeResult in e.Results)
			{
				CityAndCountry? caa = JsonSerializer.Deserialize<CityAndCountry>(barcodeResult.Value);
				city.Text = caa.city;
				country.Text = caa.country;

			}
		});
	}
}

public class CityAndCountry
{
	public string? city { get; set; }

	public string? country { get; set; }
}