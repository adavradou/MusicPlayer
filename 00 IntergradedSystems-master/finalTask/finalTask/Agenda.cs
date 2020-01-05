using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using finalTask.Classes;
using System.Security;
using System.Drawing;
using System.Text.RegularExpressions;

namespace finalTask
{
    public partial class Agenda : Form
    {//wtf
        BindingSource bs = new BindingSource();
        BindingSource bs2 = new BindingSource();
        BindingSource bs3 = new BindingSource();    
        public List<string> inputCons = new List<string>(); // tmp 
        String globalFilePath = "";
               
        public void readContactsFile(){
            int counter = 0; string line;
            try{
                //System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\User\source\gitHub\IDE\IntergradedSystems\finalTask\finalTask\contacts.txt");              
                if (globalFilePath == "")
                {
                    MessageBox.Show("Please Select File first");
                    return;
                }
                System.IO.StreamReader file = new System.IO.StreamReader(globalFilePath);
                

                while ((line = file.ReadLine()) != null) {
                    if (line!= "     "){
                        inputCons.Add(line);
                        counter++;                        
                    }                    
                  //System.Console.WriteLine(line+" me counter "+counter);
                }
                file.Close();
            }
            catch (FileNotFoundException ex){
                MessageBox.Show(ex.ToString());
            }
        }            
        
        public Agenda(){
            InitializeComponent();
            //this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            
            dataGridView1.DataSource = bs3;
            
            CenterToParent();
           // readContactsFile();
            hideAdd();
            MobileBox.MaxLength = 10;
            //this.Owner.Show();
        }

        public void hideAdd()
        {
            this.NameBox.Hide();this.Namelbl.Hide();
            this.lastNameBox.Hide();this.lastNamelbl.Hide();
            this.mailBox.Hide(); this.emaillbl.Hide();
            this.MobileBox.Hide();this.mobileLbl.Hide();
            this.dateBox.Hide();this.datelbl.Hide();
            this.addConBtn.Hide();
        }

        public void showAdd()
        {
            this.NameBox.Show(); this.Namelbl.Show();
            this.lastNameBox.Show(); this.lastNamelbl.Show();
            this.mailBox.Show(); this.emaillbl.Show();
            this.MobileBox.Show(); this.mobileLbl.Show();
            this.dateBox.Show(); this.datelbl.Show();
            this.addConBtn.Show();
        }       

        string testRead() {

            OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sr = new StreamReader(openFileDialog1.FileName);                    
                    return openFileDialog1.FileName;
                }
                catch (SecurityException ex )
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return "";
        }

