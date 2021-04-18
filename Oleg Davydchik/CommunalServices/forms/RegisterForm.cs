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
    public partial class RegisterForm : Form
    {
        private bool loginAlreadyExists = false;
        private bool isCreatingByAdmin;


        public RegisterForm(bool isCreatingByAdmin = false)
        {
            InitializeComponent();
            this.isCreatingByAdmin = isCreatingByAdmin;
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            List<string> numbers = new List<string>();
            foreach (DataGridViewRow row in dataGridViewPhoneNumbers.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    numbers.Add(row.Cells[0].Value.ToString().Trim());
                }
            }

            CredentialsResolver.createCredentialsAndConsumer(textBoxLogin.Text.Trim(), textBoxPassword.Text.Trim(),
                textBoxStreet.Text.Trim(), textBoxHouse.Text.Trim(), Int32.Parse(textBoxFlat.Text.Trim()),
                numbers, radioButtonAdmin.Checked, textBoxName.Text.Trim(), textBoxSurname.Text.Trim());

            Credentials credentials = CredentialsDAO.getCredentialsByLoginAndPassword(textBoxLogin.Text.Trim(), textBoxPassword.Text.Trim());
            Consumer consumer = ConsumerDAO.getConsumerByCredentialsId(credentials.id);

            MainForm mainForm = new MainForm(consumer);
            mainForm.Show();
            this.Hide();
        }

        private bool isRegisterEnabled()
        {
            return textBoxLogin.Text.Length != 0 && textBoxPassword.Text.Length != 0 && !loginAlreadyExists
                && textBoxName.Text.Length != 0 && textBoxSurname.Text.Length != 0 && textBoxStreet.Text.Length != 0
                && textBoxHouse.Text.Length != 0 && textBoxFlat.Text.Length != 0 && numbersAreFilled();
        }

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

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            Credentials potentialCredentials = CredentialsDAO.getCredentialsByLogin(textBoxLogin.Text.Trim());
            loginAlreadyExists = potentialCredentials != null;
            labelLoginExists.Visible = loginAlreadyExists;

            buttonRegister.Enabled = isRegisterEnabled();
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            buttonRegister.Enabled = isRegisterEnabled();
        }

        private void textBoxKey_TextChanged(object sender, EventArgs e)
        {
            buttonRegister.Enabled = isRegisterEnabled();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewPhoneNumbers.Rows)
            {
                row.Selected = false;
            }
        }

        private void dataGridViewPhoneNumbers_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            buttonRegister.Enabled = isRegisterEnabled();
        }
    }
}
