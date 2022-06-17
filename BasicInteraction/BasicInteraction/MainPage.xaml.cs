namespace BasicInteraction
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            TermLabel.Text = TermEntry.Text.ToUpper();
        }
    }
}
