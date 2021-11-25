using CommunalServices.model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
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
    /// Класс для взаимодействия класса Consumer в коде с ее реализацией в БД
    /// </summary>
    public static class ConsumerDAO
    {
        public static IMongoCollection<Consumer> getCollection(MongoClient client)
        {
            return client.GetDatabase("communal_services").GetCollection<Consumer>("consumer");
        }

        private static IMongoCollection<BsonDocument> getCollectionBSON(MongoClient client)
        {
            return client.GetDatabase("communal_services").GetCollection<BsonDocument>("consumer");
        }


        /// <summary>
        /// Получить клиента по id его учетных данных
        /// </summary>
        /// <param name="credentialsId">id учетных данных</param>
        /// <param name="externalClient">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <returns>Объект Клиент</returns>
        public static Consumer getConsumerByCredentialsId(int credentialsId, MongoClient externalClient = null)
        {
            // В случае если нет внешнего соединения, сделаем новое локальное
            MongoClient client = externalClient != null ? externalClient : MongoDAO.createConnect();

            using (var session = client.StartSession())
            {
                try
                {
                    var collection = getCollection(client);
                    var results = collection.Find(doc => doc.credentialsId == credentialsId).ToList();
                    return results[0];
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Сохранить клиента
        /// </summary>
        /// <param name="consumer">Объект клиент</param>
        /// <param name="externalClient">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <returns>True - если успех, false - провал</returns>
        public static bool saveConsumer(Consumer consumer, MongoClient externalClient = null)
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
                    consumer.id = collection.Find(_ => true).ToList().Count;
                    collection.InsertOne(consumer);
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
        /// Обновление Клиента
        /// </summary>
        /// <param name="consumer">Объект Клиент к обновлению</param>
        /// <param name="externalClient">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <returns>True - успех, false - провал</returns>
        public static bool updateConsumer(Consumer consumer, MongoClient externalClient = null)
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
                    collection.ReplaceOne(doc => doc.id == consumer.id, consumer);
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
        /// Получить список Клиентов по части имени/фамилии
        /// </summary>
        /// <param name="name">Часть имени</param>
        /// <param name="surname">Часть фамилии</param>
        /// <param name="externalClient">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <returns>Список найденных Клиентов</returns>
        public static List<Consumer> getConsumersByTemplate(string name, string surname, MongoClient externalClient = null)
        {
            // В случае если нет внешнего соединения, сделаем новое локальное
            MongoClient client = externalClient != null ? externalClient : MongoDAO.createConnect();

            using (var session = client.StartSession())
            {
                try
                {
                    var collection = getCollectionBSON(client);
                    var builder = Builders<BsonDocument>.Filter;
                    var filter = builder.Regex("name", new BsonRegularExpression(name)) & builder.Regex("surname", new BsonRegularExpression(surname));
                    var results = collection.Find(filter).ToList();

                    var res = new List<Consumer>();
                    for (int i = 0; i < results.Count; i++)
                    {
                        res.Add(BsonSerializer.Deserialize<Consumer>(results[i]));
                    }
                    return res;
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Получить клиента по его id
        /// </summary>
        /// <param name="id">id клиента</param>
        /// <param name="externalClient">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <returns>Найденный клиент</returns>
        public static Consumer getConsumerById(int id, MongoClient externalClient = null)
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

        /// <summary>
        /// Получить клиента по его имени/фамилии
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="externalClient">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <returns>Найденный клиент</returns>
        public static Consumer getConsumerByNameSurname(string name, string surname, MongoClient externalClient = null)
        {
            // В случае если нет внешнего соединения, сделаем новое локальное
            MongoClient client = externalClient != null ? externalClient : MongoDAO.createConnect();

            using (var session = client.StartSession())
            {
                try
                {
                    var collection = getCollection(client);
                    var results = collection.Find(doc => doc.name == name && doc.surname == surname).ToList();
                    return results[0];
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Удаление Клиента
        /// </summary>
        /// <param name="consumer">Удаляемый клиент</param>
        /// <param name="externalClient">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <returns>true - успех, false - провал</returns>
        public static bool deleteConsumer(Consumer consumer, MongoClient externalClient = null)
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
                    collection.DeleteOne(doc => doc.id == consumer.id);
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
