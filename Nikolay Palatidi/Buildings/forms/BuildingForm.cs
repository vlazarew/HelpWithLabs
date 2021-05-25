using Buildings.dao;
using Buildings.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buildings.forms
{
    public partial class BuildingForm : Form
    {
        Building building;

        public BuildingForm(Building building = null)
        {
            InitializeComponent();
            this.building = building;
            if (this.building != null)
            {
                textBoxName.Text = building.name;
                textBoxIdContract.Text = building.contractId.ToString();
                textBoxCondition.Text = building.condition.ToString();
                textBoxLocation.Text = building.location.ToString();
                textBoxTeam.Text = building.team.ToString();
                textBoxTypeOfBuilding.Text = building.type.ToString();
                textBoxYearOFBuilding.Text = building.year.ToString();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            // Пытаемся привести к типу int
            int idContract = 0;
            int year = 0;
            try
            {
                idContract = int.Parse(textBoxIdContract.Text);
                year = int.Parse(textBoxYearOFBuilding.Text);
            }
            catch
            {
                MessageBox.Show("Некорректно указана номер контракта");
                return;
            }

            // Если у нас добавление, то сохраняем в бд
            if (this.building == null)
            {
                if (!BuildingDAO.saveBuilding(new Building(textBoxName.Text.Trim(), textBoxTypeOfBuilding.Text.Trim(), year, textBoxLocation.Text.Trim(), textBoxCondition.Text.Trim(),
                    idContract, textBoxTeam.Text.Trim())))
                {
                    MessageBox.Show("Ошибка при сохранении Объекта");
                }
            }
            else
            {
                // Иначе меняем объект и обновляем его
                this.building.name = textBoxName.Text.Trim();
                this.building.condition = textBoxCondition.Text.Trim();
                this.building.contractId = idContract;
                this.building.location = textBoxLocation.Text.Trim();
                this.building.team = textBoxTeam.Text.Trim();
                this.building.type = textBoxTypeOfBuilding.Text.Trim();
                this.building.year = year;
                if (!BuildingDAO.updatBuilding(this.building))
                {
                    MessageBox.Show("Ошибка при изменении объекта");
                }
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
