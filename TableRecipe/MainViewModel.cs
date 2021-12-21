using System;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace TableRecipe
{
    public class MainViewModel
    {
        public ICommand NavigateCommand { get; set; }

        public MainViewModel(INavigation navigation)
        {
            this.NavigateCommand = new Command<Type>(async (Type pageType) =>
            {
                Page page = (Page)Activator.CreateInstance(pageType);
                await navigation.PushAsync(page);
            });
        }
    }
}
