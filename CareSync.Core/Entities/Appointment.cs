using System;

namespace CareSync.Core.Entities
{
    public class Appointment
{
    public int AppointmentId { get; set; }
    public int DoctorId { get; set; }
    public int PatientId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public string Status { get; set; }
    public string Notes { get; set; }
    public DateTime CreatedAt { get; set; }

    public Doctor Doctor { get; set; }
    public Patient Patient { get; set; }
    public ICollection<Prescription> Prescriptions { get; set; }
}

}
