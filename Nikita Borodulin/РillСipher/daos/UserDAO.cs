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
        public static bool createUser(User user)
        {
            MySqlConnection connection = MySQLDAO.createConnect();
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
            MySqlConnection connection = MySQLDAO.createConnect();

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
            MySqlConnection connection = MySQLDAO.createConnect();

            string query = "select id, login, password from user where user.login = @login and user.password = @password";
            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@password", password);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    return new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                }
            }

            return null;
        }

    }
}
