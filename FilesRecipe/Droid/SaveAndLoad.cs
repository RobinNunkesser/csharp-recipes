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
        public void SaveText(string filename, string text)
        {            
            var documentsPath = 
                Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            File.WriteAllText(filePath, text);
        }
        public string LoadText(string filename)
        {
            var documentsPath = 
                Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            return File.ReadAllText(filePath);
        }
    }
}
