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
    public partial class ViewTransaction : Form
    {
        LaundryEntities laundry = new LaundryEntities();
        public String tempTransactionId="";
        public String role, userId;
        public void loadTables()
        {
            if (role == "Admin")
            {
                dataGridView2.DataSource = (from x in laundry.DetailTransactions
                                            where x.TransactionId == tempTransactionId
                                            select new { x.PriceList.ProductName, x.Quantity, x.Price }).ToList();
            }
        }
        public ViewTransaction(String role, String userId)
        {
            InitializeComponent();
            this.role = role;
            this.userId = userId;
            if (role == "Admin")
            {
                dataGridView1.DataSource = (from x in laundry.HeaderTransactions
                                            select new { x.TransactionId, x.UserId, x.Status }).ToList();
            }
            if(role == "Member")
            {
                btnUpdate.Visible = false;
                dataGridView1.DataSource = (from x in laundry.HeaderTransactions
                                            where x.UserId == userId
                                            select new { x.TransactionId, x.Status });
            }
            loadTables();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
         
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
            tempTransactionId = selectedRow.Cells[0].Value.ToString();
            //Bikin total qty sama grand total
            loadTables();
        }
    }
}
