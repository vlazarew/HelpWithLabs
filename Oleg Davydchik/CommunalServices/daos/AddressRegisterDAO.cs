using CommunalServices.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalServices.daos
{
    /// <summary>
    /// DAO = Data Access Odject
    /// Класс для взаимодействия класса AddressRegiste в коде с ее реализацией в БД
    /// </summary>
    class AddressRegisterDAO
    {
        /// <summary>
        /// Сохранение адреса в БД
        /// </summary>
        /// <param name="address">Объект класса Адрес</param>
        /// <param name="externalConnection">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <param name="externalTransaction">Внешняя транзакция, которая будет навешиваться на команду</param>
        /// <returns>True - если сохранение успешно, false - если пошли ошибки</returns>
        public static bool saveAddressRegister(AddressRegister address, MySqlConnection externalConnection = null, MySqlTransaction externalTransaction = null)
        {
            // В случае если нет внешнего соединения, сделаем новое локальное
            MySqlConnection connection = externalConnection != null ? externalConnection : MySQLDAO.createConnect();
            // В случае если нет внешней транкзакции, сделаем новую локальную
            MySqlTransaction transaction = externalTransaction != null ? externalTransaction : connection.BeginTransaction();

            // Текст запроса
            string query = "INSERT INTO address_register (address_register.street, address_register.house, address_register.flat) VALUES (@street, @house, @flat)";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            // Добавление параметров в запрос
            command.Parameters.AddWithValue("@street", address.street);
            command.Parameters.AddWithValue("@house", address.house);
            command.Parameters.AddWithValue("@flat", address.flat);

            try
            {
                // Выполнение команды
                command.ExecuteNonQuery();
                if (externalTransaction == null)
                {
                    // Фиксируем изменения
                    transaction.Commit();
                }

                // Если локальное соединение, то надо потушить его
                if (externalConnection == null)
                {
                    connection.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Обновление адреса
        /// </summary>
        /// <param name="addressRegister">Объект, который будем обновлять</param>
        /// <param name="externalConnection">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <param name="externalTransaction">Внешняя транзакция, которая будет навешиваться на команду</param>
        /// <returns>True - если обновление успешно, false - если пошли ошибки</returns>
        public static bool updateAddressRegister(AddressRegister addressRegister, MySqlConnection externalConnection = null, MySqlTransaction externalTransaction = null)
        {
            MySqlConnection connection = externalConnection != null ? externalConnection : MySQLDAO.createConnect();
            MySqlTransaction transaction = externalTransaction != null ? externalTransaction : connection.BeginTransaction();

            string query = "update address_register set address_register.street = @street, address_register.house = @house, " +
                "address_register.flat = @flat where address_register.id = @id";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@id", addressRegister.id);
            command.Parameters.AddWithValue("@street", addressRegister.street);
            command.Parameters.AddWithValue("@house", addressRegister.house);
            command.Parameters.AddWithValue("@flat", addressRegister.flat);

            try
            {
                command.ExecuteNonQuery();
                if (externalTransaction == null)
                {
                    transaction.Commit();
                }

                if (externalConnection == null)
                {
                    connection.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Удаление записи AdressRegister
        /// </summary>
        /// <param name="addressRegister">Удаляемый из БД объект</param>
        /// <param name="externalConnection">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <param name="externalTransaction">Внешняя транзакция, которая будет навешиваться на команду</param>
        /// <returns>True - если удаление успешно, false - если пошли ошибки</returns>
        public static bool deleteAddressRegister(AddressRegister addressRegister, MySqlConnection externalConnection = null, MySqlTransaction externalTransaction = null)
        {
            MySqlConnection connection = externalConnection != null ? externalConnection : MySQLDAO.createConnect();
            MySqlTransaction transaction = externalTransaction != null ? externalTransaction : connection.BeginTransaction();

            string query = "delete from address_register where address_register.street = @street and address_register.house = @house and " +
                "address_register.flat = @flat and address_register.id = @id";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@id", addressRegister.id);
            command.Parameters.AddWithValue("@street", addressRegister.street);
            command.Parameters.AddWithValue("@house", addressRegister.house);
            command.Parameters.AddWithValue("@flat", addressRegister.flat);

            try
            {
                command.ExecuteNonQuery();
                if (externalTransaction == null)
                {
                    transaction.Commit();
                }

                if (externalConnection == null)
                {
                    connection.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Получить объект Адрес по параметрам Улица + Дом + Квартира
        /// </summary>
        /// <param name="street">Значение параметра улица</param>
        /// <param name="house">Значение параметра дом</param>
        /// <param name="flat">Значение параметра квартира</param>
        /// <param name="externalConnection">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <param name="externalTransaction">Внешняя транзакция, которая будет навешиваться на команду</param>
        /// <returns>Найденный объект в БД или null</returns>
        public static AddressRegister getAddressRegisterFromStreetHouseFlat(string street, string house, int flat, MySqlConnection externalConnection = null,
            MySqlTransaction externalTransaction = null)
        {
            AddressRegister result = null;

            MySqlConnection connection = externalConnection != null ? externalConnection : MySQLDAO.createConnect();
            MySqlTransaction transaction = externalTransaction != null ? externalTransaction : connection.BeginTransaction();

            string query = "select * from address_register where address_register.street = @street and address_register.house = @house and " +
                "address_register.flat = @flat";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@street", street);
            command.Parameters.AddWithValue("@house", house);
            command.Parameters.AddWithValue("@flat", flat);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result = new AddressRegister(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
                }
            }

            if (externalTransaction == null)
            {
                transaction.Commit();
            }

            if (externalConnection == null)
            {
                connection.Close();
            }

            return result;
        }

        /// <summary>
        /// Получить объект Адрес по его id
        /// </summary>
        /// <param name="id">Искомый id</param>
        /// <param name="externalConnection">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <param name="externalTransaction">Внешняя транзакция, которая будет навешиваться на команду</param>
        /// <returns>Найденный объект в БД или null</returns>
        public static AddressRegister getAddressRegisterById(int id, MySqlConnection externalConnection = null,
            MySqlTransaction externalTransaction = null)
        {
            AddressRegister result = null;

            MySqlConnection connection = externalConnection != null ? externalConnection : MySQLDAO.createConnect();
            MySqlTransaction transaction = externalTransaction != null ? externalTransaction : connection.BeginTransaction();

            string query = "select * from address_register where address_register.id = @id ";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@id", id);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result = new AddressRegister(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
                }
            }

            if (externalTransaction == null)
            {
                transaction.Commit();
            }

            if (externalConnection == null)
            {
                connection.Close();
            }

            return result;
        }

        /// <summary>
        /// Получить все Адреса
        /// </summary>
        /// <param name="externalConnection">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <param name="externalTransaction">Внешняя транзакция, которая будет навешиваться на команду</param>
        /// <returns>Найденные объекты в БД</returns>
        public static List<AddressRegister> getAddressRegisters(MySqlConnection externalConnection = null, MySqlTransaction externalTransaction = null)
        {
            List<AddressRegister> result = new List<AddressRegister>();

            MySqlConnection connection = externalConnection != null ? externalConnection : MySQLDAO.createConnect();
            MySqlTransaction transaction = externalTransaction != null ? externalTransaction : connection.BeginTransaction();

            string query = "select * from address_register";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new AddressRegister(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3)));
                }
            }

            if (externalTransaction == null)
            {
                transaction.Commit();
            }

            if (externalConnection == null)
            {
                connection.Close();
            }

            return result;
        }
    }
}
