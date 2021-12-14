using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace MVVMRecipe
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

    }
}
