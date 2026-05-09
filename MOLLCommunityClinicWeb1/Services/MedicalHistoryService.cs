using MOLLCommunityClinicWeb1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MOLLCommunityClinicWeb1.Services
{
    public class MedicalHistoryService
    {

        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["CommunityClinicLLOMDB"].ConnectionString;

        // ADD MEDICAL HISTORY RECORD
        public void AddMedicalHistory(MedicalHistoryWeb history)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO MedicalHistory
                                (PatientId, Condition, Notes, DateRecorded)
                                VALUES
                                (@PatientId, @Condition, @Notes, @DateRecorded)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@PatientId", history.PatientId);
                cmd.Parameters.AddWithValue("@Condition", history.Condition);
                cmd.Parameters.AddWithValue("@Notes", history.Notes ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DateRecorded", history.DateRecorded);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // GET ALL MEDICAL HISTORY
        public List<MedicalHistoryWeb> GetAllMedicalHistory()
        {
            List<MedicalHistoryWeb> list = new List<MedicalHistoryWeb>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM MedicalHistory ORDER BY DateRecorded DESC";

                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new MedicalHistoryWeb
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        PatientId = Convert.ToInt32(reader["PatientId"]),
                        Condition = reader["Condition"].ToString(),
                        Notes = reader["Notes"].ToString(),
                        DateRecorded = Convert.ToDateTime(reader["DateRecorded"])
                    });
                }
            }

            return list;
        }

        // GET HISTORY BY PATIENT
        public List<MedicalHistoryWeb> GetByPatientId(int patientId)
        {
            List<MedicalHistoryWeb> list = new List<MedicalHistoryWeb>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT * FROM MedicalHistory
                                 WHERE PatientId = @PatientId
                                 ORDER BY DateRecorded DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PatientId", patientId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new MedicalHistoryWeb
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        PatientId = Convert.ToInt32(reader["PatientId"]),
                        Condition = reader["Condition"].ToString(),
                        Notes = reader["Notes"].ToString(),
                        DateRecorded = Convert.ToDateTime(reader["DateRecorded"])
                    });
                }
            }

            return list;
        }

        // DELETE MEDICAL HISTORY
        public void DeleteMedicalHistory(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM MedicalHistory WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}