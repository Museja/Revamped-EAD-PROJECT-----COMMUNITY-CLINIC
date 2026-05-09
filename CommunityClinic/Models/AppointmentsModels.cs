using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityClinic.Models
{
    public class AppointmentsModels
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public string DoctorName { get; set; }

        public string Status { get; set; }
        public DateTime AppointmentDateTime { get; set; }

        public string FullName { get; set; }

        public string Reason { get; set; }

    }
}