        private bool checkFormat(string[] values)
        {
            if(values.Length != 5 && values.ElementAt(5)!="")
            {   
                MessageBox.Show("Λάθος φορμάτ αρχείο ");                
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e){
            
            this.dataGridView1.Show();
            hideAdd();
            this.Owner.Show();
            
            IEnumerable<string> conView = inputCons;              
                        
            DataTable table = new DataTable(); // setting the columns of the table
            inputCons.Clear();  // resets the tmp string
            readContactsFile(); //resets the table           
            table.Reset();

            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("lastName", typeof(string));
            table.Columns.Add("Telephone", typeof(string));
            table.Columns.Add("Email", typeof(string));
            table.Columns.Add("Date of Birth", typeof(string));

            // filling the rows of the table            
            foreach (string tmp in inputCons){
                 
                string[] values = tmp.Split(' '); // ka8e index name last mobile email date
                if (!checkFormat(values)){
                    return;
                }
                
                Task.Factory.StartNew(() => checkBirthday(values.ElementAt(0), values.ElementAt(1), values.ElementAt(2), values.ElementAt(3), values.ElementAt(4)));                                
                table.Rows.Add(new object[] { values.ElementAt(0), values.ElementAt(1), values.ElementAt(2), values.ElementAt(3), values.ElementAt(4)});
                
            }

            //dataGridView1.DataSource = table;
            
            bs3.DataSource = table;
            bs3.ResetBindings(true);
            //dataGridView1.DataSource = bs2;
            bs.ResetBindings(true);
            
            //DATE FORMATTTTTTTTTTTTTTTTTTTTTTT
            string lol = DateTime.Now.ToString();
            string s = DateTime.Now.ToString("dd/MM/yyyy");
            lol = s;
            //MessageBox.Show(s);

            /*if (lol == "15-05-2019")
                MessageBox.Show("happy");
            else
                MessageBox.Show(lol);*/
            //bs2.DataSource = conView;
            //bs2.ResetBindings(true);
            //dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        }             

        public void checkBirthday(string name,string last,string mobile,string mail,string date)
        {

            string currDate = DateTime.Now.ToString("dd/MM/yyyy");
            if(date[0] == currDate[0] && date[1] == currDate[1] && date[3] == currDate[3] && date[4] == currDate[4])
            {
                MessageBox.Show("Wish Happy Birthday to " + name + " " + last + " call him at "+mobile+" or email him at: "+ mail);
            }
        }


        private void addConBtn_Click(object sender, EventArgs e)
        {
            showAdd();
            this.dataGridView1.Hide();
        }      

        
        
        // na pernaei to string ths epafis kai na bainei swsta /source/gitHub/IDE/IntergradedSystems (master)           

        public bool addContact(string name,string lastName, string mobile,string mail,string date)
        {
            //string path = @"C:\Users\User\source\gitHub\IDE\IntergradedSystems\finalTask\finalTask\contacts.txt";
            string path = globalFilePath;
            if(path==""){
                MessageBox.Show("Please Select File first");
                return false;
            }
            try
            {
                if (File.Exists(path))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        //sw.WriteLine("Hello darkness my old friend ");
                        Contact toAdd = new Contact(name, lastName, mobile, mail, date);
                        sw.WriteLine(toAdd.toString());
                        //sw.WriteLine(name + " " + lastName + " " + mobile +" "+ mail + " " + date);
                        sw.Close();
                    }                   
                }                
                return true;
            }
            catch(Exception ex){
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        private void addConBtn_Click_1(object sender, EventArgs e)
        {
            bool correct = true;
            if(MobileBox.TextLength != 10 ){
                MobileBox.BackColor = Color.Yellow;
                MobileBox.Text = "10 Νούμερα";
                correct = false;
            }
            if(!mailCheck(mailBox.Text))
            {
                mailBox.Text = "Εισάγεται Email";
                mailBox.BackColor = Color.Yellow;
                correct = false;
            }
            if (NameBox.Text.Length <= 0) { correct = false; NameBox.Text = "Συμπληρώστε"; }
            if (lastNameBox.Text.Length <= 0) { correct = false; lastNameBox.Text ="Συμπληρώστε"; }
            if (mailBox.Text.Length <= 3) { correct = false; mailBox.Text = "Συμπληρώστε"; mailBox.BackColor = Color.Yellow; }
            if (dateBox.Text.Length <= 3) { correct = false; dateBox.Text = "Συμπληρώστε"; dateBox.BackColor = Color.Yellow; }

            if (correct)
            {                
                if (addContact(NameBox.Text,lastNameBox.Text,MobileBox.Text,mailBox.Text,dateBox.Text))
                    MessageBox.Show("Η επαφή προστέθηκε","Προσθήκη Επαφής",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                else
                    MessageBox.Show("Η επαφή δε προστέθηκε", "Αποτυχία Προσθήκη Επαφής", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MobileBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            MobileBox.BackColor = Color.White;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) ){
                  e.Handled = true;
               }            
        }

        private void mailBox_TextChanged(object sender, EventArgs e)
        {
            mailBox.BackColor = Color.White;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dateBox.BackColor = Color.White;
        }

        /*
           public bool addContact(string name,string lastName, string mobile,string mail,string date)
        {
            string path = @"C:\Users\User\source\gitHub\IDE\IntergradedSystems\finalTask\finalTask\contacts.txt";
            try
            {
                if (File.Exists(path))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        //sw.WriteLine("Hello darkness my old friend ");
                        sw.WriteLine(name + " " + lastName + " " + mobile +" "+ mail + " " + date);
                    }                    
                }
                return true;
            }
            catch(Exception ex){
                MessageBox.Show(ex.ToString());
                return false;
            }
            */

        public void update(){ 
            //string path = @"C:\Users\User\source\gitHub\IDE\IntergradedSystems\finalTask\finalTask\contacts.txt";
            string path = globalFilePath;
            File.WriteAllText(path, "");
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {               
                try
                {
                    if (File.Exists(path))
                    {
                        using (StreamWriter sw = File.AppendText(path))
                        {
                            for(int i =0;i<5;i++)
                                sw.Write(row.Cells[i].Value + " ");
                            sw.WriteLine();
                        }
                    }
                }
                catch (Exception ex){
                    MessageBox.Show(ex.ToString());                    
                }

               /*for (int i = 0; i < 5; i++)
                   Console.Write(row.Cells[i].Value + " ");
               Console.WriteLine();*/
            }
        }

        public bool isNumeric(string input)
        {
            bool isIntString = input.All(char.IsDigit);
            return isIntString;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {         
            if (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString().Length!=10
                || !isNumeric(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString())) 
            {
                MessageBox.Show("Το τηλέφωνο δεν είναι 10 ψηφία, η αλλαγή δε θα αποθηκευτεί.", "Λάθος Τηλέφωνο", MessageBoxButtons.OK, MessageBoxIcon.Error);
                showContactsbtn.PerformClick();
                return;
            }
            if (!mailCheck(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString())){
                showContactsbtn.PerformClick();
                return;
            }
            //MessageBox.Show(dataGridView1.Rows[1].Cells[2].Value.ToString());
            update();
        }

        public bool mailCheck(string txtEmail)
        {
            Regex mRegxExpression;

            if (txtEmail.Trim() != string.Empty)
            {
                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                if (!mRegxExpression.IsMatch(txtEmail.Trim()))
                {
                    MessageBox.Show("Το email δεν είναι σωστό,η αλλαγή δε θα αποθηκευτεί.", "Λάθος Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void mailBox_Enter(object sender, EventArgs e)
        {
            mailBox.Text = "";
        }

        private void MobileBox_Enter(object sender, EventArgs e)
        {
            MobileBox.Text = "";
            MobileBox.BackColor = Color.White;
        }

        private void NameBox_Enter(object sender, EventArgs e)
        {
            NameBox.Text = "";
        }

        private void lastNameBox_Enter(object sender, EventArgs e)
        {
            lastNameBox.Text = "";
        }

        //delete Contact function
        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e){            
            update();
        }

        public void searchResults()
        {
            bs.DataSource = null;
            bool byName = (NameSearch.CheckState.ToString() == "Checked") ? true : false;
            bool byLast = (lastNameSearch.CheckState.ToString() == "Checked") ? true : false;
            bool byMobile = (mobileSearch.CheckState.ToString() == "Checked") ? true : false;
            
            List<Contact> Contacts = new List<Contact>();
            foreach (string tmp in inputCons) {
                string[] values = tmp.Split(' ');
                Contacts.Add(new Contact(values.ElementAt(0), values.ElementAt(1), values.ElementAt(2), values.ElementAt(3), values.ElementAt(4)));
            }       

            //listBox1.DataSource = bs;

            if (byLast && !byName && !byMobile) //only last name checked
            {
                IEnumerable<Contact> test = Contacts.Where(x => x.getLastName().ToLower().Contains(searchBox.Text.ToLower()));                
                bs.DataSource = test.Select(x => x.getName() + " " + x.getLastName() + " " + x.getTelephone() + " " + x.getEmail() + " " + x.getDate());                
                bs.ResetBindings(true);
                listBox1.DataSource = bs;
            }
            else if (byLast && byName && !byMobile) // lastName and FirstName
            {
                IEnumerable<Contact> test = Contacts.Where(x => x.getName().ToLower().Contains(searchBox.Text.ToLower()));
                IEnumerable<Contact> test1 = Contacts.Where(x => x.getLastName().ToLower().Contains(searchBox.Text.ToLower()));
                IEnumerable<Contact> firstRes = test.Union(test1);
                bs.DataSource = firstRes.Select(x => x.getName() + " " + x.getLastName() + " " + x.getTelephone() + " " + x.getEmail() + " " + x.getDate());

                bs.ResetBindings(true);
                listBox1.DataSource = bs;
            }
            else if(byLast && byName && byMobile)//all selected same as default
            {
                IEnumerable<Contact> test = Contacts.Where(x => x.getLastName().ToLower().Contains(searchBox.Text.ToLower()));
                IEnumerable<Contact> test1 = Contacts.Where(x => x.getName().ToLower().Contains(searchBox.Text.ToLower()));
                IEnumerable<Contact> test2 = Contacts.Where(x => x.getTelephone().ToLower().Contains(searchBox.Text.ToLower()));
                IEnumerable<Contact> firstRes = test.Union(test1);
                IEnumerable<Contact> finalRes = firstRes.Union(test2);
                bs.DataSource = finalRes.Select(x => x.getName() + " " + x.getLastName() + " " + x.getTelephone() + " " + x.getEmail() + " " + x.getDate());

                bs.ResetBindings(true);
                listBox1.DataSource = bs;
            }
            else if(byLast && byMobile && !byName) // lastName and Mobile
            {
                IEnumerable<Contact> test = Contacts.Where(x => x.getTelephone().ToLower().Contains(searchBox.Text.ToLower()));
                IEnumerable<Contact> test1 = Contacts.Where(x => x.getLastName().ToLower().Contains(searchBox.Text.ToLower()));
                IEnumerable<Contact> firstRes = test.Union(test1);
                bs.DataSource = firstRes.Select(x => x.getName() + " " + x.getLastName() + " " + x.getTelephone() + " " + x.getEmail() + " " + x.getDate());

                bs.ResetBindings(true);
                listBox1.DataSource = bs;
            }
            else if(byName &&!byLast && !byMobile)// only firstName
            {
                IEnumerable<Contact> test = Contacts.Where(x => x.getName().ToLower().Contains(searchBox.Text.ToLower()));
                bs.DataSource = test.Select(x => x.getName() + " " + x.getLastName() + " " + x.getTelephone() + " " + x.getEmail() + " " + x.getDate());
                bs.ResetBindings(true);
                listBox1.DataSource = bs;
            }
            else if(byName && byMobile && !byLast) // firstName and Mobile
            {
                IEnumerable<Contact> test = Contacts.Where(x => x.getTelephone().ToLower().Contains(searchBox.Text.ToLower()));
                IEnumerable<Contact> test1 = Contacts.Where(x => x.getName().ToLower().Contains(searchBox.Text.ToLower()));
                IEnumerable<Contact> firstRes = test.Union(test1);
                bs.DataSource = firstRes.Select(x => x.getName() + " " + x.getLastName() + " " + x.getTelephone() + " " + x.getEmail() + " " + x.getDate());

                bs.ResetBindings(true);
                listBox1.DataSource = bs;
            }
            else if(byMobile &&!byName && !byLast)// mobile Only
            {
                IEnumerable<Contact> test = Contacts.Where(x => x.getTelephone().ToLower().Contains(searchBox.Text.ToLower()));
                bs.DataSource = test.Select(x => x.getName() + " " + x.getLastName() + " " + x.getTelephone() + " " + x.getEmail() + " " + x.getDate());
                bs.ResetBindings(true);
                listBox1.DataSource = bs;
            }
            else
            {
                IEnumerable<Contact> test = Contacts.Where(x => x.getLastName().ToLower().Contains(searchBox.Text.ToLower()) );
                IEnumerable<Contact> test1= Contacts.Where(x => x.getName().ToLower().Contains(searchBox.Text.ToLower()));
                IEnumerable<Contact> test2 = Contacts.Where(x => x.getTelephone().ToLower().Contains(searchBox.Text.ToLower()));
                IEnumerable<Contact> firstRes = test.Union(test1);
                IEnumerable<Contact> finalRes = firstRes.Union(test2);
                bs.DataSource = finalRes.Select(x => x.getName() + " " + x.getLastName() + " " + x.getTelephone() + " " + x.getEmail() + " " + x.getDate());                
                
                bs.ResetBindings(true);
                listBox1.DataSource = bs;
            }

           // bs.DataSource = Contacts.Select(x => x.getName() + " "+ x.getLastName());

            bs.ResetBindings(true);

        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            searchResults();
        }

        private void searchBox_Click(object sender, EventArgs e)
        {
            searchBox.Text = "";
        }

        private void NameSearch_CheckedChanged(object sender, EventArgs e)
        {
            searchResults();
        }

        private void lastNameSearch_CheckedChanged(object sender, EventArgs e)
        {
            searchResults();
        }

        private void mobileSearch_CheckedChanged(object sender, EventArgs e)
        {
            searchResults();
        }

        private void pathButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sr = new StreamReader(openFileDialog1.FileName);
                    //MessageBox.Show(sr.ReadToEnd().ToString());  content of txt
                    //   MessageBox.Show(openFileDialog1.FileName); // full path
                    //     MessageBox.Show(Path.GetDirectoryName(openFileDialog1.FileName));
                    globalFilePath = openFileDialog1.FileName;                    
                    sr.Close();
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            showContactsbtn.PerformClick();
        }

        private void dateBox_Enter(object sender, EventArgs e)
        {
            dateBox.Text = "";
        }
    }
}
