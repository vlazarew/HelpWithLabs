using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PhoneBook.model;

namespace PhoneBook.daos
{
    /// <summary>
    /// DAO = Data Access Odject
    /// Класс для взаимодействия класса Consumer в коде с ее реализацией в БД
    /// </summary>
    static class PhoneBookDAO
    {

        public static List<PhoneRegister> getAllPhoneBooks()
        {
            List<PhoneRegister> result = new List<PhoneRegister>();

            MySqlConnection connection = MySQLDAO.createConnect();

            string query = "select * from phone_book";
            MySqlCommand command = new MySqlCommand(query, connection);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new PhoneRegister(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                }
            }

            connection.Close();

            return result;
        }

        public static PhoneRegister getPhoneRegisterByFIOAndPhone(string fio, string phone)
        {
            PhoneRegister result = null;

            MySqlConnection connection = MySQLDAO.createConnect();

            string query = "select * from phone_book " +
                "where phone_book.fio = @fio and phone_book.phone_number = @phone_number";
            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@fio", fio);
            command.Parameters.AddWithValue("@phone_number", phone);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result = new PhoneRegister(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                }
            }

            connection.Close();
            return result;
        }

        public static List<PhoneRegister> getPhoneRegistersByTemplate(string fio, string phone)
        {
            List<PhoneRegister> result = new List<PhoneRegister>();

            MySqlConnection connection = MySQLDAO.createConnect();

            string query = "select * from phone_book where phone_book.fio LIKE @fio and phone_book.phone_number LIKE @phone";
            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@fio", fio.Length == 0 ? "%" : "%" + fio + "%");
            command.Parameters.AddWithValue("@phone", phone.Length == 0 ? "%" : "%" + phone + "%");

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new PhoneRegister(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                }
            }

            connection.Close();
            return result;
        }

        public static bool savePhoneRegister(PhoneRegister phoneRegister)
        {
            MySqlConnection connection = MySQLDAO.createConnect();
            MySqlTransaction transaction = connection.BeginTransaction();

            string query = "INSERT INTO phone_book (phone_book.fio, phone_book.phone_number) VALUES (@fio, @phone_number)";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@fio", phoneRegister.FIO);
            command.Parameters.AddWithValue("@phone_number", phoneRegister.phone);

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

        public static bool updatePhoneRegister(PhoneRegister phoneRegister)
        {
            MySqlConnection connection = MySQLDAO.createConnect();
            MySqlTransaction transaction = connection.BeginTransaction();

            string query = "update phone_book set phone_book.fio = @fio, phone_book.phone_number = @phone_number where phone_book.id = @id";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@id", phoneRegister.id);
            command.Parameters.AddWithValue("@fio", phoneRegister.FIO);
            command.Parameters.AddWithValue("@phone_number", phoneRegister.phone);

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

        public static bool deletePhoneRegister(PhoneRegister phoneRegister)
        {
            MySqlConnection connection = MySQLDAO.createConnect();
            MySqlTransaction transaction = connection.BeginTransaction();

            string query = "delete from phone_book where phone_book.fio = @fio and phone_book.phone_number = @phone_number and phone_book.id = @id";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@id", phoneRegister.id);
            command.Parameters.AddWithValue("@fio", phoneRegister.FIO);
            command.Parameters.AddWithValue("@phone_number", phoneRegister.phone);

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
