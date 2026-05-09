using CommunityClinic.Data;
using CommunityClinic.Models;
using System;
using System.Windows.Forms;

namespace CommunityClinic
{
    public partial class Appointments : Form
    {
        private AppointmentsDAL appointmentDAL = new AppointmentsDAL();

        public Appointments()
        {
            InitializeComponent();
        }

        // SAVE BUTTON
        private void btnSave_Click(object sender, EventArgs e)
        
      
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFullname.Text))
                {
                    MessageBox.Show("Full Name is required.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDocName.Text))
                {
                    MessageBox.Show("Doctor Name is required.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtReason.Text))
                {
                    MessageBox.Show("Reason is required.");
                    return;
                }

                // CREATE DAL OBJECT (IMPORTANT)
                AppointmentsDAL dal = new AppointmentsDAL();

                bool result = dal.BookAppointment(
                    1, // TEMP PATIENT ID (replace later with logged-in user)
                    txtFullname.Text.Trim(),
                    txtDocName.Text.Trim(),
                    dateTimePicker1.Value,
                    txtReason.Text.Trim()
                );

                if (result)
                {
                    MessageBox.Show("Appointment saved successfully!");
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Failed to save appointment.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving appointment: " + ex.Message);
            }
        
        }

        // CLEAR FORM
        private void ClearFields()
        {
            txtFullname.Clear();
            txtDocName.Clear();
            txtReason.Clear();
            dateTimePicker1.Value = DateTime.Now;
        }

        // EXIT
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // BACK
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtFullname_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtDocName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtReason_TextChanged(object sender, EventArgs e)
        {

        }
    }
}