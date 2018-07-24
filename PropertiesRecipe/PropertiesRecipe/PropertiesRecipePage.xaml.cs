using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;

namespace PropertiesRecipe
{
    public partial class PropertiesRecipePage : ContentPage
    {
        const string ResourceId = "PropertiesRecipe.Resources";
        private static readonly Lazy<ResourceManager> ResMgr =
            new Lazy<ResourceManager>(
                () => new ResourceManager(ResourceId,
                                          typeof(PropertiesRecipePage)
                                          .GetTypeInfo().Assembly));

        public PropertiesRecipePage()
        {
            InitializeComponent();
            Debug.WriteLine(ResMgr.Value.GetString("Key"));
        }
    }
}
