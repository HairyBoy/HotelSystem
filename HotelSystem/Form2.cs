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
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            BookingForm BookingForm = new BookingForm();
            UIUpdate();
            ResetDates(0);
            RichTextBox Rich;
            //TEST///////////////////////////////////////
            for (int x = 1; x < 8; x++)
            {
                for (int y = 1; y < 16; y++)
                {
                    Rich = (RichTextBox)Calendar.GetControlFromPosition(x,y);
                    Rich.Text = "Test";
                }
            }
            //TEST//////////////////////////////////////
        }
        private void UIUpdate()
        {
            using (System.IO.StreamReader reader = new System.IO.StreamReader("C:\\Program Files\\HotelSystem\\config.txt"))
            {
                HotelName.Text = reader.ReadLine();
                HotelNumber.Text = reader.ReadLine();
                CoverPic.ImageLocation = reader.ReadLine();
            }
        }
        private void richTextBox1_Click(object sender, System.EventArgs e)
        {
        
        }
        int displace = 0;
        private void ResetDates(int preset)
        {
            displace = displace + (preset);
            DateTime DAnchor = DateTime.Now.AddDays(7*displace);
            
            for (int i = 1; i < 8; i++)
            {
                ((RichTextBox)Calendar.GetControlFromPosition(i, 0)).Text = DAnchor.AddDays(i-1).ToString("dd.MM.dddd");
            }
        }

        private void button1_Click(object sender, EventArgs e)
            //RIGHT DATE
        {
            ResetDates(1);
        }

        private void button3_Click(object sender, EventArgs e)
            //LEFT DATE
        {
            ResetDates(-1);
        }

        private void BookRoom_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookingForm BookingForm = new BookingForm();
            BookingForm.ShowDialog();
        }
    }
}
