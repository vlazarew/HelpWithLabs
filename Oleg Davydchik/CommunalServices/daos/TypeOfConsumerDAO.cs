using CommunalServices.model;
using MySql.Data.MySqlClient;
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
        /// <summary>
        /// Проверка, есть ли стандартные типы клиентов в БД
        /// </summary>
        /// <param name="externalConnection">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <param name="externalTransaction">Внешняя транзакция, которая будет навешиваться на команду</param>
        public static void checkTypesOfConsumer(MySqlConnection externalConnection = null, MySqlTransaction externalTransaction = null)
        {
            bool needToGenerate = false;
            MySqlConnection connection = externalConnection != null ? externalConnection : MySQLDAO.createConnect();
            MySqlTransaction transaction = externalTransaction != null ? externalTransaction : connection.BeginTransaction();

            string query = "select * from type_of_consumer";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            using (DbDataReader reader = command.ExecuteReader())
            {
                needToGenerate = !reader.HasRows;
            }

            if (needToGenerate)
            {
                generateDefaultTypesOfCustomer(connection, transaction);
            }
        }

        /// <summary>
        /// Создание Типов "Администратор" и "Клиент"
        /// </summary>
        /// <param name="connection">Cоединение с БД</param>
        /// <param name="transaction">Nранзакция, которая будет навешиваться на команду</param>
        private static void generateDefaultTypesOfCustomer(MySqlConnection connection, MySqlTransaction transaction)
        {
            saveTypeOfConsumer("Администратор", 0, connection, transaction);
            saveTypeOfConsumer("Клиент", 1, connection, transaction);
        }

        /// <summary>
        /// Сохранение типа Клиента в БД
        /// </summary>
        /// <param name="value">Значение типа</param>
        /// <param name="id">id типа</param>
        /// <param name="externalConnection">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <param name="externalTransaction">Внешняя транзакция, которая будет навешиваться на команду</param>
        /// <returns>true - успех, false - провал</returns>
        public static bool saveTypeOfConsumer(string value, int id, MySqlConnection externalConnection = null, MySqlTransaction externalTransaction = null)
        {
            MySqlConnection connection = externalConnection != null ? externalConnection : MySQLDAO.createConnect();
            MySqlTransaction transaction = externalTransaction != null ? externalTransaction : connection.BeginTransaction();

            string query = "INSERT INTO type_of_consumer (id, type_of_consumer.name) VALUES (@id, @name)";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", value);

            try
            {
                command.ExecuteNonQuery();
                if (externalTransaction == null)
                {
                    transaction.Commit();
                }

                if (externalConnection == null)
                {
                    connection.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Получить тип клиента по id типа
        /// </summary>
        /// <param name="id">id типа клиента</param>
        /// <param name="externalConnection">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <param name="externalTransaction">Внешняя транзакция, которая будет навешиваться на команду</param>
        /// <returns>Найденный тип</returns>
        public static TypeOfConsumer getTypeOfConsumerById(int id, MySqlConnection externalConnection = null, MySqlTransaction externalTransaction = null)
        {
            TypeOfConsumer result = null;

            MySqlConnection connection = externalConnection != null ? externalConnection : MySQLDAO.createConnect();
            MySqlTransaction transaction = externalTransaction != null ? externalTransaction : connection.BeginTransaction();

            string query = "select * from type_of_consumer where type_of_consumer.id = @id";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@id", id);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result = new TypeOfConsumer(reader.GetInt32(0), reader.GetString(1));
                }
            }

            if (externalTransaction == null)
            {
                transaction.Commit();
            }

            if (externalConnection == null)
            {
                connection.Close();
            }

            return result;
        }
    }
}
