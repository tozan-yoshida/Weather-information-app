using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if IOS
using UIKit;
#endif
using ZXing.Net.Maui;

namespace Weather_information_app.CustomControls
{
    class CustomCameraBarcodeReaderViewHandler : CameraBarcodeReaderViewHandler
    {
#if IOS
        protected override void DisconnectHandler(UIView nativeView)
        {
            base.DisconnectHandler(nativeView);
        }
#endif

        public void StopCamera()
        {
#if IOS
            DisconnectHandler(new UIView());
#endif
        }
    }
}
