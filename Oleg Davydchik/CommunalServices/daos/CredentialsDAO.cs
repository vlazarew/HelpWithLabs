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
    /// Класс для взаимодействия класса Credentials в коде с ее реализацией в БД
    /// </summary>
    class CredentialsDAO
    {
        /// <summary>
        /// Сохранить учетные данные
        /// </summary>
        /// <param name="credentials">Учетные данные</param>
        /// <param name="externalConnection">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <param name="externalTransaction">Внешняя транзакция, которая будет навешиваться на команду</param>
        /// <returns>true - успех, false - провал</returns>
        public static bool saveCredentials(Credentials credentials, MySqlConnection externalConnection = null, MySqlTransaction externalTransaction = null)
        {
            MySqlConnection connection = externalConnection != null ? externalConnection : MySQLDAO.createConnect();
            MySqlTransaction transaction = externalTransaction != null ? externalTransaction : connection.BeginTransaction();

            string query = "INSERT INTO credentials (credentials.login, credentials.password) VALUES (@login, @password)";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@login", credentials.login);
            command.Parameters.AddWithValue("@password", credentials.password);

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
        /// Получить учетные данные по логину
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="externalConnection">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <param name="externalTransaction">Внешняя транзакция, которая будет навешиваться на команду</param>
        /// <returns>Найденные учетные данные</returns>
        public static Credentials getCredentialsByLogin(string login, MySqlConnection externalConnection = null, MySqlTransaction externalTransaction = null)
        {
            Credentials result = null;
            MySqlConnection connection = externalConnection != null ? externalConnection : MySQLDAO.createConnect();
            MySqlTransaction transaction = externalTransaction != null ? externalTransaction : connection.BeginTransaction();

            string query = "select * from credentials where credentials.login = @login";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@login", login);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result = new Credentials(reader.GetString(1), reader.GetString(2));
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
        /// Получить учетные данные по логину/паролю
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <param name="externalConnection">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <param name="externalTransaction">Внешняя транзакция, которая будет навешиваться на команду</param>
        /// <returns>Найденные учетные данные</returns>
        public static Credentials getCredentialsByLoginAndPassword(string login, string password, MySqlConnection externalConnection = null, MySqlTransaction externalTransaction = null)
        {
            Credentials result = null;
            MySqlConnection connection = externalConnection != null ? externalConnection : MySQLDAO.createConnect();
            MySqlTransaction transaction = externalTransaction != null ? externalTransaction : connection.BeginTransaction();

            string query = "select id, login, password from credentials where credentials.login = @login and credentials.password = @password";
            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@password", password);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result = new Credentials(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
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
