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
        public String [] status = {"Pending","Waiting","Washing","Finished"};
        public void loadTables()
        {
            if (role == "Admin")
            {
                dataGridView2.DataSource = (from x in laundry.DetailTransactions
                                            where x.TransactionId == tempTransactionId
                                            select new { x.PriceList.ProductName, x.Quantity, x.Price }).ToList();
                List<DetailTransaction> dt = (from x in laundry.DetailTransactions
                                              where x.TransactionId == tempTransactionId
                                              select x).ToList();
                int total=0;
                for (int a = 0; a < dt.Count; a++)
                {
                    total += Int32.Parse(dt[a].Price.ToString());
                }
                tbTotal.Text = total.ToString();
                int qty = 0;
                for (int a = 0; a < dt.Count; a++)
                {
                    qty+= Int32.Parse(dt[a].Quantity.ToString());
                }
                tbQuantity.Text = qty.ToString();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow dgvr = dataGridView1.Rows[rowindex];
            if (dgvr.Cells[2].Value.ToString() == status[0])
            {
                MessageBox.Show("Item is pending, can't update");
            }
            if (dgvr.Cells[2].Value.ToString() == status[1])
            {
                String id = dgvr.Cells[0].Value.ToString();
                var query = (from x in laundry.HeaderTransactions
                             where x.TransactionId == id
                             select x).FirstOrDefault();
                if (query != null)
                {
                    query.Status = status[2];
                }
                laundry.SaveChanges();
            }
            if (dgvr.Cells[2].Value.ToString() == status[2])
            {
                String id = dgvr.Cells[0].Value.ToString();
                var query = (from x in laundry.HeaderTransactions
                             where x.TransactionId == id
                             select x).FirstOrDefault();
                if (query != null)
                {
                    query.Status = status[3];
                }
                laundry.SaveChanges();
            }
            dataGridView1.DataSource = (from x in laundry.HeaderTransactions
                                        select new { x.TransactionId, x.UserId, x.Status }).ToList();
        }
    }
}
