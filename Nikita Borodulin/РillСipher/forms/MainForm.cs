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
            textBoxMainText.Text = "шифр";
            textBoxKey.Text = "альпинизм";
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

        private void radioButtonFile_CheckedChanged(object sender, EventArgs e)
        {
            buttonSaveToFile.Visible = radioButtonEncrypt.Checked && radioButtonFile.Checked;
            buttonChooseFile.Visible = radioButtonDecrypt.Checked && radioButtonFile.Checked;
        }

        private void radioButtonEncrypt_CheckedChanged(object sender, EventArgs e)
        {
            buttonSaveToFile.Visible = radioButtonEncrypt.Checked && radioButtonFile.Checked;
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
            System.IO.File.WriteAllText(filename, textBoxMainText.Text.Trim());
            MessageBox.Show("Файл сохранен");
        }

        private void radioButtonDecrypt_CheckedChanged(object sender, EventArgs e)
        {
            buttonChooseFile.Visible = radioButtonDecrypt.Checked && radioButtonFile.Checked;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBoxMainText_TextChanged(object sender, EventArgs e)
        {
            buttonRun.Enabled = textBoxMainText.Text.Length > 0;
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

            foreach(char c in textBoxKey.Text)
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

            MessageBox.Show(PillCipherSolver.Solve(textBoxAlphabet.Text, textBoxKey.Text, textBoxMainText.Text));
        }
    }
}
