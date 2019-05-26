using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ComplexNavigation
{
    public class ViewModelPageRegistrySingleton
    {
        private static readonly Lazy<ViewModelPageRegistrySingleton> lazy =
            new Lazy<ViewModelPageRegistrySingleton>(() =>
                new ViewModelPageRegistrySingleton());

        private Dictionary<Type, Type> Registry;

        private ViewModelPageRegistrySingleton()
        {
            Registry = new Dictionary<Type, Type>();
            Registry.Add(typeof(DestinationOneViewModel),
                typeof(DestinationOnePage));
            Registry.Add(typeof(DestinationTwoViewModel),
                typeof(DestinationTwoPage));
            Registry.Add(typeof(DestinationThreeViewModel),
                typeof(DestinationThreePage));
        }

        public static ViewModelPageRegistrySingleton Instance => lazy.Value;

        public ContentPage GetPageForViewModel(ViewModel viewModel)
        {
            var PageType = Registry[viewModel.GetType()];
            var page = Activator.CreateInstance(PageType, viewModel);
            return (Xamarin.Forms.ContentPage) page;
        }
    }
}