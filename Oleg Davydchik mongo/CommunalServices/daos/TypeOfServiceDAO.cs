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
    /// Класс для взаимодействия класса TypeOfService в коде с ее реализацией в БД
    /// </summary>
    class TypeOfServiceDAO
    {
        public static IMongoCollection<TypeOfService> getCollection(MongoClient client)
        {
            return client.GetDatabase("communal_services").GetCollection<TypeOfService>("type_of_service");
        }

        /// <summary>
        /// Получение вид сервиса по id карты клиента
        /// </summary>
        /// <param name="id">id карты клиента</param>
        /// <param name="externalClient">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <returns>Вид сервиса</returns>
        public static TypeOfService getTypeOfServiceByConsumerCardId(int id, MongoClient externalClient = null)
        {
            // В случае если нет внешнего соединения, сделаем новое локальное
            MongoClient client = externalClient != null ? externalClient : MongoDAO.createConnect();

            using (var session = client.StartSession())
            {
                try
                {
                    var typeOfServices = getCollection(client);
                    var consumerCards = ConsumerCardDAO.getCollection(client).AsQueryable().Where(doc => doc.id == id);
                    var results = typeOfServices.AsQueryable().Join(consumerCards.AsQueryable(), service => service.id, card => card.typeOfServiceId,
                        (x, y) => new { service = x, card = y })
                        .Select(x => x.service).ToList();
                    return results[0];
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Получить вид сервиса по имени и стоимости
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="cost">Стоимость</param>
        /// <param name="externalClient">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <returns>Найденный вид сервиса</returns>
        public static TypeOfService getTypeOfServiceByNameAndCost(string name, float cost, MongoClient externalClient = null)
        {
            // В случае если нет внешнего соединения, сделаем новое локальное
            MongoClient client = externalClient != null ? externalClient : MongoDAO.createConnect();

            using (var session = client.StartSession())
            {
                try
                {
                    var collection = getCollection(client);
                    var results = collection.Find(doc => doc.name == name && doc.cost == cost).ToList();
                    return results[0];
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Получить все виды сервиса
        /// </summary>
        /// <param name="externalClient">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <returns>Все виды сервисов</returns>
        public static List<TypeOfService> getTypesOfServices(MongoClient externalClient = null)
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

        /// <summary>
        /// Сохранить вид сервиса
        /// </summary>
        /// <param name="typeOfService">Новый вид сервиса</param>
        /// <param name="externalClient">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <returns>true - успех, false - провал</returns>
        public static bool saveTypeOfService(TypeOfService typeOfService, MongoClient externalClient = null)
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

                    collection.InsertOne(typeOfService);
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
        /// Обновить вид сервиса
        /// </summary>
        /// <param name="typeOfService">Обновляемый вид сервиса</param>
        /// <param name="externalClient">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <returns>true - успех, false - провал</returns>
        public static bool updateTypeOfService(TypeOfService typeOfService, MongoClient externalClient = null)
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
                    collection.ReplaceOne(doc => doc.id == typeOfService.id, typeOfService);
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
        /// Удалить вид сервиса
        /// </summary>
        /// <param name="typeOfService">Удаляемый вид сервиса</param>
        /// <param name="externalClient">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <returns>true - успех, false - провал</returns>
        public static bool deleteTypeOfService(TypeOfService typeOfService, MongoClient externalClient = null)
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
                    collection.DeleteOne(doc => doc.id == typeOfService.id);
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
