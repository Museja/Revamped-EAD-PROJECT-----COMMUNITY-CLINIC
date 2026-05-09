using System;
using System.Security.Cryptography;
using System.Text;
using MOLLCommunityClinicWeb1.Models;
using MOLLCommunityClinicWeb1.Services;

namespace MOLLCommunityClinicWeb1
{
    public partial class PatientLogin : System.Web.UI.Page
    {
        RegistrationService userService = new RegistrationService();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Please enter email and password.";
                return;
            }

            int roleId = 1; // PATIENT ONLY

            string hashedPassword = HashPassword(password);

            RegistrationService service = new RegistrationService();

            RegistrationWeb user =
                service.LoginUser(email, hashedPassword, "Patient");

            if (user != null)
            {
                // SESSION
                Session["UserId"] = user.PatientID;
                Session["Name"] = user.FullName;
                Session["Role"] = user.Role;

                // REDIRECT TO PATIENT PORTAL
                Response.Redirect("~/PatientPortal.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid patient login credentials.";
            }
        }

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