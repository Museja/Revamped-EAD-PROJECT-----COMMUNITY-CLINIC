using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MOLLCommunityClinicWeb1.Models;
using MOLLCommunityClinicWeb1.Services;

namespace MOLLCommunityClinicWeb1
{
    public partial class AppointmentsList : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["CommunityClinicLLOMDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAppointments();
            }
        }

        private void LoadAppointments()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT Id, PatientId, AppointmentDate, Reason, Status FROM Appointments";
                SqlDataAdapter da = new SqlDataAdapter(query, con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                gvAppointments.DataSource = dt;
                gvAppointments.DataBind();
            }
        }

        protected void gvAppointments_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvAppointments.DataKeys[e.RowIndex].Value);

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "DELETE FROM Appointments WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Appointment deleted successfully.";

            LoadAppointments();
        }
    }
}