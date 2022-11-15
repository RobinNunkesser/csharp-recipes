using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SettingsRecipe
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public string TextSetting
        {
            get => Settings.TextSetting;
            set
            {
                Settings.TextSetting = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion
    }
}

