using System.ComponentModel;
using BasicCleanArch;
using Xamarin.Forms;

namespace ComplexNavigation
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage, IDisplayer<ViewModel>
    {
        private NavigationInteractor _interactor = new NavigationInteractor();

        public MainPage()
        {
            InitializeComponent();
        }

        public void Display(Result<ViewModel> response)
        {
            response.Match(async success =>
                {
                    var Page = ViewModelPageRegistrySingleton.Instance
                        .GetPageForViewModel(success);
                    await Navigation.PushAsync(Page);
                },
                async failure =>
                    await DisplayAlert("Fehler", failure.Message, "OK"));
        }

        void Handle_Clicked_1(object sender, System.EventArgs e)
        {
            _interactor.Execute(new NavigationRequest() {value = 1}, this);
        }

        void Handle_Clicked_2(object sender, System.EventArgs e)
        {
            _interactor.Execute(new NavigationRequest() {value = 2}, this);
        }

        void Handle_Clicked_3(object sender, System.EventArgs e)
        {
            _interactor.Execute(new NavigationRequest() {value = 3}, this);
        }
    }
}