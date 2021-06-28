using System;
using Xamarin.Forms;

namespace AsyncRecipe
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            var resultTask = new AsyncExample().UIExample();
            ResultLabel.Text = $"{resultTask.IsCompleted}";
            var result = await resultTask;
            ResultLabel.Text = $"{result}";
        }

    }
}
