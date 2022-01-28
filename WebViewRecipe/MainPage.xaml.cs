namespace WebViewRecipe;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        Browser.Source = "https://www.hshl.de";
    }
}

