using CommunalServices.model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalServices.daos
{
      /// <summary>
    /// DAO = Data Access Odject
    /// Класс для взаимодействия класса Payments в коде с ее реализацией в БД
    /// </summary>
    class PaymentsDAO
    {
        public static IMongoCollection<Payments> getCollection(MongoClient client)
        {
            return client.GetDatabase("communal_services").GetCollection<Payments>("payments");
        }

        /// <summary>
        /// Получить выплаты по id карты клиента
        /// </summary>
        /// <param name="id">id карты клиента</param>
        /// <param name="externalClient">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <returns>Объект Выплаты</returns>
        public static Payments getPaymentsByConsumerCardId(int id, MongoClient externalClient = null)
        {
            // В случае если нет внешнего соединения, сделаем новое локальное
            MongoClient client = externalClient != null ? externalClient : MongoDAO.createConnect();

            using (var session = client.StartSession())
            {
                try
                {
                    var collection = getCollection(client);
                    var results = collection.Find(doc => doc.consumerCardId == id).ToList();
                    return results[0];
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Получить все выплаты в БД
        /// </summary>
        /// <param name="externalClient">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <returns>Все выплаты в БД</returns>
        public static List<Payments> getPayments(MongoClient externalClient = null)
        {
            // В случае если нет внешнего соединения, сделаем новое локальное
            MongoClient client = externalClient != null ? externalClient : MongoDAO.createConnect();

            using (var session = client.StartSession())
            {
                try
                {
                    var collection = getCollection(client);
                    var results = collection.Find(_ => true).ToList();
                    return results;
                }
                catch
                {
                    return null;
                }
            }
        }

    }
}
