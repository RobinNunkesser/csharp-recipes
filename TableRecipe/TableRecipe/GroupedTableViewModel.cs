using System.Collections.ObjectModel;
using BasicCleanArch;

namespace TableRecipe
{
    public class GroupedTableViewModel
    {
        public GroupedTableViewModel()
        {
            Groups =
                new ObservableCollection<SectionViewModel<ItemViewModel>>();
            var Group1 = new SectionViewModel<ItemViewModel>
            {
                LongName = "Section 1", ShortName = "1"
            };
            Group1.Add(new ItemViewModel
            {
                Text = "Section 1, Item 1", Detail = "Detail 1"
            });
            Group1.Add(new ItemViewModel
            {
                Text = "Section 1, Item 2", Detail = "Detail 2"
            });
            Groups.Add(Group1);
            var Group2 = new SectionViewModel<ItemViewModel>
            {
                LongName = "Section 2", ShortName = "2"
            };
            Group2.Add(new ItemViewModel
            {
                Text = "Section 2, Item 1", Detail = "Detail 1"
            });
            Groups.Add(Group2);
        }

        public ObservableCollection<SectionViewModel<ItemViewModel>> Groups
        {
            get;
            set;
        }
    }
}