using System;
using MOLLCommunityClinicWeb1.Models;
using MOLLCommunityClinicWeb1.Services;

namespace MOLLCommunityClinicWeb1
{
    public partial class PatientList : System.Web.UI.Page
    {
        private PatientService patientService = new PatientService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPatients();
            }
        }

        // LOAD ALL PATIENTS (FROM DATABASE)
        private void LoadPatients()
        {
            try
            {
                var patients = patientService.GetAllPatients();

                gvPatients.DataSource = patients;
                gvPatients.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error loading patients: " + ex.Message;
            }
        }

        // SEARCH PATIENTS (USING SERVICE)
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string search = txtSearch.Text.Trim();

                var results = patientService.SearchPatients(search);

                gvPatients.DataSource = results;
                gvPatients.DataBind();

                if (results.Count == 0)
                {
                    lblMessage.Text = "No patients found.";
                }
                else
                {
                    lblMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Search error: " + ex.Message;
            }
        }

        // REFRESH
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            lblMessage.Text = "";
            LoadPatients();
        }

        //  BACK
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MainMDI.aspx");
        }

        //  EXIT
        protected void btnExit_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }
    }
}