using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ContentViewRecipe
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string itemNr = "42";
        public string ItemNr
        {
            get => itemNr;
            set
            {
                if (itemNr != value)
                {
                    itemNr = value;
                    OnPropertyChanged();
                }
            }
        }
        public MainViewModel()
        {
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion

    }
}
