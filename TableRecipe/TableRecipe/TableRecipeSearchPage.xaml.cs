using System.Linq;
using Xamarin.Forms;

namespace TableRecipe
{
    public partial class TableRecipeSearchPage : ContentPage
    {
        private readonly TableRecipeViewModel viewModel =
            new TableRecipeViewModel();

        public TableRecipeSearchPage()
        {
            InitializeComponent();
            BindingContext = viewModel;
            MainSearchBar.TextChanged += MainSearchBar_TextChanged;
        }

        private void MainSearchBar_TextChanged(object sender,
            TextChangedEventArgs e)
        {
            var filter = ((SearchBar) sender).Text;
            if (string.IsNullOrWhiteSpace(filter))
            {
                MainListView.ItemsSource = viewModel.Items;
            }
            else
            {
                MainListView.ItemsSource = viewModel.Items.Where(x =>
                    x.Text.ToLower().Contains(filter.ToLower()));
            }
        }
    }
}