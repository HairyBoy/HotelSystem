using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HotelSystem
{
    public partial class Form2 : Form
    {
        public int iv;
        public DateTime[] Dates = new DateTime[7];
        public Form2()
        {
            InitializeComponent();
             iv = 0;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            BookingForm BookingForm = new BookingForm();
            UIUpdate();
            CalUpdate();
            ResetDates(0);
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
        public int displace = 0;
        private void ResetDates(int preset)
        {
            displace = displace + (preset);
            DateTime DAnchor = DateTime.Now.AddDays(7*displace);
            
            for (int i = 1; i < 8; i++)
            {
                Dates[i - 1] = DAnchor.AddDays(i - 1);
                ((RichTextBox)Calendar.GetControlFromPosition(i, 0)).Text = DAnchor.AddDays(i-1).ToString("dd.MM.dddd");
            }
            CalUpdate();
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
        private void AddRoom_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 Form3 = new Form3();
            Form3.ShowDialog();
        }
        private string LinkString()
        {
            string path = (AppDomain.CurrentDomain.BaseDirectory);
            return ("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + path + "Database1.mdf;Integrated Security=True");
        }
        private void CalUpdate()
        {
            var OutputList = new List<Booking>();

            using (SqlConnection DB = new SqlConnection(LinkString()))
            using (SqlCommand Comm = new SqlCommand("SELECT BookingID AS ID, Bookings.VisitStart, Bookings.VisitEnd," +
                " Bookings.Price, Bookings.RoomID, Bookings.VisitorID," +
                " Rooms.RoomNumber FROM Bookings INNER JOIN Rooms on Rooms.RoomID = Bookings.RoomID INNER JOIN Visitors on Visitors.VisitorID = Bookings.VisitorID", DB))
            {
                DB.Open();
                using (SqlDataReader reader = Comm.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            OutputList.Add(new Booking
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                VStart = reader.GetDateTime(reader.GetOrdinal("VisitStart")),
                                VEnd = reader.GetDateTime(reader.GetOrdinal("VisitEnd")),
                                Price = reader.GetDouble(reader.GetOrdinal("Price")),
                                RID = reader.GetInt32(reader.GetOrdinal("RoomID")),
                                VID = reader.GetInt32(reader.GetOrdinal("VisitorID")),
                                RoomNumber = reader.GetString(reader.GetOrdinal("RoomNumber"))
                            });
                        }
                    }
                }
            }
            using (SqlConnection DB = new SqlConnection(LinkString()))
            using (SqlCommand Comm = new SqlCommand("SELECT RoomID AS ID, RoomNumber FROM Rooms", DB))
            {
                DB.Open();
                using (SqlDataReader reader = Comm.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        int b = 0;
                        int c = 1;

                        while (reader.Read())
                        {
                            if (b<=14+iv&&b>=iv)
                            {
                                ((RichTextBox)Calendar.GetControlFromPosition(0, c)).Text = reader.GetString(reader.GetOrdinal("RoomNumber"));
                                c++;
                            }
                            b++;
                        }
                        if (c < 16)
                        {
                            ((RichTextBox)Calendar.GetControlFromPosition(0, c)).Text = "";
                        }
                    }
                }
            }
            //
            int n;
            

            RichTextBox Rich;
            for (int x = 1; x < 8; x++)
            {
                for (int y = 1; y < n; y++)
                {
                    if (OutputList[(y - 1) + iv].VStart.Ticks < Dates[x-1].Ticks && Dates[x - 1].Ticks < OutputList[(y - 1) + iv].VEnd.Ticks)
                    {
                        Rich = (RichTextBox)Calendar.GetControlFromPosition(x, y);
                        Rich.Text = "Test";
                    }
                }
            }



        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            CalUpdate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (iv!=0){
                iv = iv - 1;
                CalUpdate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            iv = iv + 1;
            CalUpdate();
        }
    }
    public class Booking
    {
        private int _ID;
        private DateTime _VStart;
        private DateTime _VEnd;
        private double _Price;
        private int _RID;
        private int _VID;
        private string _RoomNumber;

        public int ID { get => _ID; set => _ID = value; }
        public DateTime VStart { get => _VStart; set => _VStart = value; }
        public DateTime VEnd { get => _VEnd; set => _VEnd = value; }
        public double Price { get => _Price; set => _Price = value; }
        public int RID { get => _RID; set => _RID = value; }
        public int VID { get => _VID; set => _VID = value; }
        public string RoomNumber { get => _RoomNumber; set => _RoomNumber = value; }
    }
}
