using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectivityRecipe
{
    public class ConnectivityTest
    {
        public ConnectivityTest()
        {
            PrintNetworkAccess();
            // Register for connectivity changes, be sure to unsubscribe when finished
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            var access = e.NetworkAccess;
            var profiles = e.ConnectionProfiles;
            PrintNetworkAccess();
        }

        private void PrintNetworkAccess()
        {
            switch (Connectivity.NetworkAccess)
            {
                case NetworkAccess.Unknown:
                    Debug.WriteLine("NetworkAccess: Unknown");
                    break;
                case NetworkAccess.None:
                    Debug.WriteLine("NetworkAccess: None");
                    break;
                case NetworkAccess.Local:
                    Debug.WriteLine("NetworkAccess: Local");
                    break;
                case NetworkAccess.ConstrainedInternet:
                    Debug.WriteLine("NetworkAccess: ConstrainedInternet");
                    break;
                case NetworkAccess.Internet:
                    Debug.WriteLine("NetworkAccess: Internet");
                    break;
            }
        }
    }
}
