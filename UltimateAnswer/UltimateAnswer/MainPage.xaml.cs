namespace UltimateAnswer;

using System.Diagnostics;
using Italbytz.Ports.Common;
using UltimateAnswer.Core;
using UltimateAnswer.Infrastructure.Adapters;

public partial class MainPage : ContentPage
{
    private readonly IService<String, String> _service =
            new GetAnswerService(new SuperComputerAdapter());

    public MainPage()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
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

