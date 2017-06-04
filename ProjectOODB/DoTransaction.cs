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
    public partial class DoTransaction : Form
    {
        LaundryEntities laundry = new LaundryEntities();
        List<DetailTransaction> DetailTransactions;
        public void loadTable()
        {
            dataGridView2.DataSource = (from x in laundry.DetailTransactions
                                        where x.HeaderTransaction.UserId == tbUserID.Text && x.HeaderTransaction.Status == "Pending"
                                        select new { x.Productid, x.PriceList.ProductName, x.Quantity, x.Price }).ToList();
           
            var query = (from x in laundry.DetailTransactions
                         where x.HeaderTransaction.UserId == tbUserID.Text && x.HeaderTransaction.Status == "Pending"
                         select x).ToList();

            DetailTransactions = query;
        }
        public void generateId()
        {
            List<HeaderTransaction> query = (from x in laundry.HeaderTransactions
                                select x).ToList();
            int total;
            if (query.Count != 0)
            {
                total = Convert.ToInt32(query[query.Count - 1].TransactionId.ToString().Substring(2, 3));
                ++total;
            }
            else
                total = 1;
            if (total < 10)
            {
                tbTransactionID.Text = "HT00" + total;
            }
            else if (total < 100)
            {
                tbTransactionID.Text = "HT0" + total;
            }
            else
            {
                tbTransactionID.Text = "HT" + total;
            }
        }
        public void resetState()
        {
            tbTransactionID.Text = "";
            tbLaundryID.Text = "";
            tbLaundryName.Text = "";
            tbProductID.Text = "";
            tbPrice.Text = "";
            tbCartQty.Text = "";
            tbGrandTotal.Text = "";

            tbTransactionID.Enabled = false;
            tbUserID.Enabled = false;
            tbLaundryID.Enabled = false;
            tbLaundryName.Enabled = false;
            tbProductID.Enabled = false;
            tbPrice.Enabled = false;
            tbCartQty.Enabled = false;
            tbGrandTotal.Enabled = false;
            generateId();
            loadTable();
        }
        public DoTransaction(String userId)
        {
            InitializeComponent();
            tbUserID.Text = userId;
            dataGridView1.DataSource = (from x in laundry.PriceLists
                                        select new { x.ProductID, x.ProductName, x.ProductPrice }).ToList();
            resetState();
            
        }

        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool flag = true;
            if (Int32.Parse(qtyNumeric.Value.ToString()) <= 0)
            {
                flag = false;
                MessageBox.Show("Please fill the quantity more than 0");
            }
            if (tbLaundryID.Text == "" || tbLaundryName.Text == "" || tbPrice.Text == "")
            {
                flag = false;
                MessageBox.Show("Please select a product first");
            }
            if(flag)
            {
                HeaderTransaction ht = new HeaderTransaction();
                ht.TransactionId = tbTransactionID.Text;
                ht.UserId = tbUserID.Text;
                ht.Status = "Pending";
                laundry.AddToHeaderTransactions(ht);

                DetailTransaction dt = new DetailTransaction();
                dt.Productid = tbLaundryID.Text;
                dt.TransactionId = tbTransactionID.Text;
                dt.Quantity = Int32.Parse(qtyNumeric.Value.ToString());
                dt.Price = Int32.Parse(qtyNumeric.Value.ToString()) * Int32.Parse(tbPrice.Text.ToString());
                laundry.AddToDetailTransactions(dt);

                laundry.SaveChanges();
                resetState();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView2.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView2.Rows[rowIndex];
            String transactionId = DetailTransactions[rowIndex].TransactionId;
            String productId = selectedRow.Cells[0].Value.ToString();
            var query = (from x in laundry.DetailTransactions
                         where x.TransactionId == transactionId && x.Productid == productId
                         select x).FirstOrDefault();
            var query2 = (from x in laundry.HeaderTransactions
                          where x.TransactionId == transactionId
                          select x).FirstOrDefault();
            DialogResult dialogResult = MessageBox.Show("Are You Sure?", "Delete Data", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                laundry.DeleteObject(query);
                laundry.DeleteObject(query2);
                laundry.SaveChanges();
                loadTable();
            }
            else if (dialogResult == DialogResult.No)
            {
                resetState();
            }
            
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
            tbLaundryID.Text = selectedRow.Cells[0].Value.ToString();
            tbLaundryName.Text = selectedRow.Cells[1].Value.ToString();
            tbPrice.Text = selectedRow.Cells[2].Value.ToString();
        }
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            int rowIndex = dataGridView2.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView2.Rows[rowIndex];
            tbGrandTotal.Text = selectedRow.Cells[3].Value.ToString();
            tbProductID.Text = selectedRow.Cells[0].Value.ToString();
            tbCartQty.Text = selectedRow.Cells[2].Value.ToString();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView2.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView2.Rows[rowIndex];
            String transactionId = DetailTransactions[rowIndex].TransactionId;
            HeaderTransaction ht = (from x in laundry.HeaderTransactions
                                 where x.TransactionId == transactionId
                                 select x).FirstOrDefault();
            ht.Status = "Waiting";
            laundry.SaveChanges();
            loadTable();
        }
    }
}
