using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityClinic.Data
{
    public class MedicalHistoryDAL
    {
        // GET HISTORY BY PATIENT
        public DataTable GetHistoryByPatient(int patientId)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM MedicalHistory WHERE PatientId=@Id";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@Id", patientId);

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        // ADD HISTORY RECORD
        public bool AddHistory(int patientId, string condition, string notes)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"INSERT INTO MedicalHistory
                                (PatientId, Condition, Notes)
                                VALUES (@PatientId, @Condition, @Notes)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@PatientId", patientId);
                cmd.Parameters.AddWithValue("@Condition", condition);
                cmd.Parameters.AddWithValue("@Notes", notes);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
