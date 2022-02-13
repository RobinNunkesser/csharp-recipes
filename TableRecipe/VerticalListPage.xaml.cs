namespace TableRecipe
{
    public partial class VerticalListPage : ContentPage
    {
        public VerticalListPage()
        {
            InitializeComponent();
            BindingContext = new VerticalListViewModel();
        }
    }
}
