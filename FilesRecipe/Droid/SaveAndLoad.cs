using System;
using System.Diagnostics;
using System.IO;
using FilesRecipe.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(SaveAndLoad))]
namespace FilesRecipe.Droid
{
    public class SaveAndLoad : ISaveAndLoad
    {
        string documentsPath = 
            Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        public void SaveText(string filename, string text) =>
            File.WriteAllText(Path.Combine(documentsPath, filename), text);

        public string LoadText(string filename) =>
            File.ReadAllText(Path.Combine(documentsPath, filename));
    }
}
