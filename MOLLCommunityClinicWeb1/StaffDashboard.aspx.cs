using System;

namespace MOLLCommunityClinicWeb1
{
    public partial class StaffDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 1. CHECK LOGIN FIRST
            if (Session["UserId"] == null || Session["Role"] == null)
            {
                Response.Redirect("~/StaffLogin.aspx");
                return;
            }

            // 2. ROLE CHECK
            int role = Convert.ToInt32(Session["Role"]);

            if (role != 2 && role != 3)
            {
                Response.Redirect("~/StaffLogin.aspx");
                return;
            }

            // 3. SET NAME ONLY ON FIRST LOAD
            if (!IsPostBack)
            {
                if (Session["Name"] != null)
                {
                    lblName.Text = Session["Name"].ToString();
                }
                else
                {
                    lblName.Text = "Staff";
                }
            }
        }

        // LOGOUT BUTTON
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            Response.Redirect("~/StaffLogin.aspx");
        }
    }
}