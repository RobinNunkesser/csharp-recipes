using Xamarin.Forms;
using BasicCleanArch;
using System.Diagnostics;
using System;

namespace MinimalCleanArch
{
    public partial class MainPage : ContentPage, IDisplayer<string>
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var presenter = new MinimalPresenter();
            var interactor = new MinimalInteractor(presenter);
            interactor.Execute(null,this);
        }

        public void Display(string value, int requestCode = 0)
        {
            ResultLabel.Text = value;
        }

        public void Display(Exception error)
        {
            Debug.WriteLine(error);
        }
    }
}
