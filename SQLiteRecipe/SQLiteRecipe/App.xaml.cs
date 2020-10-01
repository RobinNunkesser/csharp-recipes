using System;
using System.Diagnostics;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteRecipe
{
    public partial class App : Application
    {
        static TodoItemDatabase _database;

        public static TodoItemDatabase Database
        {
            get
            {
                if (_database != null) return _database;                
                var dbPath = Path.Combine(FileSystem.AppDataDirectory,"SQLite.db3");                
                Debug.WriteLine(dbPath);
                _database = new TodoItemDatabase(dbPath);
                return _database;
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
