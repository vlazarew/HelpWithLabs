using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalServices.model
{
    class Credentials
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }

        public Credentials(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public Credentials(int id, string login, string password)
        {
            this.id = id;
            this.login = login;
            this.password = password;
        }

    }
}
