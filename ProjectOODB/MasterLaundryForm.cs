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
    public partial class MasterLaundryForm : Form
    {
        LaundryEntities laundry = new LaundryEntities();
        public bool insertButtonClicked;
        public bool updateButtonClicked;
        public bool deleteButtonClicked;
        public static int colCount = 3;
        public String id;
        public String name;
        public int price;


        public MasterLaundryForm()
        {
            insertButtonClicked = updateButtonClicked = deleteButtonClicked = false;
            InitializeComponent();
            dataGridView1.ClearSelection();
            updateTable();
        }
        //Koleksi Inisialisasi
        private void updateTable()
        {
            dataGridView1.DataSource = (from x in laundry.PriceLists select new { x.ProductID, x.ProductName, x.ProductPrice }).ToList();
        }
        public void resetState()
        {
            insertButton.Enabled = true;
            updateButton.Enabled = true;
            deleteButton.Enabled = true;
            saveButton.Enabled = false;
            cancelButton.Enabled = false;
            insertButtonClicked = false;
            updateButtonClicked = false;
            deleteButtonClicked = false;

            idTextBox.Text = "";
            nameTextBox.Text = "";
            priceTextBox.Text = "";
        }
        //END

        //Berhubungan dengan InsertButton
        //Buat masukin data ke dalam database dari save button
        private void insertNew()
        {
            PriceList pl = new PriceList();
            pl.ProductID = idTextBox.Text;
            pl.ProductName = nameTextBox.Text;
            pl.ProductPrice = Convert.ToInt32(priceTextBox.Text);
            laundry.AddToPriceLists(pl);
            laundry.SaveChanges();
        }
        //END

        //Berhubungan dengan UpdateButton
        //update isi textbox
        private void updateDataOnTextBox()
        {
            idTextBox.Text = id;
            nameTextBox.Text = name;
            priceTextBox.Text = price.ToString();
            dataGridView1.Enabled = false;
        }
        //update data di gridview
        private void updateDataOnGridView()
        {
            PriceList pl = (from x in laundry.PriceLists
                            where x.ProductID == id
                            select x).SingleOrDefault();
            pl.ProductName = nameTextBox.Text;
            pl.ProductPrice = Convert.ToInt32(priceTextBox.Text);
            laundry.SaveChanges();
            dataGridView1.Refresh();
        }
        //END
        
        //Berhubungan dengan DeleteButton
        private void deleteData()
        {
            PriceList pl = (from x in laundry.PriceLists
                            where x.ProductID == id
                            select x).SingleOrDefault();
            laundry.DeleteObject(pl);
            laundry.SaveChanges();
        }
        //END
        
        //ActionChange
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
            id = selectedRow.Cells[0].Value.ToString();
            name = selectedRow.Cells[1].Value.ToString();
            price = Convert.ToInt32(selectedRow.Cells[2].Value.ToString());
        }
        //END

        //Koleksi button click
        //Insert Button
        private void insertButton_Click(object sender, EventArgs e)
        {
            //validasi tombol yg diklik
            insertButtonClicked = true;
            updateButtonClicked = deleteButtonClicked = false;

            idTextBox.Enabled = true;
            nameTextBox.Enabled = true;
            priceTextBox.Enabled = true;
            List<PriceList> query = (from x in laundry.PriceLists
                                     select x).ToList();
            int count;
            if (query.Count != 0)
            {
                count = Convert.ToInt32(query[query.Count - 1].ProductID.ToString().Substring(2, 3));
                ++count;
            }
            else
            {
                count = 1;
            }
            if (count < 10)
            {
                idTextBox.Text = "PD00" + count;
            }
            else if (count < 100)
            {
                idTextBox.Text = "PD0" + count;
            }
            else
            {
                idTextBox.Text = "PD" + count;
            }
            insertButton.Enabled = false;
            updateButton.Enabled = false;
            deleteButton.Enabled = false;
            saveButton.Enabled = true;
            cancelButton.Enabled = true;
        }
        //Update Button Kalau Diklik
        private void updateButton_Click(object sender, EventArgs e)
        {


            if (dataGridView1.CurrentCell.RowIndex == -1)
            {
                MessageBox.Show("Select product first");
            }
            else
            {
                //validasi tombol yg diklik
                updateButtonClicked = true;
                insertButtonClicked = deleteButtonClicked = false;
                //Buat button save dan cancel saja yg bisa diklik
                idTextBox.Enabled = false;
                insertButton.Enabled = false;
                updateButton.Enabled = false;
                deleteButton.Enabled = false;
                saveButton.Enabled = true;
                cancelButton.Enabled = true;
                nameTextBox.Enabled = true;
                priceTextBox.Enabled = true;
                updateDataOnTextBox();
            }
        }
        //Delete button
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
                //validasi tombol yg diklik
                updateButtonClicked = true;
                insertButtonClicked = deleteButtonClicked = false;
                //Buat button save dan cancel saja yg bisa diklik
                idTextBox.Enabled = false;
                insertButton.Enabled = false;
                updateButton.Enabled = false;
                deleteButton.Enabled = false;
                saveButton.Enabled = true;
                cancelButton.Enabled = true;
                nameTextBox.Enabled = true;
                priceTextBox.Enabled = true;
                updateDataOnTextBox();
                deleteData();
                updateTable();
                resetState();
            }
        }

        //Save Button
        private void saveButton_Click(object sender, EventArgs e)
        {
            bool flag = true;
            String msg = "";
            if (nameTextBox.Text == "")
            {
                msg += "Please Fill the Laundry Name Field!";
                flag = false;
            }
            if (!nameTextBox.Text.All(char.IsLetter) && !nameTextBox.Text.All(char.IsWhiteSpace))
            {
                msg += "\nLaundry Name must be alphabet only";
                flag = false;
            }
            if (priceTextBox.Text == "")
            {
                msg += "\nPlease Fill the Laundry Price Field";
                flag = false;
            }
            if (!priceTextBox.Text.All(char.IsNumber))
            {
                msg += "\nLaundry Price must be Numeric";
                flag = false;
            }
            if (flag)
            {
                if (insertButtonClicked)
                {
                    insertNew();
                    updateTable();
                }
                if (updateButtonClicked)
                {
                    updateDataOnGridView();
                    dataGridView1.Enabled = true;
                    updateTable();

                }
                if (deleteButtonClicked)
                {

                }
                resetState();
            }
            else
            {
                MessageBox.Show(msg);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            resetState();
        }
        //END
    }
}
