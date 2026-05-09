using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityClinic.Data
{
    public class PrescriptionsDAL
    {
        // GET PRESCRIPTIONS BY PATIENT
        public DataTable GetPrescriptionsByPatient(int patientId)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM Prescriptions WHERE PatientId=@Id";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@Id", patientId);

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        // ADD PRESCRIPTION
        public bool AddPrescription(int patientId, string medication, string dosage)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"INSERT INTO Prescriptions
                                (PatientId, Medication, Dosage)
                                VALUES (@PatientId, @Medication, @Dosage)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@PatientId", patientId);
                cmd.Parameters.AddWithValue("@Medication", medication);
                cmd.Parameters.AddWithValue("@Dosage", dosage);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
