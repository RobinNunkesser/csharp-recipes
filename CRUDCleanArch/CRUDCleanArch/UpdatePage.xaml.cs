using System;
using BasicCleanArch;
using Xamarin.Forms;

namespace CRUDCleanArch
{
    public partial class UpdatePage : ContentPage,
        IDisplayer<UpdatePageViewModel>, IDisplayer<bool>
    {
        private string _key;

        private RetrievePersonInteractor _retrieveInteractor =
            new RetrievePersonInteractor();

        private UpdatePersonInteractor _updateInteractor =
            new UpdatePersonInteractor();

        public UpdatePage(String key)
        {
            InitializeComponent();
            _key = key;
            _retrieveInteractor.Execute(
                new RetrievePersonRequest() {Key = _key}, this);
        }

        public void Display(Result<bool> response)
        {
            response.Match(
                async success =>
                    await DisplayAlert("Nachricht", $"Erfolg: {success}", "OK"),
                async failure =>
                    await DisplayAlert("Fehler", failure.Message, "OK"));
        }

        public void Display(Result<UpdatePageViewModel> response)
        {
            response.Match(success => BindingContext = success,
                async failure =>
                    await DisplayAlert("Fehler", failure.Message, "OK"));
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            _updateInteractor.Execute(
                new UpdatePersonRequest
                {
                    Key = _key,
                    Forename =
                        ((UpdatePageViewModel) BindingContext).Forename,
                    Surname =
                        ((UpdatePageViewModel) BindingContext).Surname,
                }, this);
        }
    }
}