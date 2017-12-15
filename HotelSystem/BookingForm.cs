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
            this.FormClosing += new FormClosingEventHandler(BookingForm_Closing);
        }
        private void BookingForm_Closing(object sender, FormClosingEventArgs e)
        {
            Form2 HomeScreen = Application.OpenForms["Form2"] as Form2;
            HomeScreen.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Validation(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text))
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
                using(SqlCommand Comm = new SqlCommand(
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
            return ("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename="+ path + "Database1.mdf;Integrated Security=True");
        }
        private bool Validation(string FName, string SName, string Numb, string VEmail, string Notes)
        {
            //FIRSTNAME START
            label35.Text = "";
            Regex AlphNum = new Regex("^[a-zA-Z0-9]*$");
            Regex Num = new Regex("^[0-9]*$");
            bool end = true;
            if (AlphNum.IsMatch(FName)==false)
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
            if ((Numb.Length>0&&Numb.Length<6)||Numb.Length>15)
            {
                end = false;
                label35.Text += "\r\nPNumber must be between 6 and 14 characters";
            }
            if (Num.IsMatch(Numb)==false)
            {
                end = false;
                label35.Text += "\r\nPNumber must contain only numbers.";
            }
            //CONTACTNO END
            //EMAIL START

            //EMAIL END
            //NOTES START

            //NOTES END

            return false;
        }
    }
}
