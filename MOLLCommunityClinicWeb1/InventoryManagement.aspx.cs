using System;
using System.Linq;
using MOLLCommunityClinicWeb1.Models;
using MOLLCommunityClinicWeb1.Services;

namespace MOLLCommunityClinicWeb1
{
    public partial class InventoryManagement : System.Web.UI.Page
    {
        InventoryService inventoryService = new InventoryService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("~/StaffLogin.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadInventory();
            }
        }

        // LOAD INVENTORY
        private void LoadInventory()
        {
            gvInventory.DataSource =
                inventoryService.GetAllInventory();

            gvInventory.DataBind();
        }

        // SEARCH
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim().ToLower();

            var results = inventoryService.GetAllInventory()
                .Where(i => i.Item.ToLower().Contains(search))
                .ToList();

            gvInventory.DataSource = results;
            gvInventory.DataBind();
        }

        // SELECT ITEM
        protected void gvInventory_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtId.Text =
                gvInventory.SelectedRow.Cells[0].Text;

            txtItemName.Text =
                gvInventory.SelectedRow.Cells[1].Text;

            txtQuantity.Text =
                gvInventory.SelectedRow.Cells[2].Text;

            txtCategory.Text =
                gvInventory.SelectedRow.Cells[3].Text;
        }

        // UPDATE
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Inventory1 item = new Inventory1
            {
                Id = Convert.ToInt32(txtId.Text),
                Item = txtItemName.Text,
                Quantity = Convert.ToInt32(txtQuantity.Text),
                Category = txtCategory.Text
            };

            inventoryService.UpdateInventory(item);

            lblMessage.Text = "Inventory updated successfully.";

            LoadInventory();
        }

        // DELETE
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);

            inventoryService.DeleteInventory(id);

            lblMessage.Text = "Item deleted successfully.";

            LoadInventory();
        }
    }
}