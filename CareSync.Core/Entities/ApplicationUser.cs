using Microsoft.AspNetCore.Identity;
using CareSync.Core.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    public virtual ICollection<Doctor> Doctors { get; set; }
    public virtual ICollection<Patient> Patients { get; set; }
    public virtual ICollection<Notification> Notifications { get; set; }
}
