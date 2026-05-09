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

        }//register button, opens the registration form

        private void button1_Click(object sender, EventArgs e)
        {
            RegistrationForm reg = new RegistrationForm();
            reg.Show();
        }
        //login button for patients, opens the patient login form
        private void PatientLogin_Click(object sender, EventArgs e)
        {
            PatientLogin reg = new PatientLogin();
            reg.Show();
        }
        //login button for staff, opens the staff login form
        private void StaffLogin_Click(object sender, EventArgs e)
        {
            StaffLogin  reg = new   StaffLogin();
            reg.Show();
        }
    }
}
