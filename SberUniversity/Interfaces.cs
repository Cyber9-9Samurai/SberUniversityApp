using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SberUniversity
{
    public interface ITest
    {
       double GetTestResults();
    }

    public interface IMail
    {
        string SmtpServer { get; set; }
        int Port { get; set; }
        bool EnableSsl { get; set; }
        string SenderEmail { get; set; }
        string SenderPassword { get; set; }

        void LoadMailSettings(string path);
        Task SentMail(string usermail,string theme, string text);
    }
}
