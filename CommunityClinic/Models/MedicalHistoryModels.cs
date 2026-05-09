using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityClinic.Models
{
    internal class MedicalHistoryModels
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public string Condition { get; set; }

        public string Notes { get; set; }

        public DateTime DateRecorded { get; set; }
    }
}
