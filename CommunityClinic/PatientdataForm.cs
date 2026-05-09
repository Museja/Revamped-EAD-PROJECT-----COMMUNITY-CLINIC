using CommunityClinic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CommunityClinic.Models.Patient;

namespace CommunityClinic
{
    public partial class PatientdataForm : Form
    {
        public PatientdataForm()
        {
            InitializeComponent();
        }

        private void PatientdataForm_Load(object sender, EventArgs e)
        {
            // optional: load data if needed
        }

        // SAVE (INSERT via DAL)
        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                // VALIDATION
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Name is required");
                    txtName.Focus();
                    return;
                }

                if (!int.TryParse(txtAge.Text, out int age) || age <= 0)
                {
                    MessageBox.Show("Enter a valid age");
                    txtAge.Focus();
                    return;
                }

                if (!DateTime.TryParse(txtDOB.Text, out DateTime dob))
                {
                    MessageBox.Show("Enter a valid Date of Birth");
                    txtDOB.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPhonenumber.Text))
                {
                    MessageBox.Show("Phone number is required");
                    txtPhonenumber.Focus();
                    return;
                }

                if (!txtEmail.Text.Contains("@"))
                {
                    MessageBox.Show("Enter a valid email");
                    txtEmail.Focus();
                    return;
                }

                // CREATE MODEL
                Patient patient = new Patient
                {
                    Name = txtName.Text.Trim(),
                    DateOfBirth = dob,
                    Age = age,
                    Address = txtAddress.Text.Trim(),
                    PhoneNumber = txtPhonenumber.Text.Trim(),
                    EmailAddress = txtEmail.Text.Trim(),
                    Gender = txtGender.Text.Trim(),
                    Allergies = txtAllergies.Text.Trim(),
                    History = txtHistory.Text.Trim(),
                    Medications = txtMedications.Text.Trim()
                };

                // CALL DAL (INSERT)
                PatientDAL dal = new PatientDAL();
                bool success = dal.AddPatient(patient);

                MessageBox.Show(
                    success ? "Patient saved successfully!" : "Save failed.",
                    success ? "Success" : "Error",
                    MessageBoxButtons.OK,
                    success ? MessageBoxIcon.Information : MessageBoxIcon.Error
                );

                if (success)
                    ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // UPDATE (UPDATE via DAL)
        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                Patient patient = new Patient
                {
                    Name = txtName.Text.Trim(),
                    DateOfBirth = DateTime.Parse(txtDOB.Text),
                    Age = int.Parse(txtAge.Text),
                    Address = txtAddress.Text.Trim(),
                    PhoneNumber = txtPhonenumber.Text.Trim(),
                    EmailAddress = txtEmail.Text.Trim(),
                    Gender = txtGender.Text.Trim(),
                    Allergies = txtAllergies.Text.Trim(),
                    History = txtHistory.Text.Trim(),
                    Medications = txtMedications.Text.Trim()
                };

                PatientDAL dal = new PatientDAL();
                bool success = dal.UpdatePatient(patient);

                MessageBox.Show(
                    success ? "Patient updated successfully!" : "Update failed.",
                    success ? "Success" : "Error",
                    MessageBoxButtons.OK,
                    success ? MessageBoxIcon.Information : MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // CLEAR FORM
        private void Clear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtDOB.Clear();
            txtAge.Clear();
            txtAddress.Clear();
            txtPhonenumber.Clear();
            txtEmail.Clear();
            txtGender.Clear();
            txtAllergies.Clear();
            txtHistory.Clear();
            txtMedications.Clear();
        }

        // NAVIGATION
        private void button1_Click(object sender, EventArgs e)
        {
            PatientPortalForm form = new PatientPortalForm();
            form.Show();
            this.Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }

        private void button2_Click(object sender, EventArgs e)
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