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
    /// Класс для взаимодействия класса Phone в коде с ее реализацией в БД
    /// </summary>
    class PhoneDAO
    {
        private static IMongoCollection<PhoneNumber> getCollection(MongoClient client)
        {
            return client.GetDatabase("communal_services").GetCollection<PhoneNumber>("phone");
        }

        /// <summary>
        /// Сохранить номер телефона
        /// </summary>
        /// <param name="phoneNumber">Номер телефона</param>
        /// <param name="externalClient">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <returns>true - успех, false - провал</returns>
        public static bool saveNumber(PhoneNumber phoneNumber, MongoClient externalClient = null)
        {
            // В случае если нет внешнего соединения, сделаем новое локальное
            MongoClient client = externalClient != null ? externalClient : MongoDAO.createConnect();

            using (var session = client.StartSession())
            {
                // В случае если нет внешней транкзакции, сделаем новую локальную
                // session.StartTransaction();

                try
                {
                    var collection = getCollection(client);

                    collection.InsertOne(phoneNumber);
                    // session.CommitTransaction();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Получить номер телефона по id клиента
        /// </summary>
        /// <param name="id">id клиента</param>
        /// <param name="externalClient">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <returns>Список найденных номеров телефона</returns>
        public static List<PhoneNumber> getPhoneByConsumerId(int id, MongoClient externalClient = null)
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
        /// Удаление телефонов Клиента (не используется)
        /// </summary>
        /// <param name="consumer">Клиент</param>
        /// <param name="externalClient">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <returns>true - успех, false - провал</returns>
        public static bool deletePhoneByConsumer(Consumer consumer, MongoClient externalClient = null)
        {
            // В случае если нет внешнего соединения, сделаем новое локальное
            MongoClient client = externalClient != null ? externalClient : MongoDAO.createConnect();

            using (var session = client.StartSession())
            {
                // В случае если нет внешней транкзакции, сделаем новую локальную
                // session.StartTransaction();

                try
                {
                    var collection = getCollection(client);
                    collection.DeleteOne(doc => doc.consumerId == consumer.id);
                    // session.CommitTransaction();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
