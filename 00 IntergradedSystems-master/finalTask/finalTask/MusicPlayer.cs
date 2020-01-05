using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace finalTask
{


    public partial class MusicPlayer : Form
    {

        string[] filesNames, paths;
        string[] allFilenames, allPaths;
        int counter = 0;
        ArrayList sortList = new ArrayList();
        List<string> listBoxItems = new List<string>();

        DataTable dt = new DataTable();
               

        public MusicPlayer()
        {
            InitializeComponent();

            dataGridView1.DataSource = dt;
            dt.Clear();
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("Name"), new DataColumn("Path") });
        }


        private void searchTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void searchTextBox_Enter(object sender, EventArgs e)
        {   
        }

        private void searchTextBox_Leave(object sender, EventArgs e)
        {
            
        }
               

        private void removeButton_Click(object sender, EventArgs e)
        {

            //Delete the selected row in the dataGridView.
            try
            { 
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);

                //Update the current playlist by reading all the files on the dataGridView. 
                allFilenames = getSongsInPlaylist("Name"); //get all the name files shown on the dataGridView.
                allPaths = getSongsInPlaylist("Path"); //get all the paths of the songs shown on the dataGridView.


                //Create a Media playlist with all the items in the listBox.
                List<string> listPaths = dataGridView1.Rows.OfType<DataGridViewRow>().Where(x => x.Cells[1].Value != null).Select(x => x.Cells[1].Value.ToString()).ToList(); //get all the paths of the dataGridView.
                foreach (var item in listPaths)
                {
                    listBox5.Items.Add(item); //Add all the paths of the dataGridView in a listBox.
                }

                ListBox.ObjectCollection list = listBox5.Items;

                WMPLib.IWMPPlaylist playlist = axWindowsMediaPlayer1.playlistCollection.newPlaylist("myplaylist");
                WMPLib.IWMPMedia media;
                foreach (object item in listPaths)
                {
                    media = axWindowsMediaPlayer1.newMedia((string)item);
                    playlist.appendItem(media);
                }
                axWindowsMediaPlayer1.currentPlaylist = playlist;
                axWindowsMediaPlayer1.Ctlcontrols.play(); //Start playing the songs in the playlist    


            }
            catch (Exception) { }    

        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
        }


        private void shuffleBox_CheckedChanged(object sender, EventArgs e)
        {
            counter = counter + 1;

            if (counter % 2 == 0)
            {
                shuffleBox.Checked = false;

                string[] sortedFileNames = allFilenames;
                string[] sortedPaths = allPaths;

                //Instantiate the reverse comparer.
                IComparer revComparer = new ReverseComparer();
                Array.Sort(sortedFileNames);
                Array.Sort(sortedPaths);


                //Delete everything in the dataGridView.
                do
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        try
                        {
                            dataGridView1.Rows.Remove(row);
                        }
                        catch (Exception) { }
                    }
                } while (dataGridView1.Rows.Count > 1);


                //Add the shuffled songs to the dataGridView.
                for (int i = 0; i < sortedFileNames.Length; i++)
                {
                    //Dislay the playlist on a DataGridView. The first column holds the filenames and the second the file paths. 
                    try
                    {
                        fillDataTable(allFilenames[i], allPaths[i]);
                    }
                    catch (Exception ex)
                    {
                    }
                }


                //Create a Media playlist with all the items in the listbox.
                List<string> listPaths = dataGridView1.Rows.OfType<DataGridViewRow>().Where(x => x.Cells[1].Value != null).Select(x => x.Cells[1].Value.ToString()).ToList(); //get all the paths of the dataGridView.
                foreach (var item in listPaths)
                {
                    listBox5.Items.Add(item); //Add all the paths of the dataGridView in a listBox.
                }

                ListBox.ObjectCollection list = listBox5.Items;

                WMPLib.IWMPPlaylist playlist = axWindowsMediaPlayer1.playlistCollection.newPlaylist("myplaylist");
                WMPLib.IWMPMedia media;
                foreach (object item in listPaths)
                {
                    media = axWindowsMediaPlayer1.newMedia((string)item);
                    playlist.appendItem(media);
                }
                axWindowsMediaPlayer1.currentPlaylist = playlist;
                axWindowsMediaPlayer1.Ctlcontrols.play(); //Start playing the songs in the playlist    
            


            }
            else
            {                
                    shuffleBox.Checked = true;

                    string[] shuffledFileNames = allFilenames;
                    string[] shuffledPaths = allPaths;

                    Random random = new Random();

                    for (int i = 0; i < allPaths.Length; i++)
                    {
                        //Change the order of the media playlist.

                        int w = random.Next(shuffledFileNames.Length);

                        string value2 = shuffledFileNames[i];
                        shuffledFileNames[i] = shuffledFileNames[w];
                        shuffledFileNames[w] = value2;

                        //Change the order of the listbox.
                        string value1 = shuffledPaths[i];
                        shuffledPaths[i] = shuffledPaths[w];
                        shuffledPaths[w] = value1;
                    }

                    //Delete everything in the dataGridView.
                    do
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            try
                            {
                                dataGridView1.Rows.Remove(row);
                            }
                            catch (Exception) { }
                        }
                    } while (dataGridView1.Rows.Count > 1);


                //Add the shuffled songs to the dataGridView.
                for (int i = 0; i < shuffledFileNames.Length; i++)
                    {

                    //Dislay the playlist on a DataGridView. The first column holds the filenames and the second the file paths. 
                    try
                    {

                        fillDataTable(allFilenames[i], allPaths[i]);

                    }
                    catch (Exception ex)
                        {
                        }                
                    }    
            

                    //Create a Media playlist with all the items in the listbox.
                    List<string> listPaths = dataGridView1.Rows.OfType<DataGridViewRow>().Where(x => x.Cells[1].Value != null).Select(x => x.Cells[1].Value.ToString()).ToList(); //get all the paths of the dataGridView.
                    foreach (var item in listPaths)
                    {
                        listBox5.Items.Add(item); //Add all the paths of the dataGridView in a listBox.
                }

                    ListBox.ObjectCollection list = listBox5.Items;

                    WMPLib.IWMPPlaylist playlist = axWindowsMediaPlayer1.playlistCollection.newPlaylist("myplaylist");
                    WMPLib.IWMPMedia media;
                    foreach (object item in listPaths)
                    {
                        media = axWindowsMediaPlayer1.newMedia((string)item);
                        playlist.appendItem(media);
                    }
                    axWindowsMediaPlayer1.currentPlaylist = playlist;
                    axWindowsMediaPlayer1.Ctlcontrols.play(); //Start playing the songs in the playlist    
                }
            }
        

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {}

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = string.Format("Name like '%{0}%'", searchTextBox.Text.Trim().Replace("'", "''"));
            dataGridView1.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { }


        private void dataGridView1_CellDoubleClick(Object sender, DataGridViewCellEventArgs e)
        {
            {
                try
                {
                    // Get the media item at the position of the selected index in the current playlist.
                    WMPLib.IWMPMedia media = axWindowsMediaPlayer1.currentPlaylist.get_Item(e.RowIndex);

                    // Play the media item.
                    axWindowsMediaPlayer1.Ctlcontrols.playItem(media);
                }
                catch (IndexOutOfRangeException)
                { }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //Select the items to add to the dataGridView.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "Mp3 Files|*.mp3|Avi Files| *.avi | Wav Files | *.wav";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filesNames = openFileDialog1.SafeFileNames;
                paths = openFileDialog1.FileNames;


                for (int i = 0; i < paths.Length; i++)
                {

                    //Dislay the playlist on a DataGridView. The first column holds the filenames and the second the file paths. 
                    try
                    {
                        fillDataTable(filesNames[i], paths[i]);
                    }
                    catch (Exception ex)
                    {
                    }                                                        

                }                 
            }

            allFilenames = getSongsInPlaylist("Name"); //get all the name files shown on the dataGridView.
            allPaths = getSongsInPlaylist("Path"); //get all the paths of the songs shown on the dataGridView.

            //Create a Media playlist with all the items in the dataGridView.
            List<string> listPaths = dataGridView1.Rows.OfType<DataGridViewRow>().Where(x => x.Cells[1].Value != null).Select(x => x.Cells[1].Value.ToString()).ToList(); //get all the paths of the dataGridView.
            foreach(var item in listPaths)
            {
                listBox5.Items.Add(item); //Add all the paths in a listBox.
            }


            ListBox.ObjectCollection list = listBox5.Items;           

            WMPLib.IWMPPlaylist playlist = axWindowsMediaPlayer1.playlistCollection.newPlaylist("myplaylist");
            WMPLib.IWMPMedia media;
            foreach (object item in listPaths)
            {
                media = axWindowsMediaPlayer1.newMedia((string)item);
                playlist.appendItem(media);
            }
            axWindowsMediaPlayer1.currentPlaylist = playlist;
            axWindowsMediaPlayer1.Ctlcontrols.play(); //Start playing the songs in the playlist       

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchTextBox.Visible= true;
            okButton.Visible = true;
            searchButton.Enabled = false;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            searchTextBox.Visible = false;
            okButton.Visible = false;
            searchButton.Enabled = true;

            ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = null;

            dataGridView1.Enabled = true;
        }

        private void fillDataTable(String currentFile, String currentPath)
        {
            //Fill the datatable         
            dt.Rows.Add(currentFile, currentPath);
        }

        private string[] getSongsInPlaylist(string columnName)
        {
            string[] columnData = dt
                             .AsEnumerable()
                             .Select(row => row.Field<string>(columnName))
                             .ToArray();
        
            return columnData;
        }

    }
}
