using System;
using System.Linq;
using MOLLCommunityClinicWeb1.Models;
using MOLLCommunityClinicWeb1.Services;

namespace MOLLCommunityClinicWeb1
{
    public partial class UserManagement : System.Web.UI.Page
    {
        PatientService PatientService = new PatientService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("~/StaffLogin.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadPatients();
            }
        }

        // LOAD ALL PATIENTS
        private void LoadPatients()
        {
            gvPatients.DataSource =
                PatientService.GetAllPatients();

            gvPatients.DataBind();
        }

        // SEARCH
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string name = txtSearch.Text.Trim();

            var results = PatientService.GetAllPatients()
                .Where(p => p.Name.ToLower().Contains(name.ToLower()))
                .ToList();

            gvPatients.DataSource = results;
            gvPatients.DataBind();
        }

        // SELECT PATIENT FROM GRID
        protected void gvPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = gvPatients.SelectedIndex;

            txtId.Text =
                gvPatients.SelectedRow.Cells[0].Text;

            txtName.Text =
                gvPatients.SelectedRow.Cells[1].Text;

            txtEmail.Text =
                gvPatients.SelectedRow.Cells[2].Text;

            txtPhone.Text =
                gvPatients.SelectedRow.Cells[3].Text;

            txtAddress.Text =
                gvPatients.SelectedRow.Cells[4].Text;
        }

        // UPDATE
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            PatientWeb patient = new PatientWeb
            {
                PatientID = Convert.ToInt32(txtId.Text),
                Name = txtName.Text,
                EmailAddress = txtEmail.Text,
                PhoneNumber = txtPhone.Text,
                Address = txtAddress.Text
            };

            PatientService PatientService = new PatientService();

            PatientService.UpdatePatient(patient);
            lblMessage.Text = "Patient updated successfully.";

            LoadPatients();
        }

        // DELETE
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);

            PatientService.DeletePatient(id);

            lblMessage.Text = "Patient deleted successfully.";

            LoadPatients();
        }
    }
}