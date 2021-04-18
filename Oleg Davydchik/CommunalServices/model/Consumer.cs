using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalServices.model
{
    public class Consumer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int addressRegisterId { get; set; }
        public int typeOfConsumerId { get; set; }
        public int credentialsId { get; set; }
        public int phoneNumberId { get; set; }
        //public string login { get; set; }
        // public string password { get; set; }

        /*public Consumer(int id, string login, string password)
        {
            this.id = id;
            this.login = login;
            this.password = password;
        }

        public Consumer(string login, string password)
        {
            this.login = login;
            this.password = password;
        }*/
    }
}
