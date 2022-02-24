using System.Diagnostics;

namespace ConnectivityRecipe;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var _ = new ConnectivityTest();

    }

}

