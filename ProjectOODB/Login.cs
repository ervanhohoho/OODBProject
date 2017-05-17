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
    public partial class Login : Form
    {
        String role = "";
        public Login()
        {
            InitializeComponent();
        }
        
        private void pindahRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register reg = new Register();
            this.Hide();
            reg.ShowDialog();
            this.Close();
        }
        public void pressEnter()
        {
            loginButton.PerformClick();
        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            LaundryEntities laundry = new LaundryEntities();
            String email = emailTextBox.Text;
            String password = passwordTextBox.Text;
            bool flag = true ;
            String errmsg = "";

            if (email == "")
            {
                errmsg += "Email must be filled!";
                flag = false;
            }
            if (password == "")
            {
                errmsg += "\nPassword must be filled!";
                flag = false;
            }
            if (flag)
            {
                int count = (from x in laundry.Users
                             where x.UserPassword == password && x.UserEmail == email
                             select x).ToList().Count;
                if (count > 0)
                {
                    role = (from x in laundry.Users where x.UserPassword == password && x.UserEmail == email select x.RoleName).First().ToString();
                    String userId = (from x in laundry.Users where x.UserPassword == password && x.UserEmail == email select x.UserID).First().ToString();
                    Home home = new Home(role,userId);
                    this.Hide();
                    home.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Email or Password is incorrect");
                }
            }
            else
            {
                MessageBox.Show(errmsg);
            }
        }

        private void emailTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                pressEnter();
        }

        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                pressEnter();
        }

    }
}
