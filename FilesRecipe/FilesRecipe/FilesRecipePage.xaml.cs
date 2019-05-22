using System;
using Xamarin.Forms;

namespace FilesRecipe
{
    public partial class FilesRecipePage : ContentPage
    {

        public FilesRecipePage()
        {
            InitializeComponent();
        }

        void Handle_Save_Clicked(object sender, System.EventArgs e)
        {
            var text = textEntry.Text;
            DependencyService.Get<ISaveAndLoad>().SaveText("temp", text);
        }

        void Handle_Load_Clicked(object sender, System.EventArgs e)
        {
            var text = DependencyService.Get<ISaveAndLoad>().LoadText("temp");
            textLabel.Text = text;
        }
    }
}
