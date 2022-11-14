using System.Collections.Generic;
using System.Diagnostics;

namespace ListsComet;
public class VerticalListPage : View
{

    List<ItemViewModel> Items = new List<ItemViewModel> {
        new ItemViewModel { Text = "Item 1", Detail = "Detail 1" },
        new ItemViewModel { Text = "Item 2", Detail = "Detail 2" }
    };

    [Body]
    View body() => new ListView<ItemViewModel>(Items)
    {
        ViewFor = (item) => new ItemView(item),
    }.OnSelected((item) => { Debug.WriteLine($"{item.Text} Selected"); });

}


