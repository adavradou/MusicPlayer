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
    public partial class Form1 : Form
    {
        public Form1(){
            InitializeComponent();
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e){
            Agenda agenda = new Agenda();
            agenda.Show(this);
           // this.Hide();
        }

        private void button2_Click(object sender, EventArgs e){
            Calendar calendar = new Calendar();
            calendar.Show(this);

        }

        private void button3_Click(object sender, EventArgs e){
            MusicPlayer musicPlayer = new MusicPlayer();
            musicPlayer.Show(this);
        }
    }

}
