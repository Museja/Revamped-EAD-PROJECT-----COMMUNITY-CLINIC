using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using UserMgmt.Web.Helpers;

namespace UserMgmt.Web
{
    public partial class EditAppointment : Page
    {
        private int _apptID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.QueryString["id"], out _apptID))
            {
                lblMessage.CssClass = "msg-error";
                lblMessage.Text = "Invalid appointment ID.";
                return;
            }

            if (!IsPostBack)
            {
                PopulateTimeSlots();
                LoadAppointment();
            }
        }

        private void PopulateTimeSlots()
        {
            ddlTime.Items.Clear();
            ddlTime.Items.Add(new System.Web.UI.WebControls.ListItem("-- Select Time --", ""));

            DateTime slot = DateTime.Today.AddHours(8);
            DateTime end = DateTime.Today.AddHours(17);

            while (slot <= end)
            {
                string time = slot.ToString("hh:mm tt");
                ddlTime.Items.Add(new System.Web.UI.WebControls.ListItem(time, time));
                slot = slot.AddMinutes(30);
            }
        }

        private void LoadAppointment()
        {
            string connStr = ConfigurationManager.ConnectionStrings["HealthcareDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = "SELECT * FROM Appointments WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", _apptID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtFirstName.Text = reader["FirstName"].ToString();
                            txtLastName.Text = reader["LastName"].ToString();
                            txtEmail.Text = reader["Email"].ToString();
                            txtAddress.Text = reader["Address"].ToString();
                            txtTown.Text = reader["Town"].ToString();
                            txtNotes.Text = reader["Notes"] != DBNull.Value
                                                    ? reader["Notes"].ToString() : "";

                            txtApptDate.Text = Convert.ToDateTime(reader["AppointmentDate"])
                                                        .ToString("yyyy-MM-dd");

                            rblGender.SelectedValue = reader["Gender"].ToString();
                            rblNewPatient.SelectedValue = reader["IsNewPatient"].ToString();

                            txtCell.Text = reader["CellPhone"] != DBNull.Value
                                                ? reader["CellPhone"].ToString() : "";
                            txtMobile.Text = reader["MobilePhone"] != DBNull.Value
                                                ? reader["MobilePhone"].ToString() : "";

                            ddlParish.SelectedValue = reader["Parish"].ToString();
                            ddlApptType.SelectedValue = reader["AppointmentType"].ToString();
                            ddlDocName.SelectedValue = reader["DoctorName"].ToString();
                            ddlTime.SelectedValue = reader["AppointmentTime"].ToString();
                        }
                        else
                        {
                            lblMessage.CssClass = "msg-error";
                            lblMessage.Text = "Appointment not found.";
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

                string query = @"UPDATE Appointments SET
                                    FirstName       = @FirstName,
                                    LastName        = @LastName,
                                    Email           = @Email,
                                    Gender          = @Gender,
                                    CellPhone       = @CellPhone,
                                    MobilePhone     = @MobilePhone,
                                    Address         = @Address,
                                    Town            = @Town,
                                    Parish          = @Parish,
                                    IsNewPatient    = @IsNewPatient,
                                    AppointmentType = @AppointmentType,
                                    AppointmentDate = @AppointmentDate,
                                    AppointmentTime = @AppointmentTime,
                                    DoctorName      = @DoctorName,
                                    Notes           = @Notes
                                 WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Gender", rblGender.SelectedValue);
                    cmd.Parameters.AddWithValue("@CellPhone", hasCell ? (object)txtCell.Text.Trim() : DBNull.Value);
                    cmd.Parameters.AddWithValue("@MobilePhone", hasMobile ? (object)txtMobile.Text.Trim() : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@Town", txtTown.Text.Trim());
                    cmd.Parameters.AddWithValue("@Parish", ddlParish.SelectedValue);
                    cmd.Parameters.AddWithValue("@IsNewPatient", rblNewPatient.SelectedValue);
                    cmd.Parameters.AddWithValue("@AppointmentType", ddlApptType.SelectedValue);
                    cmd.Parameters.AddWithValue("@AppointmentDate", DateTime.Parse(txtApptDate.Text));
                    cmd.Parameters.AddWithValue("@AppointmentTime", ddlTime.SelectedValue);
                    cmd.Parameters.AddWithValue("@DoctorName", ddlDocName.SelectedValue);
                    cmd.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(txtNotes.Text)
                                                                        ? (object)DBNull.Value
                                                                        : txtNotes.Text.Trim());
                    cmd.Parameters.AddWithValue("@Id", _apptID);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["id"], out _apptID);

            if (string.IsNullOrWhiteSpace(txtCell.Text) && string.IsNullOrWhiteSpace(txtMobile.Text))
            {
                lblMessage.CssClass = "msg-error";
                lblMessage.Text = "Please enter at least one phone number (Cell or Mobile).";
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtApptDate.Text))
            {
                DateTime apptDate = DateTime.Parse(txtApptDate.Text);
                if (apptDate.Date < DateTime.Today)
                {
                    lblMessage.CssClass = "msg-error";
                    lblMessage.Text = "Appointment date must be today or a future date.";
                    return;
                }
            }

            try
            {
                SaveChanges();
                NotificationHelper.Set(this.Page, "Appointment updated successfully.", "success");
                Response.Redirect("ViewAppointments.aspx");
            }
            catch (Exception ex)
            {
                lblMessage.CssClass = "msg-error";
                lblMessage.Text = "Error updating appointment: " + ex.Message;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewAppointments.aspx");
        }
    }
}