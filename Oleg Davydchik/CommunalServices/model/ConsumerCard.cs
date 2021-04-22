using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalServices.model
{
    /// <summary>
    /// Карта клиента
    /// </summary>
    class ConsumerCard
    {
        // id карты
        public int id { get; set; }
        // дата оплаты
        public DateTime dateOfPay { get; set; }
        // id клиента
        public int consumerId { get; set; }
        // id типа сервиса
        public int typeOfServiceId { get; set; }

        /// <summary>
        /// Конструктор карты
        /// </summary>
        /// <param name="id">id карты</param>
        /// <param name="dateOfPay">дата оплаты</param>
        /// <param name="consumerId">id клиента</param>
        /// <param name="typeOfServiceId">id типа сервиса</param>
        public ConsumerCard(int id, DateTime dateOfPay, int consumerId, int typeOfServiceId)
        {
            this.id = id;
            this.dateOfPay = dateOfPay;
            this.consumerId = consumerId;
            this.typeOfServiceId = typeOfServiceId;
        }
    }
}
