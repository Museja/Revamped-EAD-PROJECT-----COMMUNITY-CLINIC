using MOLLCommunityClinicWeb1.Models;
using MOLLCommunityClinicWeb1.Services;
using System;

namespace MOLLCommunityClinicWeb1
{
    public partial class Appointments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Appointmentsweb appt = new Appointmentsweb
                {
                    PatientId = Convert.ToInt32(txtPatientId.Text),
                    AppointmentDate = Convert.ToDateTime(txtDate.Text),
                    Reason = txtReason.Text,
                    Status = ddlStatus.SelectedValue
                };

                // call service
                AppointmentsService service = new AppointmentsService();
                service.BookAppointment(appt);

                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Appointment booked successfully!";

                ClearFields();
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error: " + ex.Message;
            }
        }

        private void ClearFields()
        {
            txtPatientId.Text = "";
            txtDate.Text = "";
            txtReason.Text = "";
            ddlStatus.SelectedIndex = 0;
        }
    }
}