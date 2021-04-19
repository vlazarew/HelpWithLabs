using CommunalServices.model;
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

namespace CommunalServices.forms
{
    public partial class MainForm : Form
    {
        private Consumer currentConsumer;

        public MainForm(Consumer consumer)
        {
            this.currentConsumer = consumer;
            InitializeComponent();
            this.Text += (consumer.name + " " + consumer.surname);
            this.labelName.Text = consumer.name;
            this.labelSurname.Text = consumer.surname;
            this.labelBalance.Text = "0";
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


    }
}
