using PhoneBook.daos;
using PhoneBook.forms;
using PhoneBook.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneBook
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            textBoxFIO.Text = "";
            textBoxPhoneNumber.Text = "";
            reloadPhoneBookTable();
        }

        private void reloadPhoneBookTable()
        {
            // Очищаем таблицу
            dataGridViewPhonebook.Rows.Clear();

            // Заполняем данными
            List<PhoneRegister> phoneRegisters = PhoneBookDAO.getPhoneRegistersByTemplate(textBoxFIO.Text.Trim(), textBoxPhoneNumber.Text.Trim());
            for (int i = 0; i < phoneRegisters.Count; i++)
            {
                dataGridViewPhonebook.Rows.Add(phoneRegisters[i].FIO, phoneRegisters[i].phone, phoneRegisters[i].companyName, phoneRegisters[i].mail);
                dataGridViewPhonebook.Rows[i].Selected = false;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Создаем вспомогательную форму
            PhoneRecordForm phoneRecordForm = new PhoneRecordForm();
            DialogResult result = phoneRecordForm.ShowDialog();

            // Если результат ОК, то перезагрузим таблицу (для обновления данных)
            if (result == DialogResult.OK)
            {
                reloadPhoneBookTable();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            // Если выделена одна строчка
            if (dataGridViewPhonebook.SelectedRows.Count == 1)
            {
                // Создаем вспомогательную форму
                DataGridViewRow row = dataGridViewPhonebook.SelectedRows[0];
                PhoneRecordForm phoneRecordForm = new PhoneRecordForm(PhoneBookDAO.getPhoneRegisterByFIOAndPhone(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString()));
                DialogResult result = phoneRecordForm.ShowDialog();

                // Если результат ОК, то перезагрузим таблицу (для обновления данных)
                if (result == DialogResult.OK)
                {
                    reloadPhoneBookTable();
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // Если выделена одна строчка
            if (dataGridViewPhonebook.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dataGridViewPhonebook.SelectedRows[0];

                // перезагрузим таблицу (для обновления данных)
                if (PhoneBookDAO.deletePhoneRegister(PhoneBookDAO.getPhoneRegisterByFIOAndPhone(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString())))
                {
                    reloadPhoneBookTable();
                }
            }
        }

        private void textBoxFIO_TextChanged(object sender, EventArgs e)
        {
            reloadPhoneBookTable();
        }

        private void textBoxPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            reloadPhoneBookTable();
        }

        private void textBoxPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
