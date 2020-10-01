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

        void ListSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (sender is ListView listView)
            {
                listView.SelectedItem = null;
            }            
        }
    }
}


