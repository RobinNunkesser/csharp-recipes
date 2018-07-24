using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace TableRecipe
{
    public partial class TableRecipePage : ContentPage
    {
        public TableRecipePage()
        {
            InitializeComponent();
        }

        void listSelection(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}


