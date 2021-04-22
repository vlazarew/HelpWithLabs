using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalServices.model
{
    /// <summary>
    /// Клиент
    /// </summary>
    public class Consumer
    {
        // id
        public int id { get; set; }
        // имя
        public string name { get; set; }
        // фамилия
        public string surname { get; set; }
        // id адреса
        public int addressRegisterId { get; set; }
        // id типа клиента
        public int typeOfConsumerId { get; set; }
        // id учетных данных
        public int credentialsId { get; set; }

        /// <summary>
        /// Конструктор без id
        /// </summary>
        /// <param name="name">имя</param>
        /// <param name="surname">фамилия</param>
        /// <param name="addressRegisterId">id адреса</param>
        /// <param name="typeOfConsumerId">id типа клиента</param>
        /// <param name="credentialsId">id учетных данных</param>
        public Consumer(string name, string surname, int addressRegisterId, int typeOfConsumerId, int credentialsId)
        {
            this.name = name;
            this.surname = surname;
            this.addressRegisterId = addressRegisterId;
            this.typeOfConsumerId = typeOfConsumerId;
            this.credentialsId = credentialsId;
        }

        /// <summary>
        /// Конструктор с id
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="name">имя</param>
        /// <param name="surname">фамилия</param>
        /// <param name="addressRegisterId">id адреса</param>
        /// <param name="typeOfConsumerId">id типа клиента</param>
        /// <param name="credentialsId">id учетных данных</param>
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
