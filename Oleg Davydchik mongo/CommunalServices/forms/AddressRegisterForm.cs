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
    /// <summary>
    /// Форма для добавления/изменения адреса
    /// </summary>
    public partial class AddressRegisterForm : Form
    {
        AddressRegister addressRegister;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        /// <param name="addressRegister">адрес для изменения</param>
        public AddressRegisterForm(AddressRegister addressRegister = null)
        {
            InitializeComponent();
            this.addressRegister = addressRegister;
            // Заполняем форму, если мы изменяем адрес
            if (this.addressRegister != null)
            {
                textBoxStreet.Text = addressRegister.street;
                textBoxHouse.Text = addressRegister.house;
                textBoxFlat.Text = addressRegister.flat.ToString();
            }
        }

        // Нажимаем отмену и закрываем форму
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Нажимаем ОК
        private void buttonOK_Click(object sender, EventArgs e)
        {
            // Пытаемся получить значение квартиры
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

            // Если сохранение, то сохраняем
            if (this.addressRegister == null)
            {
                if (!AddressRegisterDAO.saveAddressRegister(new AddressRegister(textBoxStreet.Text.Trim(), textBoxHouse.Text.Trim(), flat)))
                {
                    MessageBox.Show("Ошибка при сохранении адреса");
                }
            }
            else
            {
                // Иначе изменяем полученный объект и обновляем его в БД
                this.addressRegister.flat = flat;
                this.addressRegister.street = textBoxStreet.Text.Trim();
                this.addressRegister.house = textBoxHouse.Text.Trim();
                if (!AddressRegisterDAO.updateAddressRegister(this.addressRegister))
                {
                    MessageBox.Show("Ошибка при изменении адреса");
                }
            }

            // Закрываем форму
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
