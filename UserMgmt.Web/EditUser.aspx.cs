using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace UserMgmt.Web
{
    public partial class EditUser : Page
    {
        private int _userID;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Get the UserID from the URL e.g. EditUser.aspx?id=5
            if (!int.TryParse(Request.QueryString["id"], out _userID))
            {
                lblMessage.CssClass = "msg-error";
                lblMessage.Text = "Invalid user ID.";
                return;
            }

            if (!IsPostBack)
                LoadUser();
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
                            txtDob.Text = Convert.ToDateTime(reader["DateOfBirth"])
                                                        .ToString("yyyy-MM-dd");

                            rblGender.SelectedValue = reader["Gender"].ToString();

                            txtCell.Text = reader["CellPhone"] != DBNull.Value
                                                ? reader["CellPhone"].ToString() : "";
                            txtMobile.Text = reader["MobilePhone"] != DBNull.Value
                                                ? reader["MobilePhone"].ToString() : "";

                            ddlParish.SelectedValue = reader["Parish"].ToString();
                        }
                        else
                        {
                            lblMessage.CssClass = "msg-error";
                            lblMessage.Text = "User not found.";
                        }
                    }
                }
            }
        }

        private void SaveChanges()
        {
            bool hasCell = !string.IsNullOrWhiteSpace(txtCell.Text);
            bool hasMobile = !string.IsNullOrWhiteSpace(txtMobile.Text);

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
                                 WHERE Id = @Id";

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
                    cmd.Parameters.AddWithValue("@Id", _userID);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Re-read id on postback(changed from UserID)
            int.TryParse(Request.QueryString["id"], out _userID);

            if (string.IsNullOrWhiteSpace(txtCell.Text) && string.IsNullOrWhiteSpace(txtMobile.Text))
            {
                lblMessage.CssClass = "msg-error";
                lblMessage.Text = "Please enter at least one phone number (Cell or Mobile).";
                return;
            }

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
                SaveChanges();
                Response.Redirect("ViewUsers.aspx");
            }
            catch (Exception ex)
            {
                lblMessage.CssClass = "msg-error";
                lblMessage.Text = "Error updating user: " + ex.Message;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewUsers.aspx");
        }
    }
}