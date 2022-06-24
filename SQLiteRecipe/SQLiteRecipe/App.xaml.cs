using CommonPorts;
using SQLiteRecipe.Core.Ports;
using SQLiteRecipe.Infrastructure.Database.Adapters;
using System.Diagnostics;

namespace SQLiteRecipe;

public partial class App : Application
{

    static IRepository<int, ITodoItem> _repository;

    public static IRepository<int, ITodoItem> Repository
    {
        get
        {
            if (_repository != null) return _repository;
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "SQLite.db3");
            Debug.WriteLine(dbPath);
            _repository = new RepositoryAdapter(dbPath);
            return _repository;
        }
    }
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
