using Microsoft.AspNetCore.Identity;
using CareSync.Core.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    public string FullName { get; set; }
    public string Role { get; set; }
    public virtual ICollection<Doctor> Doctors { get; set; }
    public virtual ICollection<Patient> Patients { get; set; }
    public virtual ICollection<Notification> Notifications { get; set; }
}
