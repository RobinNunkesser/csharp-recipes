namespace TableRecipe
{
    public partial class GroupedTablePage : ContentPage
    {
        public GroupedTablePage()
        {
            InitializeComponent();
            BindingContext = new GroupedTableViewModel();
        }
    }
}