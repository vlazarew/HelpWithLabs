using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalServices.daos
{
    /// <summary>
    /// Класс для общих вещей с MySQL
    /// </summary>
    public static class MySQLDAO
    {
        // Строка соединения с БД
        private static string connString = "database=communal_services;characterset=utf8;port=" + 3306 + ";" + "Server=localhost"
                        + ";user id= admin;password=admin";

        /// <summary>
        /// Создание соединения с БД
        /// </summary>
        /// <returns>Установленное соединение</returns>
        public static MySqlConnection createConnect()
        {
            MySqlConnection connection = new MySqlConnection(connString);
            try
            {
                connection.Open();
            }
            catch
            {
                throw new Exception("Не удалось установить соединение с базой");
            }

            return connection;

        }
    }
}
