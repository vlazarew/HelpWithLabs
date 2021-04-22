using CommunalServices.daos;
using CommunalServices.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalServices.resolvers
{
    /// <summary>
    /// Обработчик действий с учетными данными
    /// </summary>
    class CredentialsResolver
    {
        /// <summary>
        /// Создание учетных данных и регистрация пользователя + адрес + номера телефона
        /// </summary>
        /// <param name="login">логин</param>
        /// <param name="password">пароль</param>
        /// <param name="street">улица</param>
        /// <param name="house">дом</param>
        /// <param name="flat">квартира</param>
        /// <param name="numbers">Номера телефонов</param>
        /// <param name="isAdmin">Является ли создаваемый пользователь Администратором</param>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        public static void createCredentialsAndConsumer(string login, string password, string street, string house, int flat, List<string> numbers, bool isAdmin,
            string name, string surname)
        {
            // Создаем соединение с БД + транзакцию
            MySqlConnection connection = MySQLDAO.createConnect();
            MySqlTransaction transaction = connection.BeginTransaction();

            // Делаем объект учетных данных на основе введенных на форме
            Credentials credentials = new Credentials(login, password);
            // Пытаемся сохранить учетные данные
            if (!CredentialsDAO.saveCredentials(credentials, connection, transaction))
            {
                throw new Exception("Ошибка создания новых учетных данных");
            }
            // Получием добавленные учетные данные из БД
            credentials = CredentialsDAO.getCredentialsByLoginAndPassword(login, password, connection, transaction);

            // Делаем объект адреса на основе введенных на форме
            AddressRegister addressRegister = new AddressRegister(street, house, flat);
            // Пытаемся сохранить адрес
            if (!AddressRegisterDAO.saveAddressRegister(addressRegister, connection, transaction))
            {
                throw new Exception("Ошибка создания нового адреса");
            }
            // Получием добавленный адрес из БД
            addressRegister = AddressRegisterDAO.getAddressRegisterFromStreetHouseFlat(addressRegister.street, addressRegister.house, addressRegister.flat, connection, transaction);

            // Провка на заполненость стандратными типами в БД
            TypeOfConsumerDAO.checkTypesOfConsumer(connection, transaction);
            // Получаем тип клиента из БД на основе выбранного
            TypeOfConsumer typeOfConsumer = TypeOfConsumerDAO.getTypeOfConsumerById(isAdmin ? 0 : 1, connection, transaction);

            // Делаем объект клиента на основе введенных на форме 
            Consumer consumer = new Consumer(name, surname, addressRegister.id, typeOfConsumer.id, credentials.id);
            // Пытаемся сохранить клиента
            if (!ConsumerDAO.saveConsumer(consumer, connection, transaction))
            {
                throw new Exception("Ошибка создания нового клиента");
            }
            // Получием добавленного клиента из БД
            consumer = ConsumerDAO.getConsumerByCredentialsId(credentials.id, connection, transaction);

            foreach (string number in numbers)
            {
                // Делаем объект телефонного номера на основе введенных на форме 
                PhoneNumber phoneNumber = new PhoneNumber(number, consumer.id);
                // Пытаемся сохранить телефонный номер
                if (!PhoneDAO.saveNumber(phoneNumber, consumer.id, connection, transaction))
                {
                    throw new Exception("Ошибка создания нового номера телефона");
                }
            }

            try
            {
                // Если все успешно, фиксируем изменение в БД и закрываем соединение с базой
                transaction.Commit();
                connection.Clone();
            }
            catch
            {
                // Иначе откатываем изменения
                transaction.Rollback();
                throw new Exception("Ошибки регистрации пользователя");
            }

        }
    }
}
