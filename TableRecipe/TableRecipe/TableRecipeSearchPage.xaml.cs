using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace TableRecipe
{
    public partial class TableRecipeSearchPage : ContentPage
    {
        private TableRecipeViewModel viewModel = new TableRecipeViewModel();

        public TableRecipeSearchPage()
        {
            InitializeComponent();
            BindingContext = viewModel;
            searchbar.TextChanged += (sender, e) => FilterItems(searchbar.Text);
            searchbar.SearchButtonPressed += (sender, e) =>
            {
                FilterItems(searchbar.Text);
            };
        }

        public void FilterItems(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
            {
                listView.ItemsSource = viewModel.items;
            }
            else
            {
                listView.ItemsSource = viewModel.items
                    .Where(x => x.text.ToLower()
                   .Contains(filter.ToLower()));
            }
        }
    }
}
