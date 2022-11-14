namespace NavigationComet;
public class MyFirstTabPage : View
{

    [Body]
    View body() => new NavigationView
        {
            new VStack()
            {
                new Button("Navigate deeper",()=>{
                    Navigation.Navigate(new SecondLevelPage("Hello 2nd level!"));
                })
            }
        };
}


