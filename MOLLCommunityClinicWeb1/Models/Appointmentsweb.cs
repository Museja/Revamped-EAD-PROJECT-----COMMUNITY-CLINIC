using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MOLLCommunityClinicWeb1.Models
{
    public class Appointmentsweb
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public DateTime AppointmentDateTime { get; set; }

        public string Reason { get; set; }

        public string Status { get; set; }
    }
}