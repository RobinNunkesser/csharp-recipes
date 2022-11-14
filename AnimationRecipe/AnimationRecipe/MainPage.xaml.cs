namespace AnimationRecipe;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await TextLabel.FadeTo(1, 1000);
    }

}


