using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TableRecipe
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
            BindingContext = new MenuViewModel(Navigation);
        }
    }
}
