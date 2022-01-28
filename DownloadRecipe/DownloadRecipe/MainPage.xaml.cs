using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DownloadRecipe
{
    public partial class MainPage : ContentPage
    {
        IDownloader downloader = DependencyService.Get<IDownloader>();

        public MainPage()
        {
            InitializeComponent();
            downloader.OnFileDownloaded += OnFileDownloaded;
        }

        private void OnFileDownloaded(object sender, DownloadEventArgs e)
        {
            if (e.FileSaved)
            {
                DisplayAlert("DownloadRecipe", "File Saved Successfully", "Close");
            }
            else
            {
                DisplayAlert("DownloadRecipe", "Error while saving the file", "Close");
            }
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            downloader.DownloadFile("https://is1-ssl.mzstatic.com/image/thumb/Music115/v4/ae/4c/d4/ae4cd42a-80a9-d950-16f5-36f01a9e1881/source/60x60bb.jpg", "Downloads");
        }
    }
}
