using System;
using System.Data;
using System.Data.SqlClient;

namespace CommunityClinic.Data
{
    public class AppointmentsDAL
    {
        // REFRESH / LOAD APPOINTMENTS

        public DataTable GetAppointmentsByPatient(int PatientId)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"SELECT * 
                                 FROM Appointments 
                                 WHERE PatientId = @Id
                                 ORDER BY AppointmentDate DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@Id", PatientId);

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }


        // BOOK APPOINTMENT
        public bool BookAppointment(int Id, DateTime date, string reason)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"INSERT INTO Appointments
                                (Id, AppointmentDate, Reason, Status)
                                VALUES
                                (@PatientId, @Date, @Reason, 'Pending')";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@PatientId", Id);
                cmd.Parameters.AddWithValue("@Date", date);
                cmd.Parameters.AddWithValue("@Reason", reason);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }


        // CANCEL APPOINTMENT

        public bool CancelAppointment(int Id)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"UPDATE Appointments
                                 SET Status = 'Cancelled'
                                 WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", Id);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }


        // RESCHEDULE APPOINTMENT

        public bool RescheduleAppointment(int Id, DateTime newDate)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"UPDATE Appointments
                                 SET AppointmentDate = @Date,
                                     Status = 'Rescheduled'
                                 WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Date", newDate);
                cmd.Parameters.AddWithValue("@Id", Id);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateStatus(int appointmentId, string status)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"UPDATE Appointments
                         SET Status = @Status
                         WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", appointmentId);
                cmd.Parameters.AddWithValue("@Status", status);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }

        }

    }
}