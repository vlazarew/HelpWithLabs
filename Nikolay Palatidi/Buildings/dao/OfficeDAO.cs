using Buildings.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings.dao
{
    class OfficeDAO
    {
        public static List<Office> getAllOffices()
        {
            List<Office> result = new List<Office>();

            MySqlConnection connection = MySQLDAO.createConnect();

            string query = "select * from office";
            MySqlCommand command = new MySqlCommand(query, connection);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Office(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4)));
                }
            }

            connection.Close();

            return result;
        }
    }
}
