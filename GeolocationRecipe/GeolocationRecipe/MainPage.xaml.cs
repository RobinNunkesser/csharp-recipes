using System;
using System.Diagnostics;
using Plugin.Geolocator;
using Xamarin.Forms;

namespace GeolocationRecipe
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var locator = CrossGeolocator.Current;

            var position =
                await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

            Debug.WriteLine("Position Status: {0}", position.Timestamp);
            Debug.WriteLine("Position Latitude: {0}", position.Latitude);
            Debug.WriteLine("Position Longitude: {0}", position.Longitude);
        }
    }
}