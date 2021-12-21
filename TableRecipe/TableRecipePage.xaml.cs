using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace TableRecipe
{
    public partial class TableRecipePage : ContentPage
    {
        public TableRecipePage()
        {
            InitializeComponent();
            BindingContext = new TableRecipeViewModel();
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


