using System;
using System.Security.Cryptography;
using System.Text;
using MOLLCommunityClinicWeb1.Models;
using MOLLCommunityClinicWeb1.Services;

namespace MOLLCommunityClinicWeb1
{
    public partial class StaffLogin : System.Web.UI.Page
    {
        // CREATE SERVICE OBJECT
        UsersWebService userService = new UsersWebService();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            // VALIDATE EMPTY FIELDS
            if (string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Please enter email and password.";
                return;
            }

            // GET ROLE
            int roleId = GetRole();

            if (roleId == 0)
            {
                lblMessage.Text = "Please select a role.";
                return;
            }

            // HASH PASSWORD
            string hashedPassword = HashPassword(password);

            // LOGIN USING SERVICE
            UsersWeb user =
                userService.Login(email, hashedPassword, roleId);

            // CHECK LOGIN
            if (user != null)
            {
                // STORE SESSION VALUES
                Session["UserId"] = user.Id;
                Session["Name"] = user.Name;
                Session["Role"] = user.Role;

                // REDIRECT BASED ON ROLE
                if (user.Role == 2)
                {
                    Response.Redirect("~/AdminDashboard.aspx");
                }
                else if (user.Role == 3)
                {
                    Response.Redirect("~/MedicalStaffDashboard.aspx");
                }
            }
            else
            {
                lblMessage.Text = "Invalid login credentials.";
            }
        }

        // ROLE METHOD
        private int GetRole()
        {
            if (radioAdmin.Checked)
                return 2;

            if (radioMedicalStaff.Checked)
                return 3;

            return 0;
        }

        // HASH PASSWORD METHOD
        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes =
                    sha.ComputeHash(Encoding.UTF8.GetBytes(password));

                return Convert.ToBase64String(bytes);
            }
        }
    }
}