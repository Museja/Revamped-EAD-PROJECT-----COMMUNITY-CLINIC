using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MOLLCommunityClinicWeb1.Models
{
    public class RegistrationWeb
    {
        public int PatientID { get; set; }

        public string FullName { get; set; }

        public string EmailAddress { get; set; }

        // Store hashed password (NEVER plain text)
        public string Password { get; set; }

        public string Role { get; set; }

        // Only used depending on role
        public string AdminID { get; set; }

        public string MedStaffID { get; set; }

    }
}
