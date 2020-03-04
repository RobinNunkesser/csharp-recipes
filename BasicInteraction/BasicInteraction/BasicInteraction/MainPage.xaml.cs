using System;
using Xamarin.Forms;

namespace BasicInteraction
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Handle_Clicked(object sender, EventArgs e)
        {            
            TermLabel.Text = TermEntry.Text.ToUpper();
        }
    }
}