using Xamarin.Forms;

namespace JSONRecipe
{
    public partial class JSONRecipePage : ContentPage
    {
        public JSONRecipePage()
        {
            InitializeComponent();
            new JSONService();
        }
    }
}
