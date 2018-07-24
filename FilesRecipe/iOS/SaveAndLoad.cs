using System;
using System.Diagnostics;
using System.IO;
using FilesRecipe.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(SaveAndLoad))]
namespace FilesRecipe.iOS
{
    public class SaveAndLoad : ISaveAndLoad
    {
        public void SaveText(string filename, string text)
        {            
            var documentsPath = 
                Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            Debug.WriteLine(filePath);
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
