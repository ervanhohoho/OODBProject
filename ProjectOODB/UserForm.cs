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
    public partial class UserForm : Form
    {
        private LaundryEntities laundry = new LaundryEntities();
        bool insertButtonClicked, updateButtonClicked, deleteButtonClicked;
        int rowIndex;
        public UserForm()
        {
            InitializeComponent();
            resetState();
            refreshTable();
        }
        public void resetState()
        {
            userIdTextBox.Text = "";
            usernameTextBox.Text = "";
            passwordTextBox.Text = "";
            emailTextBox.Text = "";
            addressTextBox.Text = "";
            phoneTextBox.Text = "";
            rolenameTextBox.Text = "";

            dataGridView1.Enabled = true;
            userIdTextBox.Enabled = false;
            usernameTextBox.Enabled = false;
            passwordTextBox.Enabled = false;
            emailTextBox.Enabled = false;
            addressTextBox.Enabled = false;
            phoneTextBox.Enabled = false;
            rolenameTextBox.Enabled = false;
            
            saveButton.Enabled = false;
            cancelButton.Enabled = false;
            insertButton.Enabled = true;
            updateButton.Enabled = true;
            deleteButton.Enabled = true;

            insertButtonClicked = updateButtonClicked = deleteButtonClicked = false;
        }
        public void enableAllField()
        {
            userIdTextBox.Enabled = true;
            usernameTextBox.Enabled = true;
            passwordTextBox.Enabled = true;
            emailTextBox.Enabled = true;
            addressTextBox.Enabled = true;
            phoneTextBox.Enabled = true;
            rolenameTextBox.Enabled = true;
        }
        public void disableAllButton()
        {
            saveButton.Enabled = false;
            cancelButton.Enabled = false;
            insertButton.Enabled = false;
            updateButton.Enabled = false;
            deleteButton.Enabled = false;
        }
        public string generateUserId()
        {
            String userId;
            List<User> query = (from x in laundry.Users
                                select x).ToList();
            int total;
            if (query.Count != 0)
            {
                total = Convert.ToInt32(query[query.Count - 1].UserID.ToString().Substring(2, 3));
                ++total;
            }
            else
                total = 1;
            if (total < 10)
            {
                userId = "US00" + total;
            }
            else if (total < 100)
            {
                userId = "US0" + total;
            }
            else
            {
                userId = "US" + total;
            }
            return userId;
        }
        
        private void refreshTable()
        {
            dataGridView1.DataSource = (from x in laundry.Users
                                        select new { x.UserID, x.UserName, x.UserPassword, x.UserEmail, x.UserAddress, x.UserPhoneNumber, x.RoleName }).ToList();
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            enableAllField();
            insertButtonClicked = true;
            updateButtonClicked = deleteButtonClicked = false;
            userIdTextBox.Enabled = false;
            userIdTextBox.Text = generateUserId();
            disableAllButton();
            saveButton.Enabled = true;
            cancelButton.Enabled = true;
        }
        public bool validasi(ref String errmsg)
        {
            //string errmsg = "";
            bool flag = true;
            bool emailflag = true;
            //Validasi Kosong
            if (usernameTextBox.Text == "")
            {
                errmsg += "Username Must be Filled\n";
                flag = false;
            }
            if (passwordTextBox.Text == "")
            {
                errmsg += "Password Must be Filled\n";
                flag = false;
            }
            if (emailTextBox.Text == "")
            {
                errmsg += "Email Must be Filled\n";
                emailflag = false;
                flag = false;
            }
            if (phoneTextBox.Text == "")
            {
                errmsg += "Phone number Must be Filled\n";
                flag = false;
            }
            if (addressTextBox.Text == "")
            {
                errmsg += "Address Must be Filled\n";
                flag = false;
            }
            //Validasi username harus alphabet
            foreach (char i in usernameTextBox.Text)
            {
                if (!char.IsLetter(i) && usernameTextBox.Text != "")
                {
                    flag = false;
                    errmsg += "Username must be alphabet\n";
                }
            }

            //Validasi alamat harus akhirnya street
            if (!addressTextBox.Text.EndsWith("street") && addressTextBox.Text != "")
            {
                flag = false;
                errmsg += "Address Must ends with 'street'\n";
            }

            //Validasi Email
            if (emailflag)
            {
                int count = 0;
                foreach (char i in emailTextBox.Text)
                {
                    if (i == '@')
                    {
                        count++;
                    }
                }
                if (emailTextBox.Text[0] == '@' || emailTextBox.Text[emailTextBox.Text.Length - 1] == '@' || !emailTextBox.Text.Contains("@") || !emailTextBox.Text.Contains(".") || count > 1 || emailTextBox.Text.Contains("@."))
                {
                    errmsg += "Email is not valid\n";
                    flag = false;
                }
            }
            return flag;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            String errmsg = "";
            bool flag = validasi(ref errmsg);
            if (insertButtonClicked)
            {
                User newUser = new User();
                //Print error message
                if (!flag)
                    MessageBox.Show(errmsg);
                else
                {
                    newUser.UserName = usernameTextBox.Text;
                    newUser.UserPassword = passwordTextBox.Text;
                    newUser.UserPhoneNumber = phoneTextBox.Text;
                    newUser.UserEmail = emailTextBox.Text;
                    newUser.UserAddress = addressTextBox.Text;
                    newUser.UserID = userIdTextBox.Text;
                    newUser.RoleName = rolenameTextBox.Text;
                    laundry.AddToUsers(newUser);
                    laundry.SaveChanges();
                }
            }
            if (updateButtonClicked)
            {
                User tUser = (from x in laundry.Users
                              where x.UserID == userIdTextBox.Text
                              select x).FirstOrDefault();
                tUser.UserName = usernameTextBox.Text;
                tUser.UserPassword = passwordTextBox.Text;
                tUser.UserPhoneNumber = phoneTextBox.Text;
                tUser.UserEmail = emailTextBox.Text;
                tUser.UserAddress = addressTextBox.Text;
                tUser.UserID = userIdTextBox.Text;
                tUser.RoleName = rolenameTextBox.Text;
                laundry.SaveChanges();
            }
            refreshTable();
            resetState();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            rowIndex = dataGridView1.CurrentCell.RowIndex;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {

            updateButtonClicked = true;
            insertButtonClicked = deleteButtonClicked = false;
            DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
            dataGridView1.Enabled = false;
            enableAllField();
            userIdTextBox.Enabled = false;
            disableAllButton();
            saveButton.Enabled = true;
            cancelButton.Enabled = true;

            userIdTextBox.Text = selectedRow.Cells[0].Value.ToString();
            usernameTextBox.Text = selectedRow.Cells[1].Value.ToString();
            passwordTextBox.Text = selectedRow.Cells[2].Value.ToString();
            emailTextBox.Text = selectedRow.Cells[3].Value.ToString();
            addressTextBox.Text = selectedRow.Cells[4].Value.ToString();
            phoneTextBox.Text = selectedRow.Cells[5].Value.ToString();
            rolenameTextBox.Text = selectedRow.Cells[6].Value.ToString();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            resetState();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //validasi tombol yg diklik
            deleteButtonClicked = true;
            insertButtonClicked = updateButtonClicked = false;


            if (dataGridView1.CurrentCell.RowIndex == -1)
            {
                MessageBox.Show("Select product first");
            }
            else
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
                String userid = selectedRow.Cells[0].Value.ToString();
                User us = (from x in laundry.Users
                            where x.UserID == userid
                            select x).SingleOrDefault();
                DialogResult dialogResult = MessageBox.Show("Sure", "Some Title", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    laundry.DeleteObject(us);
                    laundry.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Cancelled");
                }
                refreshTable();
                resetState();
                
            }
        }
    }
}
