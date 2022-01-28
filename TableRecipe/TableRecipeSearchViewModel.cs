using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace TableRecipe
{
    public class TableRecipeSearchViewModel : INotifyPropertyChanged
    {
        public List<ItemViewModel> Items { get; set; } = new List<ItemViewModel>
            {
                new ItemViewModel { Text = "Sponge", Detail = "Detail 1" },
                new ItemViewModel { Text = "Banana", Detail = "Detail 2" },
                new ItemViewModel { Text = "Laptop", Detail = "Detail 3" },
                new ItemViewModel { Text = "Teddy Bear", Detail = "Detail 4" }
            };

        public List<ItemViewModel> FilteredItems { 
            get
            {
                if (string.IsNullOrEmpty(searchTerm)) return Items;
                return Items.Where(
                    item => item.Text.ToLower().Contains(searchTerm.ToLower()) ||
                    item.Detail.ToLower().Contains(searchTerm.ToLower())).ToList();
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
                    OnPropertyChanged("FilteredItems");
                }
            }
        }


        public TableRecipeSearchViewModel()
        {
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion

    }
}