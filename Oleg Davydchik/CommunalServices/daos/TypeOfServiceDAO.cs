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
    class TypeOfServiceDAO
    {
        public static TypeOfService getTypeOfServiceByConsumerCardId(int id, MySqlConnection externalConnection = null, MySqlTransaction externalTransaction = null)
        {
            TypeOfService result = null;

            MySqlConnection connection = externalConnection != null ? externalConnection : MySQLDAO.createConnect();
            MySqlTransaction transaction = externalTransaction != null ? externalTransaction : connection.BeginTransaction();

            string query = "select * from type_of_service where type_of_service.consumer_card_id = @consumer_card_id";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@consumer_card_id", id);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result = new TypeOfService(reader.GetInt32(0), reader.GetString(1));
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
                    result.Add(new TypeOfService(reader.GetInt32(0), reader.GetString(1)));
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
