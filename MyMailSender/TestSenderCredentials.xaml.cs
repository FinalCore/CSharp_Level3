using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace MyMailSender
{
    /// <summary>
    /// Interaction logic for TestSenderCredentials.xaml
    /// </summary>
    public partial class TestSenderCredentials : Window
    {
        internal string strLogin;
        internal string strPassword;
        public TestSenderCredentials()
        {
            InitializeComponent();
        }

        private void btnEnterSenderCredentials_Click(object sender, RoutedEventArgs e)
        {
            strLogin = tbSenderLogin.Text;
            strPassword = tbSenderPassword.Text;
            this.Close();
        }
    }
}
