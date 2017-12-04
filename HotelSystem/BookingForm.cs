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
            string DBAddress;
            string SQL;
            DBAddress = "Data Source=VisitorTable;Initial Catalog=Air; Trusted_Connection=True;";
            using (SqlConnection cmd = new SqlConnection(DBAddress))
            {
                
            }
        }
    }
}
