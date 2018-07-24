using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace LicenseRecipe
{
    public partial class LicenseRecipePage : ContentPage
    {
        public LicenseRecipePage()
        {
            InitializeComponent();

            var assembly = typeof(LicenseRecipePage).GetTypeInfo().Assembly;
            Stream stream = assembly
                .GetManifestResourceStream("LicenseRecipe.licenses.html");
            string html = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = html;
            browser.Source = htmlSource;
        }
    }
}
