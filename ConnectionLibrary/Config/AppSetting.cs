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
    }

    public class ConnectionStrings
    {
        public string Db { get; set; }
    }
}
