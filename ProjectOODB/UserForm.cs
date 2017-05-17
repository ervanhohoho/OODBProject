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
        public UserForm()
        {
            InitializeComponent();
            refreshTable();
        }
        private void refreshTable()
        {
            dataGridView1.DataSource = (from x in laundry.Users
                                        select new { x.UserID, x.UserName, x.UserPassword, x.UserEmail, x.UserAddress, x.UserPhoneNumber, x.RoleName }).ToList();
        }
    }
}
