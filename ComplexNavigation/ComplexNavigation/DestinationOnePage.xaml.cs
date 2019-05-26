using Xamarin.Forms;

namespace ComplexNavigation
{
    public partial class DestinationOnePage : ContentPage
    {
        public DestinationOnePage(object BindingContext)
        {
            InitializeComponent();
            this.BindingContext = BindingContext;
        }
    }
}