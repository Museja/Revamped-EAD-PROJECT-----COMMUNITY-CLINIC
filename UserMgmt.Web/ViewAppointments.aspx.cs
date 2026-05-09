using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace UserMgmt.Web
{
    public partial class ViewAppointments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LoadAppointments();
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Load attempted. Row count: " + gvAppts.Rows.Count;
                }
                catch (Exception ex)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
        }

        private void LoadAppointments()
        {
            string connStr = ConfigurationManager.ConnectionStrings["HealthcareDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = @"SELECT Id, FirstName, LastName, Email, Gender,
                                        CellPhone, MobilePhone, Parish, IsNewPatient,
                                        AppointmentType, AppointmentDate, AppointmentTime,
                                        DoctorName, Notes, CreatedAt
                                 FROM Appointments
                                 ORDER BY AppointmentDate, AppointmentTime";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gvAppts.DataSource = dt;
                    gvAppts.DataBind();
                }
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        protected void gvAppts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int apptID = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditAppt")
            {
                Response.Redirect("EditAppointment.aspx?id=" + apptID);
            }
            else if (e.CommandName == "DeleteAppt")
            {
                DeleteAppointment(apptID);
                LoadAppointments();
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Appointment deleted successfully.";
            }
        }

        protected void gvAppts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAppts.PageIndex = e.NewPageIndex;
            LoadAppointments();
        }

        private void DeleteAppointment(int apptID)
        {
            string connStr = ConfigurationManager.ConnectionStrings["HealthcareDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = "DELETE FROM Appointments WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", apptID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}