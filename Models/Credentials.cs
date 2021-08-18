using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tttServer.Models
{
    public class Credentials
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Credentials() { }
        public Credentials(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

    }
}
