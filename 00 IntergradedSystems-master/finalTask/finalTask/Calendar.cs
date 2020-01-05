using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalTask
{
    public partial class Calendar : Form
    {

        Dictionary<string, DailySchedule> allDaysSchedule = new Dictionary<string, DailySchedule>(); //Holds all the dates containing notes in the schedule.         

        public Calendar()
        {
            InitializeComponent();

            addHolidays(); //Public holidays will be shown bolded on the calendar. 
        }

        private void addHolidays()
        {
            DateTime myVacation1 = new DateTime(2019, 1, 1);
            DateTime myVacation2 = new DateTime(2019, 1, 6);
            DateTime myVacation3 = new DateTime(2019, 3, 25);
            DateTime myVacation4 = new DateTime(2019, 5, 1);
            DateTime myVacation5 = new DateTime(2019, 8, 15);
            DateTime myVacation6 = new DateTime(2019, 10, 28);
            DateTime myVacation7 = new DateTime(2019, 12, 25);
            DateTime myVacation8 = new DateTime(2019, 12, 26);

            monthCalendar1.AddAnnuallyBoldedDate(myVacation1);
            monthCalendar1.AddAnnuallyBoldedDate(myVacation2);
            monthCalendar1.AddAnnuallyBoldedDate(myVacation3);
            monthCalendar1.AddAnnuallyBoldedDate(myVacation4);
            monthCalendar1.AddAnnuallyBoldedDate(myVacation5);
            monthCalendar1.AddAnnuallyBoldedDate(myVacation6);
            monthCalendar1.AddAnnuallyBoldedDate(myVacation7);
            monthCalendar1.AddAnnuallyBoldedDate(myVacation8);


        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
                       

            for (int i = 1; i <= 5; i++) //Loop in every textBox and clear the entries.
            {
                TextBox textBox = (TextBox)Controls["textBox" + i]; //get their texts
                textBox.Text = "";

            }
            

            foreach (KeyValuePair<string, DailySchedule> kvp in allDaysSchedule) //If this date contains notes, load them in the textboxes. 
            {
                if (kvp.Value.date == monthCalendar1.SelectionRange.Start.ToShortDateString())
                {

                    textBox1.Text = kvp.Value.text1;
                    textBox2.Text = kvp.Value.text2;
                    textBox3.Text = kvp.Value.text3;
                    textBox4.Text = kvp.Value.text4;
                    textBox5.Text = kvp.Value.text5;

                }
            }

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            addButton.Enabled = false;
            monthCalendar1.Enabled = false;
            saveButton.Enabled = true;
            cancelButton.Enabled = true;

            for (int i = 1; i <= 5; i++) //Enable all the textBoxes.
            {
                TextBox textBox = (TextBox)Controls["textBox" + i];
                textBox.Enabled = true;
            }

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
           
            if (allDaysSchedule.ContainsKey(monthCalendar1.SelectionRange.Start.ToShortDateString())) //If the dictionary contains an entry with this date, remove it.
            {
                allDaysSchedule.Remove(monthCalendar1.SelectionRange.Start.ToShortDateString());
            }

            DailySchedule currentDate = new DailySchedule() //Create a new entry for the dictionary with all the notes in the textBoxes. 
            {
                date = monthCalendar1.SelectionRange.Start.ToShortDateString(),
                text1 = textBox1.Text,
                text2 = textBox2.Text,
                text3 = textBox3.Text,
                text4 = textBox4.Text,
                text5 = textBox5.Text
            };

            allDaysSchedule.Add(currentDate.date, currentDate); //Add the selected data as a key and the list as a value in the dictionary.



            addButton.Enabled = true;
            monthCalendar1.Enabled = true;
            saveButton.Enabled = false;
            cancelButton.Enabled = false;

            for (int i = 1; i <= 5; i++)
            {
                TextBox textBox = (TextBox)Controls["textBox" + i];
                textBox.Enabled = false;
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            addButton.Enabled = true;
            monthCalendar1.Enabled = true;
            saveButton.Enabled = false;
            cancelButton.Enabled = false;

            for (int i = 1; i <= 5; i++)
            {
                TextBox textBox = (TextBox)Controls["textBox" + i];
                textBox.Enabled = false;
            }
        }

    }

}
