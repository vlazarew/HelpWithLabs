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
    /// Класс для взаимодействия класса Payments в коде с ее реализацией в БД
    /// </summary>
    class PaymentsDAO
    {
        /// <summary>
        /// Получить выплаты по id карты клиента
        /// </summary>
        /// <param name="id">id карты клиента</param>
        /// <param name="externalConnection">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <param name="externalTransaction">Внешняя транзакция, которая будет навешиваться на команду</param>
        /// <returns>Объект Выплаты</returns>
        public static Payments getPaymentsByConsumerCardId(int id, MySqlConnection externalConnection = null, MySqlTransaction externalTransaction = null)
        {
            Payments result = null;

            MySqlConnection connection = externalConnection != null ? externalConnection : MySQLDAO.createConnect();
            MySqlTransaction transaction = externalTransaction != null ? externalTransaction : connection.BeginTransaction();

            string query = "select * from payments where payments.consumer_card_id = @consumer_card_id";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@consumer_card_id", id);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result = new Payments(reader.GetInt32(0), reader.GetDateTime(1), reader.GetInt32(2), reader.GetFloat(3));
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
        /// Получить все выплаты в БД
        /// </summary>
        /// <param name="externalConnection">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <param name="externalTransaction">Внешняя транзакция, которая будет навешиваться на команду</param>
        /// <returns>Все выплаты в БД</returns>
        public static List<Payments> getPayments(MySqlConnection externalConnection = null, MySqlTransaction externalTransaction = null)
        {
            List<Payments> result = new List<Payments>();

            MySqlConnection connection = externalConnection != null ? externalConnection : MySQLDAO.createConnect();
            MySqlTransaction transaction = externalTransaction != null ? externalTransaction : connection.BeginTransaction();

            string query = "select * from payments";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Payments(reader.GetInt32(0), reader.GetDateTime(1), reader.GetInt32(2), reader.GetFloat(3)));
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
