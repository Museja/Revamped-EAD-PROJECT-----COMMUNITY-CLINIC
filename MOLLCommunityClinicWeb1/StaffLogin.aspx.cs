using System;
using System.Security.Cryptography;
using System.Text;
using MOLLCommunityClinicWeb1.Models;
using MOLLCommunityClinicWeb1.Services;

namespace MOLLCommunityClinicWeb1
{
    public partial class StaffLogin : System.Web.UI.Page
    {
        // SERVICE OBJECT
        RegistrationService registrationService = new RegistrationService();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            // VALIDATE INPUT
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Please enter email and password.";
                return;
            }

            // GET ROLE FROM RADIO BUTTONS (STRING NOW)
            string role = GetRole();

            if (string.IsNullOrEmpty(role))
            {
                lblMessage.Text = "Please select a role.";
                return;
            }

            // HASH PASSWORD
            string hashedPassword = HashPassword(password);

            // LOGIN
            RegistrationService service = new RegistrationService();

            RegistrationWeb user =
                service.LoginUser(email, hashedPassword, role);
            if (user != null)
            {
                // SESSION VALUES
                Session["UserId"] = user.PatientID;
                Session["Name"] = user.FullName;
                Session["Role"] = user.Role;

                // REDIRECT BASED ON ROLE
                if (role == "Admin")
                {
                    Response.Redirect("~/StaffDashboard.aspx");
                }
                else if (role == "Medical Staff")
                {
                    Response.Redirect("~/StaffDashboard.aspx");
                }
               
            }
            else
            {
                lblMessage.Text = "Invalid login credentials.";
            }
        }

        // ROLE FROM RADIO BUTTONS
        private string GetRole()
        {
            if (radioAdmin.Checked)
                return "Admin";

            if (radioMedicalStaff.Checked)
                return "Medical Staff";

            return "";
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
    }
}