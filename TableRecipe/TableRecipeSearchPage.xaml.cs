using System.Linq;
using Microsoft.Maui.Controls;

namespace TableRecipe
{
    public partial class TableRecipeSearchPage : ContentPage
    {
        public TableRecipeSearchPage()
        {
            InitializeComponent();
            BindingContext = new TableRecipeSearchViewModel();
        }

    }
}