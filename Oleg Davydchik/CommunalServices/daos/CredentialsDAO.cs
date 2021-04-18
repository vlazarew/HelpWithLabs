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
    class CredentialsDAO
    {
        public static bool createCredentials(Credentials credentials)
        {
            MySqlConnection connection = MySQLDAO.createConnect();
            MySqlTransaction transaction = connection.BeginTransaction();

            string query = "INSERT INTO credentials (credentials.login, credentials.password) VALUES (@login, @password)";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@login", credentials.login);
            command.Parameters.AddWithValue("@password", credentials.password);

            try
            {
                command.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Credentials getCredentialsByLogin(string login)
        {
            MySqlConnection connection = MySQLDAO.createConnect();

            string query = "select * from credentials where credentials.login = @login";
            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@login", login);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())

                    return new Credentials(reader.GetString(1), reader.GetString(2));
            }

            return null;
        }

        public static Credentials getCredentialsByLoginAndPassword(string login, string password)
        {
            MySqlConnection connection = MySQLDAO.createConnect();

            string query = "select id, login, password from credentials where credentials.login = @login and credentials.password = @password";
            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@password", password);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    return new Credentials(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                }
            }

            return null;
        }

    }
}
