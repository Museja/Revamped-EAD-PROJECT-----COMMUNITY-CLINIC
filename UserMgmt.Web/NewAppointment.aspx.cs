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
    public partial class NewAppointment : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                PopulateTimeSlots();
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

        private void SaveAppointment()
        {
            bool hasCell = !string.IsNullOrWhiteSpace(txtCell.Text);
            bool hasMobile = !string.IsNullOrWhiteSpace(txtMobile.Text);

            string connStr = ConfigurationManager.ConnectionStrings["HealthcareDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = @"INSERT INTO Appointments
                                    (FirstName, LastName, Email, Gender,
                                     CellPhone, MobilePhone, Address, Town, Parish,
                                     IsNewPatient, AppointmentType, AppointmentDate,
                                     AppointmentTime, DoctorName, Notes)
                                 VALUES
                                    (@FirstName, @LastName, @Email, @Gender,
                                     @CellPhone, @MobilePhone, @Address, @Town, @Parish,
                                     @IsNewPatient, @AppointmentType, @AppointmentDate,
                                     @AppointmentTime, @DoctorName, @Notes)";

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

                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Phone — at least one required
            if (string.IsNullOrWhiteSpace(txtCell.Text) && string.IsNullOrWhiteSpace(txtMobile.Text))
            {
                lblMessage.CssClass = "msg-error";
                lblMessage.Text = "Please enter at least one phone number (Cell or Mobile).";
                return;
            }

            // Appointment date must be today or future
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
                SaveAppointment();
                NotificationHelper.Set(this.Page, "Appointment created successfully.", "success");
                Response.Redirect("ViewAppointments.aspx");
            }
            catch (Exception ex)
            {
                lblMessage.CssClass = "msg-error";
                lblMessage.Text = "Error creating appointment: " + ex.Message;
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
            txtCell.Text = "";
            txtMobile.Text = "";
            txtAddress.Text = "";
            txtTown.Text = "";
            txtApptDate.Text = "";
            txtNotes.Text = "";
            rblGender.ClearSelection();
            rblNewPatient.ClearSelection();
            ddlParish.SelectedIndex = 0;
            ddlApptType.SelectedIndex = 0;
            ddlDocName.SelectedIndex = 0;
            ddlTime.SelectedIndex = 0;
            lblMessage.Text = "";
        }
    }
}