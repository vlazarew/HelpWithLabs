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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        #region События
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Credentials credentials = CredentialsDAO.getCredentialsByLoginAndPassword(textBoxLogin.Text.Trim(), textBoxPassword.Text.Trim());
            labelBadLogin.Visible = credentials == null;

            if (credentials != null)
            {
                Consumer consumer = ConsumerDAO.getConsumerByCredentialsId(credentials.id);
                MainForm mainForm = new MainForm(consumer);
                mainForm.Show();
                this.Hide();
            }
        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            buttonLogin.Enabled = textBoxLogin.Text.Length != 0 && textBoxPassword.Text.Length != 0;
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            buttonLogin.Enabled = textBoxLogin.Text.Length != 0 && textBoxPassword.Text.Length != 0;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}
