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
    public partial class FrmEditUsers : Form
    {
        private int _userID;

        public FrmEditUsers(int userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        private void FrmEditUsers_Load(object sender, EventArgs e)
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

            // Phone placeholders as fallback
            txtCell.Text = "(876)555-5555";
            txtCell.ForeColor = Color.FromArgb(220, 220, 220);
            txtMobile.Text = "(876)555-5555";
            txtMobile.ForeColor = Color.FromArgb(220, 220, 220);

            LoadUser(); // now cmbParish has items so SelectedItem will match correctly
        }

        private void LoadUser()
        {
            string connStr = ConfigurationManager.ConnectionStrings["HealthcareDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = "SELECT * FROM Users WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", _userID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtFirstName.Text = reader["FirstName"].ToString();
                            txtLastName.Text = reader["LastName"].ToString();
                            txtEmail.Text = reader["Email"].ToString();
                            txtAddress.Text = reader["Address"].ToString();
                            txtTown.Text = reader["Town"].ToString();

                            // Gender radio buttons
                            if (reader["Gender"].ToString() == "Male")
                                radioMale.Checked = true;
                            else
                                radioFemale.Checked = true;

                            // Date of Birth
                            dtpDob.Value = Convert.ToDateTime(reader["DateOfBirth"]);

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
                            cmbParish.SelectedItem = reader["Parish"].ToString();
                        }
                    }
                }
            }
        }

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

                string query = @"UPDATE Users SET
                            FirstName   = @FirstName,
                            LastName    = @LastName,
                            Email       = @Email,
                            Gender      = @Gender,
                            DateOfBirth = @DateOfBirth,
                            CellPhone   = @CellPhone,
                            MobilePhone = @MobilePhone,
                            Address     = @Address,
                            Town        = @Town,
                            Parish      = @Parish
                         WHERE Id = @UserID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Gender", radioMale.Checked ? "Male" : "Female");
                    cmd.Parameters.AddWithValue("@DateOfBirth", dtpDob.Value.Date);
                    cmd.Parameters.AddWithValue("@CellPhone", hasCell ? (object)txtCell.Text : DBNull.Value);
                    cmd.Parameters.AddWithValue("@MobilePhone", hasMobile ? (object)txtMobile.Text : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@Town", txtTown.Text.Trim());
                    cmd.Parameters.AddWithValue("@Parish", cmbParish.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@UserID", _userID);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("User updated successfully.",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

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

            // Date of Birth 
            if (dtpDob.Value >= DateTime.Now)
            {
                MessageBox.Show("Date of Birth must be in the past.", "Check", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            // Radio buttons (Male / Female)
            if (!radioMale.Checked && !radioFemale.Checked)
            {
                MessageBox.Show("Please select Male or Female.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

            return true; // ✅ everything passed

        }
    }
}
