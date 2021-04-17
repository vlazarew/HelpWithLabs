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
    public static class WordDAO
    {

        public static void saveWordToDB(string value, User user)
        {
            MySqlConnection connection = MySQLDAO.createConnect();
            MySqlTransaction transaction = connection.BeginTransaction();

            string query = "INSERT INTO word (word.value, word.user_id) VALUES (@value, @user_id)";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@value", value);
            command.Parameters.AddWithValue("@user_id", user.id);

            try
            {
                command.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();
                return;
            }
            catch
            {
                return;
            }
        }

        public static List<string> getAllWordByUser(User user)
        {
            List<string> resultList = new List<string>();
            MySqlConnection connection = MySQLDAO.createConnect();

            string query = "select value from word where word.user_id = @user_id";
            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@user_id", user.id);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    resultList.Add(reader.GetString(0));
                }
            }

            return resultList;
        }

    }
}
