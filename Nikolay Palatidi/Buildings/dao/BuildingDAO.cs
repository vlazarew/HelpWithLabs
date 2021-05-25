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
    class BuildingDAO
    {
        public static List<Building> getAllBuildings()
        {
            List<Building> result = new List<Building>();

            MySqlConnection connection = MySQLDAO.createConnect();

            string query = "select * from building";
            MySqlCommand command = new MySqlCommand(query, connection);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Building(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5),
                        reader.GetInt32(6), reader.GetString(7)));
                }
            }

            connection.Close();

            return result;
        }

        public static Building getBuildingByContactIdAndName(int contractId, string name)
        {
            MySqlConnection connection = MySQLDAO.createConnect();

            string query = "select * from building where building.customer_contract_id = @customer_contract_id and building.name = @name";
            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@customer_contract_id", contractId);
            command.Parameters.AddWithValue("@name", name);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    return new Building(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5),
                        reader.GetInt32(6), reader.GetString(7));
                }
            }

            connection.Close();
            return null;

        }


        public static bool deleteBuilding(Building building)
        {
            MySqlConnection connection = MySQLDAO.createConnect();
            MySqlTransaction transaction = connection.BeginTransaction();

            string query = "delete from building where building.id = @id";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@id", building.id);

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

        public static bool saveBuilding(Building building)
        {
            MySqlConnection connection = MySQLDAO.createConnect();
            MySqlTransaction transaction = connection.BeginTransaction();

            string query = "insert into buildings.building (building.name, building.type, building.year, customer_contract_id, location, building.condition, team) values" +
                "  (@name, @type, @year, @customer_contract_id, @location, @condition, @team)";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@name", building.name);
            command.Parameters.AddWithValue("@type", building.type);
            command.Parameters.AddWithValue("@year", building.year);
            command.Parameters.AddWithValue("@customer_contract_id", building.contractId);
            command.Parameters.AddWithValue("@location", building.location);
            command.Parameters.AddWithValue("@condition", building.condition);
            command.Parameters.AddWithValue("@team", building.team);

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


        public static bool updatBuilding(Building building)
        {
            MySqlConnection connection = MySQLDAO.createConnect();
            MySqlTransaction transaction = connection.BeginTransaction();

            string query = "update building set building.name = @name, building.type = @type, building.year = @year, customer_contract_id = @customer_contract_id, location = @location," +
                " building.condition = @condition, team = @team where building.id = @id";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@id", building.id);
            command.Parameters.AddWithValue("@name", building.name);
            command.Parameters.AddWithValue("@type", building.type);
            command.Parameters.AddWithValue("@year", building.year);
            command.Parameters.AddWithValue("@customer_contract_id", building.contractId);
            command.Parameters.AddWithValue("@location", building.location);
            command.Parameters.AddWithValue("@condition", building.condition);
            command.Parameters.AddWithValue("@team", building.team);

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

    }
}
