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
    /// Класс для взаимодействия класса Credentials в коде с ее реализацией в БД
    /// </summary>
    class CredentialsDAO
    {
        private static IMongoCollection<Credentials> getCollection(MongoClient client)
        {
            return client.GetDatabase("communal_services").GetCollection<Credentials>("credentials");
        }
        /// <summary>
        /// Сохранить учетные данные
        /// </summary>
        /// <param name="credentials">Учетные данные</param>
        /// <param name="externalClient">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <returns>true - успех, false - провал</returns>
        public static bool saveCredentials(Credentials credentials, MongoClient externalClient = null)
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
                    credentials.id = collection.Find(_ => true).ToList().Count;
                    collection.InsertOne(credentials);
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
        /// Получить учетные данные по логину
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="externalClient">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <returns>Найденные учетные данные</returns>
        public static Credentials getCredentialsByLogin(string login, MongoClient externalClient = null)
        {
            // В случае если нет внешнего соединения, сделаем новое локальное
            MongoClient client = externalClient != null ? externalClient : MongoDAO.createConnect();

            using (var session = client.StartSession())
            {
                try
                {
                    var collection = getCollection(client);
                    var results = collection.Find(doc => doc.login == login).ToList();
                    return results[0];
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Получить учетные данные по логину/паролю
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <param name="externalClient">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <returns>Найденные учетные данные</returns>
        public static Credentials getCredentialsByLoginAndPassword(string login, string password, MongoClient externalClient = null)
        {
            // В случае если нет внешнего соединения, сделаем новое локальное
            MongoClient client = externalClient != null ? externalClient : MongoDAO.createConnect();

            using (var session = client.StartSession())
            {
                try
                {
                    var collection = getCollection(client);
                    var results = collection.Find(doc => doc.login == login && doc.password == password).ToList();
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
