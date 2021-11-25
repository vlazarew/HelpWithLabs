using CommunalServices.daos;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalServices.resolvers
{
    /// <summary>
    /// Структура для отчета по "Ведомость оплат"
    /// </summary>
    struct PaymentReport
    {
        // вид услуги
        public string typeOfService { get; set; }
        // id плательщика
        public int consumerId { get; set; }
        // улица
        public string street { get; set; }
        // дом
        public string house { get; set; }
        // квартира
        public int flat { get; set; }
        // дата оплаты
        public DateTime dateOfPay { get; set; }
        // крайний срок
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

    /// <summary>
    /// Структура для отчета по "Объемы услуг"
    /// </summary>
    struct ValueOfServices
    {
        // вид сервиса
        public string typeOfService { get; set; }
        // id плательщика
        public int consumerId { get; set; }
        // улица
        public string street { get; set; }
        // дом
        public string house { get; set; }
        // квартира
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

    /// <summary>
    /// Структура для отчета по "Ведомость должников"
    /// </summary>
    struct ReportDebtor
    {
        // вид услуги
        public string typeOfService { get; set; }
        // id плательщика
        public int consumerId { get; set; }
        // дата оплаты
        public DateTime dateOfPay { get; set; }
        // крайний срок
        public DateTime deadline { get; set; }

        public ReportDebtor(string typeOfService, int consumerId, DateTime dateOfPay, DateTime deadline)
        {
            this.typeOfService = typeOfService;
            this.consumerId = consumerId;
            this.dateOfPay = dateOfPay;
            this.deadline = deadline;
        }
    }

    /// <summary>
    /// Класс для обработки всех отчетов
    /// </summary>
    class ReportResolver
    {
        /// <summary>
        /// Получить отчет "Ведомость оплат"
        /// </summary>
        /// <param name="externalConnection">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <param name="externalTransaction">Внешняя транзакция, которая будет навешиваться на команду</param>
        /// <returns>Отчет "Ведомость оплат"</returns>
        public static List<PaymentReport> getPaymentReport(MongoClient externalClient = null)
        {
            List<PaymentReport> result = new List<PaymentReport>();

            // В случае если нет внешнего соединения, сделаем новое локальное
            MongoClient client = externalClient != null ? externalClient : MongoDAO.createConnect();

            using (var session = client.StartSession())
            {
                try
                {
                    var payments = PaymentsDAO.getCollection(client);
                    var consumerCards = ConsumerCardDAO.getCollection(client);
                    var typeOfServices = TypeOfServiceDAO.getCollection(client);
                    var consumers = ConsumerDAO.getCollection(client);
                    var adressRegisters = AddressRegisterDAO.getCollection(client);
                    var results = payments.AsQueryable()
                        .Join(consumerCards.AsQueryable(), p => p.consumerCardId, c => c.id, (x, y) => new { payment = x, consumerCard = y })
                        .Join(typeOfServices.AsQueryable(), temp => temp.consumerCard.id, t => t.id, (x, y) => new { temp = x, typeOfService = y })
                        .Join(consumers.AsQueryable(), temp => temp.temp.consumerCard.consumerId, c => c.id, (x, y) => new { temp = x, consumer = y })
                        .Join(adressRegisters.AsQueryable(), temp => temp.consumer.addressRegisterId, a => a.id, (x, y) => new { temp = x, adressRegister = y })
                        .Select((x, y) => new PaymentReport(x.temp.temp.typeOfService.name,
                                                            x.temp.temp.temp.consumerCard.consumerId,
                                                            x.adressRegister.street,
                                                            x.adressRegister.house,
                                                            x.adressRegister.flat,
                                                            x.temp.temp.temp.payment.deadline,
                                                            x.temp.temp.temp.consumerCard.dateOfPay)).ToList();
                    return results;
                }
                catch
                {
                    return null;
                }
            }
        }


        /// <summary>
        /// Получить отчет "Объемы услуг"
        /// </summary>
        /// <param name="externalConnection">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <param name="externalTransaction">Внешняя транзакция, которая будет навешиваться на команду</param>
        /// <returns>Отчет "Объемы услуг"</returns>
        public static List<ValueOfServices> getValueOfServices(MongoClient externalClient = null)
        {
            List<ValueOfServices> result = new List<ValueOfServices>();

            // В случае если нет внешнего соединения, сделаем новое локальное
            MongoClient client = externalClient != null ? externalClient : MongoDAO.createConnect();

            using (var session = client.StartSession())
            {
                try
                {
                    var payments = PaymentsDAO.getCollection(client);
                    var consumerCards = ConsumerCardDAO.getCollection(client);
                    var typeOfServices = TypeOfServiceDAO.getCollection(client);
                    var consumers = ConsumerDAO.getCollection(client);
                    var adressRegisters = AddressRegisterDAO.getCollection(client);
                    var results = consumerCards.AsQueryable()
                        .Join(typeOfServices.AsQueryable(), c => c.typeOfServiceId, t => t.id, (x, y) => new { consumerCard = x, typeOfService = y })
                        .Join(consumers.AsQueryable(), temp => temp.consumerCard.id, c => c.id, (x, y) => new { temp = x, consumer = y })
                        .Join(adressRegisters.AsQueryable(), temp => temp.consumer.addressRegisterId, a => a.id, (x, y) => new { temp = x, adressRegister = y })
                        .Select((x, y) => new ValueOfServices(x.temp.temp.typeOfService.name,
                                                            x.temp.consumer.id,
                                                            x.adressRegister.street,
                                                            x.adressRegister.house,
                                                            x.adressRegister.flat)).ToList();
                    return results;
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Получить отчет "Ведомость должников"
        /// </summary>
        /// <param name="externalConnection">Внешнее соединение с БД (необходимо для одной большой транзакции)</param>
        /// <param name="externalTransaction">Внешняя транзакция, которая будет навешиваться на команду</param>
        /// <returns>Отчет "Ведомость должников"</returns>
        public static List<ReportDebtor> getReportDebtor(MongoClient externalClient = null)
        {
            List<ReportDebtor> result = new List<ReportDebtor>();

            // В случае если нет внешнего соединения, сделаем новое локальное
            MongoClient client = externalClient != null ? externalClient : MongoDAO.createConnect();

            using (var session = client.StartSession())
            {
                try
                {
                    var payments = PaymentsDAO.getCollection(client);
                    var consumerCards = ConsumerCardDAO.getCollection(client);
                    var typeOfServices = TypeOfServiceDAO.getCollection(client);
                    var consumers = ConsumerDAO.getCollection(client);
                    var results = consumerCards.AsQueryable()
                        .Join(typeOfServices.AsQueryable(), c => c.typeOfServiceId, t => t.id, (x, y) => new { consumerCard = x, typeOfService = y })
                        .Join(consumers.AsQueryable(), temp => temp.consumerCard.id, c => c.id, (x, y) => new { temp = x, consumer = y })
                        .Join(payments.AsQueryable(), temp => temp.temp.consumerCard.id, p => p.consumerCardId, (x, y) => new { temp = x, payment = y })
                        .Select((x, y) => new ReportDebtor(x.temp.temp.typeOfService.name,
                                                            x.temp.consumer.id,
                                                            x.temp.temp.consumerCard.dateOfPay,
                                                            x.payment.deadline)).ToList().FindAll(val => val.dateOfPay < val.deadline);
                    return results;
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
