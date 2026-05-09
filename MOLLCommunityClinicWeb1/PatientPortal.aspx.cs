using System;
using System.Linq;
using System.Web.UI;
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
            if (Session["UserId"] == null)
            {
                Response.Redirect("~/PatientLogin.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadAllData();
            }
        }

        // LOAD ALL DATA
        private void LoadAllData()
        {
            LoadPatientData();
            LoadAppointments();
            LoadMedicalHistory();
        }

        // PROFILE
        private void LoadPatientData()
        {
            int patientId = Convert.ToInt32(Session["UserId"]);

            var patients = patientService.GetAllPatients();
            var patient = patients.FirstOrDefault(p => p.PatientID == patientId);

            if (patient != null)
            {
                txtFullName.Text = patient.Name;
                txtEmail.Text = patient.EmailAddress;
                txtPhone.Text = patient.PhoneNumber;
                txtAddress.Text = patient.Address;
            }
        }

        //  APPOINTMENTS
        private void LoadAppointments()
        {
            int patientId = Convert.ToInt32(Session["UserId"]);

            var appointments = appointmentService.GetByPatientId(patientId);

            gvAppointments.DataSource = appointments;
            gvAppointments.DataBind();
        }

        // MEDICAL HISTORY 
        private void LoadMedicalHistory()
        {
            try
            {
                int patientId = Convert.ToInt32(Session["UserId"]);

                MedicalHistoryService historyService =
                    new MedicalHistoryService();

                var history =
                    historyService.GetByPatientId(patientId);

                gvHistory.DataSource = history;
                gvHistory.DataBind();
            }
            catch (Exception ex)
            {
                lblMessages.Text =
                    "Error loading medical history: " + ex.Message;
            }
        }

        // SAVE PROFILE
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int patientId = Convert.ToInt32(Session["UserId"]);

            PatientWeb patient = new PatientWeb
            {
                PatientID = patientId,
                Name = txtFullName.Text,
                EmailAddress = txtEmail.Text,
                PhoneNumber = txtPhone.Text,
                Address = txtAddress.Text
            };

            patientService.UpdatePatient(patient);

            lblMessages.Text = "Profile updated successfully.";
        }

        // BOOK APPOINTMENT
        protected void btnBook_Click(object sender, EventArgs e)
        {
            int patientId = Convert.ToInt32(Session["UserId"]);

            Appointmentsweb appointment = new Appointmentsweb
            {
                PatientId = patientId,
                AppointmentDate = DateTime.Parse(txtNewDate.Text),
                Reason = "New Appointment",
                Status = "Pending"
            };

            appointmentService.BookAppointment(appointment);

            lblMessages.Text = "Appointment booked successfully.";

            LoadAppointments();
        }

        // ================= RESCHEDULE =================
        protected void btnReschedule_Click(object sender, EventArgs e)
        {
            int appointmentId = Convert.ToInt32(txtAppointmentId.Text);

            appointmentService.UpdateStatus(appointmentId, "Rescheduled");

            lblMessages.Text = "Appointment rescheduled.";
            LoadAppointments();
        }

        //  CANCEL
        protected void btnCancelAppointment_Click(object sender, EventArgs e)
        {
            int appointmentId = Convert.ToInt32(txtAppointmentId.Text);

            appointmentService.UpdateStatus(appointmentId, "Cancelled");

            lblMessages.Text = "Appointment cancelled.";
            LoadAppointments();
        }

        //  RELOAD
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