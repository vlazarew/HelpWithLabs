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
    /// Класс для взаимодействия класса TypeOfService в коде с ее реализацией в БД
    /// </summary>
    class TypeOfServiceDAO
    {
        /// <summary>
        /// Получение вид сервиса по id карты клиента
        /// </summary>
        /// <param name="id">id карты клиента</param>
        /// <param name="externalConnection">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <param name="externalTransaction">Внешняя транзакция, которая будет навешиваться на команду</param>
        /// <returns>Вид сервиса</returns>
        public static TypeOfService getTypeOfServiceByConsumerCardId(int id, MySqlConnection externalConnection = null, MySqlTransaction externalTransaction = null)
        {
            TypeOfService result = null;

            MySqlConnection connection = externalConnection != null ? externalConnection : MySQLDAO.createConnect();
            MySqlTransaction transaction = externalTransaction != null ? externalTransaction : connection.BeginTransaction();

            string query = "select * from type_of_service " +
                "join consumer_card on consumer_card.type_of_service_id = type_of_service.id and consumer_card.id = @consumer_card_id";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@consumer_card_id", id);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result = new TypeOfService(reader.GetInt32(0), reader.GetString(1), reader.GetFloat(2));
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

        /// <summary>
        /// Получить вид сервиса по имени и стоимости
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="cost">Стоимость</param>
        /// <param name="externalConnection">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <param name="externalTransaction">Внешняя транзакция, которая будет навешиваться на команду</param>
        /// <returns>Найденный вид сервиса</returns>
        public static TypeOfService getTypeOfServiceByNameAndCost(string name, float cost, MySqlConnection externalConnection = null, MySqlTransaction externalTransaction = null)
        {
            TypeOfService result = null;

            MySqlConnection connection = externalConnection != null ? externalConnection : MySQLDAO.createConnect();
            MySqlTransaction transaction = externalTransaction != null ? externalTransaction : connection.BeginTransaction();

            string query = "select * from type_of_service " +
                "where type_of_service.name = @name and type_of_service.cost = @cost";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@cost", cost);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result = new TypeOfService(reader.GetInt32(0), reader.GetString(1), reader.GetFloat(2));
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

        /// <summary>
        /// Получить все виды сервиса
        /// </summary>
        /// <param name="externalConnection">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <param name="externalTransaction">Внешняя транзакция, которая будет навешиваться на команду</param>
        /// <returns>Все виды сервисов</returns>
        public static List<TypeOfService> getTypesOfServices(MySqlConnection externalConnection = null, MySqlTransaction externalTransaction = null)
        {
            List<TypeOfService> result = new List<TypeOfService>();

            MySqlConnection connection = externalConnection != null ? externalConnection : MySQLDAO.createConnect();
            MySqlTransaction transaction = externalTransaction != null ? externalTransaction : connection.BeginTransaction();

            string query = "select * from type_of_service";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new TypeOfService(reader.GetInt32(0), reader.GetString(1), reader.GetFloat(2)));
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

        /// <summary>
        /// Сохранить вид сервиса
        /// </summary>
        /// <param name="typeOfService">Новый вид сервиса</param>
        /// <param name="externalConnection">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <param name="externalTransaction">Внешняя транзакция, которая будет навешиваться на команду</param>
        /// <returns>true - успех, false - провал</returns>
        public static bool saveTypeOfService(TypeOfService typeOfService, MySqlConnection externalConnection = null, MySqlTransaction externalTransaction = null)
        {
            MySqlConnection connection = externalConnection != null ? externalConnection : MySQLDAO.createConnect();
            MySqlTransaction transaction = externalTransaction != null ? externalTransaction : connection.BeginTransaction();

            string query = "INSERT INTO type_of_service (type_of_service.name, type_of_service.cost) VALUES (@name, @cost)";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@name", typeOfService.name);
            command.Parameters.AddWithValue("@cost", typeOfService.cost);

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
        /// Обновить вид сервиса
        /// </summary>
        /// <param name="typeOfService">Обновляемый вид сервиса</param>
        /// <param name="externalConnection">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <param name="externalTransaction">Внешняя транзакция, которая будет навешиваться на команду</param>
        /// <returns>true - успех, false - провал</returns>
        public static bool updateTypeOfService(TypeOfService typeOfService, MySqlConnection externalConnection = null, MySqlTransaction externalTransaction = null)
        {
            MySqlConnection connection = externalConnection != null ? externalConnection : MySQLDAO.createConnect();
            MySqlTransaction transaction = externalTransaction != null ? externalTransaction : connection.BeginTransaction();

            string query = "update type_of_service set type_of_service.name = @name, type_of_service.cost = @cost where type_of_service.id = @id";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@id", typeOfService.id);
            command.Parameters.AddWithValue("@name", typeOfService.name);
            command.Parameters.AddWithValue("@cost", typeOfService.cost);

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
        /// Удалить вид сервиса
        /// </summary>
        /// <param name="typeOfService">Удаляемый вид сервиса</param>
        /// <param name="externalConnection">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <param name="externalTransaction">Внешняя транзакция, которая будет навешиваться на команду</param>
        /// <returns>true - успех, false - провал</returns>
        public static bool deleteTypeOfService(TypeOfService typeOfService, MySqlConnection externalConnection = null, MySqlTransaction externalTransaction = null)
        {
            MySqlConnection connection = externalConnection != null ? externalConnection : MySQLDAO.createConnect();
            MySqlTransaction transaction = externalTransaction != null ? externalTransaction : connection.BeginTransaction();

            string query = "delete from type_of_service where type_of_service.name = @name and type_of_service.cost = @cost and type_of_service.id = @id";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@id", typeOfService.id);
            command.Parameters.AddWithValue("@name", typeOfService.name);
            command.Parameters.AddWithValue("@cost", typeOfService.cost);

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

    }
}
