using Buildings.dao;
using Buildings.forms;
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

namespace Buildings
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            updateTables();
        }

        private void updateTables()
        {
            fillCustomers();
            fillObjects();
            fillMaterials();
            fillOffices();
        }

        private void fillOffices()
        {
            // Очищаем таблицу
            dataGridViewOffice.Rows.Clear();

            // Заполняем данными
            List<Office> offices = OfficeDAO.getAllOffices();
            for (int i = 0; i < offices.Count; i++)
            {
                dataGridViewOffice.Rows.Add(offices[i].id, offices[i].buildingNames, offices[i].contractId, offices[i].payment, offices[i].name);
                dataGridViewOffice.Rows[i].Selected = false;
            }
        }

        private void fillMaterials()
        {
            // Очищаем таблицу
            dataGridViewMaterials.Rows.Clear();

            // Заполняем данными
            List<Materials> materials = MaterialsDAO.getAllMaterials();
            for (int i = 0; i < materials.Count; i++)
            {
                dataGridViewMaterials.Rows.Add(materials[i].id, materials[i].buildingType, materials[i].materialsAmount, materials[i].typeOfMaterial, materials[i].contractId);
                dataGridViewMaterials.Rows[i].Selected = false;
            }
        }

        private void fillObjects()
        {
            // Очищаем таблицу
            dataGridViewObjects.Rows.Clear();

            // Заполняем данными
            List<Building> buildings = BuildingDAO.getAllBuildings();
            for (int i = 0; i < buildings.Count; i++)
            {
                dataGridViewObjects.Rows.Add(buildings[i].name, buildings[i].type, buildings[i].year, buildings[i].location, buildings[i].condition, buildings[i].contractId, buildings[i].team);
                dataGridViewObjects.Rows[i].Selected = false;
            }
        }

        private void fillCustomers()
        {
            // Очищаем таблицу
            dataGridViewCustomer.Rows.Clear();

            // Заполняем данными
            List<Customer> customers = CustomerDAO.getAllCustomers();
            for (int i = 0; i < customers.Count; i++)
            {
                dataGridViewCustomer.Rows.Add(customers[i].contractid, customers[i].name, customers[i].workingHours, customers[i].typeOfPayment, customers[i].paymentAmount);
                dataGridViewCustomer.Rows[i].Selected = false;
            }
        }

        private void buttonDeleteCustomer_Click(object sender, EventArgs e)
        {
            // Если выделена одна строчка
            if (dataGridViewCustomer.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dataGridViewCustomer.SelectedRows[0];

                // перезагрузим таблицу (для обновления данных)
                if (CustomerDAO.deleteCustomer(CustomerDAO.getCustomerByContactId(Int32.Parse(row.Cells[0].Value.ToString()))))
                {
                    updateTables();
                }
            }
        }

        private void buttonAddCustomer_Click(object sender, EventArgs e)
        {
            // Создаем вспомогательную форму
            CustomerForm customerForm = new CustomerForm();
            DialogResult result = customerForm.ShowDialog();

            // Если результат ОК, то перезагрузим таблицу (для обновления данных)
            if (result == DialogResult.OK)
            {
                fillCustomers();
            }
        }

        private void buttonEditCustomer_Click(object sender, EventArgs e)
        {
            // Если выделена одна строчка
            if (dataGridViewCustomer.SelectedRows.Count == 1)
            {
                // Создаем вспомогательную форму
                DataGridViewRow row = dataGridViewCustomer.SelectedRows[0];
                CustomerForm customerForm = new CustomerForm(CustomerDAO.getCustomerByContactId(int.Parse(row.Cells[0].Value.ToString())));
                DialogResult result = customerForm.ShowDialog();

                // Если результат ОК, то перезагрузим таблицу (для обновления данных)
                if (result == DialogResult.OK)
                {
                    fillCustomers();
                }
            }
        }

        private void buttonDeleteObject_Click(object sender, EventArgs e)
        {
            // Если выделена одна строчка
            if (dataGridViewObjects.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dataGridViewObjects.SelectedRows[0];

                // перезагрузим таблицу (для обновления данных)
                if (BuildingDAO.deleteBuilding(BuildingDAO.getBuildingByContactIdAndName(Int32.Parse(row.Cells[5].Value.ToString()), row.Cells[0].Value.ToString())))
                {
                    fillObjects();
                }
            }
        }

        private void buttonAddObject_Click(object sender, EventArgs e)
        {
            // Создаем вспомогательную форму
            BuildingForm buildingForm = new BuildingForm();
            DialogResult result = buildingForm.ShowDialog();

            // Если результат ОК, то перезагрузим таблицу (для обновления данных)
            if (result == DialogResult.OK)
            {
                fillObjects();
            }
        }

        private void buttonEditObject_Click(object sender, EventArgs e)
        {
            // Если выделена одна строчка
            if (dataGridViewObjects.SelectedRows.Count == 1)
            {
                // Создаем вспомогательную форму
                DataGridViewRow row = dataGridViewObjects.SelectedRows[0];
                BuildingForm buildingForm = new BuildingForm(BuildingDAO.getBuildingByContactIdAndName(Int32.Parse(row.Cells[5].Value.ToString()), row.Cells[0].Value.ToString()));
                DialogResult result = buildingForm.ShowDialog();

                // Если результат ОК, то перезагрузим таблицу (для обновления данных)
                if (result == DialogResult.OK)
                {
                    fillObjects();
                }
            }
        }
    }
}
