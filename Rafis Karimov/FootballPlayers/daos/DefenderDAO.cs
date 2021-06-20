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
    public static class DefenderDAO
    {
        /// <summary>
        /// Получить всех защитников из БД
        /// </summary>
        /// <returns></returns>
        public static List<Defender> getAllDefenders()
        {
            List<Defender> result = new List<Defender>();

            // получаем соединение
            MySqlConnection connection = MySQLDAO.createConnect();

            // генерация запроса
            string query = "select * from Defender";
            // генерация команды
            MySqlCommand command = new MySqlCommand(query, connection);

            // обработка команды
            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Defender(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6),
                        reader.GetInt32(7), reader.GetInt32(8), reader.GetInt32(9)));
                }
            }

            connection.Close();
            return result;
        }

        // Получить всех защитников по фильтрам
        public static List<Defender> getDefendersByTemplate(string name = null, string lastname = null, string club = null, int heading = 0, int opeka = 0,
            int otbor = 0, int strenght = 0, int speed = 0, int cost = -1)
        {
            List<Defender> result = new List<Defender>();

            // получаем соединение
            MySqlConnection connection = MySQLDAO.createConnect();
            bool addHeading = false;
            bool addOpeka = false;
            bool addOtbor = false;
            bool addStrenght = false;
            bool addSpeed = false;
            bool addCost = false;

            // генерация запроса
            string query = "select * from Defender where true";
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
            if (heading != 0)
            {
                query += " and heading>=@heading";
                addHeading = true;
            }
            if (opeka != 0)
            {
                query += " and opeka>=@opeka";
                addOpeka = true;
            }
            if (otbor != 0)
            {
                query += " and otbor>=@otbor";
                addOtbor = true;
            }
            if (strenght != 0)
            {
                query += " and strenght>=@strenght";
                addStrenght = true;
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


            // генерация команды
            MySqlCommand command = new MySqlCommand(query, connection);
            if (addHeading) { command.Parameters.AddWithValue("@heading", heading); }
            if (addOpeka) { command.Parameters.AddWithValue("@opeka", opeka); }
            if (addOtbor) { command.Parameters.AddWithValue("@otbor", otbor); }
            if (addStrenght) { command.Parameters.AddWithValue("@strenght", strenght); }
            if (addSpeed) { command.Parameters.AddWithValue("@speed", speed); }
            if (addCost) { command.Parameters.AddWithValue("@cost", cost); }

            // обработка команды
            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Defender(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6),
                        reader.GetInt32(7), reader.GetInt32(8), reader.GetInt32(9)));
                }
            }

            connection.Close();
            return result;
        }

        public static Defender getBestDefenderByTemplate(string name = null, string lastname = null, string club = null, int heading = 0, int opeka = 0,
            int otbor = 0, int strenght = 0, int speed = 0, int cost = -1)
        {
            // получаем соединение
            MySqlConnection connection = MySQLDAO.createConnect();
            bool addHeading = false;
            bool addOpeka = false;
            bool addOtbor = false;
            bool addStrenght = false;
            bool addSpeed = false;
            bool addCost = false;

            // генерация запроса
            string query = "select * from Defender where true";
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
            if (heading != 0)
            {
                query += " and heading>=@heading";
                addHeading = true;
            }
            if (opeka != 0)
            {
                query += " and opeka>=@opeka";
                addOpeka = true;
            }
            if (otbor != 0)
            {
                query += " and otbor>=@otbor";
                addOtbor = true;
            }
            if (strenght != 0)
            {
                query += " and strenght>=@strenght";
                addStrenght = true;
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
            query += " order by (heading + opeka + otbor + strenght + speed) desc limit 1";


            // генерация команды
            MySqlCommand command = new MySqlCommand(query, connection);
            if (addHeading) { command.Parameters.AddWithValue("@heading", heading); }
            if (addOpeka) { command.Parameters.AddWithValue("@opeka", opeka); }
            if (addOtbor) { command.Parameters.AddWithValue("@otbor", otbor); }
            if (addStrenght) { command.Parameters.AddWithValue("@strenght", strenght); }
            if (addSpeed) { command.Parameters.AddWithValue("@speed", speed); }
            if (addCost) { command.Parameters.AddWithValue("@cost", cost); }

            // обработка команды
            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    return new Defender(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6),
                        reader.GetInt32(7), reader.GetInt32(8), reader.GetInt32(9));
                }
            }

            connection.Close();
            return null;
        }
    }
}
