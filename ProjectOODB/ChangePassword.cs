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
    public partial class ChangePassword : Form
    {
        String userId;
        LaundryEntities laundry = new LaundryEntities();
        public ChangePassword(String userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            User user = (from x in laundry.Users
                         where x.UserID == userId
                         select x).FirstOrDefault();
            bool flag = true;
            String userEmail = user.UserEmail;
            if (tbEmail.Text == "")
            {
                MessageBox.Show("Email must be filled");
                flag = false;
            }
            if (tbOld.Text == "")
            {
                MessageBox.Show("Old password must be filled");
                flag = false;
            }
            if (tbNew.Text == "")
            {
                MessageBox.Show("New password must be filled");
                flag = false;
            }
            if (tbConfirm.Text == "")
            {
                MessageBox.Show("Confirm password must be filled");
                flag = false;
            }
            if (tbNew.Text != tbConfirm.Text)
            {
                MessageBox.Show("New password and confirm password must be the same");
                flag = false;
            }
            if (userEmail != tbEmail.Text)
            {
                MessageBox.Show("Email is wrong!");
                flag = false;
            }
            if (flag)
            {
                user.UserPassword = tbNew.Text;
                MessageBox.Show("Password Changed!");
                laundry.SaveChanges();
            }
        }
    }
}
