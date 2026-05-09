using CommunityClinic.Data;
using CommunityClinic.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace CommunityClinic
{
    public partial class PatientPortalForm : Form
    {
        private int patientId;

        private PatientDAL patientDAL = new PatientDAL();
        private AppointmentsDAL appointmentDAL = new AppointmentsDAL();
        private MedicalHistoryDAL historyDAL = new MedicalHistoryDAL();

        public PatientPortalForm(int id)
        {
            InitializeComponent();
            patientId = id;
        }

        public PatientPortalForm()
        {
            InitializeComponent();
            patientId = -1;
        }

        // LOAD FORM
        private void PatientPortalForm_Load(object sender, EventArgs e)
        {
            if (patientId > 0)
            {
                LoadPatientProfile();
                LoadAppointments();
            }
        }

        // =========================
        // LOAD APPOINTMENTS
        // =========================
        private void LoadAppointments()
        {
            try
            {
                dgvappointments1.DataSource =
                    appointmentDAL.GetAppointmentsByPatient(patientId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading appointments: " + ex.Message);
            }
        }

        // LOAD PROFILE
        private void LoadPatientProfile()
        {
            try
            {
                Patient patient =
                    patientDAL.GetPatientById(patientId);

                if (patient != null)
                {
                    txtFullName.Text = patient.Name;
                    txtPhone.Text = patient.PhoneNumber;
                    txtEmail.Text = patient.EmailAddress;
                    txtAddress.Text = patient.Address;
                    dtDOB.Value = patient.DateOfBirth;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile: " + ex.Message);
            }
        }

        // UPDATE PROFILE
        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            try
            {
                Patient patient = new Patient
                {
                    PatientID = patientId,
                    Name = txtFullName.Text.Trim(),
                    PhoneNumber = txtPhone.Text.Trim(),
                    EmailAddress = txtEmail.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    DateOfBirth = dtDOB.Value
                };

                bool success = patientDAL.UpdatePatient(patient);

                MessageBox.Show(success ? "Profile updated!" : "Update failed.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    
        // BOOK APPOINTMENT
        private void btnBookAppointment_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtReason.Text))
                {
                    MessageBox.Show("Please enter a reason.");
                    return;
                }

                bool success = appointmentDAL.BookAppointment(
                    patientId,
                    dtpAppointment.Value,
                    txtReason.Text.Trim()
                );

                if (success)
                {
                    MessageBox.Show("Appointment booked successfully!");

                    LoadAppointments();

                    txtReason.Clear();
                    dtpAppointment.Value = DateTime.Now;
                }
                else
                {
                    MessageBox.Show("Booking failed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error booking appointment: " + ex.Message);
            }
        }

        // REFRESH APPOINTMENTS
        private void btnRefreshAppointments_Click(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        // CANCEL APPOINTMENT
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvappointments1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Select an appointment first.");
                    return;
                }

                int id =
                    Convert.ToInt32(dgvappointments1.SelectedRows[0].Cells["Id"].Value);

                appointmentDAL.CancelAppointment(id);

                MessageBox.Show("Appointment cancelled.");

                LoadAppointments();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cancelling appointment: " + ex.Message);
            }
        }

        // RESCHEDULE APPOINTMENT
        private void btnReschedule_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvappointments1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Select an appointment first.");
                    return;
                }

                int id =
                    Convert.ToInt32(dgvappointments1.SelectedRows[0].Cells["Id"].Value);

                appointmentDAL.RescheduleAppointment(id, dtpAppointment.Value);

                MessageBox.Show("Appointment rescheduled.");

                LoadAppointments();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error rescheduling: " + ex.Message);
            }
        }

        // HISTORY
        private void btnLoadHistory_Click(object sender, EventArgs e)
        {
            dgvHistory1.DataSource =
                historyDAL.GetHistoryByPatient(patientId);
        }


        // EXIT APP
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        // LOGOUT

        private void Logout_Click(object sender, EventArgs e)
        {
            LogoutForm form = new LogoutForm();
            form.Show();
            this.Close();
        }

        private void btnLoadPrescriptions_Click(object sender, EventArgs e)
        {

        }
    }
}