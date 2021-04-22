using CommunalServices.daos;
using CommunalServices.forms;
using CommunalServices.model;
using CommunalServices.resolvers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommunalServices
{
    /// <summary>
    /// Форма регистрации в приложении
    /// </summary>
    public partial class RegisterForm : Form
    {
        // Флажок на "Логин уже занят"
        private bool loginAlreadyExists = false;
        // Создание при помощи админа (выбор ролей)
        private bool isCreatingByAdmin;


        public RegisterForm(bool isCreatingByAdmin = false, Consumer consumer = null)
        {
            InitializeComponent();
            // По умолчанию - ложь
            this.isCreatingByAdmin = isCreatingByAdmin;
            // По умолчанию - ложь
            this.groupBoxTypeOfUser.Visible = isCreatingByAdmin;
            // // По умолчанию - тип пользователя = "Клиент"
            this.radioButtonConsumer.Checked = true;
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            // Собираем все введенные телефонные номера в список
            List<string> numbers = new List<string>();
            foreach (DataGridViewRow row in dataGridViewPhoneNumbers.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    // Обрезаем их справа и слева от пробелов
                    numbers.Add(row.Cells[0].Value.ToString().Trim());
                }
            }

            // Сохраняем и регистрируем пользователя
            CredentialsResolver.createCredentialsAndConsumer(textBoxLogin.Text.Trim(), textBoxPassword.Text.Trim(),
                textBoxStreet.Text.Trim(), textBoxHouse.Text.Trim(), Int32.Parse(textBoxFlat.Text.Trim()),
                numbers, radioButtonAdmin.Checked, textBoxName.Text.Trim(), textBoxSurname.Text.Trim());

            Credentials credentials = CredentialsDAO.getCredentialsByLoginAndPassword(textBoxLogin.Text.Trim(), textBoxPassword.Text.Trim());
            Consumer consumer = ConsumerDAO.getConsumerByCredentialsId(credentials.id);

            // Если была настоящая регистрация незнакомцем, то включим ему главную форму
            if (!this.isCreatingByAdmin)
            {
                MainForm mainForm = new MainForm(consumer);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                // Если админ - просто закроем форму
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        // Условие доступности кнопки "Зарегистрироваться"
        private bool isRegisterEnabled()
        {
            return textBoxLogin.Text.Length != 0 && textBoxPassword.Text.Length != 0 && !loginAlreadyExists
                && textBoxName.Text.Length != 0 && textBoxSurname.Text.Length != 0 && textBoxStreet.Text.Length != 0
                && textBoxHouse.Text.Length != 0 && textBoxFlat.Text.Length != 0 && numbersAreFilled();
        }

        // Проверка, что введен хотя бы один телефонный номер
        private bool numbersAreFilled()
        {
            bool result = false;
            foreach (DataGridViewRow row in dataGridViewPhoneNumbers.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        // Провека на занятый логин при измении текстового поля ЛОГИН
        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            Credentials potentialCredentials = CredentialsDAO.getCredentialsByLogin(textBoxLogin.Text.Trim());
            loginAlreadyExists = potentialCredentials != null;
            labelLoginExists.Visible = loginAlreadyExists;

            buttonRegister.Enabled = isRegisterEnabled();
        }

        // Снимаем выделение со всех строк в таблице с номерами телефонов
        private void RegisterForm_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewPhoneNumbers.Rows)
            {
                row.Selected = false;
            }
        }

        // Выключаем приложение, если окно не создано админом
        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (!this.isCreatingByAdmin)
            {
                Application.Exit();
            }
        }

        // Выключаем приложение, если окно не создано админом
        private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!this.isCreatingByAdmin)
            {
                Application.Exit();
            }
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            buttonRegister.Enabled = isRegisterEnabled();
        }

        private void textBoxKey_TextChanged(object sender, EventArgs e)
        {
            buttonRegister.Enabled = isRegisterEnabled();
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            buttonRegister.Enabled = isRegisterEnabled();
        }

        private void textBoxSurname_TextChanged(object sender, EventArgs e)
        {
            buttonRegister.Enabled = isRegisterEnabled();
        }

        private void textBoxStreet_TextChanged(object sender, EventArgs e)
        {
            buttonRegister.Enabled = isRegisterEnabled();
        }

        private void textBoxHouse_TextChanged(object sender, EventArgs e)
        {
            buttonRegister.Enabled = isRegisterEnabled();
        }

        private void textBoxFlat_TextChanged(object sender, EventArgs e)
        {
            buttonRegister.Enabled = isRegisterEnabled();
        }

        private void dataGridViewPhoneNumbers_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            buttonRegister.Enabled = isRegisterEnabled();
        }

        private void dataGridViewPhoneNumbers_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            buttonRegister.Enabled = isRegisterEnabled();
        }

        private void dataGridViewPhoneNumbers_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            buttonRegister.Enabled = isRegisterEnabled();
        }

        private void dataGridViewPhoneNumbers_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            buttonRegister.Enabled = isRegisterEnabled();
        }
    }
}
