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
    class AddressRegisterDAO
    {
        public static bool saveAddressRegister(AddressRegister address, MySqlConnection externalConnection = null, MySqlTransaction externalTransaction = null)
        {
            MySqlConnection connection = externalConnection != null ? externalConnection : MySQLDAO.createConnect();
            MySqlTransaction transaction = externalTransaction != null ? externalTransaction : connection.BeginTransaction();

            string query = "INSERT INTO address_register (address_register.street, address_register.house, address_register.flat) VALUES (@street, @house, @flat)";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@street", address.street);
            command.Parameters.AddWithValue("@house", address.house);
            command.Parameters.AddWithValue("@flat", address.flat);

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

        public static AddressRegister getAddressRegisterFromStreetHouseFlat(string street, string house, int flat, MySqlConnection externalConnection = null,
            MySqlTransaction externalTransaction = null)
        {
            AddressRegister result = null;

            MySqlConnection connection = externalConnection != null ? externalConnection : MySQLDAO.createConnect();
            MySqlTransaction transaction = externalTransaction != null ? externalTransaction : connection.BeginTransaction();

            string query = "select * from address_register where address_register.street = @street and address_register.house = @house and " +
                "address_register.flat = @flat";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@street", street);
            command.Parameters.AddWithValue("@house", house);
            command.Parameters.AddWithValue("@flat", flat);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result = new AddressRegister(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
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
