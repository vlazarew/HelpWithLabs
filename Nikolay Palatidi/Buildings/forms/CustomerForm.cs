using Buildings.dao;
using Buildings.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buildings.forms
{
    public partial class CustomerForm : Form
    {
        Customer customer;

        public CustomerForm(Customer customer = null)
        {
            InitializeComponent();
            this.customer = customer;
            if (this.customer != null)
            {
                textBoxName.Text = customer.name;
                textBoxIdContract.Text = customer.contractid.ToString();
                textBoxPaymentAmount.Text = customer.paymentAmount.ToString();
                textBoxTypeOfPayment.Text = customer.typeOfPayment.ToString();
                textBoxWorkedHours.Text = customer.workingHours.ToString();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            // Пытаемся привести к типу int
            int idContract = 0;
            int payment = 0;
            try
            {
                idContract = int.Parse(textBoxIdContract.Text);
                payment = int.Parse(textBoxPaymentAmount.Text);
            }
            catch
            {
                MessageBox.Show("Некорректно указана номер контракта");
                return;
            }

            // Если у нас добавление, то сохраняем в бд
            if (this.customer == null)
            {
                if (!CustomerDAO.saveCustomer(new Customer(idContract, textBoxName.Text.Trim(), textBoxWorkedHours.Text.Trim(), textBoxTypeOfPayment.Text.Trim(), payment)))
                {
                    MessageBox.Show("Ошибка при сохранении клиента");
                }
            }
            else
            {
                // Иначе меняем объект и обновляем его
                this.customer.name = textBoxName.Text.Trim();
                this.customer.paymentAmount = payment;
                // this.customer.contractid = idContract;
                this.customer.workingHours = textBoxWorkedHours.Text.Trim();
                this.customer.typeOfPayment = textBoxTypeOfPayment.Text.Trim();
                if (!CustomerDAO.updatCustomer(this.customer))
                {
                    MessageBox.Show("Ошибка при изменении клиента");
                }
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
