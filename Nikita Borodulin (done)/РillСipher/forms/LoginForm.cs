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
using РillСipher.forms;
using РillСipher.model;

namespace РillСipher
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
            User user = UserDAO.getUserByLoginAndPassword(textBoxLogin.Text.Trim(), textBoxPassword.Text.Trim());
            labelBadLogin.Visible = user == null;

            if (user != null)
            {
                MainForm mainForm = new MainForm(user);
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
