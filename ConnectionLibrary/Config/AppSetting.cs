using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConnectionLibrary.Config
{
    public class AppSettings
    {
        public static ConnectionStrings ConnectionStrings { get; set; } = new ConnectionStrings();
        public static SMTPConfigModel SMTPConfigModel { get; set; } = new SMTPConfigModel();


    }

    public class ConnectionStrings
    {
        public string Db { get; set; }
    }
    public class SMTPConfigModel
    {

        public string SenderAddress { get; set; }
        public string SenderDisplayName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSSL { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public bool IsBodyHTML { get; set; }


    }
}
