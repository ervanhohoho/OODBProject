using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectOODB
{
    public partial class MasterLaundryForm : Form
    {
        LaundryEntities laundry = new LaundryEntities();
        public MasterLaundryForm()
        {
            InitializeComponent();
            dataGridView1.DataSource = (from x in laundry.PriceLists select x).ToList();
        } 

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            idTextBox.Enabled = true;
            nameTextBox.Enabled = true;
            priceTextBox.Enabled = true;
            int count = (from x in laundry.PriceLists
                         select x).ToList().Count()+1;
            if (count < 10)
            {
                idTextBox.Text = "PD00" + count;
            }else if (count < 100)
            {
                idTextBox.Text = "PD0" + count;
            }else
            {
                idTextBox.Text = "PD" + count;
            }
            insertButton.Enabled = false;
            updateButton.Enabled = false;
            deleteButton.Enabled = false;
            saveButton.Enabled = true;
            cancelButton.Enabled = true;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            String data = dataGridView1.SelectedRows.ToString();
            saveButton.Enabled = true;
            cancelButton.Enabled = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            
            string a = dataGridView1.CurrentCell.RowIndex.ToString();
            MessageBox.Show(a);
        }
    }
}
