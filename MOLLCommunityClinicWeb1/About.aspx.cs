using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOLLCommunityClinicWeb1
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // This page currently displays static information

            if (!IsPostBack)
            {
                // Runs only the first time the page loads
                LoadAboutContent();
            }
        }

        private void LoadAboutContent()
        {

        }
    }
}