using System.Diagnostics;
using CleanArchRecipe.Common;
using Xamarin.Forms;

namespace CleanArchRecipe
{
    public partial class MainPage : ContentPage, IOutputBoundary<string>
    {
        private IInputBoundary<object, string> inputBoundary = new Interactor();

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            inputBoundary.Send(null,this);
        }

        public void Receive(Response<string> response)
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
