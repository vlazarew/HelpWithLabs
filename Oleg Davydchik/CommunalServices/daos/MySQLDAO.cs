using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalServices.daos
{
    public static class MySQLDAO
    {
        private static string connString = "database=communal_services;characterset=utf8;port=" + 3306 + ";" + "Server=localhost"
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
