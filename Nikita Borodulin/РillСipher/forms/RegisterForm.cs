using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using РillСipher.daos;
using РillСipher.model;

namespace РillСipher.forms
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
            User user = new User(textBoxLogin.Text.Trim(), textBoxPassword.Text.Trim());
            bool createUser = UserDAO.createUser(user);
            if (!createUser)
            {
                MessageBox.Show("Ошибка создания пользователя");
            }

            user = UserDAO.getUserByLoginAndPassword(textBoxLogin.Text.Trim(), textBoxPassword.Text.Trim());

            MainForm mainForm = new MainForm(user);
            mainForm.Show();
            this.Hide();
        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            User potentialUser = UserDAO.getUserByLogin(textBoxLogin.Text.Trim());
            loginAlreadyExists = potentialUser != null;
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
