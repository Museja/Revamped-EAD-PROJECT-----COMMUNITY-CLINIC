using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using CommunityClinic.Models;

namespace CommunityClinic
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        // HASH PASSWORD
        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        // REGISTER BUTTON
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName = txtFullname.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmpassword.Text;
            string adminId = txtAdminId.Text.Trim();

            string role = "";

            if (radioPatient.Checked)
                role = "Patient";
            else if (radioAdmin.Checked)
                role = "Admin";
            else if (radioMedicalstaff.Checked)
                role = "Medical Staff";

            List<string> errors = new List<string>();

            // VALIDATION
            if (string.IsNullOrWhiteSpace(fullName))
                errors.Add("Full Name is required");

            if (string.IsNullOrWhiteSpace(email))
                errors.Add("Email is required");

            if (string.IsNullOrWhiteSpace(password))
                errors.Add("Password is required");
            else if (password.Length < 6)
                errors.Add("Password must be at least 6 characters");

            if (password != confirmPassword)
                errors.Add("Passwords do not match");

            if (string.IsNullOrEmpty(role))
                errors.Add("Please select a role");

            if (role == "Admin")
            {
                if (string.IsNullOrWhiteSpace(adminId))
                    errors.Add("Admin ID is required");

                if (adminId != "12345")
                    errors.Add("Invalid Admin ID");
            }

            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join("\n", errors), "Validation Error");
                return;
            }

            try
            {
                string passwordHash = HashPassword(password);

                // FIXED DAL USAGE
                RegistrationDAL dal = new RegistrationDAL();

                UserRegistration user = new UserRegistration
                {
                    FullName = fullName,
                    EmailAddress = email,
                    Password = passwordHash,
                    Role = role,
                    AdminID = role == "Admin" ? adminId : null
                };

                bool success = dal.InsertUser(user);

                if (success)
                {
                    //Form nextForm = (role == "Patient")
                    //    ? new SuccessForm()
                    //    : new MainFormMDI();
                    //nextForm.Show();
                    //this.Hide();

                    SuccessForm f = new SuccessForm();
                    f.Show();
                    this.Hide();
                    
                }
                else
                {
                    MessageBox.Show("Error saving registration.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
            }
        }

        // EXIT
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit?",
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