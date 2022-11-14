using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ListsComet;
public class SectionedListViewPage : View
{

    List<SectionViewModel<ItemViewModel>> Sections = new();

    public SectionedListViewPage()
    {
        var Section1 = new SectionViewModel<ItemViewModel>
        {
            Header = "Section 1"
        };
        Section1.Add(new ItemViewModel
        {
            Text = "Section 1, Item 1",
            Detail = "Detail 1"
        });
        Section1.Add(new ItemViewModel
        {
            Text = "Section 1, Item 2",
            Detail = "Detail 2"
        });
        Sections.Add(Section1);
        var Section2 = new SectionViewModel<ItemViewModel>
        {
            Header = "Section 2"
        };
        Section2.Add(new ItemViewModel
        {
            Text = "Section 2, Item 1",
            Detail = "Detail 1"
        });
        Sections.Add(Section2);

    }

    [Body]
    View body() => new SectionedListView(Sections.Select(sec =>
            new Section(header: new Text(sec.Header)) {
                sec.Select(item => new ItemView(item))
            }
        ).ToList());

}


