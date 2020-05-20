using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace AsyncWPFTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnStartButtonClick(object sender, RoutedEventArgs e)
        {
            const string message = "Hello, World!";
            Result.Text = GetMessageLength(message).ToString();
        }

        private void OnStopButtonClick(object sender, RoutedEventArgs e)
        {

        }

        // Метод для тестирования приложения
        private int GetMessageLength(string message)
        {
            for(int i = 0; i < 100; i++)
            {
                Thread.Sleep(30);                
            }
            return message.Length;
        }
    }
}
