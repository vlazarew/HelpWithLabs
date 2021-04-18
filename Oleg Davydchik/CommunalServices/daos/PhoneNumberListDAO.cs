/*using CommunalServices.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalServices.daos
{
    class PhoneNumberListDAO
    {
        public static bool SaveNumberList(PhoneNumberList phoneNumberList, MySqlConnection externalConnection = null, MySqlTransaction externalTransaction = null)
        {
            MySqlConnection connection = externalConnection != null ? externalConnection : MySQLDAO.createConnect();
            MySqlTransaction transaction = externalTransaction != null ? externalTransaction : connection.BeginTransaction();

            string query = "INSERT INTO phone_number (phone_number.value) VALUES (@value)";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@value", phoneNumber.value);

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
}*/
