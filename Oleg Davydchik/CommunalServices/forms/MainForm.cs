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
    public partial class MainForm : Form
    {
        private Consumer currentConsumer;
        private bool externalOpen = false;


        public MainForm(Consumer consumer, bool externalOpen = false)
        {
            this.currentConsumer = consumer;
            InitializeComponent();
            this.Text += (consumer.name + " " + consumer.surname);
            this.labelName.Text = consumer.name;
            this.labelSurname.Text = consumer.surname;
            this.labelBalance.Text = "0";
            this.externalOpen = externalOpen;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!externalOpen)
            {
                Application.Exit();
            }
        }

        private void tabPageConsumerCard_Enter(object sender, EventArgs e)
        {
            float balance = 0;
            dataGridViewConsumerCard.Rows.Clear();
            List<ConsumerCard> consumerCards = ConsumerCardDAO.getConsumerCardByConsumerId(currentConsumer.id);
            for (int i = 0; i < consumerCards.Count; i++)
            {
                TypeOfService typeOfService = TypeOfServiceDAO.getTypeOfServiceByConsumerCardId(consumerCards[i].id);
                Payments payments = PaymentsDAO.getPaymentsByConsumerCardId(consumerCards[i].id);
                dataGridViewConsumerCard.Rows.Add(typeOfService.name, consumerCards[i].dateOfPay, typeOfService.cost, payments.payed, payments.deadline);
                dataGridViewConsumerCard.Rows[i].Selected = false;
                balance += (payments.payed - typeOfService.cost);
            }
            labelBalance.Text = balance.ToString();
        }

        private void tabPageReportPayment_Enter(object sender, EventArgs e)
        {
            dataGridViewReport.Rows.Clear();
            List<PaymentReport> paymentReports = ReportResolver.getPaymentReport();
            for (int i = 0; i < paymentReports.Count; i++)
            {
                dataGridViewReport.Rows.Add(paymentReports[i].typeOfService, paymentReports[i].consumerId, paymentReports[i].street, paymentReports[i].house,
                    paymentReports[i].flat, paymentReports[i].dateOfPay, paymentReports[i].deadline);
                dataGridViewReport.Rows[i].Selected = false;
            }
        }

        private void tabPageValueOfServices_Enter(object sender, EventArgs e)
        {
            dataGridViewValueOfServices.Rows.Clear();
            List<ValueOfServices> valueOfServices = ReportResolver.getValueOfServices();
            for (int i = 0; i < valueOfServices.Count; i++)
            {
                dataGridViewValueOfServices.Rows.Add(valueOfServices[i].typeOfService, valueOfServices[i].consumerId, valueOfServices[i].street, valueOfServices[i].house, valueOfServices[i].flat);
                dataGridViewValueOfServices.Rows[i].Selected = false;
            }
        }

        private void tabPageReportDebtor_Enter(object sender, EventArgs e)
        {
            dataGridViewDebtor.Rows.Clear();
            List<ReportDebtor> reportDebtors = ReportResolver.getReportDebtor();
            for (int i = 0; i < reportDebtors.Count; i++)
            {
                dataGridViewDebtor.Rows.Add(reportDebtors[i].consumerId, reportDebtors[i].typeOfService, reportDebtors[i].dateOfPay, reportDebtors[i].deadline);
                dataGridViewDebtor.Rows[i].Selected = false;
            }
        }

        private void tabPageTypesOfServices_Enter(object sender, EventArgs e)
        {
            dataGridViewTypesOfServices.Rows.Clear();
            List<TypeOfService> typeOfServices = TypeOfServiceDAO.getTypesOfServices();
            for (int i = 0; i < typeOfServices.Count; i++)
            {
                dataGridViewTypesOfServices.Rows.Add(typeOfServices[i].name, typeOfServices[i].cost);
                dataGridViewTypesOfServices.Rows[i].Selected = false;
            }
        }

        private void tabPageAddressRegister_Enter(object sender, EventArgs e)
        {
            dataGridViewAddressRegister.Rows.Clear();
            List<AddressRegister> addressRegisters = AddressRegisterDAO.getAddressRegisters();
            for (int i = 0; i < addressRegisters.Count; i++)
            {
                dataGridViewAddressRegister.Rows.Add(addressRegisters[i].street, addressRegisters[i].house, addressRegisters[i].flat);
                dataGridViewAddressRegister.Rows[i].Selected = false;
            }
        }

        private void tabPageConsumers_Enter(object sender, EventArgs e)
        {
            dataGridViewConsumers.Rows.Clear();
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

        private void tabPagePayTrack_Enter(object sender, EventArgs e)
        {
            dataGridViewPayTrack.Rows.Clear();
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

        private void buttonAddService_Click(object sender, EventArgs e)
        {
            TypeOfServiceForm typeOfServiceForm = new TypeOfServiceForm();
            DialogResult result = typeOfServiceForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                tabPageTypesOfServices_Enter(sender, e);
            }
        }

        private void buttonEditService_Click(object sender, EventArgs e)
        {
            if (dataGridViewTypesOfServices.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dataGridViewTypesOfServices.SelectedRows[0];
                TypeOfServiceForm typeOfServiceForm = new TypeOfServiceForm(TypeOfServiceDAO.getTypeOfServiceByNameAndCost(row.Cells[0].Value.ToString(),
                    float.Parse(row.Cells[1].Value.ToString())));
                DialogResult result = typeOfServiceForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tabPageTypesOfServices_Enter(sender, e);
                }
            }
        }

        private void buttonDeleteService_Click(object sender, EventArgs e)
        {
            if (dataGridViewTypesOfServices.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dataGridViewTypesOfServices.SelectedRows[0];
                if (TypeOfServiceDAO.deleteTypeOfService(TypeOfServiceDAO.getTypeOfServiceByNameAndCost(row.Cells[0].Value.ToString(),
                    float.Parse(row.Cells[1].Value.ToString()))))
                {
                    tabPageTypesOfServices_Enter(sender, e);
                }
            }
        }

        private void buttonAddAddress_Click(object sender, EventArgs e)
        {
            AddressRegisterForm addressRegisterForm = new AddressRegisterForm();
            DialogResult result = addressRegisterForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                tabPageAddressRegister_Enter(sender, e);
            }
        }

        private void buttonEditAddress_Click(object sender, EventArgs e)
        {
            if (dataGridViewAddressRegister.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dataGridViewAddressRegister.SelectedRows[0];
                AddressRegisterForm addressRegisterForm = new AddressRegisterForm(AddressRegisterDAO.getAddressRegisterFromStreetHouseFlat(row.Cells[0].Value.ToString(),
                    row.Cells[1].Value.ToString(), int.Parse(row.Cells[2].Value.ToString())));
                DialogResult result = addressRegisterForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tabPageAddressRegister_Enter(sender, e);
                }
            }
        }

        private void buttonDeleteAddress_Click(object sender, EventArgs e)
        {
            if (dataGridViewAddressRegister.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dataGridViewAddressRegister.SelectedRows[0];
                if (AddressRegisterDAO.deleteAddressRegister(AddressRegisterDAO.getAddressRegisterFromStreetHouseFlat(row.Cells[0].Value.ToString(),
                    row.Cells[1].Value.ToString(), int.Parse(row.Cells[2].Value.ToString()))))
                {
                    tabPageAddressRegister_Enter(sender, e);
                }
            }
        }

        private void buttonAddConsumer_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm(true);
            DialogResult result = registerForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                tabPageConsumers_Enter(sender, e);
            }
        }

        private void buttonEditConsumer_Click(object sender, EventArgs e)
        {
            if (dataGridViewConsumers.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dataGridViewConsumers.SelectedRows[0];
                Consumer consumer = ConsumerDAO.getConsumerByNameSurname(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());

                ConsumerEditForm consumerEditForm = new ConsumerEditForm(consumer);
                DialogResult result = consumerEditForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tabPageConsumers_Enter(sender, e);
                }
            }
        }

        private void buttonDeleteConsumer_Click(object sender, EventArgs e)
        {
            if (dataGridViewConsumers.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dataGridViewConsumers.SelectedRows[0];
                Consumer consumer = ConsumerDAO.getConsumerByNameSurname(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());

                if (ConsumerDAO.deleteConsumer(consumer))
                {
                    tabPageConsumers_Enter(sender, e);
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (this.currentConsumer.typeOfConsumerId == 1)
            {
                tabControlAdditionalReport.Visible = false;
                tabControlAdditionalData.Visible = false;
                tabPagePayTrack.Visible = false;
                dataGridViewPayTrack.Visible = false;
            }
        }

        private void buttonOpenCustomerCard_Click(object sender, EventArgs e)
        {
            if (dataGridViewConsumers.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dataGridViewConsumers.SelectedRows[0];
                Consumer consumer = ConsumerDAO.getConsumerByNameSurname(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());

                MainForm mainForm = new MainForm(consumer, true);
                mainForm.ShowDialog();
            }
        }

        private void textBoxSurname_TextChanged(object sender, EventArgs e)
        {
            tabPageConsumers_Enter(sender, e);
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            tabPageConsumers_Enter(sender, e);
        }
    }
}
