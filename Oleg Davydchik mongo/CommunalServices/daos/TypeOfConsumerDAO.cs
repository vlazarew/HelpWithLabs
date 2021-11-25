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
    /// Класс для взаимодействия класса TypeOfConsumer в коде с ее реализацией в БД
    /// </summary>
    class TypeOfConsumerDAO
    {
        private static IMongoCollection<TypeOfConsumer> getCollection(MongoClient client)
        {
            return client.GetDatabase("communal_services").GetCollection<TypeOfConsumer>("type_of_consumer");
        }

        /// <summary>
        /// Проверка, есть ли стандартные типы клиентов в БД
        /// </summary>
        /// <param name="externalClient">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        public static void checkTypesOfConsumer(MongoClient externalClient = null)
        {
            bool needToGenerate = false;
            // В случае если нет внешнего соединения, сделаем новое локальное
            MongoClient client = externalClient != null ? externalClient : MongoDAO.createConnect();
            var results = new List<TypeOfConsumer>();

            using (var session = client.StartSession())
            {
                try
                {
                    var collection = getCollection(client);
                    results = collection.Find(_ => true).ToList();
                }
                catch { }
            }

            needToGenerate = results.Count == 0;

            if (needToGenerate)
            {
                generateDefaultTypesOfCustomer(externalClient);
            }
        }

        /// <summary>
        /// Создание Типов "Администратор" и "Клиент"
        /// </summary>
        /// <param name="externalClient">Cоединение с БД</param>
        private static void generateDefaultTypesOfCustomer(MongoClient externalClient = null)
        {
            saveTypeOfConsumer("Администратор", 0, externalClient);
            saveTypeOfConsumer("Клиент", 1, externalClient);
        }

        /// <summary>
        /// Сохранение типа Клиента в БД
        /// </summary>
        /// <param name="value">Значение типа</param>
        /// <param name="id">id типа</param>
        /// <param name="externalClient">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <returns>true - успех, false - провал</returns>
        public static bool saveTypeOfConsumer(string value, int id, MongoClient externalClient = null)
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

                    collection.InsertOne(new TypeOfConsumer(id, value));
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
        /// Получить тип клиента по id типа
        /// </summary>
        /// <param name="id">id типа клиента</param>
        /// <param name="externalClient">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <returns>Найденный тип</returns>
        public static TypeOfConsumer getTypeOfConsumerById(int id, MongoClient externalClient = null)
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
