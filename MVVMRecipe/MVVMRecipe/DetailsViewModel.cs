using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVMRecipe
{
    public class DetailsViewModel : INotifyPropertyChanged
    {
        string forename, surname;
        public string Forename
        {
            get => forename;
            set
            {
                if (forename != value)
                {
                    forename = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Surname
        {
            get => surname;
            set
            {
                if (surname != value)
                {
                    surname = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ResetCommand { get; private set; }

        public DetailsViewModel()
        {
            ResetCommand = new Command(Reset);
        }

        public void Reset()
        {
            Forename = "";
            Surname = "";
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string name = "") =>
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion
    }
}