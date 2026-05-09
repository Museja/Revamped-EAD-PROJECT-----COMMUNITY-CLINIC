using CommunityClinic.Data;
using CommunityClinic.Models;
using System;
using System.Windows.Forms;

namespace CommunityClinic
{
    public partial class PatientLogin : Form
    {
        private RegistrationDAL usersDAL = new RegistrationDAL();

        public PatientLogin()
        {
            InitializeComponent();
        }

        private void PatientLogin_Load(object sender, EventArgs e)
        {
            EmailAddress.Clear();
            Password.Clear();
        }
        // Event handler for the Login button click
        private void Login_Click(object sender, EventArgs e)
        {
            string email = EmailAddress.Text.Trim();
            string password = Password.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter email and password.");
                return;
            }

            try
            {
                Registrationclass user =
                    usersDAL.LoginUser(email, password, "Patient");

                if (user == null)
                {
                    MessageBox.Show("Invalid login or account is locked.");
                    return;
                }

                if (user.Role != "Patient")
                {
                    MessageBox.Show("Access denied. Patients only.");
                    return;
                }

                SessionManager.UserId = user.PatientID;
                SessionManager.Name = user.FullName;
                SessionManager.Role = user.Role;

                MessageBox.Show("Welcome " + user.FullName);

                PatientPortalForm portal = new PatientPortalForm();
                portal.Show();

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login error: " + ex.Message);
            }
        }
        // Event handler for the Exit button click
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void EmailAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void Password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}