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
    /// Форма для создания/изменения видов услуг
    /// </summary>
    public partial class TypeOfServiceForm : Form
    {
        TypeOfService typeOfService;

        public TypeOfServiceForm(TypeOfService typeOfService = null)
        {
            InitializeComponent();
            this.typeOfService = typeOfService;

            // Отрисовка данных при изменении объекта
            if (this.typeOfService != null)
            {
                textBoxName.Text = typeOfService.name;
                textBoxCost.Text = typeOfService.cost.ToString();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            // Пытаемся привести стоимость к типу float
            float cost = 0;
            try
            {
                cost = float.Parse(textBoxCost.Text);
            }
            catch
            {
                MessageBox.Show("Некорректно указана стоимость");
                return;
            }

            // Если у нас добавление, то сохраняем в бд
            if (this.typeOfService == null)
            {
                if (!TypeOfServiceDAO.saveTypeOfService(new TypeOfService(textBoxName.Text.Trim(), cost)))
                {
                    MessageBox.Show("Ошибка при сохранении вида коммунальных услуг");
                }
            }
            else
            {
                // Иначе меняем объект и обновляем его
                this.typeOfService.cost = cost;
                this.typeOfService.name = textBoxName.Text.Trim();
                if (!TypeOfServiceDAO.updateTypeOfService(this.typeOfService))
                {
                    MessageBox.Show("Ошибка при изменении вида коммунальных услуг");
                }
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void TypeOfServiceForm_Load(object sender, EventArgs e)
        {

        }
    }
}
