namespace TableRecipe
{
    public partial class VerticalListGroupingPage : ContentPage
    {
        public VerticalListGroupingPage()
        {
            InitializeComponent();
            BindingContext = new VerticalListGroupingViewModel();
        }
    }
}
