using System;
using System.Collections.ObjectModel;

namespace TableRecipe
{
    public class TableRecipeViewModel
    {
        public ObservableCollection<ItemModels.ViewModel> items {get; set;}

        public TableRecipeViewModel()
        {
            items = new ObservableCollection<ItemModels.ViewModel>();
            items.Add(new ItemModels.ViewModel()
            {
                text = "Item 1",
                detail = "Detail 1"
            });
            items.Add(new ItemModels.ViewModel()
            {
                text = "Item 2",
                detail = "Detail 2"
            });
        }
    }
}
