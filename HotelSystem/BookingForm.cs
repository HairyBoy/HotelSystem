using System;
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
            DBVisitorAdd(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
        }
        private void DBVisitorAdd(string FName, string SName, string Numb, string VEmail, string Notes)
        {
            
            string ConStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\lewis\\Source\\Repos\\HotelSystem\\HotelSystem\\Database1.mdf;Integrated Security=True";
            using (SqlConnection DB = new SqlConnection(ConStr))
            {
                DB.Open();
                using(SqlCommand Comm = new SqlCommand(
                "INSERT INTO Visitors VALUES(@FName, @SName, @ContactNo, @Email, @Notes)", DB))
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
    }
}
