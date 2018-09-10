using Plugin.DeviceSensors;
using Xamarin.Forms;

namespace DeviceSensors
{
    public partial class MainPage : ContentPage
    {
        private SensorsViewModel sensorsViewModel = new SensorsViewModel();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = sensorsViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (CrossDeviceSensors.Current.Accelerometer.IsSupported)
            {
                CrossDeviceSensors.Current.Accelerometer.OnReadingChanged += 
                    (s, a) => {
                    sensorsViewModel.Accelerometer = a.Reading.ToString();
                    sensorsViewModel.AccValues = 
                        new double[] {a.Reading.X, a.Reading.Y, a.Reading.Z};
                    };
                CrossDeviceSensors.Current.Accelerometer.StartReading();
            }
            if (CrossDeviceSensors.Current.Gyroscope.IsSupported)
            {
                CrossDeviceSensors.Current.Gyroscope.OnReadingChanged += 
                    (s, a) => {
                    sensorsViewModel.Gyroscope = a.Reading.ToString();
                    sensorsViewModel.GyrValues = 
                        new double[] { a.Reading.X, a.Reading.Y, a.Reading.Z };
                    };
                CrossDeviceSensors.Current.Gyroscope.StartReading();
            }
            if (CrossDeviceSensors.Current.Magnetometer.IsSupported)
            {
                CrossDeviceSensors.Current.Magnetometer.OnReadingChanged += 
                    (s, a) => {
                    sensorsViewModel.Magnetometer = a.Reading.ToString();
                    sensorsViewModel.MagValues = 
                        new double[] { a.Reading.X, a.Reading.Y, a.Reading.Z };
                };
                CrossDeviceSensors.Current.Magnetometer.StartReading();
            }
        }
    }
}
