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
        public static Consumer getConsumerByCredentialsId(int credentialsId)
        {
            MySqlConnection connection = MySQLDAO.createConnect();

            string query = "select * from consumer where consumer.credentials_id = @credentialsId";
            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@credentialsId", credentialsId);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())

                    //return new Consumer(reader.GetString(1), reader.GetString(2));
                    return new Consumer();
            }

            return null;
        }
    }
}
