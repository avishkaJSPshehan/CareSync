using System;

namespace CareSync.Core.DTOs
{
    public class RegisterDto
    {
        public string FullName { get; set; }
        public string Role { get; set; }  // e.g. Admin, Doctor, Patient
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
