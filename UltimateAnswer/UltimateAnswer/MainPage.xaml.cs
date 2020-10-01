using System;
using System.ComponentModel;
using System.Diagnostics;
using UltimateAnswer.Common;
using UltimateAnswer.Core;
using UltimateAnswer.Infrastructure.Adapters;
using Xamarin.Forms;

namespace UltimateAnswer
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private readonly ICommandHandler<GetAnswerCommandDTO, string> _service =
            GetAnswerCommand(new SuperComputerAdapter());

        public MainPage()
        {
            InitializeComponent();
        }

        private void Handle_Clicked(object sender, EventArgs e)
        {
            _service.Execute(
                new GetAnswerCommandDTO() {Question = QuestionEntry.Text},
                Success, Failure);
        }

        private void Success(string value)
        {
            AnswerLabel.Text = value;
        }

        private void Failure(Exception error)
        {
            Debug.WriteLine(error);
        }
    }
}