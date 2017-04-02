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
                    MessageBox.Show("Logged in!");
                }
                else
                {
                    MessageBox.Show("No User Found!");
                }
            }
            else
            {
                MessageBox.Show(errmsg);
            }
        }
    }
}
