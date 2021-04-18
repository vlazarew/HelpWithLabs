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
    static class ConsumerDAO
    {
        public static Consumer getConsumerByCredentialsId(int credentialsId, MySqlConnection externalConnection = null, MySqlTransaction externalTransaction = null)
        {
            Consumer result = null;

            MySqlConnection connection = externalConnection != null ? externalConnection : MySQLDAO.createConnect();
            MySqlTransaction transaction = externalTransaction != null ? externalTransaction : connection.BeginTransaction();

            string query = "select * from consumer where consumer.credentials_id = @credentialsId";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@credentialsId", credentialsId);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result = new Consumer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5));
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

        public static bool saveConsumer(Consumer consumer, MySqlConnection externalConnection = null, MySqlTransaction externalTransaction = null)
        {
            MySqlConnection connection = externalConnection != null ? externalConnection : MySQLDAO.createConnect();
            MySqlTransaction transaction = externalTransaction != null ? externalTransaction : connection.BeginTransaction();

            string query = "INSERT INTO consumer (consumer.name, consumer.surname, consumer.address_register_id, consumer.type_of_consumer_id, consumer.credentials_id)" +
                " VALUES (@name, @surname, @address_register_id, @type_of_consumer_id, @credentials_id)";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@name", consumer.name);
            command.Parameters.AddWithValue("@surname", consumer.surname);
            command.Parameters.AddWithValue("@address_register_id", consumer.addressRegisterId);
            command.Parameters.AddWithValue("@type_of_consumer_id", consumer.typeOfConsumerId);
            command.Parameters.AddWithValue("@credentials_id", consumer.credentialsId);

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

        public static Consumer getConsumerByNameSurnameCredentials(string name, string surname, int id,  MySqlConnection externalConnection = null, MySqlTransaction externalTransaction = null)
        {
            Consumer result = null;

            MySqlConnection connection = externalConnection != null ? externalConnection : MySQLDAO.createConnect();
            MySqlTransaction transaction = externalTransaction != null ? externalTransaction : connection.BeginTransaction();

            string query = "select * from consumer where consumer.credentials_id = @credentialsId and consumer.name = @name and consumer.surname = @surname";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@credentialsId", id);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@surname", surname);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result = new Consumer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5));
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
