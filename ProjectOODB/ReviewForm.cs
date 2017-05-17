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
    public partial class ReviewForm : Form
    {
        LaundryEntities laundry = new LaundryEntities();
        String tempProductID = "";
        String reviewId, userID;
        public void loadTables()
        {
            
            dataGridView2.DataSource = (from x in laundry.Reviews
                                        where x.ProductId == tempProductID && x.UserId == userID
                                        select new { x.ReviewId, Review = x.Review1}).ToList();
        }
        public void generateReviewId()
        {
            List<Review> query = (from x in laundry.Reviews
                                  select x).ToList();
            int total;
            if (query.Count != 0)
            {
                total = Convert.ToInt32(query[query.Count - 1].ReviewId.ToString().Substring(2, 3));
                ++total;
            }
            else
                total = 1;
            if (total < 10)
            {
                reviewId = "RV00" + total;
            }
            else if (total < 100)
            {
                reviewId = "RV0" + total;
            }
            else
            {
                reviewId = "RV" + total;
            }
            textBox1.Text = reviewId;
        }
        public ReviewForm(String userID)
        {
            InitializeComponent();
            this.userID = userID;
            dataGridView1.DataSource = (from x in laundry.PriceLists
                                        select new { x.ProductID, x.ProductName, x.ProductPrice }).ToList();
            int rowIndex = 0;
            DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
            tempProductID = selectedRow.Cells[0].Value.ToString();
            
            //Inisialisasi Kode Review

           
            loadTables();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
                MessageBox.Show("Review Must be Filled");
            Review newReview = new Review();
            newReview.Review1 = richTextBox1.Text;
            newReview.ReviewId = reviewId;
            newReview.ProductId = tempProductID;
            newReview.UserId = userID;
            laundry.AddToReviews(newReview);
            laundry.SaveChanges();
            loadTables();
            generateReviewId();
            textBox1.Text = reviewId;
            richTextBox1.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
            tempProductID = selectedRow.Cells[0].Value.ToString();
            loadTables();
            generateReviewId();
            textBox1.Text = reviewId;
        }
    }
}
