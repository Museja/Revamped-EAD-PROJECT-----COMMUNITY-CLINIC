using System;
using System.Web;
using System.Web.UI;

namespace UserMgmt.Web.Helpers
{
    public static class NotificationHelper
    {
        // Types: success, info, warning, error
        public static void Set(Page page, string message, string type = "info")
        {
            if (page == null) return;
            page.Session["NotificationMessage"] = message;
            page.Session["NotificationType"] = type;
        }

        public static void Clear(Page page)
        {
            if (page == null) return;
            page.Session.Remove("NotificationMessage");
            page.Session.Remove("NotificationType");
        }
    }
}
