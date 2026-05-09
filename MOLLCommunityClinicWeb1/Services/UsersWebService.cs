using System;
using System.Configuration;
using System.Data.SqlClient;
using MOLLCommunityClinicWeb1.Models;

namespace MOLLCommunityClinicWeb1.Services
{
    public class UsersWebService
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["CommunityClinicLLOMDB"].ConnectionString;
        // LOGIN METHOD
        public UsersWeb Login(string email, string hashedPassword, int roleId)
        {
            UsersWeb user = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT *
                    FROM Users
                    WHERE Email = @Email
                    AND Password = @Password
                    AND Role = @Role";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", hashedPassword);
                cmd.Parameters.AddWithValue("@Role", roleId);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    bool isLocked = Convert.ToBoolean(reader["IsLocked"]);

                    if (isLocked)
                        return null;

                    user = new UsersWeb
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        Password = reader["Password"].ToString(),
                        Role = Convert.ToInt32(reader["Role"]),
                        DateCreated = Convert.ToDateTime(reader["DateCreated"]),
                        IsLocked = Convert.ToBoolean(reader["IsLocked"]),
                        FailedAttempts = Convert.ToInt32(reader["FailedAttempts"])
                    };
                }
            }

            return user;
        }

        // RESET FAILED ATTEMPTS
        public void ResetFailedAttempts(string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    UPDATE Users
                    SET FailedAttempts = 0
                    WHERE Email = @Email";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // INCREASE FAILED ATTEMPTS
        public void IncreaseFailedAttempts(string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    UPDATE Users
                    SET FailedAttempts = FailedAttempts + 1
                    WHERE Email = @Email";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LockAccountIfNeeded(email);
        }

        // LOCK ACCOUNT
        private void LockAccountIfNeeded(string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    UPDATE Users
                    SET IsLocked = 1
                    WHERE Email = @Email
                    AND FailedAttempts >= 3";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // UNLOCK USER (ADMIN USE)
        public void UnlockUser(string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    UPDATE Users
                    SET IsLocked = 0,
                        FailedAttempts = 0
                    WHERE Email = @Email";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}