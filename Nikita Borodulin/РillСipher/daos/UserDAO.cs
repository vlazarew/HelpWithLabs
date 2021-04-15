using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using РillСipher.model;

namespace РillСipher.daos
{
    static class UserDAO
    {
        //private static string connectionString = "database=pill_cipher;characterset=utf8;port=" + 3306 + ";";
        //private static string ip = "localhost";
        //private static string username = "admin";
        //private static string password = "admin";
        //string connString = connectionString + "Server=" + ip
        //                + ";user id=" + username + ";password=" + password;
        private static string connString = "database=pill_cipher;characterset=utf8;port=" + 3306 + ";" + "Server=localhost"
                        + ";user id= admin;password=admin";

        private static MySqlConnection createConnect()
        {
            MySqlConnection connection = new MySqlConnection(connString);
            try
            {
                connection.Open();
            }
            catch
            {
                throw new Exception("Не удалось установить соединение с базой");
            }

            return connection;

        }

        public static bool createUser(User user)
        {
            MySqlConnection connection = createConnect();
            MySqlTransaction transaction = connection.BeginTransaction();

            string query = "INSERT INTO user (user.login, user.password) VALUES (@login, @password)";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@login", user.login);
            command.Parameters.AddWithValue("@password", user.password);

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

        public static User getUserByLogin(string login)
        {
            MySqlConnection connection = createConnect();

            string query = "select * from user where user.login = @login";
            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@login", login);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())

                    return new User(reader.GetString(1), reader.GetString(2));
            }

            return null;
        }

        public static User getUserByLoginAndPassword(string login, string password)
        {
            MySqlConnection connection = createConnect();

            string query = "select * from user where user.login = @login and user.password = @password";
            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@password", password);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())

                    return new User(reader.GetString(1), reader.GetString(2));
            }

            return null;
        }

    }
}
