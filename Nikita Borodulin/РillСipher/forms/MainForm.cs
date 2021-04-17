using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using РillСipher.daos;
using РillСipher.model;

namespace РillСipher.forms
{
    public partial class MainForm : Form
    {
        private User currentUser;

        public MainForm(User user)
        {
            this.currentUser = user;
            InitializeComponent();
            this.Text += user.login;
            radioButtonFile.Checked = true;
            radioButtonEncrypt.Checked = true;
            buttonSaveToFile.Visible = true;
            buttonRun.Enabled = false;
            textBoxAlphabet.Text = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя., ?";
            buttonSaveToFile.Enabled = false;
            buttonChooseFromDB.Visible = false;
            //textBoxMainText.Text = "шифр";
            //textBoxMainText.Text = "аюнчхя";
            //textBoxKey.Text = "альпинизм";
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void buttonChooseFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);
            textBoxMainText.Text = fileText;
        }

        private void buttonSaveToFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, labelResult.Text.Trim());
            MessageBox.Show("Файл сохранен");
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            int easd = textBoxKey.Text.Length;
            int esqrt = (int)Math.Sqrt(easd);
            if (esqrt * esqrt != easd)
            {
                MessageBox.Show("Ключ должен быть квадратом целого числа");
                return;
            }

            foreach (char c in textBoxKey.Text)
            {
                if (!textBoxAlphabet.Text.Contains(c))
                {
                    MessageBox.Show("Ключ должен состоять из символов алфавита");
                    return;
                }
            }

            foreach (char c in textBoxMainText.Text)
            {
                if (!textBoxAlphabet.Text.Contains(c))
                {
                    MessageBox.Show("Исходный текст должен состоять из символов алфавита");
                    return;
                }
            }


            if (radioButtonEncrypt.Checked)
            {
                string encoded = PillCipherSolver.Encrypt(textBoxAlphabet.Text, textBoxKey.Text, textBoxMainText.Text);
                labelResult.Text = encoded;
                WordDAO.saveWordToDB(encoded, currentUser);
            }
            else
            {
                string decoded = PillCipherSolver.Decrypt(textBoxAlphabet.Text, textBoxKey.Text, textBoxMainText.Text);
                labelResult.Text = decoded;
            }
        }

        private void buttonChooseFromDB_Click(object sender, EventArgs e)
        {
            List<string> values = WordDAO.getAllWordByUser(currentUser);
            ChooseFromDBForm chooseFromDBForm = new ChooseFromDBForm(values);
            var result = chooseFromDBForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxMainText.Text = chooseFromDBForm.SelectedValue;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void radioButtonFile_CheckedChanged(object sender, EventArgs e)
        {
            buttonSaveToFile.Visible = radioButtonEncrypt.Checked && radioButtonFile.Checked;
            buttonChooseFile.Visible = radioButtonDecrypt.Checked && radioButtonFile.Checked;
            buttonChooseFromDB.Visible = radioButtonDecrypt.Checked && radioButtonDB.Checked;
        }

        private void radioButtonEncrypt_CheckedChanged(object sender, EventArgs e)
        {
            buttonSaveToFile.Visible = radioButtonEncrypt.Checked && radioButtonFile.Checked;
            buttonChooseFromDB.Visible = radioButtonDecrypt.Checked && radioButtonDB.Checked;
        }

        private void radioButtonDecrypt_CheckedChanged(object sender, EventArgs e)
        {
            buttonChooseFile.Visible = radioButtonDecrypt.Checked && radioButtonFile.Checked;
            buttonChooseFromDB.Visible = radioButtonDecrypt.Checked && radioButtonDB.Checked;
        }

        private void textBoxMainText_TextChanged(object sender, EventArgs e)
        {
            buttonRun.Enabled = textBoxMainText.Text.Length > 0;
        }

        private void labelResult_TextChanged(object sender, EventArgs e)
        {
            buttonSaveToFile.Enabled = labelResult.Text.Length > 0;
        }


    }
}
