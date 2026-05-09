using CommunityClinic.Data;
using CommunityClinic.Models;
using System;
using System.Windows.Forms;

namespace CommunityClinic
{
    public partial class StaffLogin : Form
    {
        private UsersDAL usersDAL = new UsersDAL();

        public StaffLogin()
        {
            InitializeComponent();
        }

        private void StaffLogin_Load(object sender, EventArgs e)
        {
            EmailAddress.Clear();
            Password.Clear();
        }

        private void EmailAddress_TextChanged(object sender, EventArgs e)
        {
            // optional validation later
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            // optional validation later
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
                MessageBox.Show("Invalid login or account locked.");
                return;
            }

            // STAFF CHECK (Role 2 = Admin, Role 3 = Medical Staff)
            if (user.Role != 2 && user.Role != 3)
            {
                MessageBox.Show("Access denied. This login is for staff only.");
                return;
            }

            // Store session
            SessionManager.UserId = user.Id;
            SessionManager.Name = user.Name;
            SessionManager.Role = user.Role;
            SessionManager.Email = user.Email;

            MessageBox.Show("Welcome " + user.Name);

            // OPEN STAFF DASHBOARD (MDI)
            StaffDashboard dashboard = new StaffDashboard();
            dashboard.Show();

            this.Hide();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}