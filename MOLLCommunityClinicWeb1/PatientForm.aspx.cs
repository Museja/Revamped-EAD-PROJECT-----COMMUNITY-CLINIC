using System;
using MOLLCommunityClinicWeb1.Models;
using MOLLCommunityClinicWeb1.Services;

namespace MOLLCommunityClinicWeb1
{
    public partial class PatientForm : System.Web.UI.Page
    {
        private PatientService patientService = new PatientService();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // SAVE PATIENT
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                PatientWeb patient = new PatientWeb
                {
                    Name = txtFullName.Text,
                    EmailAddress = txtEmail.Text,
                    DateOfBirth = Convert.ToDateTime(txtDOB.Text),
                    Age = Convert.ToInt32(txtAge.Text),
                    Gender = ddlGender.SelectedValue,
                    PhoneNumber = txtPhone.Text,
                    Address = txtAddress.Text,
                    Allergies = txtAllergies.Text,
                    Medications = txtMedications.Text,
                    History = txtHistory.Text
                };

                patientService.AddPatient(patient);

                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Patient saved successfully.";
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error saving patient: " + ex.Message;
            }
        }

        // CLEAR FORM
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtDOB.Text = "";
            txtAge.Text = "";
            ddlGender.SelectedIndex = 0;
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtAllergies.Text = "";
            txtMedications.Text = "";
            txtHistory.Text = "";

            lblMessage.Text = "";
        }

        // BACK
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Success.aspx");
        }

        // EXIT
        protected void btnExit_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }
    }
}