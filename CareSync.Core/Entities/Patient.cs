using System.ComponentModel.DataAnnotations.Schema;

namespace CareSync.Core.Entities
{
    public class Patient
{
    public int PatientId { get; set; }
    public Guid UserId { get; set; }
    public string FullName { get; set; }
    public DateTime? DOB { get; set; }
    public string Gender { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public DateTime CreatedAt { get; set; }

    public ApplicationUser User { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
}

}
