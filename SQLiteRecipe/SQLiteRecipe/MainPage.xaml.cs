namespace SQLiteRecipe;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var todoItem = new TodoItem()
        {
            Name = "Test",
            Notes = "Note",
            Done = false
        };
        await App.Repository.Create(todoItem);
    }
}

