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
    class CustomerDAO
    {
        public static List<Customer> getAllCustomers()
        {
            List<Customer> result = new List<Customer>();

            MySqlConnection connection = MySQLDAO.createConnect();

            string query = "select * from customer";
            MySqlCommand command = new MySqlCommand(query, connection);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Customer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4)));
                }
            }

            connection.Close();

            return result;
        }

        public static Customer getCustomerByContactId(int contractId)
        {
            MySqlConnection connection = MySQLDAO.createConnect();

            string query = "select * from customer where customer.contract_id = @contract_id";
            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@contract_id", contractId);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    return new Customer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4));
                }
            }

            connection.Close();
            return null;

        }


        public static bool deleteCustomer(Customer customer)
        {
            MySqlConnection connection = MySQLDAO.createConnect();
            MySqlTransaction transaction = connection.BeginTransaction();

            string query = "delete from customer where customer.contract_id = @contract_id";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@contract_id", customer.contractid);

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

        public static bool saveCustomer(Customer customer)
        {
            MySqlConnection connection = MySQLDAO.createConnect();
            MySqlTransaction transaction = connection.BeginTransaction();

            string query = "insert into buildings.customer (contract_id, name, working_hours, type_of_payment, payment_amount) values (@contract_id, @namе, @working_hours, @type_of_payment, @payment_amount)";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@contract_id", customer.contractid);
            command.Parameters.AddWithValue("@namе", customer.name);
            command.Parameters.AddWithValue("@working_hours", customer.workingHours);
            command.Parameters.AddWithValue("@type_of_payment", customer.typeOfPayment);
            command.Parameters.AddWithValue("@payment_amount", customer.paymentAmount);

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


        public static bool updatCustomer(Customer customer)
        {
            MySqlConnection connection = MySQLDAO.createConnect();
            MySqlTransaction transaction = connection.BeginTransaction();

            string query = "update customer set customer.contract_id = @contract_id, customer.name = @name, customer.working_hours = @working_hours,  customer.type_of_payment = @type_of_payment, customer.payment_amount = @payment_amount where customer.contract_id = @contract_id";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@contract_id", customer.contractid);
            command.Parameters.AddWithValue("@name", customer.name);
            command.Parameters.AddWithValue("@working_hours", customer.workingHours);
            command.Parameters.AddWithValue("@type_of_payment", customer.typeOfPayment);
            command.Parameters.AddWithValue("@payment_amount", customer.paymentAmount);

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
