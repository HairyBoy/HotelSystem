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
        public int r;
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
            string Link = LinkString();
            using (SqlConnection DB = new SqlConnection(Link))
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
            for (int i = 1; i < 16&&i<OutputList.Count; i++)
            {
                ((RichTextBox)Calendar.GetControlFromPosition(0, i)).Text = OutputList[(i-1) + r].RoomNumber;
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            CalUpdate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (r!=0){
                r = r - 1;
                CalUpdate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            r = r + 1;
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
