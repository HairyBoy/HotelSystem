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
        List<Booking> MiniListG = new List<Booking>();
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
                " Rooms.RoomNumber, Visitors.FName, Visitors.SName,Visitors.ContactNo,Visitors.Email,Visitors.Notes,Bookings.Status FROM Bookings INNER JOIN Rooms on Rooms.RoomID = Bookings.RoomID INNER JOIN Visitors on Visitors.VisitorID = Bookings.VisitorID", DB))
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
                                SName = reader.GetString(reader.GetOrdinal("SName")),
                                ContactNo = reader.GetString(reader.GetOrdinal("ContactNo")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                Notes = reader.GetString(reader.GetOrdinal("Notes")),
                                Status = reader.GetString(reader.GetOrdinal("Status"))
                            });
                        }
                    }
                }
            }
            return OutputList;
        }
        public int val;
        private void Checkbox_Click(object sender, EventArgs e)
        {
            List<Booking> BookList = ViewBooks();
            for(int i = 1; i < 8; i++)
            {
                if(((CheckBox)tableLayoutPanel1.GetControlFromPosition(4, i)).Checked == true)
                {
                    val = i-1;
                    break;
                }
            }
            if (((RichTextBox)tableLayoutPanel1.GetControlFromPosition(1, val+1)).Text == "In")
            {

                using (SqlConnection DB = new SqlConnection(LinkString()))
                using (SqlCommand Comm = new SqlCommand("UPDATE Bookings SET Status = 'A' WHERE BookingID="+MiniListG[val].ID, DB))
                {
                    DB.Open();
                    Comm.ExecuteNonQuery();
                    DB.Close();
                }
            }
            else if (((RichTextBox)tableLayoutPanel1.GetControlFromPosition(1, val + 1)).Text == "Out")
            {
                using (SqlConnection DB = new SqlConnection(LinkString()))
                using (SqlCommand Comm = new SqlCommand("UPDATE Bookings SET Status = 'R' WHERE BookingID = "+MiniListG[val].ID, DB))
                {
                    DB.Open();
                    Comm.ExecuteNonQuery();
                    DB.Close();
                }
            }
            CalUpdate();
        }

        private void MiniUpdate()
        {
            for(int x = 0; x < 4; x++)
            {
                for(int y = 1; y < 8; y++)
                {
                    ((RichTextBox)tableLayoutPanel1.GetControlFromPosition(x, y)).Text = "";
                    ((CheckBox)tableLayoutPanel1.GetControlFromPosition(4, y)).Visible = false;
                    ((CheckBox)tableLayoutPanel1.GetControlFromPosition(4, y)).Checked = false;
                }
            }
            List<Booking> BookList = ViewBooks();
            List<Booking> MiniListP = new List<Booking>();
            int c=1;
            for (int i =0; i < BookList.Count&&i<7; i++)
            {
                if(BookList[i].VStart == DateTime.Now.Date && BookList[i].Status!="A")
                {
                    MiniListP.Add(BookList[i]);
                    ((RichTextBox)tableLayoutPanel1.GetControlFromPosition(0, c)).Text = BookList[i].FName +" "+ BookList[i].SName;
                    ((RichTextBox)tableLayoutPanel1.GetControlFromPosition(1, c)).Text = "In";
                    ((RichTextBox)tableLayoutPanel1.GetControlFromPosition(2, c)).Text = "£"+BookList[i].Price;
                    ((RichTextBox)tableLayoutPanel1.GetControlFromPosition(3, c)).Text = BookList[i].Notes;
                    ((CheckBox)tableLayoutPanel1.GetControlFromPosition(4, c)).Visible = true;
                    c = c + 1;
                }
                else if(BookList[i].VEnd == DateTime.Now.Date && BookList[i].Status != "R")
                {
                    MiniListP.Add(BookList[i]);
                    ((RichTextBox)tableLayoutPanel1.GetControlFromPosition(0, c)).Text = BookList[i].FName + " " + BookList[i].SName;
                    ((RichTextBox)tableLayoutPanel1.GetControlFromPosition(1, c)).Text = "Out";
                    ((RichTextBox)tableLayoutPanel1.GetControlFromPosition(2, c)).Text = "£" + BookList[i].Price;
                    ((RichTextBox)tableLayoutPanel1.GetControlFromPosition(3, c)).Text = BookList[i].Notes;
                    ((CheckBox)tableLayoutPanel1.GetControlFromPosition(4, c)).Visible = true;
                    c = c + 1;
                }
                
            }
            MiniListG = MiniListP;
        }
        private void CalUpdate()
        {
            ClearTable();
            MiniUpdate();
            //Dates refresh
                for (int i = 1; i < 8; i++)
                {
                    Dates[i - 1] = DAnchor.AddDays(i - 1);
                    ((RichTextBox)Calendar.GetControlFromPosition(i, 0)).Text = DAnchor.AddDays(i - 1).ToString("dd.MM.dddd");
                }
            
            //DatesRefresh

            var OutputList = ViewBooks();
            var RoomList = RoomGrab();

            if (RoomList.Count > 0)
            {
                int b = 0;
                int c = 1;

                foreach (Room room in RoomList)
                {
                    if (b <= 14 + iv && b >= iv)
                    {
                        ((RichTextBox)Calendar.GetControlFromPosition(0, c)).Text = room.RoomNumber;
                        c++;
                    }
                    b++;
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
                                if(OutputList[m].Status == "R") { Rich.BackColor = Color.Red; }
                            else if (OutputList[m].Status == "G") { Rich.BackColor = Color.Green; }
                            else if (OutputList[m].Status == "A") { Rich.BackColor = Color.Orange; }
                  
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
            var BookList = ViewBooks();
            Point cellPos = GetRowColIndex(Calendar, Calendar.PointToClient(Cursor.Position));
            bool RGotsBooks = false;
            
            if (cellPos.X == 0 && Calendar.GetControlFromPosition(cellPos.X,cellPos.Y).Text != "") {
                Room Obj = OutputList[cellPos.Y + (iv - 1)];
                switch (MessageBox.Show("\r\nRoom: "+Obj.RoomNumber+"\r\nPrice: £" + Obj.Price + "\r\nSize: "+Obj.RoomSize+ "\r\nNotes: "+Obj.Notes + "\r\nDelete?", "Room " + Obj.RoomNumber + " Details", MessageBoxButtons.YesNo))
                {
                    case DialogResult.Yes:
                        for (int n = 0; n < BookList.Count; n++)
                        {
                            if (Obj.ID == BookList[n].RID)
                            {
                                RGotsBooks = true;
                            }
                        }
                        if (!RGotsBooks)
                        {
                            using (SqlConnection DB = new SqlConnection(LinkString()))
                            using (SqlCommand Comm = new SqlCommand("DELETE FROM Rooms WHERE RoomID='" + Obj.ID + "'", DB))
                            {
                                DB.Open();
                                Comm.ExecuteNonQuery();
                                DB.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Cannot delete a room when it has bookings.","Oh no!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
            }
           else if (Calendar.GetControlFromPosition(cellPos.X, cellPos.Y).BackColor != SystemColors.Control)
            {
                Booking Book=BookList[0];
                for (int i = 0; i < BookList.Count; i++)
                {
                    if(DateTime.Compare(BookList[i].VStart, Dates[cellPos.X-1]) <= 0 && DateTime.Compare(BookList[i].VEnd, Dates[cellPos.X-1]) >= 0&&BookList[i].RoomNumber == Calendar.GetControlFromPosition(0, cellPos.Y).Text)
                    {
                        Book = BookList[i];
                        break;
                    }
                }
                
                switch (MessageBox.Show("\r\nVisitorName: " + Book.FName+" "+ Book.SName + "\r\nPrice: £" + Book.Price + "\r\nRoom Number: " + Book.RoomNumber + "\r\nVisit Length: " + Book.VStart +" - "+ Book.VEnd +"\r\nEmail:"+Book.Email+ "\r\nContact Number: "+ Book.ContactNo + "\r\nDelete?",  Book.SName + "'s visit", MessageBoxButtons.YesNo))
                {
                    case DialogResult.Yes:
                        using (SqlConnection DB = new SqlConnection(LinkString()))
                        using (SqlCommand Comm = new SqlCommand("DELETE FROM Bookings WHERE BookingID='" + Book.ID + "'", DB))
                        {
                            DB.Open();
                            Comm.ExecuteNonQuery();
                            DB.Close();
                        }

                        break;
                }

            }
            CalUpdate();
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
                        Rich.BackColor = SystemColors.Control;
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
        private string _Email;
        private string _ContactNo;
        private string _Notes;
        private string _Status;

        public int ID { get => _ID; set => _ID = value; }
        public DateTime VStart { get => _VStart; set => _VStart = value; }
        public DateTime VEnd { get => _VEnd; set => _VEnd = value; }
        public double Price { get => _Price; set => _Price = value; }
        public int RID { get => _RID; set => _RID = value; }
        public int VID { get => _VID; set => _VID = value; }
        public string RoomNumber { get => _RoomNumber; set => _RoomNumber = value; }
        public string FName { get => _FName; set => _FName = value; }
        public string SName { get => _SName; set => _SName = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string ContactNo { get => _ContactNo; set => _ContactNo = value; }
        public string Notes { get => _Notes; set => _Notes = value; }
        public string Status { get => _Status; set => _Status = value; }
    }
    public class Room:Booking
    {
        private string _RoomSize;
        private string _KeyCard;

        public string KeyCard { get => _KeyCard; set => _KeyCard = value; }
        public string RoomSize { get => _RoomSize; set => _RoomSize = value; }
    }
}
