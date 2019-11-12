using System;
using BasicCleanArch;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace CleanArchRecipe
{
    public partial class MainPage : ContentPage, IDisplayer<string>
    {
        private readonly IUseCase<object, string> _getInteractor =
            new HttpBinGetInteractor(new HttpBinGateway(),
                new HttpBinResponsePresenter());

        private readonly IUseCase<HttpBinPostRequest, string> _postInteractor =
            new HttpBinPostInteractor(new HttpBinGateway(),
                new HttpBinResponsePresenter());

        public MainPage()
        {
            InitializeComponent();
            On<iOS>().SetUseSafeArea(true);
        }

        public void Display(string value, int requestCode = 0)
        {
            ResultLabel.Text = value;
        }

        public async void Display(Exception error)
        {
            await DisplayAlert("Fehler", error.Message, "OK");
        }

        private void Get_Button_OnClicked(object sender, EventArgs e)
        {
            _getInteractor.Execute(null, this);
        }

        private void Post_Button_OnClicked(object sender, EventArgs e)
        {
            _postInteractor.Execute(
                new HttpBinPostRequest {term = ParameterEntry.Text}, this);
        }
    }
}