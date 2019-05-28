using System.Collections.ObjectModel;
using BasicCleanArch;

namespace TableRecipe
{
    public class GroupedTableViewModel
    {
        public GroupedTableViewModel()
        {
            Groups =
                new ObservableCollection<SectionViewModel<ItemModels.ViewModel>
                >();
            var Group1 = new SectionViewModel<ItemModels.ViewModel>
            {
                LongName = "Section 1", ShortName = "1"
            };
            Group1.Add(new ItemModels.ViewModel
            {
                text = "Section 1, Item 1", detail = "Detail 1"
            });
            Group1.Add(new ItemModels.ViewModel
            {
                text = "Section 1, Item 2", detail = "Detail 2"
            });
            Groups.Add(Group1);
            var Group2 = new SectionViewModel<ItemModels.ViewModel>
            {
                LongName = "Section 2", ShortName = "2"
            };
            Group2.Add(new ItemModels.ViewModel
            {
                text = "Section 2, Item 1", detail = "Detail 1"
            });
            Groups.Add(Group2);
        }

        public ObservableCollection<SectionViewModel<ItemModels.ViewModel>>
            Groups { get; set; }
    }
}