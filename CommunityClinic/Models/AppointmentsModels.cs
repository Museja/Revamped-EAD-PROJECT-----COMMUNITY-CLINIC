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

        public DateTime AppointmentDate { get; set; }

        public string Reason { get; set; }

        public string Status { get; set; }
    }
}
