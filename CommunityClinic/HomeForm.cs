using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommunityClinic
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistrationForm reg = new RegistrationForm();
            reg.Show();
        }

        private void PatientLogin_Click(object sender, EventArgs e)
        {
            PatientLogin reg = new PatientLogin();
            reg.Show();
        }

        private void StaffLogin_Click(object sender, EventArgs e)
        {
            StaffLogin  reg = new   StaffLogin();
            reg.Show();
        }
    }
}
