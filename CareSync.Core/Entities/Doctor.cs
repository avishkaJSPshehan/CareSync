using System.ComponentModel.DataAnnotations.Schema;

namespace CareSync.Core.Entities
{
    public class Doctor
{
    public int DoctorId { get; set; }
    public Guid UserId { get; set; }
    public string FullName { get; set; }
    public string Specialty { get; set; }
    public string PhoneNumber { get; set; }
    public string ProfileImage { get; set; }
    public DateTime CreatedAt { get; set; }

    public ApplicationUser User { get; set; }
    public ICollection<DoctorSchedule> Schedules { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
}

}

