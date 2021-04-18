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


        public Consumer(string name, string surname, int addressRegisterId, int typeOfConsumerId, int credentialsId)
        {
            this.name = name;
            this.surname = surname;
            this.addressRegisterId = addressRegisterId;
            this.typeOfConsumerId = typeOfConsumerId;
            this.credentialsId = credentialsId;
        }

        public Consumer(int id, string name, string surname, int addressRegisterId, int typeOfConsumerId, int credentialsId)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.addressRegisterId = addressRegisterId;
            this.typeOfConsumerId = typeOfConsumerId;
            this.credentialsId = credentialsId;
        }
    }
}
