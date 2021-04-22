using CommunalServices.daos;
using CommunalServices.model;
using CommunalServices.resolvers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommunalServices.forms
{
    /// <summary>
    /// Главная форма приложения
    /// </summary>
    public partial class MainForm : Form
    {
        // Текущий пользователь
        private Consumer currentConsumer;
        // Открыто извне как карточка пользоватля
        private bool externalOpen = false;

        public MainForm(Consumer consumer, bool externalOpen = false)
        {
            this.currentConsumer = consumer;
            InitializeComponent();
            // В заголовок формы добавляем имя + фамилию
            this.Text += (consumer.name + " " + consumer.surname);
            this.labelName.Text = consumer.name;
            this.labelSurname.Text = consumer.surname;
            this.labelBalance.Text = "0";
            this.externalOpen = externalOpen;
        }

        // Если открыто не как внешнее окно, то выключаем приложение
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!externalOpen)
            {
                Application.Exit();
            }
        }

        // Когда активна вкладка Карточка Клиента
        private void tabPageConsumerCard_Enter(object sender, EventArgs e)
        {
            float balance = 0;

            // Очищаем таблицу
            dataGridViewConsumerCard.Rows.Clear();

            // Заполняем данными
            List<ConsumerCard> consumerCards = ConsumerCardDAO.getConsumerCardByConsumerId(currentConsumer.id);
            for (int i = 0; i < consumerCards.Count; i++)
            {
                TypeOfService typeOfService = TypeOfServiceDAO.getTypeOfServiceByConsumerCardId(consumerCards[i].id);
                Payments payments = PaymentsDAO.getPaymentsByConsumerCardId(consumerCards[i].id);
                dataGridViewConsumerCard.Rows.Add(typeOfService.name, consumerCards[i].dateOfPay, typeOfService.cost, payments.payed, payments.deadline);
                dataGridViewConsumerCard.Rows[i].Selected = false;
                balance += (payments.payed - typeOfService.cost);
            }
            // Изменяем состояние баланса
            labelBalance.Text = balance.ToString();
        }

        // Когда активна вкладка Ведомость Оплат
        private void tabPageReportPayment_Enter(object sender, EventArgs e)
        {
            // Очищаем таблицу
            dataGridViewReport.Rows.Clear();

            // Заполняем данными
            List<PaymentReport> paymentReports = ReportResolver.getPaymentReport();
            for (int i = 0; i < paymentReports.Count; i++)
            {
                dataGridViewReport.Rows.Add(paymentReports[i].typeOfService, paymentReports[i].consumerId, paymentReports[i].street, paymentReports[i].house,
                    paymentReports[i].flat, paymentReports[i].dateOfPay, paymentReports[i].deadline);
                dataGridViewReport.Rows[i].Selected = false;
            }
        }

        // Когда активна вкладка Объем услуг
        private void tabPageValueOfServices_Enter(object sender, EventArgs e)
        {
            // Очищаем таблицу
            dataGridViewValueOfServices.Rows.Clear();

            // Заполняем данными
            List<ValueOfServices> valueOfServices = ReportResolver.getValueOfServices();
            for (int i = 0; i < valueOfServices.Count; i++)
            {
                dataGridViewValueOfServices.Rows.Add(valueOfServices[i].typeOfService, valueOfServices[i].consumerId, valueOfServices[i].street, valueOfServices[i].house, valueOfServices[i].flat);
                dataGridViewValueOfServices.Rows[i].Selected = false;
            }
        }

        // Когда активна вкладка Ведомость должников
        private void tabPageReportDebtor_Enter(object sender, EventArgs e)
        {
            // Очищаем таблицу
            dataGridViewDebtor.Rows.Clear();

            // Заполняем данными
            List<ReportDebtor> reportDebtors = ReportResolver.getReportDebtor();
            for (int i = 0; i < reportDebtors.Count; i++)
            {
                dataGridViewDebtor.Rows.Add(reportDebtors[i].consumerId, reportDebtors[i].typeOfService, reportDebtors[i].dateOfPay, reportDebtors[i].deadline);
                dataGridViewDebtor.Rows[i].Selected = false;
            }
        }

        // Когда активна вкладка Виды услуг
        private void tabPageTypesOfServices_Enter(object sender, EventArgs e)
        {
            // Очищаем таблицу
            dataGridViewTypesOfServices.Rows.Clear();

            // Заполняем данными
            List<TypeOfService> typeOfServices = TypeOfServiceDAO.getTypesOfServices();
            for (int i = 0; i < typeOfServices.Count; i++)
            {
                dataGridViewTypesOfServices.Rows.Add(typeOfServices[i].name, typeOfServices[i].cost);
                dataGridViewTypesOfServices.Rows[i].Selected = false;
            }
        }

        // Когда активна вкладка Адреса
        private void tabPageAddressRegister_Enter(object sender, EventArgs e)
        {
            // Очищаем таблицу
            dataGridViewAddressRegister.Rows.Clear();

            // Заполняем данными
            List<AddressRegister> addressRegisters = AddressRegisterDAO.getAddressRegisters();
            for (int i = 0; i < addressRegisters.Count; i++)
            {
                dataGridViewAddressRegister.Rows.Add(addressRegisters[i].street, addressRegisters[i].house, addressRegisters[i].flat);
                dataGridViewAddressRegister.Rows[i].Selected = false;
            }
        }

        // Когда активна вкладка Клиенты
        private void tabPageConsumers_Enter(object sender, EventArgs e)
        {
            // Очищаем таблицу
            dataGridViewConsumers.Rows.Clear();

            // Заполняем данными
            List<Consumer> consumers = ConsumerDAO.getConsumersByTemplate(textBoxName.Text.Trim(), textBoxSurname.Text.Trim());
            for (int i = 0; i < consumers.Count; i++)
            {
                AddressRegister addressRegister = AddressRegisterDAO.getAddressRegisterById(consumers[i].addressRegisterId);
                List<PhoneNumber> phoneNumbers = PhoneDAO.getPhoneByConsumerId(consumers[i].id);
                dataGridViewConsumers.Rows.Add(consumers[i].name, consumers[i].surname, addressRegister.street, addressRegister.house, addressRegister.flat,
                    phoneNumbers.Count > 0 ? phoneNumbers[0].value : null);
                dataGridViewConsumers.Rows[i].Selected = false;
            }
        }

        // Когда активна вкладка Учет оплат
        private void tabPagePayTrack_Enter(object sender, EventArgs e)
        {
            // Очищаем таблицу
            dataGridViewPayTrack.Rows.Clear();

            // Заполняем данными
            List<Payments> payments = PaymentsDAO.getPayments();
            for (int i = 0; i < payments.Count; i++)
            {
                ConsumerCard consumerCard = ConsumerCardDAO.getConsumerCardByConsumerCardId(payments[i].consumerCardId);
                Consumer consumer = ConsumerDAO.getConsumerById(consumerCard.consumerId);
                TypeOfService typeOfService = TypeOfServiceDAO.getTypeOfServiceByConsumerCardId(consumerCard.id);
                dataGridViewPayTrack.Rows.Add(consumer.name, consumer.surname, typeOfService.name, consumerCard.dateOfPay, payments[i].deadline);
                dataGridViewPayTrack.Rows[i].Selected = false;
            }
        }

        // Делаем авто переключение на первуб подвкладку (может быть пролаг из-за этого, но все свойства зато отрабатывают)
        private void tabControlMain_Click(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedIndex == 1)
            {
                tabControlAdditionalReport.SelectedIndex = (tabControlAdditionalReport.SelectedIndex + 1) % tabControlAdditionalReport.TabCount;
                tabControlAdditionalReport.SelectedIndex = 0;
            }
            if (tabControlMain.SelectedIndex == 2)
            {
                tabControlAdditionalData.SelectedIndex = (tabControlAdditionalData.SelectedIndex + 1) % tabControlAdditionalData.TabCount;
                tabControlAdditionalData.SelectedIndex = 0;
            }
        }

        // Добавление Вида услуг
        private void buttonAddService_Click(object sender, EventArgs e)
        {
            // Создаем вспомогательную форму
            TypeOfServiceForm typeOfServiceForm = new TypeOfServiceForm();
            DialogResult result = typeOfServiceForm.ShowDialog();

            // Если результат ОК, то перезагрузим таблицу (для обновления данных)
            if (result == DialogResult.OK)
            {
                tabPageTypesOfServices_Enter(sender, e);
            }
        }

        // Обновление Вида услуг
        private void buttonEditService_Click(object sender, EventArgs e)
        {
            // Если выделена одна строчка
            if (dataGridViewTypesOfServices.SelectedRows.Count == 1)
            {
                // Создаем вспомогательную форму
                DataGridViewRow row = dataGridViewTypesOfServices.SelectedRows[0];
                TypeOfServiceForm typeOfServiceForm = new TypeOfServiceForm(TypeOfServiceDAO.getTypeOfServiceByNameAndCost(row.Cells[0].Value.ToString(),
                    float.Parse(row.Cells[1].Value.ToString())));
                DialogResult result = typeOfServiceForm.ShowDialog();

                // Если результат ОК, то перезагрузим таблицу (для обновления данных)
                if (result == DialogResult.OK)
                {
                    tabPageTypesOfServices_Enter(sender, e);
                }
            }
        }

        // Удаление Вида Услуг
        private void buttonDeleteService_Click(object sender, EventArgs e)
        {
            // Если выделена одна строчка
            if (dataGridViewTypesOfServices.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dataGridViewTypesOfServices.SelectedRows[0];

                // перезагрузим таблицу (для обновления данных)
                if (TypeOfServiceDAO.deleteTypeOfService(TypeOfServiceDAO.getTypeOfServiceByNameAndCost(row.Cells[0].Value.ToString(),
                    float.Parse(row.Cells[1].Value.ToString()))))
                {
                    tabPageTypesOfServices_Enter(sender, e);
                }
            }
        }

        // Добавление Адреса
        private void buttonAddAddress_Click(object sender, EventArgs e)
        {
            // Создаем вспомогательную форму
            AddressRegisterForm addressRegisterForm = new AddressRegisterForm();
            DialogResult result = addressRegisterForm.ShowDialog();

            // Если результат ОК, то перезагрузим таблицу (для обновления данных)
            if (result == DialogResult.OK)
            {
                tabPageAddressRegister_Enter(sender, e);
            }
        }

        // Изменение Адреса
        private void buttonEditAddress_Click(object sender, EventArgs e)
        {
            // Если выделена одна строчка
            if (dataGridViewAddressRegister.SelectedRows.Count == 1)
            {
                // Создаем вспомогательную форму
                DataGridViewRow row = dataGridViewAddressRegister.SelectedRows[0];
                AddressRegisterForm addressRegisterForm = new AddressRegisterForm(AddressRegisterDAO.getAddressRegisterFromStreetHouseFlat(row.Cells[0].Value.ToString(),
                    row.Cells[1].Value.ToString(), int.Parse(row.Cells[2].Value.ToString())));
                DialogResult result = addressRegisterForm.ShowDialog();

                // Если результат ОК, то перезагрузим таблицу (для обновления данных)
                if (result == DialogResult.OK)
                {
                    tabPageAddressRegister_Enter(sender, e);
                }
            }
        }

        // Удаление Адреса
        private void buttonDeleteAddress_Click(object sender, EventArgs e)
        {
            // Если выделена одна строчка
            if (dataGridViewAddressRegister.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dataGridViewAddressRegister.SelectedRows[0];

                // перезагрузим таблицу (для обновления данных)
                if (AddressRegisterDAO.deleteAddressRegister(AddressRegisterDAO.getAddressRegisterFromStreetHouseFlat(row.Cells[0].Value.ToString(),
                    row.Cells[1].Value.ToString(), int.Parse(row.Cells[2].Value.ToString()))))
                {
                    tabPageAddressRegister_Enter(sender, e);
                }
            }
        }

        // Добавление клиента
        private void buttonAddConsumer_Click(object sender, EventArgs e)
        {
            // Создаем вспомогательную форму
            RegisterForm registerForm = new RegisterForm(true);
            DialogResult result = registerForm.ShowDialog();

            // Если результат ОК, то перезагрузим таблицу (для обновления данных)
            if (result == DialogResult.OK)
            {
                tabPageConsumers_Enter(sender, e);
            }
        }

        // Изменение клиента
        private void buttonEditConsumer_Click(object sender, EventArgs e)
        {
            // Если выделена одна строчка
            if (dataGridViewConsumers.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dataGridViewConsumers.SelectedRows[0];
                Consumer consumer = ConsumerDAO.getConsumerByNameSurname(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());

                // Создаем вспомогательную форму
                ConsumerEditForm consumerEditForm = new ConsumerEditForm(consumer);
                DialogResult result = consumerEditForm.ShowDialog();

                // Если результат ОК, то перезагрузим таблицу (для обновления данных)
                if (result == DialogResult.OK)
                {
                    tabPageConsumers_Enter(sender, e);
                }
            }
        }

        // Удаление клиента
        private void buttonDeleteConsumer_Click(object sender, EventArgs e)
        {
            // Если выделена одна строчка
            if (dataGridViewConsumers.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dataGridViewConsumers.SelectedRows[0];
                Consumer consumer = ConsumerDAO.getConsumerByNameSurname(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());

                // перезагрузим таблицу (для обновления данных)
                if (ConsumerDAO.deleteConsumer(consumer))
                {
                    tabPageConsumers_Enter(sender, e);
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Настройки приватности для обыкновеного клиета (скрыто все)
            if (this.currentConsumer.typeOfConsumerId == 1)
            {
                tabControlAdditionalReport.Visible = false;
                tabControlAdditionalData.Visible = false;
                tabPagePayTrack.Visible = false;
                dataGridViewPayTrack.Visible = false;
            }
        }

        // Открыть карту клиента выбранного пользователя
        private void buttonOpenCustomerCard_Click(object sender, EventArgs e)
        {
            // Если выделена одна строчка
            if (dataGridViewConsumers.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dataGridViewConsumers.SelectedRows[0];
                Consumer consumer = ConsumerDAO.getConsumerByNameSurname(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());

                // Создаем вспомогательную форму
                MainForm mainForm = new MainForm(consumer, true);
                mainForm.ShowDialog();
            }
        }

        // Для динамического отбора среди пользователей
        private void textBoxSurname_TextChanged(object sender, EventArgs e)
        {
            tabPageConsumers_Enter(sender, e);
        }

        // Для динамического отбора среди пользователей
        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            tabPageConsumers_Enter(sender, e);
        }
    }
}
