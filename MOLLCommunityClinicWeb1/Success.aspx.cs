using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOLLCommunityClinicWeb1
{
    public partial class Success : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // GO TO NEXT PAGE (PATIENT FORM)
        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PatientForm.aspx");
        }

        // EXIT (LOG OUT SYSTEM)
        protected void btnExit_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            // Redirect to login or home page
            Response.Redirect("~/Login.aspx");
        }
    }
}