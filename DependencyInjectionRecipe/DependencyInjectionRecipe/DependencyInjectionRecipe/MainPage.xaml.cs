using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DependencyInjectionRecipe
{
    public partial class MainPage : ContentPage
    {
        private IDependencyExample Dependency =>
            (IDependencyExample) ServiceProvider.Provider.GetService(
                typeof(IDependencyExample));
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Debug.WriteLine(Dependency.GetEnvironment());
        }
    }
}