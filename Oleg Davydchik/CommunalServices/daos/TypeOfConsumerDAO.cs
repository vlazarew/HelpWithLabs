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
    class TypeOfConsumerDAO
    {
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

        private static void generateDefaultTypesOfCustomer(MySqlConnection connection, MySqlTransaction transaction)
        {
            saveTypeOfConsumer("Администратор", 0, connection, transaction);
            saveTypeOfConsumer("Клиент", 1, connection, transaction);
        }

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
