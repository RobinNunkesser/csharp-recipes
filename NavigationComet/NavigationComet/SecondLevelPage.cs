namespace NavigationComet;
public class SecondLevelPage : View
{
    private string text;

    public SecondLevelPage(string text)
    {
        this.text = text;
    }

    [Body]
    View body() => new VStack
    {
        new Text(text)
    };
}


