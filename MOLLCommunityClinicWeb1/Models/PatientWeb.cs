using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MOLLCommunityClinicWeb1.Models
{
    public class PatientWeb
    {
        public int PatientID { get; set; }

        public string Name { get; set; } = "";

        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }

        public string Address { get; set; } = "";

        public string PhoneNumber { get; set; } = "";

        public string EmailAddress { get; set; } = "";

        public string Gender { get; set; } = "";

        public string Allergies { get; set; } = "";

        public string History { get; set; } = "";

        public string Medications { get; set; } = "";
    }
}