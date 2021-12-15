using System;
using System.IO;
using System.Reflection;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace LicenseRecipe
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
            var stream = await FileSystem.OpenAppPackageFileAsync("Resources/Raw/licenses.html");
            string html = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = html;
            Browser.Source = htmlSource;
        }

    }
}
