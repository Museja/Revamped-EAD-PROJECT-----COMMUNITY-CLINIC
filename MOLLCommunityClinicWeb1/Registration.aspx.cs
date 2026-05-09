using System;
using System.Text;
using System.Security.Cryptography;
using MOLLCommunityClinicWeb1.Models;
using MOLLCommunityClinicWeb1.Services;

namespace MOLLCommunityClinicWeb1
{
    public partial class Registration : System.Web.UI.Page
    {
        private RegistrationService userService = new RegistrationService();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
        }
        //Visible if User selects Admin or Medical Staff role
        protected void Role_CheckedChanged(object sender, EventArgs e)
        {
            pnlAdmin.Visible = radioAdmin.Checked;
            pnlMedStaff.Visible = radioMedicalstaff.Checked;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate password match
                if (txtPassword.Text != txtConfirmpassword.Text)
                {
                    lblMessage.Text = "Passwords do not match.";
                    return;
                }

                string role = GetRole();

                if (string.IsNullOrEmpty(role))
                {
                    lblMessage.Text = "Please select a role.";
                    return;
                }

                // Build user object
                RegistrationWeb user = new RegistrationWeb
                {
                    FullName = txtFullname.Text,
                    EmailAddress = txtEmail.Text,
                    Password = HashPassword(txtPassword.Text),
                    Role = role,
                    AdminID = role == "Admin" ? txtAdminId.Text : null,
                    MedStaffID = role == "Medical Staff" ? txtMedStaff.Text : null
                };

                // Save to database
                userService.RegisterUser(user);

                // ROLE-BASED REDIRECT
                if (role == "Patient")
                {
                    Response.Redirect("~/Success.aspx");
                }
                else if (role == "Admin" || role == "Medical Staff")
                {
                    Response.Redirect("~/StaffDashboard.aspx");
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        private string GetRole()
        {
            if (radioPatient.Checked) return "Patient";
            if (radioAdmin.Checked) return "Admin";
            if (radioMedicalstaff.Checked) return "Medical Staff";
            return "";
        }

        //Exit button to return to home page
        protected void btnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}