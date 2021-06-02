using System;
using System.Diagnostics;
using System.IO;
using CommonPorts;
using SQLiteRecipe.Core.Ports;
using SQLiteRecipe.Infrastructure.Database.Adapters;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteRecipe
{
    public partial class App : Application
    {
        static IRepository<int,ITodoItem> _repository;

        public static IRepository<int, ITodoItem> Repository
        {
            get
            {
                if (_repository != null) return _repository;                
                var dbPath = Path.Combine(FileSystem.AppDataDirectory,"SQLite.db3");                
                Debug.WriteLine(dbPath);
                _repository = new RepositoryAdapter(dbPath);
                return _repository;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
