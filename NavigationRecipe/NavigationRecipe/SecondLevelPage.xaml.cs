using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NavigationRecipe
{
    public partial class SecondLevelPage : ContentPage
    {
        public SecondLevelPage(String text)
        {
            InitializeComponent();
            BindingContext = text;
        }
    }
}
