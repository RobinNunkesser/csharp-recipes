using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace TableRecipe
{
    public class TableRecipeSearchViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<ItemViewModel> items;
        public ObservableCollection<ItemViewModel> Items
        {
            get
            {
                if (string.IsNullOrEmpty(searchTerm)) return items;
                var filteredItems = items.Where(
                    item => item.Text.ToLower().Contains(searchTerm.ToLower()) ||
                    item.Detail.ToLower().Contains(searchTerm.ToLower()));
                return new ObservableCollection<ItemViewModel>(filteredItems);
            }
            set
            {
                if (items != value)
                {
                    items = value;
                    OnPropertyChanged();
                }
            }
        }

        private string searchTerm = "";
        public string SearchTerm
        {
            get => searchTerm;
            set
            {
                if (searchTerm != value)
                {
                    searchTerm = value;
                    OnPropertyChanged("Items");
                }
            }
        }


        public TableRecipeSearchViewModel()
        {
            Items = new ObservableCollection<ItemViewModel>
            {
                new ItemViewModel { Text = "Sponge", Detail = "Detail 1" },
                new ItemViewModel { Text = "Banana", Detail = "Detail 2" },
                new ItemViewModel { Text = "Laptop", Detail = "Detail 3" },
                new ItemViewModel { Text = "Teddy Bear", Detail = "Detail 4" }
            };
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion

    }
}