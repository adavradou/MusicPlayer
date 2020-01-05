using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalTask
{
    class SongList
    {

        public String name;
        public String path;

        public SongList(String newName, String newPath) //Constructor
        {
            name = newName;
            path = newPath;
        }

        ~SongList() //Destructor
        {
            //MessageBox.Show(this.GetHashCode().ToString());
        }

    }
}
