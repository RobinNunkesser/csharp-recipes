using System.Diagnostics;
using BasicCleanArch;
using Xamarin.Forms;

namespace CleanArchRecipe
{
    public partial class MainPage : ContentPage, IDisplayer<string>
    {
        private IUseCase<object, string> interactor = 
            new HttpBinGetInteractor(new HttpBinGateway(), 
                                         new HttpBinResponsePresenter());

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            interactor.Execute(null,this);
        }

        public void Display(Result<string> response)
        {
            response.Match(success => {
                Debug.WriteLine(success);
            }, failure => {
                // Handle Errpr
                Debug.WriteLine(failure);
            });
        }

    }
}
