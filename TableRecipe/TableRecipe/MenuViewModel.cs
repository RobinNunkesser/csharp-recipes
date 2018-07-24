using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace TableRecipe
{
    public class MenuViewModel
    {
        public ICommand NavigateCommand { get; set; }

        public MenuViewModel(INavigation navigation)
        {
            this.NavigateCommand = new Command<Type>(async (Type pageType) =>
            {
                Page page = (Page)Activator.CreateInstance(pageType);
                await navigation.PushAsync(page);
            });
        }
    }
}
