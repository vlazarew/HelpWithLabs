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
        // При нажатии на регистрацию переходим в форму регистрации
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();
        }

        // При нажатии на логин
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // Получаем учетные данные на основе введенных
            Credentials credentials = CredentialsDAO.getCredentialsByLoginAndPassword(textBoxLogin.Text.Trim(), textBoxPassword.Text.Trim());
            labelBadLogin.Visible = credentials == null;

            // Если норм данные, то получаем клиента и запускам главную форму
            if (credentials != null)
            {
                Consumer consumer = ConsumerDAO.getConsumerByCredentialsId(credentials.id);
                MainForm mainForm = new MainForm(consumer);
                mainForm.Show();
                this.Hide();
            }
        }

        // Логин доступен, если введен логин/пароль
        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            buttonLogin.Enabled = textBoxLogin.Text.Length != 0 && textBoxPassword.Text.Length != 0;
        }

        // Логин доступен, если введен логин/пароль
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
