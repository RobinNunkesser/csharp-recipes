using Foundation;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace NavigationRecipe
{
	[Register("AppDelegate")]
	public class AppDelegate : MauiUIApplicationDelegate
	{
		protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
	}
}