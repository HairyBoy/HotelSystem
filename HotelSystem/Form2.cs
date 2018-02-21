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
using System.Diagnostics;

namespace HotelSystem
{
    public partial class Form2 : Form
    {
        public int iv;
        public DateTime[] Dates = new DateTime[7];
        public DateTime DAnchor = DateTime.Now.Date;

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

    
        private void button1_Click(object sender, EventArgs e)
            //RIGHT DATE
        {
            DAnchor = DAnchor.AddDays(7);
            CalUpdate();
        }

        private void button3_Click(object sender, EventArgs e)
            //LEFT DATE
        {
            DAnchor = DAnchor.AddDays(-7);
            CalUpdate();
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
        private List<Booking> ViewBooks()
        {
            var OutputList = new List<Booking>();
            using (SqlConnection DB = new SqlConnection(LinkString()))
            using (SqlCommand Comm = new SqlCommand("SELECT BookingID AS ID, Bookings.VisitStart, Bookings.VisitEnd," +
                " Bookings.Price, Bookings.RoomID, Bookings.VisitorID," +
                " Rooms.RoomNumber, Visitors.FName, Visitors.SName FROM Bookings INNER JOIN Rooms on Rooms.RoomID = Bookings.RoomID INNER JOIN Visitors on Visitors.VisitorID = Bookings.VisitorID", DB))
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
                                VStart = reader.GetDateTime(reader.GetOrdinal("VisitStart")).Date,
                                VEnd = reader.GetDateTime(reader.GetOrdinal("VisitEnd")).Date,
                                Price = reader.GetDouble(reader.GetOrdinal("Price")),
                                RID = reader.GetInt32(reader.GetOrdinal("RoomID")),
                                VID = reader.GetInt32(reader.GetOrdinal("VisitorID")),
                                RoomNumber = reader.GetString(reader.GetOrdinal("RoomNumber")),
                                FName = reader.GetString(reader.GetOrdinal("FName")),
                                SName = reader.GetString(reader.GetOrdinal("SName"))
                            });
                        }
                    }
                }
            }
            return OutputList;
        }
        private void CalUpdate()
        {
            ClearTable();
            //Dates refresh
                for (int i = 1; i < 8; i++)
                {
                    Dates[i - 1] = DAnchor.AddDays(i - 1);
                    ((RichTextBox)Calendar.GetControlFromPosition(i, 0)).Text = DAnchor.AddDays(i - 1).ToString("dd.MM.dddd");
                }
            
            //DatesRefresh

            var OutputList = ViewBooks();
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
                    }
                }
            }
            RichTextBox Rich;
            bool checkie;
            int XVal=0;
            bool check = true;
            for (int m = 0; m < OutputList.Count; m++)
            {
                check = true;
                checkie = false;
                for (int numplace=1; numplace < 16; numplace++)
                {
                    if(Calendar.GetControlFromPosition(0, numplace).Text == OutputList[m].RoomNumber) {
                        checkie = true;
                        XVal = numplace;
                        break; }
                }
                if (checkie)
                {
                    for (int D = 1; D < 8; D++)
                    {
                        if (DateTime.Compare(OutputList[m].VStart, Dates[D-1]) <= 0 && DateTime.Compare(OutputList[m].VEnd, Dates[D-1]) >= 0)
                        {
                             Rich = (RichTextBox)Calendar.GetControlFromPosition(D, XVal);
                                if (check)
                                {
                                    Rich.Text = OutputList[m].FName;
                                    check = false;
                                }
                             Rich.BackColor = Color.Green;
                        }
                    }
                }
            }


        }
        /////////////////////////////////////////////////
        Point GetRowColIndex(TableLayoutPanel tlp, Point point)
        {
            int w = tlp.Width;
            int h = tlp.Height;
            int[] widths = tlp.GetColumnWidths();

            int i;
            for (i = widths.Length - 1; i >= 0 && point.X < w; i--)
                w -= widths[i];
            int col = i + 1;

            int[] heights = tlp.GetRowHeights();
            for (i = heights.Length - 1; i >= 0 && point.Y < h; i--)
                h -= heights[i];

            int row = i + 1;

            return new Point(col, row);
        }
        private void Calendar_Click(object sender, EventArgs e)
        {
            var OutputList = RoomGrab();
            Point cellPos = GetRowColIndex(Calendar, Calendar.PointToClient(Cursor.Position));
            
            if (cellPos.X == 0 && Calendar.GetControlFromPosition(cellPos.X,cellPos.Y).Text != "") {
                Room Obj = OutputList[cellPos.Y + (iv - 1)];
                switch (MessageBox.Show("\r\nRoom: "+Obj.RoomNumber+"\r\nPrice:" + Obj.Price + "\r\nSize: "+Obj.RoomSize+ "\r\nNotes: "+Obj.Notes + "\r\nDelete?", "Room " + Obj.RoomNumber + " Details", MessageBoxButtons.YesNo))
                {
                    case DialogResult.Yes:
                        // "Yes" processing
                        break;

                    case DialogResult.No:
                        // "No" processing
                        break;
                }
            }
           else if (cellPos.Y != 0 && Calendar.GetControlFromPosition(cellPos.X, cellPos.Y).BackColor == Color.Green)
            {
                switch (MessageBox.Show("Do you want to create a new file?", "WonderWord", MessageBoxButtons.YesNo))
                {
                    case DialogResult.Yes:
                        // "Yes" processing
                        break;

                    case DialogResult.No:
                        // "No" processing
                        break;
                }
            }
        }
        /////////////////////////////////////////////////
        private void ClearTable()
        {
            RichTextBox Rich;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 16; y++)
                {

                        Rich = (RichTextBox)Calendar.GetControlFromPosition(x, y);
                        Rich.Text = "";
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
        private List<Room> RoomGrab()
        {
            var OutputList = new List<Room>();
            using (SqlConnection DB = new SqlConnection(LinkString()))
            using (SqlCommand Comm = new SqlCommand("SELECT RoomID AS ID, RoomNumber, RoomSize, Price, Notes, KeycardNo FROM Rooms", DB))
            {
                DB.Open();
                using (SqlDataReader reader = Comm.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            OutputList.Add(new Room
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                RoomNumber = reader.GetString(reader.GetOrdinal("RoomNumber")),
                                RoomSize = reader.GetString(reader.GetOrdinal("RoomSize")),
                                Notes = reader.GetString(reader.GetOrdinal("Notes")),
                                KeyCard = reader.GetString(reader.GetOrdinal("KeycardNo")),
                                Price = reader.GetDouble(reader.GetOrdinal("Price")),
                            });
                        }
                    }
                }
            }
            return OutputList;
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
        private string _FName;
        private string _SName;

        public int ID { get => _ID; set => _ID = value; }
        public DateTime VStart { get => _VStart; set => _VStart = value; }
        public DateTime VEnd { get => _VEnd; set => _VEnd = value; }
        public double Price { get => _Price; set => _Price = value; }
        public int RID { get => _RID; set => _RID = value; }
        public int VID { get => _VID; set => _VID = value; }
        public string RoomNumber { get => _RoomNumber; set => _RoomNumber = value; }
        public string FName { get => _FName; set => _FName = value; }
        public string SName { get => _SName; set => _SName = value; }
    }
    public class Room:Booking
    {
        private string _RoomSize;
        private string _KeyCard;
        private string _Notes;


        public string Notes { get => _Notes; set => _Notes = value; }
        public string KeyCard { get => _KeyCard; set => _KeyCard = value; }
        public string RoomSize { get => _RoomSize; set => _RoomSize = value; }
    }
}
