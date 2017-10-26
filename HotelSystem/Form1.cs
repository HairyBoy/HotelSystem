using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog Background = new OpenFileDialog();
            Background.Filter = "Image Files (JPG,PNG,GIF)|*.JPG;*.PNG;*.GIF";
            Background.ShowDialog();
            string path = (Background.FileName);
            imgupdate(path);
        }
        private void imgupdate(string file)
        {
            pictureBox1.ImageLocation = file;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void SavePathClick_Click(object sender, EventArgs e)
        {
            SavePathDialog.ShowDialog();
            string SavePath = (SavePathDialog.SelectedPath + "\"HotelSystem"");
            SavePathText.Text = SavePath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            V(ContactNo.Text, HotelName.Text, SavePathText.Text);

        }
        private bool NumbVal (string St)
        {
            for (int i=0;i<St.Length;i++)
            {
                if (Char.IsNumber(St[i]) == true) { }
                else if (St[i] == ' ') { }
                else { return false; }
            }
            return true;
        }
        private bool V(string ContactNo ,string HotelName, string Path)
        {
            bool val = true;
            // ContactNumber
            if (NumbVal(ContactNo) == true && ContactNo.Length < 17)
            {
                NumbWarn.Visible = false;
            }
            else
            {
                NumbWarn.Visible = true;
                val = false;
            }
            // HotelName
            if (HotelName.Length < 31)
            {
                label6.Visible = false;
            }
            else
            {
                label6.Visible = true;
                val = false;
            }
            // HotelSystem Domain
            System.IO.Directory.CreateDirectory(Path);
            



            return val;
            
        }

        private void SavePathDialog_HelpRequest(object sender, EventArgs e)
        {

        }
    }
}
