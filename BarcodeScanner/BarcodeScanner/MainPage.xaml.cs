using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BarcodeScanner
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {

#if __ANDROID__
	        // Initialize the scanner first so it can track the current context
	        MobileBarcodeScanner.Initialize (Application);
#endif

            var scanner = new ZXing.Mobile.MobileBarcodeScanner();

            var result = await scanner.Scan();

            if (result != null)
                Console.WriteLine("Scanned Barcode: " + result.Text);
        }
    }
}
