using System;

namespace ListsComet
{
    public class ItemView : View
    {
        public ItemView(ItemViewModel item)
        {
            Body = () => new VStack(LayoutAlignment.Start, spacing: 2) {
                new Text (item.Text).FontSize(17),
                new Text (item.Detail).Color(Colors.Grey),
            };
        }
    }
}

