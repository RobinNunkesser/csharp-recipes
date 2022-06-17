
/* Nicht gemergte Änderung aus Projekt "TableRecipe (net6.0-windows10.0.19041)"
Vor:
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
Nach:
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
*/

/* Nicht gemergte Änderung aus Projekt "TableRecipe (net6.0-ios)"
Vor:
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
Nach:
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
*/

/* Nicht gemergte Änderung aus Projekt "TableRecipe (net6.0-maccatalyst)"
Vor:
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
Nach:
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
*/
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


