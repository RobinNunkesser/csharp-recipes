using System.Diagnostics;

using Xamarin.Forms;

namespace RESTRecipe
{
    public partial class RESTRecipePage : ContentPage
    {
        public RESTRecipePage()
        {
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            var data = new iTunesService();
            var result = await data.GetSongs("Jack Johnson");
            Debug.WriteLine(result);
        }

    }
}
