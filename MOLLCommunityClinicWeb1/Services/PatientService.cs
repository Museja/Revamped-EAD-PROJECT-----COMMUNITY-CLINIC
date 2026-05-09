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

        // ADD PATIENT
        public void AddPatient(PatientWeb Patient)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Patient
                (Name, DOB, Age, Gender, Phone, Address, Allergies, History, Medications, Email)
                VALUES
                (@FullName, @DOB, @Age, @Gender, @Phone, @Address, @Allergies, @MedicalHistory, @Medications, @Email)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@FullName", Patient.Name);
                cmd.Parameters.AddWithValue("@DOB", Patient.DOB);
                cmd.Parameters.AddWithValue("@Age", Patient.Age);
                cmd.Parameters.AddWithValue("@Gender", Patient.Gender);
                cmd.Parameters.AddWithValue("@Phone", Patient.Phone);
                cmd.Parameters.AddWithValue("@Address", Patient.Address);
                cmd.Parameters.AddWithValue("@Allergies", Patient.Allergies ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@MedicalHistory", Patient.History ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Medications", Patient.Medications ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", Patient.Email ?? (object)DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //  GET ALL PATIENTS
        public List<PatientWeb> GetAllPatients()
        {
            List<PatientWeb> patients = new List<PatientWeb>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Patient";

                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    patients.Add(new PatientWeb
                    {
                        PatientID = Convert.ToInt32(reader["Id"]),
                        Name = reader["FullName"].ToString(),
                        DOB = Convert.ToDateTime(reader["DOB"]),
                        Age = Convert.ToInt32(reader["Age"]),
                        Gender = reader["Gender"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Address = reader["Address"].ToString(),
                        Allergies = reader["Allergies"].ToString(),
                        History = reader["MedicalHistory"].ToString(),
                        Medications = reader["Medications"].ToString(),
                        Email = reader["Email"].ToString()
                    });
                }
            }

            return patients;
        }

        // SEARCH PATIENTS
        public List<PatientWeb> SearchPatient(string keyword)
        {
            List<PatientWeb> Patient = new List<PatientWeb>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT * FROM Patient
                                 WHERE Name LIKE @Keyword
                                 OR Phone LIKE @Keyword
                                 OR Email LIKE @Keyword";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Patient.Add(new PatientWeb
                    {
                        PatientID = Convert.ToInt32(reader["Id"]),
                        Name = reader["FullName"].ToString(),
                        DOB = Convert.ToDateTime(reader["DOB"]),
                        Age = Convert.ToInt32(reader["Age"]),
                        Gender = reader["Gender"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Address = reader["Address"].ToString(),
                        Allergies = reader["Allergies"].ToString(),
                        History = reader["MedicalHistory"].ToString(),
                        Medications = reader["Medications"].ToString(),
                        Email = reader["Email"].ToString()
                    });
                }
            }

            return Patient;
        }

        // DELETE PATIENT
        public void DeletePatient(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Patient WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // UPDATE PATIENT
        public void UpdatePatient(PatientWeb Patient)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Patient SET
                                Name = @Name,
                                DOB = @DOB,
                                Age = @Age,
                                Gender = @Gender,
                                Phone = @Phone,
                                Address = @Address,
                                Allergies = @Allergies,
                                History = @History,
                                Medications = @Medications,
                                Email = @Email
                                WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Id", Patient.PatientID);
                cmd.Parameters.AddWithValue("@FullName", Patient.Name);
                cmd.Parameters.AddWithValue("@DOB", Patient.DOB);
                cmd.Parameters.AddWithValue("@Age", Patient.Age);
                cmd.Parameters.AddWithValue("@Gender", Patient.Gender);
                cmd.Parameters.AddWithValue("@Phone", Patient.Phone);
                cmd.Parameters.AddWithValue("@Address", Patient.Address);
                cmd.Parameters.AddWithValue("@Allergies", Patient.Allergies ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@MedicalHistory", Patient.History ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Medications", Patient.Medications ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", Patient.Email ?? (object)DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}