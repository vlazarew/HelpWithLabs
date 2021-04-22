using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace РillСipher.forms
{
    public partial class ChooseFromDBForm : Form
    {
        public string SelectedValue { get; set; }

        private List<string> values;

        public ChooseFromDBForm(List<string> values)
        {
            InitializeComponent();
            this.values = values;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            if (dataGridViewValues.SelectedRows.Count == 1)
            {
                this.SelectedValue = dataGridViewValues.SelectedRows[0].Cells[0].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Выбери текст для загрузки из БД.");
            }
        }

        private void ChooseFromDBForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < values.Count; i++)
            {
                dataGridViewValues.Rows.Add(values[i]);
                dataGridViewValues.Rows[i].Selected = false;
            }
        }
    }
}
