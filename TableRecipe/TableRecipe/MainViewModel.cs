
/* Nicht gemergte Änderung aus Projekt "TableRecipe (net6.0-windows10.0.19041)"
Vor:
using System;
using System.Windows.Input;
using Microsoft.Maui.Controls;
Nach:
using Microsoft.Maui.Controls;
using System;
using System.Windows.Input;
*/

/* Nicht gemergte Änderung aus Projekt "TableRecipe (net6.0-ios)"
Vor:
using System;
using System.Windows.Input;
using Microsoft.Maui.Controls;
Nach:
using Microsoft.Maui.Controls;
using System;
using System.Windows.Input;
*/

/* Nicht gemergte Änderung aus Projekt "TableRecipe (net6.0-maccatalyst)"
Vor:
using System;
using System.Windows.Input;
using Microsoft.Maui.Controls;
Nach:
using Microsoft.Maui.Controls;
using System;
using System.Windows.Input;
*/
using System.Windows.Input;

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
