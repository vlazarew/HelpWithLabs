using PhoneBook.daos;
using PhoneBook.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneBook.forms
{
    public partial class PhoneRecordForm : Form
    {
        PhoneRegister phoneRegister;

        public PhoneRecordForm(PhoneRegister phoneRegister = null)
        {
            InitializeComponent();

            this.phoneRegister = phoneRegister;

            // Отрисовка данных при изменении объекта
            if (this.phoneRegister != null)
            {
                textBoxFIO.Text = phoneRegister.FIO;
                textBoxPhone.Text = phoneRegister.phone;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (textBoxFIO.Text.Length <= 0)
            {
                MessageBox.Show("Заполните ФИО");
                return;
            }

            if (textBoxPhone.Text.Length != 11)
            {
                MessageBox.Show("Заполните номер телефона. Формат ввода: 11 цифр - 70123456789");
                return;
            }

            /*Match match = Regex.Match(textBoxPhone.Text.Trim(), @"^\(\d{3}\) \d{3}-\d{4}$");
            if (!match.Success)
            {
                MessageBox.Show("Введенный номер телефона не соответствует шаблону '(XXX) XXX-XXXX'");
                return;
            }*/

            // Если у нас добавление, то сохраняем в бд
            if (this.phoneRegister == null)
            {
                if (!PhoneBookDAO.savePhoneRegister(new PhoneRegister(textBoxFIO.Text.Trim(), textBoxPhone.Text.Trim())))
                {
                    MessageBox.Show("Ошибка при сохранении номера телефона");
                }
            }
            else
            {
                // Иначе меняем объект и обновляем его
                this.phoneRegister.FIO = textBoxFIO.Text.Trim();
                this.phoneRegister.phone = textBoxPhone.Text.Trim();
                if (!PhoneBookDAO.updatePhoneRegister(this.phoneRegister))
                {
                    MessageBox.Show("Ошибка при изменении номера телефона");
                }
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void textBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
