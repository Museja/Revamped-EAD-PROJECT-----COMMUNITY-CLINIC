using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOLLCommunityClinicWeb1
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Clear session immediately when page loads
            Session.Clear();
            Session.Abandon();
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {

            Session.Clear();
            Session.Abandon();


            Response.Write("<script>window.close();</script>");
        }
    }
}
