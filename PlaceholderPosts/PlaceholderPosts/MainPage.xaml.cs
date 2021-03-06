using System;
using System.ComponentModel;
using ExplicitArchitecture;
using PlaceholderPosts.Core;
using PlaceholderPosts.Core.Ports;
using PlaceholderPosts.Infrastructure;
using Xamarin.Forms;

namespace PlaceholderPosts
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private readonly IService<IPostID, IPost>
            _service = new GetPostService(new PostRepositoryAdapter());

        public MainPage()
        {
            InitializeComponent();
        }

        private void Retrieve_Button_OnClicked(object sender, EventArgs e)
        {
            _service.Execute(
                new GetPostServiceDTO() {Id = int.Parse(IdEntry.Text)},
                success => ResultLabel.Text = success.ToString(),
                async error =>
                    await DisplayAlert("Fehler", error.Message, "OK"));
        }
    }
}