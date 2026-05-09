using System;
using System.Data;
using System.Windows.Forms;

namespace CommunityClinic
{
    public partial class Patientlist : Form
    {
        // DAL CONNECTION
        private PatientDAL dal = new PatientDAL();

        public Patientlist()
        {
            InitializeComponent();
            this.Load += Patientlist_Load; 
        }

        // LOAD DATA WHEN FORM OPENS
        private void Patientlist_Load(object sender, EventArgs e)
        {
            LoadPatients();
        }

        // CALL DAL AND BIND TO GRID
        private void LoadPatients()
        {
            try
            {
                DataTable dt = dal.GetPatients();
                Patientlistdgv.DataSource = dt;

                Patientlistdgv.ReadOnly = true;
                Patientlistdgv.AllowUserToAddRows = false;
                Patientlistdgv.AllowUserToDeleteRows = false;
                Patientlistdgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                Patientlistdgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading patients: " + ex.Message);
            }
        }

        private void Patientlistdgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        // EXIT BUTTON
        private void button1_Click(object sender, EventArgs e)
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}