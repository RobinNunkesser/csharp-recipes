using System;
using System.ComponentModel;
using System.Linq;

namespace DeviceSensors
{
    public class SensorsViewModel : INotifyPropertyChanged
    {
        string accelerometer, gyroscope, magnetometer;

        double[] accValues = new double[3];
        double accScale = 20;
        double accShift = 10;

        double[] gyrValues = new double[3];
        double gyrScale = 0.01;
        double gyrShift = 0.01;

        double[] magValues = new double[3];
        double magScale = 100;
        double magShift = 50;

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

        public double[] GyrValues
        {
            get => gyrValues.Select(x => (x + gyrShift) / gyrScale).ToArray();
            set
            {
                if (gyrValues != value)
                {
                    gyrValues = value;
                    OnPropertyChanged("GyrValues");
                }
            }
        }

        public double[] MagValues
        {
            get => magValues.Select(x => (x + magShift) / magScale).ToArray();
            set
            {
                if (magValues != value)
                {
                    magValues = value;
                    OnPropertyChanged("MagValues");
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

        public string Gyroscope
        {
            get => gyroscope;
            set
            {
                if (gyroscope != value)
                {
                    gyroscope = value;
                    OnPropertyChanged("Gyroscope");
                }
            }
        }

        public string Magnetometer
        {
            get => magnetometer;
            set
            {
                if (magnetometer != value)
                {
                    magnetometer = value;
                    OnPropertyChanged("Magnetometer");
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



