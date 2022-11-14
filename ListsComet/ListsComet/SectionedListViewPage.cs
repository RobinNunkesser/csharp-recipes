using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ListsComet;
public class SectionedListViewPage : View
{

    List<SectionViewModel<ItemViewModel>> SectionsData = new();
    List<Section> Sections;

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
        SectionsData.Add(Section1);
        var Section2 = new SectionViewModel<ItemViewModel>
        {
            Header = "Section 2"
        };
        Section2.Add(new ItemViewModel
        {
            Text = "Section 2, Item 1",
            Detail = "Detail 1"
        });
        SectionsData.Add(Section2);

        Sections = SectionsData.Select(sec =>
            new Section(header: new Text(sec.Header)) {
                sec.Select(item => new VStack(LayoutAlignment.Start, spacing: 2) {
            new Text (item.Text).FontSize(17),
            new Text (item.Detail).Color(Colors.Grey),
        })
            }
        ).ToList();

    }

    [Body]
    View body() => new SectionedListView(Sections);

}


