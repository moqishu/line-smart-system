using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINE.SMA.Generator.DBSchema
{
    public class DbConfig
    {
        public DbConfig(string ip, string dataBaseName, string userName, string password, int port)
        {
            this.ip = ip;
            this.dataBaseName = dataBaseName;
            this.userName = userName;
            this.password = password;
            this.port = port;
        }

        public DbConfig()
        {

        }
        public string ip { get; set; }

        public string dataBaseName { get; set; }

        public string userName { get; set; }

        public string password { get; set; }

        public int port { get; set; }

    }
}
