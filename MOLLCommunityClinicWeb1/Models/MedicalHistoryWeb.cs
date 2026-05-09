using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MOLLCommunityClinicWeb1.Models
{
    public class MedicalHistoryWeb
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public string Condition { get; set; }

        public string Notes { get; set; }

        public DateTime DateRecorded { get; set; }
    }
}