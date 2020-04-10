using System;
using System.Windows;
using EmailSendServiceDLL;

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
                   
        }

        private void editSend_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btnGotoCalendar_Click(object sender, EventArgs e)
        {
            tabControl.SelectedItem = Calendar;
        }
 

        private void btnSendMail_Click(object sender, RoutedEventArgs e)
        {
            string strLogin = tbSenderLogin.Text;
            string strPassword = pbSenderPassword.Password;
            if (string.IsNullOrEmpty(strLogin))
            {
                MessageBox.Show("Выберите отправителя");
                return;
            }
            if (string.IsNullOrEmpty(strPassword))
            {
                MessageBox.Show("Укажите пароль отправителя");
                return;
            }

            EmailSendServiceClass emailSender = new EmailSendServiceClass(strLogin, strPassword);
            emailSender.MessageSubject = tbMailTopic.Text;
            emailSender.MessageBody = tbMailText.Text;
            emailSender.SendMail(strLogin, cbRecipients.Text);

        }
    }
}
