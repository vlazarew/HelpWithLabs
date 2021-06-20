using FootballPlayers.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballPlayers.daos
{
    /// <summary>
    /// DAO = Data Access Odject
    /// Класс для взаимодействия класса Payments в коде с ее реализацией в БД
    /// </summary>
    public static class MidfielderDAO
    {
        // получить всех полузащитников
        public static List<Midfielder> getAllMidfielders()
        {
            List<Midfielder> result = new List<Midfielder>();

            MySqlConnection connection = MySQLDAO.createConnect();

            string query = "select * from Midfielder";
            MySqlCommand command = new MySqlCommand(query, connection);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Midfielder(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6),
                        reader.GetInt32(7), reader.GetInt32(8), reader.GetInt32(9)));
                }
            }

            connection.Close();
            return result;
        }

        // получить всех полузащитников по фильтрам
        public static List<Midfielder> getMidfieldersByTemplate(string name = null, string lastname = null, string club = null, int dribbling = 0, int pass = 0,
            int technical = 0, int agility = 0, int speed = 0, int cost = -1)
        {
            List<Midfielder> result = new List<Midfielder>();

            MySqlConnection connection = MySQLDAO.createConnect();
            bool addDribbling = false;
            bool addPass = false;
            bool addTechnical = false;
            bool addAgility = false;
            bool addSpeed = false;
            bool addCost = false;

            string query = "select * from Midfielder where true";
            if (name != null)
            {
                query += " and name LIKE '%" + name + "%'";
            }
            if (lastname != null)
            {
                query += " and lastname LIKE '%" + lastname + "%'";
            }
            if (club != null)
            {
                query += " and club LIKE '%" + club + "%'";
            }
            if (dribbling != 0)
            {
                query += " and dribbling>=@dribbling";
                addDribbling = true;
            }
            if (pass != 0)
            {
                query += " and pass>=@pass";
                addPass = true;
            }
            if (technical != 0)
            {
                query += " and technical>=@technical";
                addTechnical = true;
            }
            if (agility != 0)
            {
                query += " and agility>=@agility";
                addAgility = true;
            }
            if (speed != 0)
            {
                query += " and speed>=@speed";
                addSpeed = true;
            }
            if (cost != -1)
            {
                query += " and cost<=@cost";
                addCost = true;
            }


            MySqlCommand command = new MySqlCommand(query, connection);
            if (addDribbling) { command.Parameters.AddWithValue("@dribbling", dribbling); }
            if (addPass) { command.Parameters.AddWithValue("@pass", pass); }
            if (addTechnical) { command.Parameters.AddWithValue("@technical", technical); }
            if (addAgility) { command.Parameters.AddWithValue("@agility", agility); }
            if (addSpeed) { command.Parameters.AddWithValue("@speed", speed); }
            if (addCost) { command.Parameters.AddWithValue("@cost", cost); }


            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Midfielder(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6),
                        reader.GetInt32(7), reader.GetInt32(8), reader.GetInt32(9)));
                }
            }

            connection.Close();
            return result;
        }

        public static Midfielder getBestMidfielderdByTemplate(string name = null, string lastname = null, string club = null, int dribbling = 0, int pass = 0,
            int technical = 0, int agility = 0, int speed = 0, int cost = -1)
        {
            MySqlConnection connection = MySQLDAO.createConnect();
            bool addDribbling = false;
            bool addPass = false;
            bool addTechnical = false;
            bool addAgility = false;
            bool addSpeed = false;
            bool addCost = false;

            string query = "select * from Midfielder where true";
            if (name != null)
            {
                query += " and name LIKE '%" + name + "%'";
            }
            if (lastname != null)
            {
                query += " and lastname LIKE '%" + lastname + "%'";
            }
            if (club != null)
            {
                query += " and club LIKE '%" + club + "%'";
            }
            if (dribbling != 0)
            {
                query += " and dribbling>=@dribbling";
                addDribbling = true;
            }
            if (pass != 0)
            {
                query += " and pass>=@pass";
                addPass = true;
            }
            if (technical != 0)
            {
                query += " and technical>=@technical";
                addTechnical = true;
            }
            if (agility != 0)
            {
                query += " and agility>=@agility";
                addAgility = true;
            }
            if (speed != 0)
            {
                query += " and speed>=@speed";
                addSpeed = true;
            }
            if (cost != -1)
            {
                query += " and cost<=@cost";
                addCost = true;
            }

            // добавление упорядочивания по сумме хар-ок и взятие первой записи
            query += " order by (dribbling + pass + technical + agility + speed) desc limit 1";

            MySqlCommand command = new MySqlCommand(query, connection);
            if (addDribbling) { command.Parameters.AddWithValue("@dribbling", dribbling); }
            if (addPass) { command.Parameters.AddWithValue("@pass", pass); }
            if (addTechnical) { command.Parameters.AddWithValue("@technical", technical); }
            if (addAgility) { command.Parameters.AddWithValue("@agility", agility); }
            if (addSpeed) { command.Parameters.AddWithValue("@speed", speed); }
            if (addCost) { command.Parameters.AddWithValue("@cost", cost); }


            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    return new Midfielder(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6),
                        reader.GetInt32(7), reader.GetInt32(8), reader.GetInt32(9));
                }
            }

            connection.Close();
            return null;
        }
    }
}
