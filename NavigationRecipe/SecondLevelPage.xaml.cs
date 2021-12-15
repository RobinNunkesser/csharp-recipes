using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

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
