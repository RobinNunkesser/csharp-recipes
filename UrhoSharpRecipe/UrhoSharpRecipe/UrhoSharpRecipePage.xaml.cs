using Urho;
using Xamarin.Forms;

namespace UrhoSharpRecipe
{
    public partial class UrhoSharpRecipePage : ContentPage
    {
        Urho.Application urhoApp;

        public UrhoSharpRecipePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            urhoApp = await urhoSurface.Show<HelloWorld>(
                new ApplicationOptions(assetsFolder: null)
            { 
                Orientation = ApplicationOptions.OrientationType.Landscape 
            });
        }

    }
}
