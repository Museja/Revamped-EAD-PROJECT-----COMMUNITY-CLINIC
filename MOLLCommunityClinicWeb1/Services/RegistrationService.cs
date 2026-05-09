using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MOLLCommunityClinicWeb1.Models;

namespace MOLLCommunityClinicWeb1.Services
{
    public class RegistrationService
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["CommunityClinicLLOMDB"].ConnectionString;

        // REGISTER USER
        public void RegisterUser(RegistrationWeb user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Registration
                (FullName, EmailAddress, Password, Role, AdminID, MedStaffID)
                VALUES
                (@FullName, @EmailAddress, @Password, @Role, @AdminID, @MedStaffID)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@FullName", user.FullName);
                cmd.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Role", user.Role);

                cmd.Parameters.AddWithValue("@AdminID",
                    (object)user.AdminID ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@MedStaffID",
                    (object)user.MedStaffID ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // GET USER BY EMAIL
        public RegistrationWeb GetUserByEmail(string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Registration WHERE EmailAddress = @Email";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new RegistrationWeb
                    {
                        PatientID = Convert.ToInt32(reader["PatientID"]),
                        FullName = reader["FullName"].ToString(),
                        EmailAddress = reader["EmailAddress"].ToString(),
                        Password = reader["Password"].ToString(),
                        Role = reader["Role"].ToString(),
                        AdminID = reader["AdminID"].ToString(),
                        MedStaffID = reader["MedStaffID"].ToString()
                    };
                }

                return null;
            }
        }
    }
}