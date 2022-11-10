namespace BasicInteractionComet;
public class MainPage : View
{

    readonly State<String> text = "";
    readonly State<String> outputText = " ";

    [Body]
    View body()
        => new VStack {
                new TextField(text, "Enter text"),
                new Button("Process", process),
                new Text(outputText),
        }.FillHorizontal();

    private void process()
    {
        outputText.Value = text.Value.ToUpper();
    }
}


