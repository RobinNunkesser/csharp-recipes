using System.Collections.ObjectModel;

namespace TableRecipe
{
    public class TableRecipeViewModel
    {
        public TableRecipeViewModel()
        {
            Items = new ObservableCollection<ItemViewModel>();
            Items.Add(new ItemViewModel {Text = "Item 1", Detail = "Detail 1"});
            Items.Add(new ItemViewModel {Text = "Item 2", Detail = "Detail 2"});
        }

        public ObservableCollection<ItemViewModel> Items { get; set; }
    }
}