namespace ProjectOODB
{
    partial class MasterLaundryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.detailGroupBox = new System.Windows.Forms.GroupBox();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.priceLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.laundryLabel = new System.Windows.Forms.Label();
            this.controllerGroupBox = new System.Windows.Forms.GroupBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.insertButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.laundryDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.laundryDataSet = new ProjectOODB.LaundryDataSet();
            this.detailGroupBox.SuspendLayout();
            this.controllerGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laundryDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laundryDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Turquoise;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(159, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Master Laundry Form";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // detailGroupBox
            // 
            this.detailGroupBox.Controls.Add(this.priceTextBox);
            this.detailGroupBox.Controls.Add(this.nameTextBox);
            this.detailGroupBox.Controls.Add(this.idTextBox);
            this.detailGroupBox.Controls.Add(this.priceLabel);
            this.detailGroupBox.Controls.Add(this.nameLabel);
            this.detailGroupBox.Controls.Add(this.laundryLabel);
            this.detailGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailGroupBox.Location = new System.Drawing.Point(12, 256);
            this.detailGroupBox.Name = "detailGroupBox";
            this.detailGroupBox.Size = new System.Drawing.Size(294, 174);
            this.detailGroupBox.TabIndex = 1;
            this.detailGroupBox.TabStop = false;
            this.detailGroupBox.Text = "Detail";
            // 
            // priceTextBox
            // 
            this.priceTextBox.Enabled = false;
            this.priceTextBox.Location = new System.Drawing.Point(165, 116);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(112, 26);
            this.priceTextBox.TabIndex = 3;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Enabled = false;
            this.nameTextBox.Location = new System.Drawing.Point(165, 77);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(112, 26);
            this.nameTextBox.TabIndex = 3;
            // 
            // idTextBox
            // 
            this.idTextBox.Enabled = false;
            this.idTextBox.Location = new System.Drawing.Point(165, 45);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(112, 26);
            this.idTextBox.TabIndex = 3;
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(16, 119);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(44, 20);
            this.priceLabel.TabIndex = 2;
            this.priceLabel.Text = "Price";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(14, 81);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(112, 20);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Laundry Name";
            // 
            // laundryLabel
            // 
            this.laundryLabel.AutoSize = true;
            this.laundryLabel.Location = new System.Drawing.Point(15, 45);
            this.laundryLabel.Name = "laundryLabel";
            this.laundryLabel.Size = new System.Drawing.Size(87, 20);
            this.laundryLabel.TabIndex = 0;
            this.laundryLabel.Text = "Laundry ID";
            // 
            // controllerGroupBox
            // 
            this.controllerGroupBox.Controls.Add(this.cancelButton);
            this.controllerGroupBox.Controls.Add(this.saveButton);
            this.controllerGroupBox.Controls.Add(this.deleteButton);
            this.controllerGroupBox.Controls.Add(this.updateButton);
            this.controllerGroupBox.Controls.Add(this.insertButton);
            this.controllerGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controllerGroupBox.Location = new System.Drawing.Point(339, 256);
            this.controllerGroupBox.Name = "controllerGroupBox";
            this.controllerGroupBox.Size = new System.Drawing.Size(250, 174);
            this.controllerGroupBox.TabIndex = 2;
            this.controllerGroupBox.TabStop = false;
            this.controllerGroupBox.Text = "Controller";
            // 
            // cancelButton
            // 
            this.cancelButton.Enabled = false;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(137, 96);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(91, 30);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(137, 60);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(91, 30);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Location = new System.Drawing.Point(20, 114);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(91, 30);
            this.deleteButton.TabIndex = 0;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // updateButton
            // 
            this.updateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateButton.Location = new System.Drawing.Point(20, 77);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(91, 30);
            this.updateButton.TabIndex = 0;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // insertButton
            // 
            this.insertButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.insertButton.Location = new System.Drawing.Point(20, 41);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(91, 30);
            this.insertButton.TabIndex = 0;
            this.insertButton.Text = "Insert";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(577, 179);
            this.dataGridView1.TabIndex = 3;
            // 
            // laundryDataSetBindingSource
            // 
            this.laundryDataSetBindingSource.DataSource = this.laundryDataSet;
            this.laundryDataSetBindingSource.Position = 0;
            // 
            // laundryDataSet
            // 
            this.laundryDataSet.DataSetName = "LaundryDataSet";
            this.laundryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // MasterLaundryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(601, 451);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.controllerGroupBox);
            this.Controls.Add(this.detailGroupBox);
            this.Controls.Add(this.label1);
            this.Name = "MasterLaundryForm";
            this.Text = "MasterLaundryForm";
            this.detailGroupBox.ResumeLayout(false);
            this.detailGroupBox.PerformLayout();
            this.controllerGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laundryDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laundryDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox detailGroupBox;
        private System.Windows.Forms.GroupBox controllerGroupBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource laundryDataSetBindingSource;
        private LaundryDataSet laundryDataSet;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label laundryLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button insertButton;
    }
}