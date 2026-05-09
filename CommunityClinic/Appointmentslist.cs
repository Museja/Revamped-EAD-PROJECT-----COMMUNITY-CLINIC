using System;
using System.Data;
using System.Windows.Forms;
using CommunityClinic.Data;

namespace CommunityClinic
{
    public partial class Appointmentslist : Form
    {
        private AppointmentsDAL appointmentDAL = new AppointmentsDAL();

        public Appointmentslist()
        {
            InitializeComponent();
        }

        // LOAD FORM
        private void Appointmentslist_Load(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        // LOAD ALL APPOINTMENTS
        private void LoadAppointments()
        {
            try
            {
                DataTable dt = appointmentDAL.GetAllAppointments();

                dgvAppointments.DataSource = dt;

                // READ ONLY GRID
                dgvAppointments.ReadOnly = true;
                dgvAppointments.AllowUserToAddRows = false;
                dgvAppointments.AllowUserToDeleteRows = false;
                dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading appointments: " + ex.Message);
            }
        }

        // BACK
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            StaffDashboard dashboard = new StaffDashboard();
            dashboard.Show();
        }

        // EXIT
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgvAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}