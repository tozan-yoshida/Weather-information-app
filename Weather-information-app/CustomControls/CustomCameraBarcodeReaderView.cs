using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Net.Maui.Controls;

namespace Weather_information_app.CustomControls
{
    class CustomCameraBarcodeReaderView : CameraBarcodeReaderView
    {
        public static readonly BindableProperty IsCameraEnabledPropery =
            BindableProperty.Create(
                nameof(IsCameraEnabled),
                typeof(bool),
                typeof(CustomCameraBarcodeReaderView),
                true);

        /// <summary>
        /// カメラの動作状況
        /// </summary>
        public bool IsCameraEnabled
        {
            get
            {
                return (bool)GetValue(IsCameraEnabledPropery);
            }
            set
            {
                SetValue(IsCameraEnabledPropery, value);
            }
        }
    }
}
