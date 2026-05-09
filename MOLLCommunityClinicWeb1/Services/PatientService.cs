using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MOLLCommunityClinicWeb1.Models;

namespace MOLLCommunityClinicWeb1.Services
{
    public class PatientService
    {
        private readonly string connectionString =
           ConfigurationManager.ConnectionStrings["CommunityClinicLLOMDB"].ConnectionString;

        // ✔ ADD PATIENT
        public void AddPatient(PatientWeb patient)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Patients
                (FullName, DOB, Age, Gender, Phone, Address, Allergies, MedicalHistory, Medications, Email)
                VALUES
                (@FullName, @DOB, @Age, @Gender, @Phone, @Address, @Allergies, @MedicalHistory, @Medications, @Email)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@FullName", patient.Name);
                cmd.Parameters.AddWithValue("@DOB", patient.DateOfBirth);
                cmd.Parameters.AddWithValue("@Age", patient.Age);
                cmd.Parameters.AddWithValue("@Gender", patient.Gender);
                cmd.Parameters.AddWithValue("@Phone", patient.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", patient.Address);
                cmd.Parameters.AddWithValue("@Allergies", patient.Allergies ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@MedicalHistory", patient.History ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Medications", patient.Medications ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", patient.EmailAddress ?? (object)DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ✔ GET ALL PATIENTS
        public List<PatientWeb> GetAllPatients()
        {
            List<PatientWeb> patients = new List<PatientWeb>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Patients";

                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    patients.Add(new PatientWeb
                    {
                        PatientID = Convert.ToInt32(reader["Id"]),
                        Name = reader["FullName"].ToString(),
                        DateOfBirth = Convert.ToDateTime(reader["DOB"]),
                        Age = Convert.ToInt32(reader["Age"]),
                        Gender = reader["Gender"].ToString(),
                        PhoneNumber = reader["Phone"].ToString(),
                        Address = reader["Address"].ToString(),
                        Allergies = reader["Allergies"].ToString(),
                        History = reader["MedicalHistory"].ToString(),
                        Medications = reader["Medications"].ToString(),
                        EmailAddress = reader["Email"].ToString()
                    });
                }
            }

            return patients;
        }

        // ✔ SEARCH PATIENTS
        public List<PatientWeb> SearchPatients(string keyword)
        {
            List<PatientWeb> patients = new List<PatientWeb>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT * FROM Patients
                                 WHERE FullName LIKE @Keyword
                                 OR Phone LIKE @Keyword
                                 OR Email LIKE @Keyword";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    patients.Add(new PatientWeb
                    {
                        PatientID = Convert.ToInt32(reader["Id"]),
                        Name = reader["FullName"].ToString(),
                        DateOfBirth = Convert.ToDateTime(reader["DOB"]),
                        Age = Convert.ToInt32(reader["Age"]),
                        Gender = reader["Gender"].ToString(),
                        PhoneNumber = reader["Phone"].ToString(),
                        Address = reader["Address"].ToString(),
                        Allergies = reader["Allergies"].ToString(),
                        History = reader["MedicalHistory"].ToString(),
                        Medications = reader["Medications"].ToString(),
                        EmailAddress = reader["Email"].ToString()
                    });
                }
            }

            return patients;
        }

        // DELETE PATIENT
        public void DeletePatient(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Patients WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ✔ UPDATE PATIENT (optional but recommended)
        public void UpdatePatient(PatientWeb patient)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Patients SET
                                FullName = @FullName,
                                DOB = @DOB,
                                Age = @Age,
                                Gender = @Gender,
                                Phone = @Phone,
                                Address = @Address,
                                Allergies = @Allergies,
                                MedicalHistory = @MedicalHistory,
                                Medications = @Medications,
                                Email = @Email
                                WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Id", patient.PatientID);
                cmd.Parameters.AddWithValue("@FullName", patient.Name);
                cmd.Parameters.AddWithValue("@DOB", patient.DateOfBirth);
                cmd.Parameters.AddWithValue("@Age", patient.Age);
                cmd.Parameters.AddWithValue("@Gender", patient.Gender);
                cmd.Parameters.AddWithValue("@Phone", patient.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", patient.Address);
                cmd.Parameters.AddWithValue("@Allergies", patient.Allergies ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@MedicalHistory", patient.History ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Medications", patient.Medications ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", patient.EmailAddress ?? (object)DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}