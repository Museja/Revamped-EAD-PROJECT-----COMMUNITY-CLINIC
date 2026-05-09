using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace UserMgmt.Web
{
    public partial class UserPortal : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Nothing needed here for now
        }

        private void SaveUser()
        {
            bool hasCell = !string.IsNullOrWhiteSpace(txtCell.Text);
            bool hasMobile = !string.IsNullOrWhiteSpace(txtMobile.Text);

            string connStr = ConfigurationManager.ConnectionStrings["HealthcareDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = @"INSERT INTO Users
                                    (FirstName, LastName, Email, Gender, DateOfBirth,
                                     CellPhone, MobilePhone, Address, Town, Parish)
                                 VALUES
                                    (@FirstName, @LastName, @Email, @Gender, @DateOfBirth,
                                     @CellPhone, @MobilePhone, @Address, @Town, @Parish)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Gender", rblGender.SelectedValue);
                    cmd.Parameters.AddWithValue("@DateOfBirth", DateTime.Parse(txtDob.Text));
                    cmd.Parameters.AddWithValue("@CellPhone", hasCell ? (object)txtCell.Text.Trim() : DBNull.Value);
                    cmd.Parameters.AddWithValue("@MobilePhone", hasMobile ? (object)txtMobile.Text.Trim() : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@Town", txtTown.Text.Trim());
                    cmd.Parameters.AddWithValue("@Parish", ddlParish.SelectedValue);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Phone check
            if (string.IsNullOrWhiteSpace(txtCell.Text) && string.IsNullOrWhiteSpace(txtMobile.Text))
            {
                lblMessage.CssClass = "msg-error";
                lblMessage.Text = "Please enter at least one phone number (Cell or Mobile).";
                return;
            }

            // DOB check
            if (!string.IsNullOrWhiteSpace(txtDob.Text))
            {
                DateTime dob = DateTime.Parse(txtDob.Text);
                if (dob >= DateTime.Today)
                {
                    lblMessage.CssClass = "msg-error";
                    lblMessage.Text = "Date of Birth must be in the past.";
                    return;
                }
            }

            try
            {
                SaveUser();
                lblMessage.CssClass = "msg-success";
                lblMessage.Text = "User created successfully!";
                ClearForm();
            }
            catch (Exception ex)
            {
                lblMessage.CssClass = "msg-error";
                lblMessage.Text = "Error creating user: " + ex.Message;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtDob.Text = "";
            txtCell.Text = "";
            txtMobile.Text = "";
            txtAddress.Text = "";
            txtTown.Text = "";
            rblGender.ClearSelection();
            ddlParish.SelectedIndex = 0;
            lblMessage.Text = "";
        }
    }
}