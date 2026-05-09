using System;
using System.Data.SqlClient;

namespace CommunityClinic
{
    public static class DatabaseHelper
    {
        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection conn = new SqlConnection(
                    @"Data Source=TEEN-HUB-LAP-03\SQLEXPRESS;
                      Initial Catalog=CommunityClinicLLOMDB;
                      Integrated Security=True;
                      TrustServerCertificate=True"
                );

                // conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                throw new Exception("Database connection failed: " + ex.Message);
            }
        }
    }
}