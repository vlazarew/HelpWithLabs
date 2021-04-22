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
    /// Класс для взаимодействия класса ConsumerCard в коде с ее реализацией в БД
    /// </summary>
    class ConsumerCardDAO
    {
        /// <summary>
        /// Получить карточку клиента по id клиента
        /// </summary>
        /// <param name="id">id клиента</param>
        /// <param name="externalConnection">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <param name="externalTransaction">Внешняя транзакция, которая будет навешиваться на команду</param>
        /// <returns>Список карточек указанного клиента</returns>
        public static List<ConsumerCard> getConsumerCardByConsumerId(int id, MySqlConnection externalConnection = null, MySqlTransaction externalTransaction = null)
        {
            List<ConsumerCard> result = new List<ConsumerCard>();

            MySqlConnection connection = externalConnection != null ? externalConnection : MySQLDAO.createConnect();
            MySqlTransaction transaction = externalTransaction != null ? externalTransaction : connection.BeginTransaction();

            string query = "select * from consumer_card where consumer_card.consumer_id = @consumer_id";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@consumer_id", id);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new ConsumerCard(reader.GetInt32(0), reader.GetDateTime(1), reader.GetInt32(2), reader.GetInt32(3)));
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
        /// Получить карточку клиента по id карточки клиента
        /// </summary>
        /// <param name="id">id карточки клиента</param>
        /// <param name="externalConnection">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <param name="externalTransaction">Внешняя транзакция, которая будет навешиваться на команду</param>
        /// <returns>Карта клиента</returns>
        public static ConsumerCard getConsumerCardByConsumerCardId(int id, MySqlConnection externalConnection = null, MySqlTransaction externalTransaction = null)
        {
            ConsumerCard result = null;

            MySqlConnection connection = externalConnection != null ? externalConnection : MySQLDAO.createConnect();
            MySqlTransaction transaction = externalTransaction != null ? externalTransaction : connection.BeginTransaction();

            string query = "select * from consumer_card where consumer_card.id = @id";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@id", id);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result = new ConsumerCard(reader.GetInt32(0), reader.GetDateTime(1), reader.GetInt32(2), reader.GetInt32(3));
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
