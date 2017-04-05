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
    public partial class Home : Form
    {
        public String role;
        public Home(String trole)
        {
            InitializeComponent();
            role = trole;
            if (role == "Member")
            {
                manageProductToolStripMenuItem.Visible = false;
                manageUserToolStripMenuItem.Visible = false;
            }
            else if (role == "Admin")
            {
                orderToolStripMenuItem.Visible = false;
                giveReviewToolStripMenuItem.Visible = false;
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.ShowDialog();
            this.Close();
        }

        private void manageProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MasterLaundryForm mlf = new MasterLaundryForm();
            mlf.ShowDialog();
        }
    }
}
