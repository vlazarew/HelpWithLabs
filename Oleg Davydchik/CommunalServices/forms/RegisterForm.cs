using CommunalServices.daos;
using CommunalServices.forms;
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

namespace CommunalServices
{
    public partial class RegisterForm : Form
    {
        private bool loginAlreadyExists = false;

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            Credentials credentials = new Credentials(textBoxLogin.Text.Trim(), textBoxPassword.Text.Trim());
            //Credentials credentials = CredentialsDAO.getCredentialsByLoginAndPassword(textBoxLogin.Text.Trim(), textBoxPassword.Text.Trim());
            //User user = new User(textBoxLogin.Text.Trim(), textBoxPassword.Text.Trim());
            bool createCredentials = CredentialsDAO.createCredentials(credentials);
            if (!createCredentials)
            {
                MessageBox.Show("Ошибка создания пользователя");
            }

            Consumer consumer = ConsumerDAO.getConsumerByCredentialsId(credentials.id);

            MainForm mainForm = new MainForm(consumer);
            mainForm.Show();
            this.Hide();
        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            Credentials potentialCredentials = CredentialsDAO.getCredentialsByLogin(textBoxLogin.Text.Trim());
            loginAlreadyExists = potentialCredentials != null;
            labelLoginExists.Visible = loginAlreadyExists;

            buttonRegister.Enabled = textBoxLogin.Text.Length != 0 && textBoxPassword.Text.Length != 0 && !loginAlreadyExists;
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            buttonRegister.Enabled = textBoxLogin.Text.Length != 0 && textBoxPassword.Text.Length != 0 && !loginAlreadyExists;
        }

        private void textBoxKey_TextChanged(object sender, EventArgs e)
        {
            buttonRegister.Enabled = textBoxLogin.Text.Length != 0 && textBoxPassword.Text.Length != 0 && !loginAlreadyExists;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
