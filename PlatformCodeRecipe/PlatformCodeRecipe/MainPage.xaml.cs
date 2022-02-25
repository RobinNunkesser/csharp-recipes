using PlatformCodeRecipe.Services;

namespace PlatformCodeRecipe;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
		HelloWorldLabel.Text = (new HelloWorldService()).HelloWorld();
		//SemanticScreenReader.Announce(HelloWorldLabel.Text);

	}

}

