using Xamarin.Forms;

namespace NavigationRecipe
{
    public partial class MyFirstTabPage : ContentPage
    {
        public MyFirstTabPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SecondLevelPage("Hello 2nd level!"));
        }
    }
}
