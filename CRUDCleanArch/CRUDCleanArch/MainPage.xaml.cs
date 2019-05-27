using System;
using System.ComponentModel;
using BasicCleanArch;
using Xamarin.Forms;

namespace CRUDCleanArch
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage, IDisplayer<String>
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void Display(Result<string> response)
        {
            response.Match(
                async success =>
                    await Navigation.PushAsync(new UpdatePage(success)),
                async failure =>
                    await DisplayAlert("Fehler", failure.Message, "OK"));
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var personRequest = new CreatePersonRequest()
            {
                Forename = ForenameEntry.Text, Surname = SurnameEntry.Text
            };
            new CreatePersonInteractor().Execute(personRequest, this);
        }
    }
}