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
    class ConsumerCardDAO
    {
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
                    result.Add(new ConsumerCard(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3)));
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
