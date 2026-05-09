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
    public partial class LogoutForm : Form
    {
        public LogoutForm()
        {
            InitializeComponent();
        }
        // Event handler for the link label click event to navigate back to the HomeForm
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HomeForm homeForm = new HomeForm();
            homeForm.Show();

            this.Hide();
        }
        // Event handler for the button click event to confirm exit and close the application
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
          "Are you sure you want to exit the application?",
           "Exit Application",
           MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
