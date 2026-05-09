using CommunityClinic.Models;
using System;
using System.Data;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace CommunityClinic
{
    public partial class UserManagement : Form
    {
        private PatientDAL patientDAL = new PatientDAL();

        public UserManagement()
        {
            InitializeComponent();
        }

        // FORM LOAD
        private void UserManagement_Load(object sender, EventArgs e)
        {
            LoadPatients();
        }

        // LOAD PATIENTS
        private void LoadPatients(string search = "")
        {
            DataTable dt = patientDAL.SearchPatients(search);

            dgvUsers.DataSource = dt;

            dgvUsers.ReadOnly = false;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
        }

        // UPDATE PATIENTS
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvUsers.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    Patient p = new Patient
                    {
                        PatientID = Convert.ToInt32(row.Cells["PatientID"].Value),
                        Name = row.Cells["Name"].Value.ToString(),
                        DateOfBirth = Convert.ToDateTime(row.Cells["DateOfBirth"].Value),
                        Age = Convert.ToInt32(row.Cells["Age"].Value),
                        Address = row.Cells["Address"].Value.ToString(),
                        PhoneNumber = row.Cells["PhoneNumber"].Value.ToString(),
                        EmailAddress = row.Cells["EmailAddress"].Value.ToString(),
                        Gender = row.Cells["Gender"].Value.ToString(),
                        Allergies = row.Cells["Allergies"].Value.ToString(),
                        History = row.Cells["History"].Value.ToString(),
                        Medications = row.Cells["Medications"].Value.ToString()
                    };

                    patientDAL.UpdatePatient(p);
                }

                MessageBox.Show("Patients updated successfully.");
                LoadPatients();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // DELETE PATIENT
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsers.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(
                        dgvUsers.SelectedRows[0].Cells["PatientID"].Value);

                    patientDAL.DeletePatient(id);

                    MessageBox.Show("Patient deleted successfully.");

                    LoadPatients();
                }
                else
                {
                    MessageBox.Show("Please select a patient.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting patient: " + ex.Message);
            }
        }

        // BACK
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // EXIT APPLICATION
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit the application?",
                "Confirm Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            String search = txtSearch.Text.Trim();

            // SHOW ALL PATIENTS IF SEARCH IS EMPTY
            if (string.IsNullOrWhiteSpace(search))
            {
                LoadPatients();
                return;
            }

            // VALIDATION
            if (search.Length < 2)
            {
                MessageBox.Show("Please enter at least 2 characters to search.");
                return;
            }

            // SEARCH PATIENTS
            LoadPatients(search);
        }
    }
}