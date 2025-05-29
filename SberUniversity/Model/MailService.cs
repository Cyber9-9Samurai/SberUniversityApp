using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Text.Json;
using System.Windows.Controls.Primitives;

namespace SberUniversity.Model
{
    public class MailService : IMail
    {
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public string SenderEmail { get; set; }
        public string SenderPassword { get; set; }

        public void LoadMailSettings(string path)
        {
            string jsonSettings = File.ReadAllText(path);
            MailService settings = JsonSerializer.Deserialize<MailService>(jsonSettings);
            if (settings != null)
            {
                SmtpServer = settings.SmtpServer;
                Port = settings.Port;
                EnableSsl = settings.EnableSsl;
                SenderEmail = settings.SenderEmail;
                SenderPassword = settings.SenderPassword;
            }
        }

        public async Task SentMail(string usermail, string theme, string text)
        {
            if (isNotEmpty(this)) {
                SmtpClient client = new(SmtpServer, Port);
                client.EnableSsl = EnableSsl;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(SenderEmail, SenderPassword);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                MailMessage message = new(SenderEmail, usermail, theme, text);
                await client.SendMailAsync(message);
            }
            else{
                throw new Exception("Настройки конфигурации не считаны");
            }
        }

        public bool isNotEmpty(IMail mail)
        {
            if(mail.SmtpServer != null && mail.Port > 0 && mail.EnableSsl != false && mail.SenderEmail != null && mail.SenderPassword != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
