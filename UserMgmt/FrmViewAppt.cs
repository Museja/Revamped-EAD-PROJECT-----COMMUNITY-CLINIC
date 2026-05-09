using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace UserMgmt
{
    public partial class FrmViewAppt : Form
    {
        public FrmViewAppt()
        {
            InitializeComponent();
        }

        private void FrmViewAppt_Load(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void LoadAppointments()
        {
            string connStr = ConfigurationManager.ConnectionStrings["HealthcareDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = @"SELECT Id, FirstName, LastName, Email, Gender,
                                CellPhone, MobilePhone, Address, Town, Parish,
                                IsNewPatient, AppointmentType, AppointmentDate,
                                AppointmentTime, DoctorName, Notes, CreatedAt
                         FROM Appointments
                         ORDER BY AppointmentDate, AppointmentTime";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvViewAppt.DataSource = dt;

                    // Appearance
                    dgvViewAppt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvViewAppt.RowHeadersVisible = false;
                    dgvViewAppt.AllowUserToAddRows = false;
                    dgvViewAppt.ReadOnly = true;
                    dgvViewAppt.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    // Friendly column headers
                    dgvViewAppt.Columns["Id"].HeaderText = "ID";
                    dgvViewAppt.Columns["FirstName"].HeaderText = "First Name";
                    dgvViewAppt.Columns["LastName"].HeaderText = "Last Name";
                    dgvViewAppt.Columns["CellPhone"].HeaderText = "Cell";
                    dgvViewAppt.Columns["MobilePhone"].HeaderText = "Mobile";
                    dgvViewAppt.Columns["Address"].HeaderText = "Address";
                    dgvViewAppt.Columns["Town"].HeaderText = "Town";
                    dgvViewAppt.Columns["Parish"].HeaderText = "Parish";
                    dgvViewAppt.Columns["IsNewPatient"].HeaderText = "New Patient?";
                    dgvViewAppt.Columns["AppointmentType"].HeaderText = "Type";
                    dgvViewAppt.Columns["AppointmentDate"].HeaderText = "Date";
                    dgvViewAppt.Columns["AppointmentTime"].HeaderText = "Time";
                    dgvViewAppt.Columns["DoctorName"].HeaderText = "Doctor";
                    dgvViewAppt.Columns["CreatedAt"].HeaderText = "Date Added";
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvViewAppt.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to edit.", "No Selection",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            int apptID = Convert.ToInt32(dgvViewAppt.SelectedRows[0].Cells["Id"].Value);

            FrmEditAppt editForm = new FrmEditAppt(apptID);
            editForm.ShowDialog();
            LoadAppointments();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvViewAppt.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to delete.", "No Selection",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            string firstName = dgvViewAppt.SelectedRows[0].Cells["FirstName"].Value.ToString();
            string lastName = dgvViewAppt.SelectedRows[0].Cells["LastName"].Value.ToString();
            string date = dgvViewAppt.SelectedRows[0].Cells["AppointmentDate"].Value.ToString();
            int apptID = Convert.ToInt32(dgvViewAppt.SelectedRows[0].Cells["Id"].Value);

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to delete the appointment for " + firstName + " " + lastName +
                " on " + date + "?\nThis cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                DeleteAppointment(apptID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting appointment: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Appointment for " + firstName + " " + lastName + " has been deleted.",
                            "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadAppointments();
        }

        private void DeleteAppointment(int apptID)
        {
            string connStr = ConfigurationManager.ConnectionStrings["HealthcareDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = "DELETE FROM Appointments WHERE Id = @AppointmentID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AppointmentID", apptID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
