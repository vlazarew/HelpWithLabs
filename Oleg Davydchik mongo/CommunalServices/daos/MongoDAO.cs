using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalServices.daos
{
    /// <summary>
    /// Класс для общих вещей с Mongo
    /// </summary>
    public static class MongoDAO
    {
        // Строка соединения с БД
        //private static string connString = "database=communal_services;characterset=utf8;port=" + 27017 + ";" + "Server=localhost;user id= admin;password=admin";
        // private static string connString = "mongodb+srv://admin:admin@localhost/communal_services?w=majority";
        private static string connString = "mongodb://localhost:27017";

        /// <summary>
        /// Создание соединения с БД
        /// </summary>
        /// <returns>Установленное соединение</returns>
        public static MongoClient createConnect()
        {
            MongoClient client = new MongoClient(connString);
            try
            {
                client.StartSession();
            }
            catch
            {
                throw new Exception("Не удалось установить соединение с базой");
            }

            return client;

        }
    }
}
