using Italbytz.Ports.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UltimateAnswer.Core;
using UltimateAnswer.Infrastructure.Adapters;

namespace UltimateAnswer.WinApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IService<String, String> _service =
            new GetAnswerService(new SuperComputerAdapter());

        public MainWindow()
        {
            InitializeComponent();
        }



        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Success(await _service.Execute(QuestionTextBox.Text));
            }
            catch (Exception ex)
            {
                Failure(ex);
            }
        }


        private void Success(String value)
        {
            AnswerLabel.Content = value;
        }

        private void Failure(Exception error)
        {
            Debug.WriteLine(error);
        }
    }
}
