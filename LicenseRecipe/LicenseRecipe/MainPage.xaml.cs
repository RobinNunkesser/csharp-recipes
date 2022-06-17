namespace LicenseRecipe
{
    public partial class MainPage : ContentPage
    {
        private readonly string Filename = "licenses.html";

        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            using var stream = await FileSystem.OpenAppPackageFileAsync(Filename);
            using var reader = new StreamReader(stream);
            var html = reader.ReadToEnd();

            var htmlSource = new HtmlWebViewSource
            {
                Html = html
            };
            Browser.Source = htmlSource;
        }

    }
}
