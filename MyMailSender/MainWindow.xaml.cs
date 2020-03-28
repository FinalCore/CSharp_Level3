using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyMailSender
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OnSendButtonClick(object sender, RoutedEventArgs e)
        {
            TestSenderCredentials testSenderCredentials = new TestSenderCredentials();
            testSenderCredentials.Show();
            
            
            if (string.IsNullOrEmpty(testSenderCredentials.strLogin))
            {
                MessageBox.Show("Выберите отправителя");
                return;
            }
            if (string.IsNullOrEmpty(testSenderCredentials.strPassword))
            {
                MessageBox.Show("Укажите пароль отправителя");
                return;
            }

            EmailSendServiceClass emailSender = new EmailSendServiceClass(testSenderCredentials.strLogin, testSenderCredentials.strPassword);
            emailSender.SendMails((IQueryable<Recipient>)dgEmails.ItemsSource);
        }

        private void editSend_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btnGotoCalendar_Click(object sender, EventArgs e)
        {
            tabControl.SelectedItem = Calendar;
        }

        
    }
}
