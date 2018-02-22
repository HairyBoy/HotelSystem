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
        public static int send = 0;
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
            string SavePath;
            if (SavePathDialog.SelectedPath == "")
            {
                SavePath = "C:\\Program Files\\HotelSystem";
            }
            else
            {
                SavePath = (SavePathDialog.SelectedPath + "\\HotelSystem");
            }
            if (System.IO.File.Exists(SavePath + "\\config.txt"))
            {
                Form2 HomeScreen = Application.OpenForms["Form2"] as Form2;
                try { HomeScreen.Show(); }
                catch { }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (V(ContactNo.Text, HotelName.Text) == true)
            {
                //Directory Creation
                System.IO.Directory.CreateDirectory("C:\\Program Files\\HotelSystem");
                //
                using (var writer=new System.IO.StreamWriter("C:\\Program Files\\HotelSystem\\config.txt")) {
                    writer.WriteLine(HotelName.Text);
                    writer.WriteLine(ContactNo.Text);
                    writer.WriteLine(pictureBox1.ImageLocation);
                    writer.WriteLine(SysColour.ToArgb().ToString());
                }
                if (send == 1)
                {
                    MessageBox.Show("Application must restart to have effective changes.");
                    Application.Exit();
                }
                else { HomeCall(); }
            }


        }
        Color SysColour;
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
        private bool V(string ContactNo ,string HotelName)
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
            return val;
        }
        private void HomeCall()
        {
            this.Hide();
            Form2 HomeScreen = new Form2();
        HomeScreen.ShowDialog();
            this.Close();
        }
        private void SavePathDialog_HelpRequest(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(send == 1)
            {
                this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                using (System.IO.StreamReader reader = new System.IO.StreamReader("C:\\Program Files\\HotelSystem\\config.txt"))
                {
                    reader.ReadLine();
                    reader.ReadLine();
                    reader.ReadLine();
                    this.BackColor = Color.FromArgb(Convert.ToInt32(reader.ReadLine()));
                }
            }
            if (System.IO.File.Exists("C:\\Program Files\\HotelSystem\\config.txt") && send == 0)
            {
                HomeCall();
            }
            this.FormClosing += new FormClosingEventHandler(BookingForm_Closing);
        }
        private void BookingForm_Closing(object sender, FormClosingEventArgs e)
        {
            if (send == 1)
            {
                Form2 HomeScreen = Application.OpenForms["Form2"] as Form2;
                try { HomeScreen.Show(); }
                catch { }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                SysColour = colorDialog1.Color;
                textBox1.BackColor = SysColour;
            }
        }
    }
}
