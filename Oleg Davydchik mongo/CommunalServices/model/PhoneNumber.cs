using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalServices.model
{
    /// <summary>
    /// Номер телефона
    /// </summary>
    class PhoneNumber
    {
        // id клиента
        [BsonId]
        public int consumerId { get; set; }
        // значение номера телефона
        [BsonElement("value")]
        public string value { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="number">значение номера телефона</param>
        /// <param name="consumerId">id клиента</param>
        public PhoneNumber(string number, int consumerId)
        {
            this.consumerId = consumerId;
            this.value = number;
        }

    }
}
