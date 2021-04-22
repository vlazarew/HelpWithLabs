using CommunalServices.daos;
using CommunalServices.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommunalServices.forms
{
    public partial class AddressRegisterForm : Form
    {
        AddressRegister addressRegister;

        public AddressRegisterForm(AddressRegister addressRegister = null)
        {
            InitializeComponent();
            this.addressRegister = addressRegister;
            if (this.addressRegister != null)
            {
                textBoxStreet.Text = addressRegister.street;
                textBoxHouse.Text = addressRegister.house;
                textBoxFlat.Text = addressRegister.flat.ToString();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            int flat = 0;
            try
            {
                flat = int.Parse(textBoxFlat.Text);
            }
            catch
            {
                MessageBox.Show("Некорректно указана квартира");
                return;
            }

            if (this.addressRegister == null)
            {
                if (!AddressRegisterDAO.saveAddressRegister(new AddressRegister(textBoxStreet.Text.Trim(), textBoxHouse.Text.Trim(), flat)))
                {
                    MessageBox.Show("Ошибка при сохранении адреса");
                }
            }
            else
            {
                this.addressRegister.flat = flat;
                this.addressRegister.street = textBoxStreet.Text.Trim();
                this.addressRegister.house = textBoxHouse.Text.Trim();
                if (!AddressRegisterDAO.updateAddressRegister(this.addressRegister))
                {
                    MessageBox.Show("Ошибка при изменении адреса");
                }
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
