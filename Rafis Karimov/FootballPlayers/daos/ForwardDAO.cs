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
    public static class ForwardDAO
    {
        // получить всех нападаюших
        public static List<Forward> getAllForwards()
        {
            List<Forward> result = new List<Forward>();

            MySqlConnection connection = MySQLDAO.createConnect();

            string query = "select * from forward";
            MySqlCommand command = new MySqlCommand(query, connection);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Forward(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6),
                        reader.GetInt32(7), reader.GetInt32(8), reader.GetInt32(9)));
                }
            }

            connection.Close();
            return result;
        }

        // получить всех нападающих по фильтрам
        public static List<Forward> getForwardsByTemplate(string name = null, string lastname = null, string club = null, int attacking = 0, int shooting = 0,
            int technical = 0, int physical = 0, int speed = 0, int cost = -1)
        {
            List<Forward> result = new List<Forward>();

            MySqlConnection connection = MySQLDAO.createConnect();
            bool addAttacking = false;
            bool addShooting = false;
            bool addTechnical = false;
            bool addPhysical = false;
            bool addSpeed = false;
            bool addCost = false;

            string query = "select * from forward where true";
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
            if (attacking != 0)
            {
                query += " and attacking>=@attacking";
                addAttacking = true;
            }
            if (shooting != 0)
            {
                query += " and shooting>=@shooting";
                addShooting = true;
            }
            if (technical != 0)
            {
                query += " and technical>=@technical";
                addTechnical = true;
            }
            if (physical != 0)
            {
                query += " and physical>=@physical";
                addPhysical = true;
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
            if (addAttacking) { command.Parameters.AddWithValue("@attacking", attacking); }
            if (addShooting) { command.Parameters.AddWithValue("@shooting", shooting); }
            if (addTechnical) { command.Parameters.AddWithValue("@technical", technical); }
            if (addPhysical) { command.Parameters.AddWithValue("@physical", physical); }
            if (addSpeed) { command.Parameters.AddWithValue("@speed", speed); }
            if (addCost) { command.Parameters.AddWithValue("@cost", cost); }


            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Forward(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6),
                        reader.GetInt32(7), reader.GetInt32(8), reader.GetInt32(9)));
                }
            }

            connection.Close();
            return result;
        }

        public static Forward getBestForwardByTemplate(string name = null, string lastname = null, string club = null, int attacking = 0, int shooting = 0,
            int technical = 0, int physical = 0, int speed = 0, int cost = -1)
        {
            MySqlConnection connection = MySQLDAO.createConnect();
            bool addAttacking = false;
            bool addShooting = false;
            bool addTechnical = false;
            bool addPhysical = false;
            bool addSpeed = false;
            bool addCost = false;

            string query = "select * from forward where true";
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
            if (attacking != 0)
            {
                query += " and attacking>=@attacking";
                addAttacking = true;
            }
            if (shooting != 0)
            {
                query += " and shooting>=@shooting";
                addShooting = true;
            }
            if (technical != 0)
            {
                query += " and technical>=@technical";
                addTechnical = true;
            }
            if (physical != 0)
            {
                query += " and physical>=@physical";
                addPhysical = true;
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
            query += " order by (attacking + shooting + technical + physical + speed) desc limit 1";


            MySqlCommand command = new MySqlCommand(query, connection);
            if (addAttacking) { command.Parameters.AddWithValue("@attacking", attacking); }
            if (addShooting) { command.Parameters.AddWithValue("@shooting", shooting); }
            if (addTechnical) { command.Parameters.AddWithValue("@technical", technical); }
            if (addPhysical) { command.Parameters.AddWithValue("@physical", physical); }
            if (addSpeed) { command.Parameters.AddWithValue("@speed", speed); }
            if (addCost) { command.Parameters.AddWithValue("@cost", cost); }


            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    return new Forward(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6),
                        reader.GetInt32(7), reader.GetInt32(8), reader.GetInt32(9));
                }
            }

            connection.Close();
            return null;
        }
    }
}
