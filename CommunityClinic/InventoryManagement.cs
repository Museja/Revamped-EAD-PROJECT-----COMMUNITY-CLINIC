using CommunityClinic.Models;
using System;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace CommunityClinic
{
    public partial class InventoryManagement : Form
    {
        private InventoryDAL inventoryDAL = new InventoryDAL();

        public InventoryManagement()
        {
            InitializeComponent();
        }

        // FORM LOAD
       
        private void InventoryManagement_Load(object sender, EventArgs e)
        {
            LoadInventory();
        }

        // LOAD INVENTORY
        private void LoadInventory()
        {
            DataTable dt = inventoryDAL.GetItems();
            dgvInventory.DataSource = dt;

            dgvInventory.ReadOnly = false;
            dgvInventory.AllowUserToAddRows = false;
            dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventory.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
        }

        // UPDATE INVENTORY
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvInventory.Rows)
                {
                    if (row.IsNewRow) continue;

                    Inventoryitems item = new Inventoryitems
                    {
                        Item = row.Cells["Item"].Value.ToString(),
                        Date_Added = Convert.ToDateTime(row.Cells["Date_Added"].Value),
                        Quantity = Convert.ToInt32(row.Cells["Quantity"].Value),
                        Description = row.Cells["Description"].Value.ToString(),
                        Price = Convert.ToDecimal(row.Cells["Price"].Value),
                        Expiration = Convert.ToDateTime(row.Cells["Expiration"].Value),
                        Category = row.Cells["Category"].Value.ToString(),
                        Unit = row.Cells["Unit"].Value.ToString(),
                        Batch = row.Cells["Batch"].Value.ToString(),
                        Manufacturer = row.Cells["Manufacturer"].Value.ToString(),
                        Supplier = row.Cells["Supplier"].Value.ToString(),
                        Status = row.Cells["Status"].Value.ToString(),
                        Notes = row.Cells["Notes"].Value.ToString()
                    };

                    inventoryDAL.Update(item);
                }

                MessageBox.Show("Inventory updated successfully.");
                LoadInventory();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // DELETE ITEM
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count > 0)
            {
                string batch = dgvInventory.SelectedRows[0].Cells["Batch"].Value.ToString();

                Inventoryitems item = new Inventoryitems
                {
                    Batch = batch
                };

                inventoryDAL.Update(item); 

                MessageBox.Show("Item processed.");
                LoadInventory();
            }
        }

        // BACK TO MDI
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // EXIT APPLICATION
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit?",
                "Confirm Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            InventoryDAL dal = new InventoryDAL();

            dgvInventory.DataSource = dal.SearchItems(txtSearch.Text.Trim());
        }
       

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}