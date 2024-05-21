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
		// スレッドが異なるためエラーになる
		// そのエラーを回避するために「this.Dispatcher.Dispatch()」を利用する
		this.Dispatcher.Dispatch(() =>
		{
			foreach (BarcodeResult barcodeResult in e.Results)
			{
				lblText.Text = barcodeResult.Value;
			}
		});
	}
}