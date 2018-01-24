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
        public BookingForm()
        {
            InitializeComponent();
        }

        private void BookingForm_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (Validation(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, dateTimePicker1.Value, dateTimePicker2.Value, comboBox1.Text))
            {
                DBVisitorAdd(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
            }
        }
        private void DBVisitorAdd(string FName, string SName, string Numb, string VEmail, string Notes)
        {

            string ConStr = LinkString();
            using (SqlConnection DB = new SqlConnection(ConStr))
            {
                DB.Open();
                using (SqlCommand Comm = new SqlCommand(
                "INSERT INTO Visitors (FName, SName, ContactNo, Email, Notes) VALUES(@FName, @SName, @ContactNo, @Email, @Notes)", DB))
                {
                    Comm.Parameters.Add(new SqlParameter("FName", FName));
                    Comm.Parameters.Add(new SqlParameter("SName", SName));
                    Comm.Parameters.Add(new SqlParameter("ContactNo", Numb));
                    Comm.Parameters.Add(new SqlParameter("Email", VEmail));
                    Comm.Parameters.Add(new SqlParameter("Notes", Notes));
                    Comm.ExecuteNonQuery();
                }
            }
        }
        private string LinkString()
        {
            string path = (AppDomain.CurrentDomain.BaseDirectory);
            return ("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + path + "Database1.mdf;Integrated Security=True");
        }
        private bool Validation(string FName, string SName, string Numb, string VEmail, string Notes, DateTime DateStart, DateTime DateEnd, string Combo)
        {
            //FIRSTNAME START
            label35.Text = "";
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

            return end;

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
            if (Validation(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, dateTimePicker1.Value, dateTimePicker2.Value, comboBox1.Text))
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
                var SearchList = new List<TempRoom>();
                TimeSpan diff = dateTimePicker2.Value - dateTimePicker1.Value;
                for (int n = 1; n < 8; n++)
                {
                    tabnum = (Label)tableLayoutPanel1.GetControlFromPosition(0, y);
                    tabnum.Text = "";
                    tabnote = (Label)tableLayoutPanel1.GetControlFromPosition(1, y);
                    tabnote.Text = "";
                    tabprice = (Label)tableLayoutPanel1.GetControlFromPosition(2, y);
                    tabprice.Text = "";
                    y++;
                }
                y = 1;
                for (int i = 0; i < OutputList.Count; i++)
                {
                    if (RoomSearch(OutputList[i]))
                    {
                        tabnum = (Label)tableLayoutPanel1.GetControlFromPosition(0, y);
                        tabnum.Text = OutputList[i].Num;
                        tabnote = (Label)tableLayoutPanel1.GetControlFromPosition(1, y);
                        tabnote.Text = OutputList[i].Notes;
                        tabprice = (Label)tableLayoutPanel1.GetControlFromPosition(2, y);
                        tabprice.Text = Convert.ToString(OutputList[i].Price * (diff.Days + 1));
                        y = y + 1;
                        SearchList.Add(OutputList[i]);
                    }

                    if (y == 7)
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
