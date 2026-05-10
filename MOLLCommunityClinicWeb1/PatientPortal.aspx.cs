using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using MOLLCommunityClinicWeb1.Models;
using MOLLCommunityClinicWeb1.Services;

namespace MOLLCommunityClinicWeb1
{
    public partial class PatientPortal : System.Web.UI.Page
    {
        private PatientService patientService = new PatientService();
        private AppointmentsService appointmentService = new AppointmentsService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null)
            {
                Response.Redirect("~/PatientLogin.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadAllData();
            }
        }

        //LOAD ALL
        private void LoadAllData()
        {
            LoadPatientData();
            LoadAppointments();
            LoadMedicalHistory();
        }

        // PROFILE
        private void LoadPatientData()
        {
            string email = Session["UserEmail"].ToString();

            var patient = patientService.GetPatientByEmail(email);

            if (patient != null)
            {
                gvProfile.DataSource = new[] { patient };
                gvProfile.DataBind();
            }
        }

        // EDIT PROFILE
        protected void gvProfile_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvProfile.EditIndex = e.NewEditIndex;
            LoadPatientData();
        }

        protected void gvProfile_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvProfile.EditIndex = -1;
            LoadPatientData();
        }

        protected void gvProfile_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int patientId = Convert.ToInt32(gvProfile.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvProfile.Rows[e.RowIndex];

            PatientWeb patient = new PatientWeb
            {
                PatientID = patientId,
                Name = ((TextBox)row.Cells[1].Controls[0]).Text,
                Email = ((TextBox)row.Cells[2].Controls[0]).Text,
                Phone = ((TextBox)row.Cells[3].Controls[0]).Text,
                Address = ((TextBox)row.Cells[4].Controls[0]).Text
            };

            patientService.UpdatePatient(patient);

            gvProfile.EditIndex = -1;
            LoadPatientData();

            lblMessages.Text = "Profile updated successfully.";
        }

        // APPOINTMENTS
        private void LoadAppointments()
        {
            int patientId = Convert.ToInt32(Session["UserId"]);

            gvAppointments.DataSource = appointmentService.GetByPatientId(patientId);
            gvAppointments.DataBind();
        }

        //  MEDICAL HISTORY
        private void LoadMedicalHistory()
        {
            int patientId = Convert.ToInt32(Session["UserId"]);

            MedicalHistoryService service = new MedicalHistoryService();

            gvHistory.DataSource = service.GetByPatientId(patientId);
            gvHistory.DataBind();
        }

        // BOOK 
        protected void btnBook_Click(object sender, EventArgs e)
        {
            int patientId = Convert.ToInt32(Session["UserId"]);

            if (!DateTime.TryParse(txtNewDate.Text, out DateTime date))
            {
                lblMessages.Text = "Invalid date.";
                return;
            }

            appointmentService.BookAppointment(new Appointmentsweb
            {
                PatientId = patientId,
                AppointmentDateTime = date,
                Reason = "New Appointment",
                Status = "Pending"
            });

            LoadAppointments();
        }

        // RESCHEDULE
        protected void btnReschedule_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtAppointmentId.Text, out int id))
            {
                appointmentService.UpdateStatus(id, "Rescheduled");
                LoadAppointments();
            }
        }

        //CANCEL
        protected void btnCancelAppointment_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtAppointmentId.Text, out int id))
            {
                appointmentService.UpdateStatus(id, "Cancelled");
                LoadAppointments();
            }
        }

        // RELOAD
        protected void btnLoad_Click(object sender, EventArgs e)
        {
            LoadAllData();
        }

       // LOGOUT
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/PatientLogin.aspx");
        }
    }
}