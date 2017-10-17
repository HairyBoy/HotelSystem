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
            openFileDialog1.ShowDialog();
            string path = openFileDialog1.FileName;
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
            string SavePath = SavePathDialog.SelectedPath;
            SavePathText.Text = SavePath;
        }
    }
}
