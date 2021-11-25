using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalServices.model
{
    /// <summary>
    /// Оплаты
    /// </summary>
    class Payments
    {
        // id оплаты
        [BsonId]
        public int id { get; set; }
        // крайний срок
        [BsonElement("deadline")]
        public DateTime deadline { get; set; }
        // id карты клиента
        [BsonElement("consumer_card_id")]
        public int consumerCardId { get; set; }
        // сколько оплачено
        [BsonElement("payed")]
        public float payed { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">id оплаты</param>
        /// <param name="deadline">крайний срок</param>
        /// <param name="consumerCardId">id карты клиента</param>
        /// <param name="payed">сколько оплачено</param>
        public Payments(int id, DateTime deadline, int consumerCardId, float payed)
        {
            this.id = id;
            this.deadline = deadline;
            this.consumerCardId = consumerCardId;
            this.payed = payed;
        }

    }
}
