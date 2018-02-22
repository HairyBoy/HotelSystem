using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelSystem
{

    public partial class BookingForm : Form
    {
        public static int send=0;
        public List<TempRoom> SearchList = new List<TempRoom>();
        public BookingForm()
        {
            InitializeComponent();
        }

        private void BookingForm_Load(object sender, EventArgs e)
        {

            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            using (System.IO.StreamReader reader = new System.IO.StreamReader("C:\\Program Files\\HotelSystem\\config.txt"))
            {
                reader.ReadLine();
                reader.ReadLine();
                reader.ReadLine();
                this.BackColor = Color.FromArgb(Convert.ToInt32(reader.ReadLine()));
            }
            dateTimePicker1.Value = DateTime.Now.Date;
            dateTimePicker2.Value = DateTime.Now.Date;
            string[] combo = new string[] { "Single", "Double", "Triple", "Quad", "Queen", "King", "Twin", "Double-double", "Studio", "Other" };
            comboBox1.Items.AddRange(combo);
            this.FormClosing += new FormClosingEventHandler(BookingForm_Closing);
        }
        private void BookingForm_Closing(object sender, FormClosingEventArgs e)
        {
            Form2 HomeScreen = Application.OpenForms["Form2"] as Form2;
            HomeScreen.Show();
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (Validation(true, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, dateTimePicker1.Value, dateTimePicker2.Value, comboBox1.Text, SearchList[(checkcol() - 1)].Num))
            {
                DBVisitorAdd(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
                DBBookingAdd(SearchList[(checkcol()-1)]);
            }
        }
        private void DBBookingAdd(TempRoom choiceroom)
        {
            TimeSpan diff = dateTimePicker2.Value - dateTimePicker1.Value;
            string ConStr = LinkString();
            using (SqlConnection DB = new SqlConnection(ConStr))
            {
                DB.Open();
                using (SqlCommand Comm = new SqlCommand(
                "INSERT INTO Bookings (VisitStart, VisitEnd, Price, RoomID, VisitorID) VALUES(@VisitStart, @VisitEnd, @Price, @RoomID, @VisitorID)", DB))
                {
                    Comm.Parameters.Add(new SqlParameter("VisitStart", dateTimePicker1.Value));
                    Comm.Parameters.Add(new SqlParameter("VisitEnd", dateTimePicker2.Value));
                    Comm.Parameters.Add(new SqlParameter("Price", choiceroom.Price*(diff.Days+1)));
                    Comm.Parameters.Add(new SqlParameter("RoomID", choiceroom.Id));
                    Comm.Parameters.Add(new SqlParameter("VisitorID",VID));
                    Comm.ExecuteNonQuery();
                }
            }
        }
        private int checkcol()
        {
            CheckBox check;
            for (int i = 1; i < 8;i++)
            {
                check = (CheckBox)tableLayoutPanel1.GetControlFromPosition(3, i);
                if (check.Checked)
                { return i; }
            }
            return -1;
        }
        public int VID;
        private void DBVisitorAdd(string FName, string SName, string Numb, string VEmail, string Notes)
        {
           
            string ConStr = LinkString();
            using (SqlConnection DB = new SqlConnection(ConStr))
            {
                DB.Open();
                using (SqlCommand Comm = new SqlCommand(
                "INSERT INTO Visitors (FName, SName, ContactNo, Email, Notes) OUTPUT INSERTED.VisitorID VALUES(@FName, @SName, @ContactNo, @Email, @Notes)", DB))
                {
                    Comm.Parameters.Add(new SqlParameter("FName", FName));
                    Comm.Parameters.Add(new SqlParameter("SName", SName));
                    Comm.Parameters.Add(new SqlParameter("ContactNo", Numb));
                    Comm.Parameters.Add(new SqlParameter("Email", VEmail));
                    Comm.Parameters.Add(new SqlParameter("Notes", Notes));
                    
                    VID = (int)Comm.ExecuteScalar();
                }
            }
        }
        private string LinkString()
        {
            string path = (AppDomain.CurrentDomain.BaseDirectory);
            return ("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + path + "Database1.mdf;Integrated Security=True");
        }
        private bool Validation(bool booking, string FName, string SName, string Numb, string VEmail, string Notes, DateTime DateStart, DateTime DateEnd, string Combo,string RNum)
        {

            //FIRSTNAME START
            label35.Text = "";
            List<Booking> BookList = ViewBooks();
            Regex AlphNum = new Regex("^[a-zA-Z0-9]*$");
            Regex Num = new Regex("^[0-9]*$");
            bool end = true;
            if (AlphNum.IsMatch(FName) == false)
            {
                end = false;
                label35.Text += "\r\nFName must only contain alphanumerics.";
            }
            if (FName.Length > 20)
            {
                end = false;
                label35.Text += "\r\nFName must have less than 20 characters";
            }
            if (FName == "")
            {
                end = false;
                label35.Text += "\r\nFName cannot be blank";
            }
            //FIRSTNAME END
            //SECONDNAME START
            if (AlphNum.IsMatch(SName) == false)
            {
                end = false;
                label35.Text += "\r\nSName must only contain alphanumerics.";
            }
            if (SName.Length > 20)
            {
                end = false;
                label35.Text += "\r\nSName must have less than 20 characters";
            }
            if (SName == "")
            {
                end = false;
                label35.Text += "\r\nSName cannot be blank";
            }
            //SECONDNAME END
            //CONTACTNO START
            if ((Numb.Length > 0 && Numb.Length < 6) || Numb.Length > 15)
            {
                end = false;
                label35.Text += "\r\nPNumber must be between 6 and 14 characters";
            }
            if (Num.IsMatch(Numb) == false)
            {
                end = false;
                label35.Text += "\r\nPNumber must contain only numbers.";
            }
            //CONTACTNO END
            //EMAIL START
            if (VEmail.Length > 50)
            {
                end = false;
                label35.Text += "\r\nEmail must contain 50 or less characters.";
            }
            if (AtVal(VEmail))
            {
                end = false;
                label35.Text += "\r\nEmail must contain a '@'.";
            }
            //EMAIL END
            //NOTES START
            if (Notes.Length > 50)
            {
                end = false;
                label35.Text += "\r\nNotes must contain 50 or less characters.";
            }
            //NOTES END
            //DATE START
            if (DateTime.Compare(DateStart, DateEnd) >= 0)
            {
                end = false;
                label35.Text += "\r\nThe second date must follow the first date.";
            }
            //DATE END
            //COMBO START
            if (Combo == "")
            {
                end = false;
                label35.Text += "\r\nA size of room must be selected.";
            }
            //COMBO END
            //CHECK START
            if(booking)
            {
                if (checkcheck() != 1)
                {
                    end = false;
                    label35.Text += "\r\nOnly one textbox must be checked.";
                }
                else {
                    for (int i = 0; i < BookList.Count; i++)
                    {
                        if (BookList[i].RoomNumber == RNum)
                        {
                            if (DateTime.Compare(DateStart.Date, BookList[i].VStart) <= 0 && DateTime.Compare(DateEnd.Date, BookList[i].VEnd) >= 0)
                            {
                                    label35.Text += "\r\nA Booking already exists there.";
                                    end = false;
                                    break;
                            }
                        }
                    }
                }

            }
            //CHECK END

                return end;

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
                                VStart = reader.GetDateTime(reader.GetOrdinal("VisitStart")).Date,
                                VEnd = reader.GetDateTime(reader.GetOrdinal("VisitEnd")).Date,
                                RoomNumber = reader.GetString(reader.GetOrdinal("RoomNumber"))
                            });
                        }
                    }
                }
            }
            return OutputList;
        }
        private int checkcheck()
        {
            CheckBox check;
            int n=0;
            for (int i=1;i<8;i++)
            {
                check = (CheckBox)tableLayoutPanel1.GetControlFromPosition(3, i);
                if(check.Checked)
                { n=n+1; }
                
            }
            return n;
        }
        private bool AtVal(string VEmail)
        {
            for (int i = 0; i < VEmail.Length; i++)
            {
                if (VEmail[i] == '@')
                {
                    return false;
                }
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validation(false,textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, dateTimePicker1.Value, dateTimePicker2.Value, comboBox1.Text,"-1"))
            {
                var OutputList = new List<TempRoom>();
                string Link = LinkString();
                using (SqlConnection DB = new SqlConnection(Link))
                using (SqlCommand Comm = new SqlCommand("SELECT RoomID AS ID, RoomNumber, RoomSize, DBAccess, Price, Notes, Booked FROM Rooms", DB))
                {
                    DB.Open();
                    using (SqlDataReader reader = Comm.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                OutputList.Add(new TempRoom { Id = reader.GetInt32(reader.GetOrdinal("ID")),
                                    Booked = reader.GetBoolean(reader.GetOrdinal("Booked")),
                                    Db = reader.GetBoolean(reader.GetOrdinal("DBAccess")),
                                    Num = reader.GetString(reader.GetOrdinal("RoomNumber")),
                                    Size = reader.GetString(reader.GetOrdinal("RoomSize")),
                                    Price = reader.GetDouble(reader.GetOrdinal("Price")),
                                    Notes = reader.GetString(reader.GetOrdinal("Notes")) });

                            }
                        }
                    }
                }
                int y = 1;
                Label tabnum;
                Label tabnote;
                Label tabprice;
                
                TimeSpan diff = dateTimePicker2.Value - dateTimePicker1.Value;
                for (int n = 1; n < 8; n++)
                {
                    tabnum = (Label)tableLayoutPanel1.GetControlFromPosition(0, n);
                    tabnum.Text = "";
                    tabnote = (Label)tableLayoutPanel1.GetControlFromPosition(1, n);
                    tabnote.Text = "";
                    tabprice = (Label)tableLayoutPanel1.GetControlFromPosition(2, n);
                    tabprice.Text = "";
                   
                }
                
                for (int i = 0; i < OutputList.Count; i++)
                {
                    if (RoomSearch(OutputList[i]))
                    {
                        tabnum = (Label)tableLayoutPanel1.GetControlFromPosition(0, y);
                        tabnum.Text = OutputList[i].Num;
                        tabnote = (Label)tableLayoutPanel1.GetControlFromPosition(1, y);
                        tabnote.Text = OutputList[i].Notes;
                        tabprice = (Label)tableLayoutPanel1.GetControlFromPosition(2, y);
                        tabprice.Text = "£" + Convert.ToString(OutputList[i].Price * (diff.Days + 1));
                        y = y + 1;
                        SearchList.Add(OutputList[i]);
                    }

                    if (y == 8)
                    {
                        break;
                    }
                }
            }

        }
        private bool RoomSearch(TempRoom room)
        {
            if (DBCheck.Checked && !room.Db)
            {
                return false;
            }
            //Requires proper time validation later on.
            if (room.Size == comboBox1.Text)
            {
                return true;
            }
            return false;
        }
    }
    public class TempRoom
    {
        private int _id;
        private string _num;
        private string _size;
        private string _notes;
        private double _price;
        private bool _booked;
        private bool _db;

        public double Price { get => _price; set => _price = value; }
        public string Notes { get => _notes; set => _notes = value; }
        public string Num { get => _num; set => _num = value; }
        public int Id { get => _id; set => _id = value; }
        public bool Booked { get => _booked; set => _booked = value; }
        public bool Db { get => _db; set => _db = value; }
        public string Size { get => _size; set => _size = value; }
    }
}
