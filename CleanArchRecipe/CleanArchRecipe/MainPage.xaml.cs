using System.Diagnostics;
using CleanArchRecipe.Common;
using Xamarin.Forms;

namespace CleanArchRecipe
{
    public partial class MainPage : ContentPage, IOutputBoundary<ResponseEntity>
    {
        private IInputBoundary<ResponseEntity> inputBoundary = new Interactor();

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            inputBoundary.Send(this);
        }

        public void Receive(Response<ResponseEntity> response)
        {
            if (response.Failure == null)
            {                
                Debug.WriteLine(response.Success);
            }
            else
            {
                // Handle Errpr
                
            }
        }

    }
}
