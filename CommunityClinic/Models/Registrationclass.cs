using System;

namespace CommunityClinic.Models
{
    public class Registrationclass
    { public int PatientID { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
        public string AdminID { get; set; }
        public string MedicalStaffID { get; set; }

        // DEFAULT CONSTRUCTOR
        public Registrationclass()
        {
        }

        // PARAMETERIZED CONSTRUCTOR
        public Registrationclass(
            string fullName,
            string EmailAddress,
            string password,
            string confirmPassword,
            string role,
            string adminID,
            string medicalStaffID)
        {
            FullName = fullName;
            EmailAddress = EmailAddress;
            Password = password;
            ConfirmPassword = confirmPassword;
            Role = role;
            AdminID = adminID;
            MedicalStaffID = medicalStaffID;
        }

        // VALIDATION METHOD
        public bool IsValid(out string message)
        {
            if (string.IsNullOrWhiteSpace(FullName))
            {
                message = "Full Name is required.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(EmailAddress))
            {
                message = "Email Address is required.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                message = "Password is required.";
                return false;
            }

            if (Password != ConfirmPassword)
            {
                message = "Passwords do not match.";
                return false;
            }

            if (Role == "Admin" && string.IsNullOrWhiteSpace(AdminID))
            {
                message = "Admin ID is required for Admin users.";
                return false;
            }

            if (Role == "Medical Staff" && string.IsNullOrWhiteSpace(MedicalStaffID))
            {
                message = "Medical Staff ID is required.";
                return false;
            }

            message = "Valid";
            return true;
        }
    }
}