using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class frmManageEvent : Form
    {
        //  Potrebno je samo promijeniti "Data Source" u ime računala korisnika
        public string MyCon = @"Data Source=DESKTOP-SVE91S2\SQLEXPRESS;Initial Catalog=calendar;Integrated Security=True";
        public frmManageEvent()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        { }

        [Obsolete]
        private void frmManageEvent_Load(object sender, EventArgs e)
        {
            string date3 = frmCalendar.date2;
            DateTime dateTime = DateTime.Parse(date3);
            dtpDate.Value = dateTime;
            string   string2 = dateTime.ToString();
            using (SqlConnection sourcecon4 = new SqlConnection(MyCon)){
                sourcecon4.Open();
                SqlCommand cmd3 = new SqlCommand();
                cmd3.CommandText = "SELECT Event, Description FROM calendardb WHERE Date = @Date";
                cmd3.Parameters.Add("@Date", string2);
                cmd3.Connection = sourcecon4;
                SqlDataReader dataReader11 = cmd3.ExecuteReader();
                string evName = "";
                string evDesc = "";
                while (dataReader11.Read()){
                    evName = dataReader11[0].ToString();
                    evDesc = dataReader11[1].ToString();
                }
                txtName.Text = evName;
                txtDesc.Text = evDesc;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void txtDesc_TextChanged(object sender, EventArgs e)
        { }
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection sourcecon4 = new SqlConnection(MyCon)){
                sourcecon4.Open();
                SqlCommand cmd3 = new SqlCommand();
                cmd3.CommandText = "INSERT INTO calendardb VALUES('" + dtpDate.Value + "','" + txtName.Text + "','" + txtDesc.Text+"')";
                cmd3.Connection = sourcecon4;
                cmd3.ExecuteNonQuery();
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Naziv događaja je potreban.");
                return;
            }
            MessageBox.Show("Spremljeno.");
            return;
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        { }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtDesc.Text = "";
            using (SqlConnection sourcecon4 = new SqlConnection(MyCon))
            {
                sourcecon4.Open();
                SqlCommand cmd3 = new SqlCommand();
                cmd3.CommandText = "DELETE FROM calendardb WHERE date = ('" + dtpDate.Value + "')";
                cmd3.Connection = sourcecon4;
                cmd3.ExecuteNonQuery();
            }
        }
    }
}
