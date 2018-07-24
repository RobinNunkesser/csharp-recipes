using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SettingsRecipe
{
    public class SettingsRecipeViewModel : INotifyPropertyChanged
    {
        public bool Bool
        {
            get => Settings.Bool;
            set
            {
                if (Settings.Bool == value) return;
                Settings.Bool = value;
                OnPropertyChanged();
            }
        }  

        public int Number
        {
            get => Settings.Number;
            set
            {
                if (Settings.Number == value) return;
                Settings.Number = value;
                OnPropertyChanged();
            }
        }  

        public string Text
        {
            get => Settings.Text;
            set
            {
                if (Settings.Text == value) return;
                Settings.Text = value;
                OnPropertyChanged();
            }
        }  

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string name = "") =>
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        #endregion
    }
}
