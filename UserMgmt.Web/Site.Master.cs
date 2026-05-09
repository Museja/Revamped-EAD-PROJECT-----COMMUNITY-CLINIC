using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserMgmt.Web
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Ensure the notification script is available on the page
                var scriptUrl = ResolveUrl("~/scripts/notification.js");
                if (ScriptManager.GetCurrent(this.Page) != null)
                {
                    // For pages using ScriptManager, register include using ScriptManager
                    if (!Page.ClientScript.IsClientScriptIncludeRegistered("siteNotificationScript"))
                        Page.ClientScript.RegisterClientScriptInclude("siteNotificationScript", scriptUrl);
                }
                else
                {
                    if (!Page.ClientScript.IsClientScriptIncludeRegistered("siteNotificationScript"))
                        Page.ClientScript.RegisterClientScriptInclude("siteNotificationScript", scriptUrl);
                }

                // Render a pending notification (if any) using session keys
                if (Session["NotificationMessage"] != null)
                {
                    string msg = Session["NotificationMessage"].ToString();
                    string type = Session["NotificationType"] != null ? Session["NotificationType"].ToString() : "info";

                    string encoded = HttpUtility.JavaScriptStringEncode(msg);
                    string script = $"showNotification('{encoded}', '{type}');";

                    if (ScriptManager.GetCurrent(this.Page) != null)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "siteNotification", script, true);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "siteNotification", script, true);
                    }

                    // Clear the session keys so notification is shown only once
                    Session.Remove("NotificationMessage");
                    Session.Remove("NotificationType");
                }
            }
            catch
            {
                // Fail silently - notifications should not break pages
            }
        }
    }
}