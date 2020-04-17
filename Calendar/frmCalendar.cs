using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class frmCalendar : Form
    {
        public frmCalendar()
        {
            InitializeComponent();
        }
        private void mcCalendar_DateChanged(object sender, DateRangeEventArgs e)
        { }
        private void label1_Click(object sender, EventArgs e)
        { }
        private void calendar1_Load(object sender, EventArgs e)
        { }
        private void mcCalendar_DateSelected(object sender, DateRangeEventArgs e)
        { }
        public static string date2 = "";
        private void mcCalendar_DateChanged_1(object sender, DateRangeEventArgs e)
        {
            date2= mcCalendar.SelectionEnd.ToString();
            frmManageEvent frm2 = new frmManageEvent();
            frm2.Show();
        }
    }
}
