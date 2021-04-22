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
    class CredentialsResolver
    {
        public static bool createCredentialsAndConsumer(string login, string password, string street, string house, int flat, List<string> numbers, bool isAdmin,
            string name, string surname)
        {
            MySqlConnection connection = MySQLDAO.createConnect();
            MySqlTransaction transaction = connection.BeginTransaction();

            Credentials credentials = new Credentials(login, password);
            if (!CredentialsDAO.saveCredentials(credentials, connection, transaction))
            {
                throw new Exception("Ошибка создания новых учетных данных");
            }
            credentials = CredentialsDAO.getCredentialsByLoginAndPassword(login, password, connection, transaction);

            AddressRegister addressRegister = new AddressRegister(street, house, flat);
            if (!AddressRegisterDAO.saveAddressRegister(addressRegister, connection, transaction))
            {
                throw new Exception("Ошибка создания нового адреса");
            }
            addressRegister = AddressRegisterDAO.getAddressRegisterFromStreetHouseFlat(addressRegister.street, addressRegister.house, addressRegister.flat, connection, transaction);

            TypeOfConsumerDAO.checkTypesOfConsumer(connection, transaction);
            TypeOfConsumer typeOfConsumer = TypeOfConsumerDAO.getTypeOfConsumerById(isAdmin ? 0 : 1, connection, transaction);
            Consumer consumer = new Consumer(name, surname, addressRegister.id, typeOfConsumer.id, credentials.id);
            if (!ConsumerDAO.saveConsumer(consumer, connection, transaction))
            {
                throw new Exception("Ошибка создания нового клиента");
            }
            consumer = ConsumerDAO.getConsumerByCredentialsId(credentials.id, connection, transaction);

            foreach (string number in numbers)
            {
                PhoneNumber phoneNumber = new PhoneNumber(number,consumer.id);
                if (!PhoneDAO.saveNumber(phoneNumber, consumer.id, connection, transaction))
                {
                    throw new Exception("Ошибка создания нового номера телефона");
                }
            }

            try
            {
                transaction.Commit();
                connection.Clone();
            }
            catch
            {
                transaction.Rollback();
                throw new Exception("Ошибки регистрации пользователя");
            }


            return false;
        }
    }
}
