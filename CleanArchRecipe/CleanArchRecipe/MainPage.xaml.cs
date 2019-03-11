using System.Diagnostics;
using BasicCleanArch;
using Xamarin.Forms;

namespace CleanArchRecipe
{
    public partial class MainPage : ContentPage, IDisplayer<string>
    {
        private IUseCase<object, string> inputBoundary = new GetHttpRequestInteractor(new HttpBinGateway(), new HttpRequestPresenter());

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            inputBoundary.Execute(null,this);
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
