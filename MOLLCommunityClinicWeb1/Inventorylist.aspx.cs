using System;
using System.Linq;
using MOLLCommunityClinicWeb1.Models;

namespace MOLLCommunityClinicWeb1
{
    public partial class Inventorylist : System.Web.UI.Page
    {
        private InventoryService InventoryService = new InventoryService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInventory();
            }
        }

        // LOAD INVENTORY FROM DATABASE
        private void LoadInventory()
        {
            try
            {
                var items = InventoryService.GetAllInventory();

                gvInventory.DataSource = items;
                gvInventory.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error loading inventory: " + ex.Message;
            }
        }

        // SEARCH INVENTORY (SERVICE LAYER)
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearch.Text.Trim();

                var results = InventoryService.SearchInventory(searchText);

                gvInventory.DataSource = results;
                gvInventory.DataBind();

                lblMessage.Text = results.Count == 0
                    ? "No inventory items found."
                    : "";
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
            LoadInventory();
        }

        // BACK
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }

        // EXIT
        protected void btnExit_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}