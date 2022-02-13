
/* Nicht gemergte Änderung aus Projekt "TableRecipe (net6.0-windows10.0.19041)"
Vor:
using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
Nach:
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using System;
*/

/* Nicht gemergte Änderung aus Projekt "TableRecipe (net6.0-ios)"
Vor:
using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
Nach:
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using System;
*/

/* Nicht gemergte Änderung aus Projekt "TableRecipe (net6.0-maccatalyst)"
Vor:
using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
Nach:
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using System;
*/
namespace TableRecipe
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel(Navigation);
        }

    }
}
