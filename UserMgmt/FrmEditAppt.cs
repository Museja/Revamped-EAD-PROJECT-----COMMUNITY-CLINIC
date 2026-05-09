using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace UserMgmt
{
    public partial class FrmEditAppt : Form
    {
        private int _apptID;

        public FrmEditAppt(int apptID)
        {
            InitializeComponent();
            _apptID = apptID;
        }

        // ─────────────────────────────────────────────
        //  FORM LOAD
        // ─────────────────────────────────────────────
        private void FrmEditAppt_Load(object sender, EventArgs e)
        {
            // Populate combos first, then load the record
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

            // Phone placeholders
            txtCell.Text = "(876)555-5555";
            txtCell.ForeColor = Color.FromArgb(220, 220, 220);
            txtMobile.Text = "(876)555-5555";
            txtMobile.ForeColor = Color.FromArgb(220, 220, 220);

            LoadAppointment();
        }

        // ─────────────────────────────────────────────
        //  LOAD APPOINTMENT INTO FIELDS
        // ─────────────────────────────────────────────
        private void LoadAppointment()
        {
            string connStr = ConfigurationManager.ConnectionStrings["HealthcareDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Select explicit columns and use the actual primary key column name `Id`.
                string query = @"SELECT FirstName, LastName, Email, Address, Town,
                                        Notes, Gender, IsNewPatient, CellPhone,
                                        MobilePhone, Parish, AppointmentType,
                                        DoctorName, AppointmentTime
                                 FROM Appointments
                                 WHERE Id = @AppointmentID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Use a typed parameter instead of AddWithValue for reliability
                    cmd.Parameters.Add("@AppointmentID", System.Data.SqlDbType.Int).Value = _apptID;

                    // Only expect a single row
                    using (SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.SingleRow))
                    {
                        if (reader.Read())
                        {
                            txtFirstName.Text = reader["FirstName"].ToString();
                            txtLastName.Text = reader["LastName"].ToString();
                            txtEmail.Text = reader["Email"].ToString();
                            txtAddress.Text = reader["Address"].ToString();
                            txtTown.Text = reader["Town"].ToString();
                            txtNotes.Text = reader["Notes"] != DBNull.Value
                                                    ? reader["Notes"].ToString()
                                                    : "";

                            // Gender
                            if (reader["Gender"].ToString() == "Male")
                                radioMale.Checked = true;
                            else
                                radioFemale.Checked = true;

                            // New patient
                            if (reader["IsNewPatient"].ToString() == "Yes")
                                radioYes.Checked = true;
                            else
                                radioNo.Checked = true;

                            // Phone — restore placeholder if null
                            txtCell.Text = reader["CellPhone"] != DBNull.Value
                                ? reader["CellPhone"].ToString()
                                : "(876)555-5555";
                            txtCell.ForeColor = reader["CellPhone"] != DBNull.Value
                                ? Color.Black
                                : Color.FromArgb(220, 220, 220);

                            txtMobile.Text = reader["MobilePhone"] != DBNull.Value
                                ? reader["MobilePhone"].ToString()
                                : "(876)555-5555";
                            txtMobile.ForeColor = reader["MobilePhone"] != DBNull.Value
                                ? Color.Black
                                : Color.FromArgb(220, 220, 220);

                            // Parish
                            int parishIdx = cmbParish.FindStringExact(reader["Parish"].ToString());
                            cmbParish.SelectedIndex = parishIdx >= 0 ? parishIdx : 0;

                            // Appointment Type
                            int apptTypeIdx = cmbApptType.FindStringExact(reader["AppointmentType"].ToString());
                            cmbApptType.SelectedIndex = apptTypeIdx >= 0 ? apptTypeIdx : 0;

                            // Doctor
                            int docIdx = cmbDocName.FindStringExact(reader["DoctorName"].ToString());
                            cmbDocName.SelectedIndex = docIdx >= 0 ? docIdx : 0;

                            // Time
                            int timeIdx = cmbTime.FindStringExact(reader["AppointmentTime"].ToString());
                            cmbTime.SelectedIndex = timeIdx >= 0 ? timeIdx : 0;
                        }
                        else
                        {
                            // No record found - inform user and close
                            MessageBox.Show("Appointment not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                }
            }
        }

        // ─────────────────────────────────────────────
        //  VALIDATION
        // ─────────────────────────────────────────────
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First Name is required.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Last Name is required.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtLastName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email is required.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtEmail.Focus();
                return false;
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(txtEmail.Text);
            }
            catch
            {
                MessageBox.Show("Enter a valid email address.", "Check", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtEmail.Focus();
                return false;
            }

            if (!radioMale.Checked && !radioFemale.Checked)
            {
                MessageBox.Show("Please select Male or Female.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            if (!radioYes.Checked && !radioNo.Checked)
            {
                MessageBox.Show("Please indicate whether this is a returning patient (Yes or No).", "Required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

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

            if (hasCell && (!txtCell.Text.All(char.IsDigit) || txtCell.Text.Length != 10))
            {
                MessageBox.Show("Cell number must be exactly 10 digits.", "Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtCell.Focus();
                return false;
            }

            if (hasMobile && (!txtMobile.Text.All(char.IsDigit) || txtMobile.Text.Length != 10))
            {
                MessageBox.Show("Mobile number must be exactly 10 digits.", "Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtMobile.Focus();
                return false;
            }

            if (cmbParish.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a parish.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cmbParish.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Address is required.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtAddress.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTown.Text))
            {
                MessageBox.Show("Town is required.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtTown.Focus();
                return false;
            }

            if (cmbApptType.SelectedIndex == 0)
            {
                MessageBox.Show("Please select an appointment type.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cmbApptType.Focus();
                return false;
            }

            if (cmbDocName.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a doctor.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cmbDocName.Focus();
                return false;
            }

            if (cmbTime.SelectedIndex == 0)
            {
                MessageBox.Show("Please select an appointment time.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cmbTime.Focus();
                return false;
            }

            if (dtpApptDate.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Appointment date must be today or a future date.",
                                "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                dtpApptDate.Focus();
                return false;
            }

            return true; // ✅ all checks passed
        }

        // ─────────────────────────────────────────────
        //  SAVE CHANGES
        // ─────────────────────────────────────────────
        private void SaveChanges()
        {
            bool hasCell = !string.IsNullOrWhiteSpace(txtCell.Text)
                             && txtCell.Text != "(876)555-5555";
            bool hasMobile = !string.IsNullOrWhiteSpace(txtMobile.Text)
                             && txtMobile.Text != "(876)555-5555";

            string connStr = ConfigurationManager.ConnectionStrings["HealthcareDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = @"UPDATE Appointments SET
                                    FirstName       = @FirstName,
                                    LastName        = @LastName,
                                    Email           = @Email,
                                    Gender          = @Gender,
                                    CellPhone       = @CellPhone,
                                    MobilePhone     = @MobilePhone,
                                    Address         = @Address,
                                    Town            = @Town,
                                    Parish          = @Parish,
                                    IsNewPatient    = @IsNewPatient,
                                    AppointmentType = @AppointmentType,
                                    AppointmentDate = @AppointmentDate,
                                    AppointmentTime = @AppointmentTime,
                                    DoctorName      = @DoctorName,
                                    Notes           = @Notes
                                 WHERE Id = @AppointmentID";

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
                    cmd.Parameters.AddWithValue("@AppointmentID", _apptID);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ─────────────────────────────────────────────
        //  BUTTON HANDLERS
        // ─────────────────────────────────────────────
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating appointment: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Appointment updated successfully.",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtNotes.Clear();
            txtAddress.Clear();
            txtTown.Clear();

            txtCell.Text = "(876)555-5555";
            txtCell.ForeColor = Color.FromArgb(220, 220, 220);
            txtMobile.Text = "(876)555-5555";
            txtMobile.ForeColor = Color.FromArgb(220, 220, 220);

            radioMale.Checked = false;
            radioFemale.Checked = false;
            radioYes.Checked = false;
            radioNo.Checked = false;

            cmbParish.SelectedIndex = 0;
            cmbApptType.SelectedIndex = 0;
            cmbTime.SelectedIndex = 0;
            cmbDocName.SelectedIndex = 0;
            dtpApptDate.Value = DateTime.Today;
        }

        // ─────────────────────────────────────────────
        //  PHONE — KEYPRESS FILTERS
        // ─────────────────────────────────────────────
        private void txtCell_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        // ─────────────────────────────────────────────
        //  PHONE — PLACEHOLDER ENTER / LEAVE
        // ─────────────────────────────────────────────
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
    }
}