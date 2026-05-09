using CommunityClinic.Models;
using CommunityClinic.Data;
using System;
using System.Windows.Forms;

namespace CommunityClinic
{
    public partial class StaffDashboard : Form
    {
        public StaffDashboard()
        {
            InitializeComponent();
        }

        // FORM LOAD
        private void StaffDashboard_Load(object sender, EventArgs e)
        {
        
        }

        // INVENTORY - ADD
        private void addInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InventoryItemForm form = new InventoryItemForm();
            form.MdiParent = this;
            form.Show();
        }

        // INVENTORY - LIST

        private void inventoryListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventorylist form = new Inventorylist();
            form.MdiParent = this;
            form.Show();
        }

        // PATIENT LIST

        private void patientListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Patientlist form = new Patientlist();
            form.MdiParent = this;
            form.Show();
        }


        // USER MANAGEMENT

        private void patientManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserManagement form = new UserManagement();
            form.MdiParent = this;
            form.Show();
        }


        // INVENTORY MANAGEMENT

        private void inventoryManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InventoryManagement form = new InventoryManagement();
            form.MdiParent = this;
            form.Show();
        }


        // APPOINTMENTS LIST

        private void appointmentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Appointmentslist form = new Appointmentslist();
            form.MdiParent = this;
            form.Show();
        }


        // LOGOUT

        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Clear session
            SessionManager.UserId = 0;
            SessionManager.Name = null;
            SessionManager.Role = "Admin";
            SessionManager.Role = "Medical Staff";
            SessionManager.Email = null;

            // Return to Home
            this.Hide();

            HomeForm home = new HomeForm();
            home.Show();
        }

        // EXIT APPLICATION
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}