using CommunityClinic.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityClinic.Data
{
    internal class UsersDAL
    {
        private readonly string connectionString =
           ConfigurationManager.ConnectionStrings["CommunityClinicLLOMDB"].ConnectionString;

        // GET USER BY EMAIL
        public Users GetUserByEmail(string email)
        {
            Users user = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users WHERE Email = @Email";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    user = new Users
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


        // VALIDATE LOGIN
      
        public Users Login(string email, string password)
        {
            Users user = GetUserByEmail(email);

            if (user == null)
                return null;

            if (user.IsLocked)
                return null;

            if (user.Password != password)
            {
                IncreaseFailedAttempts(email);
                return null;
            }

            ResetFailedAttempts(email);
            return user;
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

            LockIfNeeded(email);
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
        // LOCK ACCOUNT
        private void LockIfNeeded(string email)
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
    }
}
