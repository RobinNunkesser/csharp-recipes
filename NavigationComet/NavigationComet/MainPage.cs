namespace NavigationComet;
public class MainPage : View
{

    [Body]
    View body() => new TabView
        {
            new MyFirstTabPage().TabText("Tab 1").TabIcon("one_circle_thin_s"),
            new MySecondTabPage().TabText("Tab 2").TabIcon("two_circle_thin_s")
        };
}


