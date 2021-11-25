using CommunalServices.daos;
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

namespace CommunalServices.forms
{
    /// <summary>
    /// Класс для изменения Клиента
    /// </summary>
    public partial class ConsumerEditForm : Form
    {
        Consumer consumer = null;

        public ConsumerEditForm(Consumer consumer = null)
        {
            InitializeComponent();
            this.consumer = consumer;
            // Отрисовка данных на форме
            if (this.consumer != null)
            {
                textBoxName.Text = consumer.name;
                textBoxSurname.Text = consumer.surname;

                TypeOfConsumer typeOfConsumer = TypeOfConsumerDAO.getTypeOfConsumerById(consumer.typeOfConsumerId);
                if (consumer.typeOfConsumerId == 0)
                {
                    radioButtonAdmin.Checked = true;
                    radioButtonConsumer.Checked = false;
                }
                else
                {
                    radioButtonAdmin.Checked = false;
                    radioButtonConsumer.Checked = true;
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            // Изменяем объект и обновляем его
            this.consumer.name = textBoxName.Text.Trim();
            this.consumer.surname = textBoxSurname.Text.Trim();
            this.consumer.typeOfConsumerId = radioButtonAdmin.Checked ? 0 : 1;
            if (!ConsumerDAO.updateConsumer(this.consumer))
            {
                MessageBox.Show("Ошибка при изменении клиента");
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
