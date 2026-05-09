using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MOLLCommunityClinicWeb1.Models;

namespace MOLLCommunityClinicWeb1.Services
{
    public class AppointmentsService
    {
        private readonly string connectionString =
           ConfigurationManager.ConnectionStrings["CommunityClinicLLOMDB"].ConnectionString;

        // BOOK APPOINTMENT
        public void BookAppointment(Appointmentsweb appointment)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Appointments
                                (PatientId, AppointmentDate, Reason, Status)
                                VALUES
                                (@PatientId, @AppointmentDate, @Reason, @Status)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@PatientId", appointment.PatientId);
                cmd.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                cmd.Parameters.AddWithValue("@Reason", appointment.Reason);
                cmd.Parameters.AddWithValue("@Status", appointment.Status);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // GET ALL APPOINTMENTS
        public List<Appointmentsweb> GetAllAppointments()
        {
            List<Appointmentsweb> list = new List<Appointmentsweb>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Appointments ORDER BY AppointmentDate DESC";

                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Appointmentsweb
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        PatientId = Convert.ToInt32(reader["PatientId"]),
                        AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]),
                        Reason = reader["Reason"].ToString(),
                        Status = reader["Status"].ToString()
                    });
                }
            }

            return list;
        }

        // GET BY PATIENT
        public List<Appointmentsweb> GetByPatientId(int patientId)
        {
            List<Appointmentsweb> list = new List<Appointmentsweb>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT * FROM Appointments
                                 WHERE PatientId = @PatientId
                                 ORDER BY AppointmentDate DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PatientId", patientId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Appointmentsweb
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        PatientId = Convert.ToInt32(reader["PatientId"]),
                        AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]),
                        Reason = reader["Reason"].ToString(),
                        Status = reader["Status"].ToString()
                    });
                }
            }

            return list;
        }

        // UPDATE STATUS (important for clinic workflow)
        public void UpdateStatus(int id, string status)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Appointments
                                 SET Status = @Status
                                 WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Status", status);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE APPOINTMENT
        public void DeleteAppointment(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Appointments WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}