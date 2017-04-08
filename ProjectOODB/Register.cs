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
    public partial class Register : Form
    {
        LaundryEntities laundry = new LaundryEntities();
        public Register()
        {
            InitializeComponent();
        }
        public void pindahKeLogin()
        {
            Login login = new Login();
            this.Hide();
            login.ShowDialog();
            this.Close();
        }
        private void pindahLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pindahKeLogin();   
        }
        private void pressEnter(object s, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                registerButton.PerformClick();
        }
        private void registerButton_Click(object sender, EventArgs e)
        {
            string errmsg="";
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
            if (confirmPasswordTextBox.Text == "")
            {
                errmsg += "Confirm Password Must be Filled\n";
                flag = false;
            }
            if (passwordTextBox.Text != confirmPasswordTextBox.Text)
            {
                errmsg += "Password and Confirm Passwordm must be the same\n";
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
            foreach(char i in usernameTextBox.Text)
            {
                if (!char.IsLetter(i)&& usernameTextBox.Text!="")
                {
                    flag = false;
                    errmsg += "Username must be alphabet\n";
                }
            }
            
            //Validasi alamat harus akhirnya street
            if (!addressTextBox.Text.EndsWith("street")&& addressTextBox.Text!="")
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

            //Print error message
            if (!flag)
                MessageBox.Show(errmsg);
            else
            {
                User newUser = new User();
                newUser.UserName = usernameTextBox.Text;
                newUser.UserPassword = passwordTextBox.Text;
                newUser.UserPhoneNumber = phoneTextBox.Text;
                newUser.UserEmail = emailTextBox.Text;
                newUser.UserAddress = addressTextBox.Text;
                List<User>query = (from x in laundry.Users
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
                    newUser.UserID = "US00" + total;
                }
                else if (total < 100)
                {
                    newUser.UserID = "US0" + total;
                }
                else
                {
                    newUser.UserID = "US" + total;
                }
                newUser.RoleName = "Member";
                laundry.AddToUsers(newUser);
                laundry.SaveChanges();
                pindahKeLogin();
            }
        }
    }
}
