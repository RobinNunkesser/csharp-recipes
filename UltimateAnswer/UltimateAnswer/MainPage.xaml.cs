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

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Success(await _service.Execute(QuestionEntry.Text));
        }
        catch (Exception ex)
        {
            Failure(ex);
        }
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

