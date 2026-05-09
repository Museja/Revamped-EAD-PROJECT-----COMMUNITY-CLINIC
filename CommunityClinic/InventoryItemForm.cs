using CommunityClinic.Models;
using System;
using System.Text;
using System.Windows.Forms;

namespace CommunityClinic
{
    public partial class InventoryItemForm : Form
    {
        public InventoryItemForm()
        {
            InitializeComponent();

            Save.Click += Save_Click;
            Clear.Click += Clear_Click;
            Update.Click += Update_Click;
        }

        // GET FORM DATA
        private Inventoryitems GetFormData()
        {
            Inventoryitems item = new Inventoryitems();

            item.Item = txtItem.Text.Trim();

            DateTime.TryParse(txtDateAdded.Text, out DateTime dateAdded);
            item.DateAdded = dateAdded;

            int.TryParse(txtQuantity.Text, out int quantity);
            item.Quantity = quantity;

            item.Description = txtDescription.Text.Trim();

            decimal.TryParse(txtPrice.Text, out decimal price);
            item.Price = price;

            DateTime.TryParse(txtExpiration.Text, out DateTime expiration);
            item.Expiration = expiration;

            item.Category = txtCategory.Text.Trim();
            item.Unit = txtUnit.Text.Trim();
            item.BatchNumber = txtBatchNumber.Text.Trim();
            item.Manufacturer = txtManufacturer.Text.Trim();
            item.Supplier = txtSupplier.Text.Trim();
            item.Status = txtStatus.Text.Trim();
            item.Notes = txtNotes.Text.Trim();

            return item;
        }

        // VALIDATION
        private bool ValidateForm()
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(txtItem.Text))
                errors.AppendLine("Item name is required.");

            if (!DateTime.TryParse(txtDateAdded.Text, out _))
                errors.AppendLine("Date Added must be valid.");

            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity < 0)
                errors.AppendLine("Quantity must be a valid positive number.");

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
                errors.AppendLine("Description is required.");

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
                errors.AppendLine("Price must be a valid positive number.");

            if (!DateTime.TryParse(txtExpiration.Text, out _))
                errors.AppendLine("Expiration date must be valid.");

            if (string.IsNullOrWhiteSpace(txtCategory.Text))
                errors.AppendLine("Category is required.");

            if (string.IsNullOrWhiteSpace(txtUnit.Text))
                errors.AppendLine("Unit is required.");

            if (string.IsNullOrWhiteSpace(txtBatchNumber.Text))
                errors.AppendLine("Batch Number is required.");

            if (string.IsNullOrWhiteSpace(txtStatus.Text))
                errors.AppendLine("Status is required.");

            if (errors.Length > 0)
            {
                MessageBox.Show(
                    errors.ToString(),
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        // SAVE BUTTON
        private void Save_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                Inventoryitems item = GetFormData();
                InventoryDAL dal = new InventoryDAL();

                bool success = dal.InsertItem(item);

                if (success)
                {
                    MessageBox.Show(
                        "Item saved successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ClearForm();
                }
                else
                {
                    MessageBox.Show(
                        "Error saving item.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unexpected error: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // UPDATE BUTTON
        private void Update_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                Inventoryitems item = GetFormData();
                InventoryDAL dal = new InventoryDAL();

                bool success = dal.Update(item);

                if (success)
                {
                    MessageBox.Show(
                        "Item updated successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ClearForm();
                }
                else
                {
                    MessageBox.Show(
                        "Update failed. Item may not exist.",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // CLEAR BUTTON
        private void Clear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to clear all fields?",
                "Confirm Clear",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                ClearForm();
            }
        }

        // CLEAR FORM METHOD
        private void ClearForm()
        {
            txtItem.Clear();
            txtDateAdded.Clear();
            txtQuantity.Clear();
            txtDescription.Clear();
            txtPrice.Clear();
            txtExpiration.Clear();
            txtCategory.Clear();
            txtUnit.Clear();
            txtBatchNumber.Clear();
            txtManufacturer.Clear();
            txtSupplier.Clear();
            txtStatus.Clear();
            txtNotes.Clear();
        }

        // BACK BUTTON
        private void button1_Click(object sender, EventArgs e)
        {
            //MainFormMDI form = new MainFormMDI();
            //form.Show();
            //this.Close();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
          "Are you sure you want to exit the application?",
           "Exit Application",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}