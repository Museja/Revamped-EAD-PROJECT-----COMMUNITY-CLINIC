using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserMgmt
{
    public partial class FrmNewAppt : Form
    {
        public FrmNewAppt()
        {
            InitializeComponent();
        }

        // ─────────────────────────────────────────────
        //  VALIDATION
        // ─────────────────────────────────────────────
        private bool ValidateForm()
        {
            // First Name
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First Name is required.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtFirstName.Focus();
                return false;
            }

            // Last Name
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Last Name is required.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtLastName.Focus();
                return false;
            }

            // Email
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email is required.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtEmail.Focus();
                return false;
            }

            // Email format check
            try
            {
                var email = new System.Net.Mail.MailAddress(txtEmail.Text);
            }
            catch
            {
                MessageBox.Show("Enter a valid email address.", "Check", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtEmail.Focus();
                return false;
            }

            // Radio buttons (Male / Female)
            if (!radioMale.Checked && !radioFemale.Checked)
            {
                MessageBox.Show("Please select Male or Female.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            // Radio buttons (New or Returning Patient Yes / No)
            if (!radioYes.Checked && !radioNo.Checked)
            {
                MessageBox.Show("Please indicate whether this is a returning patient or not. (Yes or No).", "Required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            // Phone validation — at least one contact required
            bool hasCell = !string.IsNullOrWhiteSpace(txtCell.Text)
                           && txtCell.Text != "(876)555-5555";
            bool hasMobile = !string.IsNullOrWhiteSpace(txtMobile.Text)
                             && txtMobile.Text != "(876)555-5555";

            if (!hasCell && !hasMobile)
            {
                MessageBox.Show("Please enter at least one phone number (Cell or Mobile).",
                                "Required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtCell.Focus();
                return false;
            }

            // Validate cell only if it was filled in
            if (hasCell && (!txtCell.Text.All(char.IsDigit) || txtCell.Text.Length != 10))
            {
                MessageBox.Show("Cell number must be exactly 10 digits.",
                                "Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtCell.Focus();
                return false;
            }

            // Validate mobile only if it was filled in
            if (hasMobile && (!txtMobile.Text.All(char.IsDigit) || txtMobile.Text.Length != 10))
            {
                MessageBox.Show("Mobile number must be exactly 10 digits.",
                                "Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtMobile.Focus();
                return false;
            }

            // Date of Birth 
            if (dtpDob.Value >= DateTime.Now)
            {
                MessageBox.Show("Date of Birth must be in the past.", "Check", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                dtpDob.Focus();
                return false;
            }

            // Parish validation
            if (cmbParish.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a parish.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cmbParish.Focus();
                return false;
            }

            // Address validation
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Address is required.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtAddress.Focus();
                return false;
            }

            // Town validation
            if (string.IsNullOrWhiteSpace(txtTown.Text))
            {
                MessageBox.Show("Town is required.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtTown.Focus();
                return false;
            }

            // Appointment Type
            if (cmbApptType.SelectedIndex == 0)
            {
                MessageBox.Show("Please select an appointment type.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cmbApptType.Focus();
                return false;
            }

            // Doctor
            if (cmbDocName.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a doctor.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cmbDocName.Focus();
                return false;
            }

            // Appointment Time
            if (cmbTime.SelectedIndex == 0)
            {
                MessageBox.Show("Please select an appointment time.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cmbTime.Focus();
                return false;
            }

            // Appointment Date
            if (dtpApptDate.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Appointment date must be today or a future date.",
                                "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            return true; // ✅ end of validation - everything passed

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtNotes.Clear();
            txtCell.Text = "(876)555-5555";
            txtCell.ForeColor = Color.FromArgb(220, 220, 220);
            txtMobile.Text = "(876)555-5555";
            txtMobile.ForeColor = Color.FromArgb(220, 220, 220);
            radioFemale.Checked = false;
            radioMale.Checked = false;
            radioYes.Checked = false;
            radioNo.Checked = false;
            txtAddress.Clear();
            txtTown.Clear();
            cmbParish.SelectedIndex = 0;
            dtpApptDate.Value = DateTime.Today;
            cmbApptType.SelectedIndex = 0;
            cmbTime.SelectedIndex = 0;
            cmbDocName.SelectedIndex = 0;
        }

        private void SaveAppointment()
        {
            bool hasCell = !string.IsNullOrWhiteSpace(txtCell.Text)
                             && txtCell.Text != "(876)555-5555";
            bool hasMobile = !string.IsNullOrWhiteSpace(txtMobile.Text)
                             && txtMobile.Text != "(876)555-5555";

            string connStr = ConfigurationManager.ConnectionStrings["HealthcareDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = @"INSERT INTO Appointments
                            (FirstName, LastName, Email, Gender,
                             CellPhone, MobilePhone, Address, Town, Parish,
                             IsNewPatient, AppointmentType, AppointmentDate,
                             AppointmentTime, DoctorName, Notes)
                         VALUES
                            (@FirstName, @LastName, @Email, @Gender,
                             @CellPhone, @MobilePhone, @Address, @Town, @Parish,
                             @IsNewPatient, @AppointmentType, @AppointmentDate,
                             @AppointmentTime, @DoctorName, @Notes)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Gender", radioMale.Checked ? "Male" : "Female");
                    cmd.Parameters.AddWithValue("@CellPhone", hasCell ? (object)txtCell.Text : DBNull.Value);
                    cmd.Parameters.AddWithValue("@MobilePhone", hasMobile ? (object)txtMobile.Text : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@Town", txtTown.Text.Trim());
                    cmd.Parameters.AddWithValue("@Parish", cmbParish.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@IsNewPatient", radioYes.Checked ? "Yes" : "No");
                    cmd.Parameters.AddWithValue("@AppointmentType", cmbApptType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@AppointmentDate", dtpApptDate.Value.Date);
                    cmd.Parameters.AddWithValue("@AppointmentTime", cmbTime.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@DoctorName", cmbDocName.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(txtNotes.Text)
                                                                        ? (object)DBNull.Value
                                                                        : txtNotes.Text.Trim());

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnNewAppt_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            string first = txtFirstName.Text;
            string last = txtLastName.Text;

            try
            {
                SaveAppointment();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating appointment: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Appointment created for: " + first + " " + last,
                            "Appointment Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Block non-digit input
            }
        } 
        private void txtCell_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Block non-digit input
            }
        }
        private void txtMobile_Enter(object sender, EventArgs e)
        {
            if (txtMobile.Text == "(876)555-5555")
            {
                txtMobile.Text = "";
                txtMobile.ForeColor = Color.Black;
            }
        }
        private void txtMobile_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMobile.Text))
            {
                txtMobile.Text = "(876)555-5555";
                txtMobile.ForeColor = Color.FromArgb(220, 220, 220);
            }
        }
        private void txtCell_Enter(object sender, EventArgs e)
        {
            if (txtCell.Text == "(876)555-5555")
            {
                txtCell.Text = "";
                txtCell.ForeColor = Color.Black;
            }
        }

        private void txtCell_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCell.Text))
            {
                txtCell.Text = "(876)555-5555";
                txtCell.ForeColor = Color.FromArgb(220, 220, 220);
            }
        }

        // ─────────────────────────────────────────────
        //  FORM LOAD
        // ─────────────────────────────────────────────
        private void FrmNewAppt_Load(object sender, EventArgs e)
        {
            if (cmbParish.Items.Count == 0)
            {
                cmbParish.Items.AddRange(new object[]
                {
                    "Select a Parish",
                    "Clarendon", "Hanover", "Kingston",
                    "Manchester", "Portland", "Saint Andrew",
                    "Saint Ann", "Saint Catherine", "Saint Elizabeth",
                    "Saint James", "Saint Mary", "Saint Thomas",
                    "Trelawny", "Westmoreland"
                });
            }
            cmbParish.SelectedItem = 0; //error here - should be "Select a Parish" but it doesn't work for some reason

            if (cmbApptType.Items.Count == 0)
            {
                cmbApptType.Items.AddRange(new object[]
                {
                    "-- Select Appointment Type --",
                    "General Consultation",
                    "Follow-up",
                    "Lab Work",
                    "Specialist Referral",
                    "Routine Check-up",
                    "Emergency"
                });
            }
            cmbApptType.SelectedItem = "-- Select Appointment Type --";

            if (cmbTime.Items.Count == 0)
            {
                cmbTime.Items.Add("-- Select Time --");
                DateTime slot = DateTime.Today.AddHours(8);
                DateTime end = DateTime.Today.AddHours(17);
                while (slot <= end)
                {
                    cmbTime.Items.Add(slot.ToString("hh:mm tt"));
                    slot = slot.AddMinutes(30);
                }
            }
            cmbTime.SelectedItem = "-- Select Time --";

            if (cmbDocName.Items.Count == 0)
            {
                cmbDocName.Items.AddRange(new object[]
                {
                    "-- Select Doctor --",
                    "Dr. Brown  —  General Practice",
                    "Dr. Clarke  —  Cardiology",
                    "Dr. Davis  —  Paediatrics",
                    "Dr. Miller  —  Orthopaedics"
                });
            }
            cmbDocName.SelectedItem = "-- Select Doctor --";

            // Phone placeholders
            txtCell.Text = "(876)555-5555";
            txtCell.ForeColor = Color.FromArgb(220, 220, 220);
            txtMobile.Text = "(876)555-5555";
            txtMobile.ForeColor = Color.FromArgb(220, 220, 220);

        }
    }
}
