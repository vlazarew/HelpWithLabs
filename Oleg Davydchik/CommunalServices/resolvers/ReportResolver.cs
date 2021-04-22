using CommunalServices.daos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalServices.resolvers
{
    struct PaymentReport
    {
        public string typeOfService { get; set; }
        public int consumerId { get; set; }
        public string street { get; set; }
        public string house { get; set; }
        public int flat { get; set; }
        public DateTime dateOfPay { get; set; }
        public DateTime deadline { get; set; }

        public PaymentReport(string typeOfService, int consumerId, string street, string house, int flat, DateTime dateOfPay, DateTime deadline)
        {
            this.typeOfService = typeOfService;
            this.consumerId = consumerId;
            this.street = street;
            this.house = house;
            this.flat = flat;
            this.dateOfPay = dateOfPay;
            this.deadline = deadline;
        }
    }

    struct ValueOfServices
    {
        public string typeOfService { get; set; }
        public int consumerId { get; set; }
        public string street { get; set; }
        public string house { get; set; }
        public int flat { get; set; }

        public ValueOfServices(string typeOfService, int consumerId, string street, string house, int flat)
        {
            this.typeOfService = typeOfService;
            this.consumerId = consumerId;
            this.street = street;
            this.house = house;
            this.flat = flat;
        }
    }

    struct ReportDebtor
    {
        public string typeOfService { get; set; }
        public int consumerId { get; set; }
        public DateTime dateOfPay { get; set; }
        public DateTime deadline { get; set; }

        public ReportDebtor(string typeOfService, int consumerId, DateTime dateOfPay, DateTime deadline)
        {
            this.typeOfService = typeOfService;
            this.consumerId = consumerId;
            this.dateOfPay = dateOfPay;
            this.deadline = deadline;
        }
    }

    class ReportResolver
    {
        public static List<PaymentReport> getPaymentReport(MySqlConnection externalConnection = null, MySqlTransaction externalTransaction = null)
        {
            List<PaymentReport> result = new List<PaymentReport>();

            MySqlConnection connection = externalConnection != null ? externalConnection : MySQLDAO.createConnect();
            MySqlTransaction transaction = externalTransaction != null ? externalTransaction : connection.BeginTransaction();

            string query = "select type_of_service.name, consumer_card.consumer_id, address_register.street, address_register.house, address_register.flat," +
                " payments.deadline, consumer_card.date_of_pay " +
                "from payments " +
                "join consumer_card on consumer_card.id = payments.consumer_card_id " +
                "join type_of_service on type_of_service.id = consumer_card.type_of_service_id " +
                "join consumer on consumer.id = consumer_card.consumer_id " +
                "join address_register on address_register.id = consumer.address_register_id";

            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new PaymentReport(reader.GetString(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetDateTime(5),
                        reader.GetDateTime(6)));
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


        public static List<ValueOfServices> getValueOfServices(MySqlConnection externalConnection = null, MySqlTransaction externalTransaction = null)
        {
            List<ValueOfServices> result = new List<ValueOfServices>();

            MySqlConnection connection = externalConnection != null ? externalConnection : MySQLDAO.createConnect();
            MySqlTransaction transaction = externalTransaction != null ? externalTransaction : connection.BeginTransaction();

            string query = "select distinct type_of_service.name, consumer.id,  address_register.street, address_register.house, address_register.flat " +
                        "from communal_services.consumer_card " +
                        "join communal_services.type_of_service on type_of_service.id = consumer_card.type_of_service_id " +
                        "join communal_services.consumer on consumer.id = consumer_card.consumer_id " +
                        "join communal_services.address_register on address_register.id = consumer.address_register_id " +
                        "order by type_of_service.name";

            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new ValueOfServices(reader.GetString(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4)));
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

        public static List<ReportDebtor> getReportDebtor(MySqlConnection externalConnection = null, MySqlTransaction externalTransaction = null)
        {
            List<ReportDebtor> result = new List<ReportDebtor>();

            MySqlConnection connection = externalConnection != null ? externalConnection : MySQLDAO.createConnect();
            MySqlTransaction transaction = externalTransaction != null ? externalTransaction : connection.BeginTransaction();

            string query = "select distinct type_of_service.name, consumer.id, consumer_card.date_of_pay, payments.deadline " +
                        "from communal_services.consumer_card " +
                        "join communal_services.type_of_service on type_of_service.id = consumer_card.type_of_service_id " +
                        "join communal_services.consumer on consumer.id = consumer_card.consumer_id " +
                        "join communal_services.payments on payments.consumer_card_id = consumer_card.id " +
                        "where consumer_card.date_of_pay < payments.deadline " +
                        "order by type_of_service.name";

            MySqlCommand command = new MySqlCommand(query, connection, transaction);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new ReportDebtor(reader.GetString(0), reader.GetInt32(1), reader.GetDateTime(2), reader.GetDateTime(3)));
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
