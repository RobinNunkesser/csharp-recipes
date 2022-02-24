namespace TextToSpeechRecipe;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await TextToSpeech.SpeakAsync("Hello World");
    }

}

