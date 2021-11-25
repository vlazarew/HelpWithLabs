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
    /// Класс для взаимодействия класса ConsumerCard в коде с ее реализацией в БД
    /// </summary>
    class ConsumerCardDAO
    {
        public static IMongoCollection<ConsumerCard> getCollection(MongoClient client)
        {
            return client.GetDatabase("communal_services").GetCollection<ConsumerCard>("consumer_card");
        }

        /// <summary>
        /// Получить карточку клиента по id клиента
        /// </summary>
        /// <param name="id">id клиента</param>
        /// <param name="externalClient">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <returns>Список карточек указанного клиента</returns>
        public static List<ConsumerCard> getConsumerCardByConsumerId(int id, MongoClient externalClient = null)
        {
            // В случае если нет внешнего соединения, сделаем новое локальное
            MongoClient client = externalClient != null ? externalClient : MongoDAO.createConnect();

            using (var session = client.StartSession())
            {
                try
                {
                    var collection = getCollection(client);
                    var results = collection.Find(doc => doc.consumerId == id).ToList();
                    return results;
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Получить карточку клиента по id карточки клиента
        /// </summary>
        /// <param name="id">id карточки клиента</param>
        /// <param name="externalClient">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <returns>Карта клиента</returns>
        public static ConsumerCard getConsumerCardByConsumerCardId(int id, MongoClient externalClient = null)
        {
            // В случае если нет внешнего соединения, сделаем новое локальное
            MongoClient client = externalClient != null ? externalClient : MongoDAO.createConnect();

            using (var session = client.StartSession())
            {
                try
                {
                    var collection = getCollection(client);
                    var results = collection.Find(doc => doc.id == id).ToList();
                    return results[0];
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
