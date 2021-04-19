using CommunalServices.daos;
using CommunalServices.model;
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

        public MainForm(Consumer consumer)
        {
            this.currentConsumer = consumer;
            InitializeComponent();
            this.Text += (consumer.name + " " + consumer.surname);
            this.labelName.Text = consumer.name;
            this.labelSurname.Text = consumer.surname;
            this.labelBalance.Text = "0";
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tabPageConsumerCard_Enter(object sender, EventArgs e)
        {
            dataGridViewConsumerCard.Rows.Clear();
            List<ConsumerCard> consumerCards = ConsumerCardDAO.getConsumerCardByConsumerId(currentConsumer.id);
            for (int i = 0; i < consumerCards.Count; i++)
            {
                TypeOfService typeOfService = TypeOfServiceDAO.getTypeOfServiceByConsumerCardId(consumerCards[i].id);
                dataGridViewConsumerCard.Rows.Add(typeOfService.name, consumerCards[i].dateOfPay);
                dataGridViewConsumerCard.Rows[i].Selected = false;
            }
        }

        private void tabPageReportPayment_Enter(object sender, EventArgs e)
        {
            //MessageBox.Show("ReportPayment");
        }

        private void tabPageValueOfServices_Enter(object sender, EventArgs e)
        {
            //MessageBox.Show("ValueOfServices");
        }

        private void tabPageReportDebtor_Enter(object sender, EventArgs e)
        {
            // MessageBox.Show("ReportDebtor");
        }

        private void tabPageTypesOfServices_Enter(object sender, EventArgs e)
        {
            dataGridViewConsumerCard.Rows.Clear();
            List<TypeOfService> typeOfServices = TypeOfServiceDAO.getTypesOfServices();
            for (int i = 0; i < typeOfServices.Count; i++)
            {
                dataGridViewConsumerCard.Rows.Add(typeOfServices[i].name);
                dataGridViewConsumerCard.Rows[i].Selected = false;
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
            List<Consumer> consumers = ConsumerDAO.getConsumers();
            for (int i = 0; i < consumers.Count; i++)
            {
                AddressRegister addressRegister = AddressRegisterDAO.getAddressRegisterById(consumers[i].addressRegisterId);
                List<PhoneNumber> phoneNumbers = PhoneDAO.getPhoneByConsumerId(consumers[i].id);
                dataGridViewConsumers.Rows.Add(consumers[i].name, consumers[i].surname, addressRegister.street, addressRegister.house, addressRegister.flat, phoneNumbers[0].value);
                dataGridViewConsumers.Rows[i].Selected = false;
            }
        }

        private void tabPagePayTrack_Enter(object sender, EventArgs e)
        {
            //MessageBox.Show("PayTrack");
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
    }
}
