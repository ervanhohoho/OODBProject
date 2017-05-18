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

        public String userId;
        public String role;
        public Home(String trole, String userId)
        {
            InitializeComponent();
            this.userId = userId;
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
            mlf.MdiParent = this;
            mlf.Show();
        }

        private void manageUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserForm usr = new UserForm();
            usr.MdiParent = this;
            usr.Show();
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewTransaction vtr = new ViewTransaction(role, userId);
            vtr.MdiParent = this;
            vtr.Show();
        }

        private void giveReviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReviewForm rv = new ReviewForm(userId);
            rv.MdiParent = this;
            rv.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword cp = new ChangePassword(userId);
            cp.MdiParent = this;
            cp.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoTransaction dt = new DoTransaction(userId);
            dt.MdiParent = this;
            dt.Show();
        }
    }
}
