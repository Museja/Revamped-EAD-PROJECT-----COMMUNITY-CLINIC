using System;

namespace MOLLCommunityClinicWeb1
{
    public partial class MedicalHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        // BACK BUTTON
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StaffDashboard.aspx");
        }
    }
}