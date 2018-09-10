using System;
using System.ComponentModel;
using System.Linq;

namespace DeviceSensors
{
    public class SensorsViewModel : INotifyPropertyChanged
    {
        string accelerometer;

        double[] accValues = new double[3];
        double accScale = 20;
        double accShift = 10;

        public double[] AccValues
        {
            get => accValues.Select(x => (x + accShift) / accScale).ToArray();
            set
            {
                if (accValues != value)
                {
                    accValues = value;
                    OnPropertyChanged("AccValues");
                }
            }
        }

        public string Accelerometer
        {
            get => accelerometer;
            set
            {
                if (accelerometer != value)
                {
                    accelerometer = value;
                    OnPropertyChanged("Accelerometer");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) {
            var changed = PropertyChanged;
            if (changed != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}



