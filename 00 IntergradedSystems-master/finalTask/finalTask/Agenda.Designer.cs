namespace finalTask
{
    partial class Agenda
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.showContactsbtn = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.createConBtn = new System.Windows.Forms.Button();
            this.Namelbl = new System.Windows.Forms.Label();
            this.lastNamelbl = new System.Windows.Forms.Label();
            this.mobileLbl = new System.Windows.Forms.Label();
            this.emaillbl = new System.Windows.Forms.Label();
            this.datelbl = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.dateBox = new System.Windows.Forms.TextBox();
            this.mailBox = new System.Windows.Forms.TextBox();
            this.MobileBox = new System.Windows.Forms.TextBox();
            this.lastNameBox = new System.Windows.Forms.TextBox();
            this.addConBtn = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.NameSearch = new System.Windows.Forms.CheckBox();
            this.lastNameSearch = new System.Windows.Forms.CheckBox();
            this.mobileSearch = new System.Windows.Forms.CheckBox();
            this.pathButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // showContactsbtn
            // 
            this.showContactsbtn.Location = new System.Drawing.Point(12, 32);
            this.showContactsbtn.Name = "showContactsbtn";
            this.showContactsbtn.Size = new System.Drawing.Size(133, 23);
            this.showContactsbtn.TabIndex = 1;
            this.showContactsbtn.Text = "Show Contacts";
            this.showContactsbtn.UseVisualStyleBackColor = true;
            this.showContactsbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(23, 495);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(524, 191);
            this.listBox1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(23, 88);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(524, 310);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_UserDeletedRow);
            // 
            // createConBtn
            // 
            this.createConBtn.Location = new System.Drawing.Point(586, 32);
            this.createConBtn.Name = "createConBtn";
            this.createConBtn.Size = new System.Drawing.Size(127, 23);
            this.createConBtn.TabIndex = 4;
            this.createConBtn.Text = "Create Contact";
            this.createConBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.createConBtn.UseVisualStyleBackColor = true;
            this.createConBtn.Click += new System.EventHandler(this.addConBtn_Click);
            // 
            // Namelbl
            // 
            this.Namelbl.AutoSize = true;
            this.Namelbl.Location = new System.Drawing.Point(583, 96);
            this.Namelbl.Name = "Namelbl";
            this.Namelbl.Size = new System.Drawing.Size(35, 13);
            this.Namelbl.TabIndex = 5;
            this.Namelbl.Text = "Name";
            // 
            // lastNamelbl
            // 
            this.lastNamelbl.AutoSize = true;
            this.lastNamelbl.Location = new System.Drawing.Point(583, 128);
            this.lastNamelbl.Name = "lastNamelbl";
            this.lastNamelbl.Size = new System.Drawing.Size(55, 13);
            this.lastNamelbl.TabIndex = 6;
            this.lastNamelbl.Text = "LastName";
            // 
            // mobileLbl
            // 
            this.mobileLbl.AutoSize = true;
            this.mobileLbl.Location = new System.Drawing.Point(583, 160);
            this.mobileLbl.Name = "mobileLbl";
            this.mobileLbl.Size = new System.Drawing.Size(38, 13);
            this.mobileLbl.TabIndex = 7;
            this.mobileLbl.Text = "Mobile";
            // 
            // emaillbl
            // 
            this.emaillbl.AutoSize = true;
            this.emaillbl.Location = new System.Drawing.Point(583, 197);
            this.emaillbl.Name = "emaillbl";
            this.emaillbl.Size = new System.Drawing.Size(32, 13);
            this.emaillbl.TabIndex = 8;
            this.emaillbl.Text = "Email";
            // 
            // datelbl
            // 
            this.datelbl.AutoSize = true;
            this.datelbl.Location = new System.Drawing.Point(583, 228);
            this.datelbl.Name = "datelbl";
            this.datelbl.Size = new System.Drawing.Size(66, 13);
            this.datelbl.TabIndex = 9;
            this.datelbl.Text = "Data of Birth";
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(669, 88);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(111, 20);
            this.NameBox.TabIndex = 10;
            this.NameBox.Enter += new System.EventHandler(this.NameBox_Enter);
            // 
            // dateBox
            // 
            this.dateBox.Location = new System.Drawing.Point(669, 228);
            this.dateBox.Name = "dateBox";
            this.dateBox.Size = new System.Drawing.Size(111, 20);
            this.dateBox.TabIndex = 11;
            this.dateBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.dateBox.Enter += new System.EventHandler(this.dateBox_Enter);
            // 
            // mailBox
            // 
            this.mailBox.Location = new System.Drawing.Point(669, 197);
            this.mailBox.Name = "mailBox";
            this.mailBox.Size = new System.Drawing.Size(111, 20);
            this.mailBox.TabIndex = 12;
            this.mailBox.TextChanged += new System.EventHandler(this.mailBox_TextChanged);
            this.mailBox.Enter += new System.EventHandler(this.mailBox_Enter);
            // 
            // MobileBox
            // 
            this.MobileBox.Location = new System.Drawing.Point(669, 160);
            this.MobileBox.Name = "MobileBox";
            this.MobileBox.Size = new System.Drawing.Size(111, 20);
            this.MobileBox.TabIndex = 13;
            this.MobileBox.Enter += new System.EventHandler(this.MobileBox_Enter);
            this.MobileBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MobileBox_KeyPress);
            // 
            // lastNameBox
            // 
            this.lastNameBox.Location = new System.Drawing.Point(669, 125);
            this.lastNameBox.Name = "lastNameBox";
            this.lastNameBox.Size = new System.Drawing.Size(111, 20);
            this.lastNameBox.TabIndex = 14;
            this.lastNameBox.Enter += new System.EventHandler(this.lastNameBox_Enter);
            // 
            // addConBtn
            // 
            this.addConBtn.Location = new System.Drawing.Point(586, 274);
            this.addConBtn.Name = "addConBtn";
            this.addConBtn.Size = new System.Drawing.Size(80, 23);
            this.addConBtn.TabIndex = 15;
            this.addConBtn.Text = "Add Contact";
            this.addConBtn.UseVisualStyleBackColor = true;
            this.addConBtn.Click += new System.EventHandler(this.addConBtn_Click_1);
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(23, 459);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(100, 20);
            this.searchBox.TabIndex = 16;
            this.searchBox.Text = "Type to Search";
            this.searchBox.Click += new System.EventHandler(this.searchBox_Click);
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // NameSearch
            // 
            this.NameSearch.AutoSize = true;
            this.NameSearch.Location = new System.Drawing.Point(129, 462);
            this.NameSearch.Name = "NameSearch";
            this.NameSearch.Size = new System.Drawing.Size(60, 17);
            this.NameSearch.TabIndex = 17;
            this.NameSearch.Text = "Όνομα";
            this.NameSearch.UseVisualStyleBackColor = true;
            this.NameSearch.CheckedChanged += new System.EventHandler(this.NameSearch_CheckedChanged);
            // 
            // lastNameSearch
            // 
            this.lastNameSearch.AutoSize = true;
            this.lastNameSearch.Location = new System.Drawing.Point(215, 462);
            this.lastNameSearch.Name = "lastNameSearch";
            this.lastNameSearch.Size = new System.Drawing.Size(70, 17);
            this.lastNameSearch.TabIndex = 18;
            this.lastNameSearch.Text = "Επώνυμο";
            this.lastNameSearch.UseVisualStyleBackColor = true;
            this.lastNameSearch.CheckedChanged += new System.EventHandler(this.lastNameSearch_CheckedChanged);
            // 
            // mobileSearch
            // 
            this.mobileSearch.AutoSize = true;
            this.mobileSearch.Location = new System.Drawing.Point(301, 462);
            this.mobileSearch.Name = "mobileSearch";
            this.mobileSearch.Size = new System.Drawing.Size(77, 17);
            this.mobileSearch.TabIndex = 19;
            this.mobileSearch.Text = "Τηλέφωνο";
            this.mobileSearch.UseVisualStyleBackColor = true;
            this.mobileSearch.CheckedChanged += new System.EventHandler(this.mobileSearch_CheckedChanged);
            // 
            // pathButton
            // 
            this.pathButton.Location = new System.Drawing.Point(249, 32);
            this.pathButton.Name = "pathButton";
            this.pathButton.Size = new System.Drawing.Size(197, 23);
            this.pathButton.TabIndex = 20;
            this.pathButton.Text = "SELECT TXT FILE";
            this.pathButton.UseVisualStyleBackColor = true;
            this.pathButton.Click += new System.EventHandler(this.pathButton_Click);
            // 
            // Agenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 698);
            this.Controls.Add(this.pathButton);
            this.Controls.Add(this.mobileSearch);
            this.Controls.Add(this.lastNameSearch);
            this.Controls.Add(this.NameSearch);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.addConBtn);
            this.Controls.Add(this.lastNameBox);
            this.Controls.Add(this.MobileBox);
            this.Controls.Add(this.mailBox);
            this.Controls.Add(this.dateBox);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.datelbl);
            this.Controls.Add(this.emaillbl);
            this.Controls.Add(this.mobileLbl);
            this.Controls.Add(this.lastNamelbl);
            this.Controls.Add(this.Namelbl);
            this.Controls.Add(this.createConBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.showContactsbtn);
            this.Name = "Agenda";
            this.Text = "Contacts";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button showContactsbtn;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button createConBtn;
        private System.Windows.Forms.Label Namelbl;
        private System.Windows.Forms.Label lastNamelbl;
        private System.Windows.Forms.Label mobileLbl;
        private System.Windows.Forms.Label emaillbl;
        private System.Windows.Forms.Label datelbl;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox dateBox;
        private System.Windows.Forms.TextBox mailBox;
        private System.Windows.Forms.TextBox MobileBox;
        private System.Windows.Forms.TextBox lastNameBox;
        private System.Windows.Forms.Button addConBtn;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.CheckBox NameSearch;
        private System.Windows.Forms.CheckBox lastNameSearch;
        private System.Windows.Forms.CheckBox mobileSearch;
        private System.Windows.Forms.Button pathButton;
    }
}