using CommunalServices.model;
using MongoDB.Bson;
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
    /// Класс для взаимодействия класса AddressRegiste в коде с ее реализацией в БД
    /// </summary>
    class AddressRegisterDAO
    {

        public static IMongoCollection<AddressRegister> getCollection(MongoClient client)
        {
            return client.GetDatabase("communal_services").GetCollection<AddressRegister>("address_register");
        }


        /// <summary>
        /// Сохранение адреса в БД
        /// </summary>
        /// <param name="address">Объект класса Адрес</param>
        /// <param name="externalClient">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <returns>True - если сохранение успешно, false - если пошли ошибки</returns>
        public static bool saveAddressRegister(AddressRegister address, MongoClient externalClient = null)
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

                    collection.InsertOne(address);
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
        /// Обновление адреса
        /// </summary>
        /// <param name="addressRegister">Объект, который будем обновлять</param>
        /// <param name="externalClient">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <returns>True - если обновление успешно, false - если пошли ошибки</returns>
        public static bool updateAddressRegister(AddressRegister addressRegister, MongoClient externalClient = null)
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
                    collection.ReplaceOne(doc => doc.id == addressRegister.id, addressRegister);
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
        /// Удаление записи AdressRegister
        /// </summary>
        /// <param name="addressRegister">Удаляемый из БД объект</param>
        /// <param name="externalClient">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <returns>True - если удаление успешно, false - если пошли ошибки</returns>
        public static bool deleteAddressRegister(AddressRegister addressRegister, MongoClient externalClient = null)
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
                    collection.DeleteOne(doc => doc.id == addressRegister.id);
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
        /// Получить объект Адрес по параметрам Улица + Дом + Квартира
        /// </summary>
        /// <param name="street">Значение параметра улица</param>
        /// <param name="house">Значение параметра дом</param>
        /// <param name="flat">Значение параметра квартира</param>
        /// <param name="externalClient">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <returns>Найденный объект в БД или null</returns>
        public static AddressRegister getAddressRegisterFromStreetHouseFlat(string street, string house, int flat, MongoClient externalClient = null)
        {
            // В случае если нет внешнего соединения, сделаем новое локальное
            MongoClient client = externalClient != null ? externalClient : MongoDAO.createConnect();

            using (var session = client.StartSession())
            {
                try
                {
                    var collection = getCollection(client);
                    var results = collection.Find(doc => doc.street == street && doc.house == house && doc.flat == flat).ToList();
                    return results[0];
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Получить объект Адрес по его id
        /// </summary>
        /// <param name="id">Искомый id</param>
        /// <param name="externalClient">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <returns>Найденный объект в БД или null</returns>
        public static AddressRegister getAddressRegisterById(int id, MongoClient externalClient = null)
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
        /// Получить все Адреса
        /// </summary>
        /// <param name="externalClient">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <returns>Найденные объекты в БД</returns>
        public static List<AddressRegister> getAddressRegisters(MongoClient externalClient = null)
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
