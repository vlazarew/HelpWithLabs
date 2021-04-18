using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РillСipher.daos
{
    public static class MySQLDAO
    {
        //private static string connectionString = "database=pill_cipher;characterset=utf8;port=" + 3306 + ";";
        //private static string ip = "localhost";
        //private static string username = "admin";
        //private static string password = "admin";
        //string connString = connectionString + "Server=" + ip
        //                + ";user id=" + username + ";password=" + password;
        private static string connString = "database=pill_cipher;characterset=utf8;port=" + 3306 + ";" + "Server=localhost"
                        + ";user id= admin;password=admin";

        public static MySqlConnection createConnect()
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
    }
}
