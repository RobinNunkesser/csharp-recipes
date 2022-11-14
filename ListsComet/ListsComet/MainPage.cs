namespace ListsComet;
public class MainPage : View
{

    [Body]
    View body() => new NavigationView
        {
            new VStack()
            {
                new Button("Dynamic Vertical List",()=>{
                    Navigation.Navigate(new VerticalListPage());
                }),
                new Button("Sectioned Vertical List",()=>{
                    Navigation.Navigate(new SectionedListViewPage());
                })

            }
        };
}


