using CommunityClinic.Data;
using CommunityClinic.Models;
using System;
using System.Windows.Forms;

namespace CommunityClinic
{
    public partial class PatientLogin : Form
    {
        private UsersDAL usersDAL = new UsersDAL();

        public PatientLogin()
        {
            InitializeComponent();
        }

        private void PatientLogin_Load(object sender, EventArgs e)
        {
            // clear fields on load
            EmailAddress.Clear();
            Password.Clear();
        }

        private void EmailAddress_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void Login_Click(object sender, EventArgs e)
        {
            string email = EmailAddress.Text.Trim();
            string password = Password.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter email and password.");
                return;
            }

            Users user = usersDAL.Login(email, password);

            if (user == null)
            {
                MessageBox.Show("Invalid login or account is locked.");
                return;
            }

            // Patient ONLY check (Role = 1)
            if (user.Role != 1)
            {
                MessageBox.Show("Access denied. This login is for patients only.");
                return;
            }

            // Store session
            SessionManager.UserId = user.Id;
            SessionManager.Name = user.Name;
            SessionManager.Role = user.Role;

            MessageBox.Show("Welcome " + user.Name);

            // OPEN PATIENT PORTAL
            PatientPortalForm portal = new PatientPortalForm();
            portal.Show();

            this.Hide();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}