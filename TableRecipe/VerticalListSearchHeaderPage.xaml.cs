namespace TableRecipe
{
    public partial class VerticalListSearchHeaderPage : ContentPage
    {
        public VerticalListSearchHeaderPage()
        {
            InitializeComponent();
            BindingContext = new VerticalListSearchHeaderViewModel();
        }
    }
}
