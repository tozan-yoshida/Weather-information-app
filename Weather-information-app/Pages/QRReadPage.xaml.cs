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
				lblText.Text = barcodeResult.Value;
			}
		});
	}
}