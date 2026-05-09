using System;
using System.Data;
using System.Data.SqlClient;

namespace CommunityClinic.Data
{
    public class AppointmentsDAL
    {
        // GET APPOINTMENTS
        public DataTable GetAppointmentsByPatient(int patientId)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"SELECT * 
                                 FROM Appointments 
                                 WHERE PatientId = @PatientId
                                 ORDER BY AppointmentDateTime DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@PatientId", patientId);

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }
        // Get All appointments for admin view
        public DataTable GetAllAppointments()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"SELECT * 
                         FROM Appointments
                         ORDER BY AppointmentDateTime DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        // BOOK APPOINTMENT
        public bool BookAppointment(int patientId, string fullName, string doctorName, DateTime appointmentDateTime, string reason)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"INSERT INTO Appointments
                                (PatientId, FullName, DoctorName, AppointmentDateTime, Reason, Status)
                                VALUES
                                (@PatientId, @FullName, @DoctorName, @AppointmentDateTime, @Reason, 'Pending')";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@PatientId", patientId);
                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@DoctorName", doctorName);
                cmd.Parameters.AddWithValue("@AppointmentDateTime", appointmentDateTime);
                cmd.Parameters.AddWithValue("@Reason", reason);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // CANCEL APPOINTMENT
        public bool CancelAppointment(int appointmentId)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"UPDATE Appointments
                                 SET Status = 'Cancelled'
                                 WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", appointmentId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // RESCHEDULE APPOINTMENT
        public bool RescheduleAppointment(int appointmentId, DateTime newDateTime)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"UPDATE Appointments
                                 SET AppointmentDateTime = @DateTime,
                                     Status = 'Rescheduled'
                                 WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@DateTime", newDateTime);
                cmd.Parameters.AddWithValue("@Id", appointmentId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // UPDATE STATUS
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