using System.Collections.ObjectModel;

namespace TableRecipe
{
    public class TableRecipeViewModel
    {
        public TableRecipeViewModel()
        {
            items = new ObservableCollection<ItemViewModel>();
            items.Add(new ItemViewModel {text = "Item 1", detail = "Detail 1"});
            items.Add(new ItemViewModel {text = "Item 2", detail = "Detail 2"});
        }

        public ObservableCollection<ItemViewModel> items { get; set; }
    }
}