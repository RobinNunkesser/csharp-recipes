using System;
using System.ComponentModel;
using System.Diagnostics;
using UltimateAnswer.Common;
using UltimateAnswer.Core;
using UltimateAnswer.Core.Ports;
using UltimateAnswer.Infrastructure.Adapters;
using Xamarin.Forms;

namespace UltimateAnswer
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private readonly ICommandHandler<String, String> _service =
            new GetAnswerService(new SuperComputerAdapter());

        public MainPage()
        {
            InitializeComponent();
        }

        private void Handle_Clicked(object sender, EventArgs e)
        {
            _service.Execute(
                QuestionEntry.Text,
                Success, Failure);
        }

        private void Success(String value)
        {
            AnswerLabel.Text = value;
        }

        private void Failure(Exception error)
        {
            Debug.WriteLine(error);
        }
    }
}