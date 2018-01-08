﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace HotelSystem
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string[] combo = new string[] { "Single", "Double", "Triple", "Quad", "Queen", "King", "Twin", "Double-double", "Studio", "Other" };
            comboBox1.Items.AddRange(combo);
            this.FormClosing += new FormClosingEventHandler(BookingForm_Closing);
        }
        private void BookingForm_Closing(object sender, FormClosingEventArgs e)
        {
            Form2 HomeScreen = Application.OpenForms["Form2"] as Form2;
            HomeScreen.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Val(textBox1.Text, comboBox1.Text, checkBox1.Checked, textBox2.Text, textBox3.Text, richTextBox1.Text))
            {
                DBRoomAdd(textBox1.Text, comboBox1.Text, checkBox1.Checked, textBox2.Text, textBox3.Text, richTextBox1.Text);
            }
            
        }
        private string LinkString()
        {
            string path = (AppDomain.CurrentDomain.BaseDirectory);
            return ("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + path + "Database1.mdf;Integrated Security=True");
        }
        private void DBRoomAdd(string RNumb, string RSize, bool DAccess, string RPrice, string KeyNumb, string RNotes)
        {

            string ConStr = LinkString();
            using (SqlConnection DB = new SqlConnection(ConStr))
            {
                DB.Open();
                using (SqlCommand Comm = new SqlCommand(
                "INSERT INTO Rooms (RoomNumber, RoomSize, DBAccess, Price, Notes, KeycardNo) VALUES(@RoomNumber, @RoomSize, @DBAccess, @Price, @Notes, @KeycardNo)", DB))
                {
                    Comm.Parameters.Add(new SqlParameter("RoomNumber", RNumb));
                    Comm.Parameters.Add(new SqlParameter("RoomSize", RSize));
                    Comm.Parameters.Add(new SqlParameter("DBAccess", DAccess));
                    Comm.Parameters.Add(new SqlParameter("Price", RPrice));
                    Comm.Parameters.Add(new SqlParameter("Notes", RNotes));
                    Comm.Parameters.Add(new SqlParameter("KeycardNo", KeyNumb));
                    Comm.ExecuteNonQuery();
                }
            }
        }
        private bool Val(string RNumb, string RSize, bool DAccess, string RPrice, string KeyNumb, string RNotes)
        {
            return true;
        }
    }
}
