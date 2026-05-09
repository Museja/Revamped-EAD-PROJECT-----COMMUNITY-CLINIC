using System;

namespace MOLLCommunityClinicWeb1.Models
{
    public class UsersWeb
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int Role { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsLocked { get; set; }

        public int FailedAttempts { get; set; }
    }
}