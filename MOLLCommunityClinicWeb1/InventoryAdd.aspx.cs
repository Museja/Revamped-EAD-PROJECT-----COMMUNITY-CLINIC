using System;
using MOLLCommunityClinicWeb1.Models;

namespace MOLLCommunityClinicWeb1
{
    public partial class InventoryAdd : System.Web.UI.Page
    {
        private InventoryService InventoryService = new InventoryService();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // SAVE INVENTORY ITEM
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Inventory1 item = new Inventory1
                {
                    Item = txtItem.Text,
                    DateAdded = Convert.ToDateTime(txtDateAdded.Text),
                    Quantity = Convert.ToInt32(txtQuantity.Text),
                    Description = txtDescription.Text,
                    Price = Convert.ToDecimal(txtPrice.Text),
                    Expiration = Convert.ToDateTime(txtExpiration.Text),
                    Category = txtCategory.Text,
                    Unit = txtUnit.Text,
                    BatchNumber = txtBatchNumber.Text,
                    Manufacturer = txtManufacturer.Text,
                    Supplier = txtSupplier.Text,
                    Status = txtStatus.Text,
                    Notes = txtNotes.Text
                };

                InventoryService.AddInventory(item);

                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Inventory item saved successfully.";
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error saving item: " + ex.Message;
            }
        }

        // UPDATE INVENTORY ITEM
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Inventory1 item = new Inventory1
                {
                    Id = Convert.ToInt32(ViewState["InventoryId"]), // assumes you store selected ID
                    Item = txtItem.Text,
                    DateAdded = Convert.ToDateTime(txtDateAdded.Text),
                    Quantity = Convert.ToInt32(txtQuantity.Text),
                    Description = txtDescription.Text,
                    Price = Convert.ToDecimal(txtPrice.Text),
                    Expiration = Convert.ToDateTime(txtExpiration.Text),
                    Category = txtCategory.Text,
                    Unit = txtUnit.Text,
                    BatchNumber = txtBatchNumber.Text,
                    Manufacturer = txtManufacturer.Text,
                    Supplier = txtSupplier.Text,
                    Status = txtStatus.Text,
                    Notes = txtNotes.Text
                };

                InventoryService.UpdateInventory(item);

                lblMessage.ForeColor = System.Drawing.Color.Blue;
                lblMessage.Text = "Inventory item updated successfully.";
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error updating item: " + ex.Message;
            }
        }

        // CLEAR FORM
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtItem.Text = "";
            txtDateAdded.Text = "";
            txtQuantity.Text = "";
            txtDescription.Text = "";
            txtPrice.Text = "";
            txtExpiration.Text = "";
            txtCategory.Text = "";
            txtUnit.Text = "";
            txtBatchNumber.Text = "";
            txtManufacturer.Text = "";
            txtSupplier.Text = "";
            txtStatus.Text = "";
            txtNotes.Text = "";

            lblMessage.Text = "";
        }

        // BACK
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MainMDI.aspx");
        }

        // EXIT
        protected void btnExit_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }
    }
}