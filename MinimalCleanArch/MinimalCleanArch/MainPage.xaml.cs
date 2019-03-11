using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using BasicCleanArch;
using System.Diagnostics;

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

        public void Display(Result<string> result)
        {
            result.Match(
            (success) => ResultLabel.Text = success,
            (failure) => Debug.WriteLine(failure)
            );
        }

    }
}
