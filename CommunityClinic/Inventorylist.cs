using System;
using System.Data;
using System.Windows.Forms;
using CommunityClinic.Data;

namespace CommunityClinic
{
    public partial class Inventorylist : Form
    {
        private InventoryDAL inventoryDAL = new InventoryDAL();

        public Inventorylist()
        {
            InitializeComponent();
        }

        // LOAD FORM DATA
        private void Inventorylist_Load(object sender, EventArgs e)
        {
            LoadInventory();
        }

        // LOAD INVENTORY INTO GRID
        private void LoadInventory()
        {
            try
            {
                DataTable dt = inventoryDAL.GetAllItems();

                dataGridView1.DataSource = dt;

                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading inventory: " + ex.Message);
            }
        }

        // EXIT BUTTON
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit the application?",
                "Exit Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // BACK BUTTON
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();

            StaffDashboard dashboard = new StaffDashboard();
            dashboard.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}