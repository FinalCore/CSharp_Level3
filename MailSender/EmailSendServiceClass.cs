using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MailSender
{
    class EmailSendServiceClass
    {
        private string strLogin;
        private string strPassword;
        private string strSmtp = "smtp.yandex.ru"; 
        private int smtpPort = 25;
        public string MessageSubject { get; set; }
        public string MessageBody { get; set; }
        public string To { get; set; }

        public readonly string from;

        public EmailSendServiceClass(string sLogin, string sPassword)
        {
            strLogin = sLogin;
            strPassword = sPassword;
        }

        public void SendMail(string mail, string name)
        {
            try
            {
                using (var message = new MailMessage(strLogin, mail))
                {
                    message.Subject = this.MessageSubject;
                    message.Body = this.MessageBody;

                    message.IsBodyHtml = false;
                    SmtpClient sc = new SmtpClient(strSmtp, smtpPort);
                    sc.EnableSsl = true;
                    sc.EnableSsl = true;
                    sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                    sc.UseDefaultCredentials = false;
                    sc.Credentials = new NetworkCredential(strLogin, strPassword);
                    try
                    {
                        sc.Send(message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Невозможно отправить письмо " + ex.ToString());
                    }
                }
                MessageBox.Show("Почта отправлена!", "Ура!!!",
                          MessageBoxButton.OK, MessageBoxImage.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

            public void SendMails(IQueryable<Recipient> emails)
            {
                foreach (Recipient email in emails)
                {
                    SendMail(email.Email, email.Name);
                }
            }
        }
    }
}

