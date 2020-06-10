using System;
using System.ComponentModel;
using PlaceholderPosts.Common;
using PlaceholderPosts.Core;
using PlaceholderPosts.Infrastructure;
using Xamarin.Forms;

namespace PlaceholderPosts
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private readonly ICommandHandler<GetPostCommandDTO, PostEntity>
            _service = new GetPostCommand(new PostRepositoryAdapter());

        public MainPage()
        {
            InitializeComponent();
        }

        private void Retrieve_Button_OnClicked(object sender, EventArgs e)
        {
            _service.Execute(
                new GetPostCommandDTO() {Id = int.Parse(IdEntry.Text)},
                success => ResultLabel.Text = success.ToString(),
                async error =>
                    await DisplayAlert("Fehler", error.Message, "OK"));
        }
    }
}