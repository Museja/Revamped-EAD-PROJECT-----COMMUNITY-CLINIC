using System;
using System.Data;
using System.Data.SqlClient;
using CommunityClinic.Models;

namespace CommunityClinic
{
    public class RegistrationDAL
    {
        // INSERT USER
        public bool InsertUser(Registrationclass user)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
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
                    string.IsNullOrWhiteSpace(user.AdminID)
                        ? (object)DBNull.Value
                        : user.AdminID);

                cmd.Parameters.AddWithValue("@MedStaffID",
                    string.IsNullOrWhiteSpace(user.MedicalStaffID)
                        ? (object)DBNull.Value
                        : user.MedicalStaffID);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // FIXED LOGIN METHOD
        public Registrationclass LoginUser(string email, string password, string role)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"SELECT * FROM Registration
                                 WHERE EmailAddress=@Email
                                 AND Password=@Password
                                 AND Role=@Role";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Role", role);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Registrationclass
                    {
                        PatientID = Convert.ToInt32(reader["Id"]),
                        FullName = reader["FullName"].ToString(),
                        EmailAddress = reader["EmailAddress"].ToString(),
                        Password = reader["Password"].ToString(),
                        Role = reader["Role"].ToString()
                    };
                }
            }

            return null;
        }

        // GET ALL USERS
        public DataTable GetAllUsers()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM Registration";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }

        // UPDATE USER
        public void UpdateUser(Registrationclass user, int id)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"UPDATE Registration SET
                    FullName=@FullName,
                    EmailAddress=@EmailAddress,
                    Password=@Password,
                    Role=@Role,
                    AdminID=@AdminID,
                    MedStaffID=@MedStaffID
                    WHERE Id=@Id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@FullName", user.FullName);
                cmd.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Role", user.Role);

                cmd.Parameters.AddWithValue("@AdminID",
                    string.IsNullOrWhiteSpace(user.AdminID)
                        ? (object)DBNull.Value
                        : user.AdminID);

                cmd.Parameters.AddWithValue("@MedStaffID",
                    string.IsNullOrWhiteSpace(user.MedicalStaffID)
                        ? (object)DBNull.Value
                        : user.MedicalStaffID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE USER
        public void DeleteUser(int id)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "DELETE FROM Registration WHERE Id=@Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // EMAIL CHECK
        public bool EmailExists(string email)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Registration WHERE EmailAddress=@Email";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}