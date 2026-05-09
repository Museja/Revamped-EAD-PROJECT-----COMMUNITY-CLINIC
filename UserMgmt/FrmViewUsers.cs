using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace UserMgmt
{
    public partial class FrmViewUsers : Form
    {
        public FrmViewUsers()
        {
            InitializeComponent();
        }

        private void FrmViewUsers_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            string connStr = ConfigurationManager.ConnectionStrings["HealthcareDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = "SELECT Id, FirstName, LastName, Email, Gender, " +
                               "DateOfBirth, CellPhone, MobilePhone, Address, Town, Parish, CreatedAt " +
                               "FROM Users ORDER BY LastName, FirstName";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvViewUsers.DataSource = dt;

                    // Appearance
                    dgvViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvViewUsers.RowHeadersVisible = false;
                    dgvViewUsers.AllowUserToAddRows = false;
                    dgvViewUsers.ReadOnly = true;
                    dgvViewUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    // Rename column headers to be friendlier
                    dgvViewUsers.Columns["Id"].HeaderText = "ID";
                    dgvViewUsers.Columns["FirstName"].HeaderText = "First Name";
                    dgvViewUsers.Columns["LastName"].HeaderText = "Last Name";
                    dgvViewUsers.Columns["DateOfBirth"].HeaderText = "Date of Birth";
                    dgvViewUsers.Columns["CellPhone"].HeaderText = "Cell";
                    dgvViewUsers.Columns["MobilePhone"].HeaderText = "Mobile";
                    dgvViewUsers.Columns["CreatedAt"].HeaderText = "Date Added";
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvViewUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to edit.", "No Selection",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            int userID = Convert.ToInt32(dgvViewUsers.SelectedRows[0].Cells["Id"].Value);

            FrmEditUsers editForm = new FrmEditUsers(userID);
            editForm.ShowDialog();
            LoadUsers(); // refresh the grid after editing
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvViewUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.", "No Selection",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            string firstName = dgvViewUsers.SelectedRows[0].Cells["FirstName"].Value.ToString();
            string lastName = dgvViewUsers.SelectedRows[0].Cells["LastName"].Value.ToString();
            int userID = Convert.ToInt32(dgvViewUsers.SelectedRows[0].Cells["Id"].Value);

            // Confirm before deleting
            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to delete " + firstName + " " + lastName + "?\nThis cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                DeleteUser(userID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting user: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(firstName + " " + lastName + " has been deleted.",
                            "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadUsers(); // refresh the grid
        }

        private void DeleteUser(int userID)
        {
            string connStr = ConfigurationManager.ConnectionStrings["HealthcareDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = "DELETE FROM Users WHERE UserID = @UserID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
