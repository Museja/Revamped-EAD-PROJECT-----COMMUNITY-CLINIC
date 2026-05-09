using System;

namespace MOLLCommunityClinicWeb1
{
    public partial class StaffDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("~/StaffLogin.aspx");
                return;
            }

            if (!IsPostBack)
            {
                lblName.Text = Session["Name"].ToString();
            }

            int role = Convert.ToInt32(Session["Role"]);

            if (role != 2 && role != 3)
            {
                Response.Redirect("~/StaffLogin.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            Response.Redirect("~/StaffLogin.aspx");
        }
    }
}