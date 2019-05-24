using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MVVMRecipe
{
    public partial class DetailsPage : ContentPage
    {
        private DetailsViewModel detailsViewModel = new DetailsViewModel();

        public DetailsPage()
        {
            InitializeComponent();
            BindingContext = detailsViewModel;
        }
    }
}
