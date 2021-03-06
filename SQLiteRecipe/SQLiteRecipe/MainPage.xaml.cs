using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SQLiteRecipe
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var todoItem = new TodoItem()
            {
                Name = "Test",
                Notes = "Note",
                Done = false
            };
            await App.Repository.Create(todoItem);
        }

    }
}
