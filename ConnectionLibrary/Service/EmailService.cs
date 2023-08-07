using ConnectionLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ConnectionLibrary.Config;

namespace ConnectionLibrary.Service
{
    public class EmailService : IEmailService
    {
        public async Task SendTestEmail()
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(AppSettings.SMTPConfigModel.UserName);
            mailMessage.To.Add("recipient@email.com");
            mailMessage.Subject = "Subject";
            mailMessage.Body = "This is test email";

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = AppSettings.SMTPConfigModel.Host;
            smtpClient.Port = AppSettings.SMTPConfigModel.Port;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(AppSettings.SMTPConfigModel.UserName, AppSettings.SMTPConfigModel.Password);
            smtpClient.EnableSsl = true;
        }

    }
}
