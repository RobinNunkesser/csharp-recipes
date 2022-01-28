using System;
using AsyncRecipe.Core;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace AsyncRecipe
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var resultTask = new AsyncExample().UIExample();
            ResultLabel.Text = $"{resultTask.IsCompleted}";
            var result = await resultTask;
            ResultLabel.Text = $"{result}";
        }
    }
}
