using CommunityClinic.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CommunityClinic
{
    public class PatientDAL
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["CommunityClinicLLOMDB"].ConnectionString;

        // GET ALL PATIENTS
       
        public DataTable GetPatients()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT PatientID, Name, DOB, Age, Address,
                           Phone, Email, Gender,
                           Allergies, History, Medications
                    FROM Patient
                    ORDER BY Name";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            return dt;
        }

        // SEARCH PATIENTS
        public DataTable SearchPatients(string search)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT PatientID, Name, DOB, Age, Address,
                           Phone, Email, Gender,
                           Allergies, History, Medications
                    FROM Patient
                    WHERE Name LIKE @Search
                       OR Email LIKE @Search
                    ORDER BY Name";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Search", "%" + search + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
            }

            return dt;
        }

        // DELETE PATIENT
        public void DeletePatient(int patientId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Patient WHERE PatientID = @PatientID";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@PatientID", patientId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ADD PATIENT
        public bool AddPatient(Patient patient)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Patient
                (Name, DOB, Age, Address, Phone,
                 Email, Gender, Allergies, History, Medications)
                VALUES
                (@Name, @DOB, @Age, @Address, @Phone,
                 @Email, @Gender, @Allergies, @History, @Medications)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Name", patient.Name);
                cmd.Parameters.AddWithValue("@DOB", patient.DateOfBirth);
                cmd.Parameters.AddWithValue("@Age", patient.Age);
                cmd.Parameters.AddWithValue("@Address", patient.Address);
                cmd.Parameters.AddWithValue("@Phone", patient.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", patient.EmailAddress);
                cmd.Parameters.AddWithValue("@Gender", patient.Gender);
                cmd.Parameters.AddWithValue("@Allergies", patient.Allergies ?? "");
                cmd.Parameters.AddWithValue("@History", patient.History ?? "");
                cmd.Parameters.AddWithValue("@Medications", patient.Medications ?? "");

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // UPDATE PATIENT
        public bool UpdatePatient(Patient patient)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Patient SET
                    Name=@Name,
                    DOB=@DOB,
                    Age=@Age,
                    Address=@Address,
                    Phone=@Phone,
                    Email=@Email,
                    Gender=@Gender,
                    Allergies=@Allergies,
                    History=@History,
                    Medications=@Medications
                    WHERE PatientID=@PatientID";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@PatientID", patient.PatientID);
                cmd.Parameters.AddWithValue("@Name", patient.Name);
                cmd.Parameters.AddWithValue("@DOB", patient.DateOfBirth);
                cmd.Parameters.AddWithValue("@Age", patient.Age);
                cmd.Parameters.AddWithValue("@Address", patient.Address);
                cmd.Parameters.AddWithValue("@Phone", patient.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", patient.EmailAddress);
                cmd.Parameters.AddWithValue("@Gender", patient.Gender);
                cmd.Parameters.AddWithValue("@Allergies", patient.Allergies ?? "");
                cmd.Parameters.AddWithValue("@History", patient.History ?? "");
                cmd.Parameters.AddWithValue("@Medications", patient.Medications ?? "");

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // GET PATIENT BY ID
        public Patient GetPatientById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query =
                    "SELECT * FROM Patient WHERE PatientID=@PatientID";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@PatientID", id);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Patient
                        {
                            PatientID = Convert.ToInt32(reader["PatientID"]),
                            Name = reader["Name"].ToString(),
                            DateOfBirth = Convert.ToDateTime(reader["DOB"]),
                            Age = Convert.ToInt32(reader["Age"]),
                            Address = reader["Address"].ToString(),
                            PhoneNumber = reader["Phone"].ToString(),
                            EmailAddress = reader["Email"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            Allergies = reader["Allergies"].ToString(),
                            History = reader["History"].ToString(),
                            Medications = reader["Medications"].ToString()
                        };
                    }
                }
            }

            return null;
        }
    }
}