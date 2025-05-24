using System;

namespace CareSync.Core.Entities;

public class Prescription
{
    public int PrescriptionId { get; set; }
    public int AppointmentId { get; set; }
    public string FileUrl { get; set; }
    public DateTime IssuedDate { get; set; }
    public string Notes { get; set; }

    public Appointment Appointment { get; set; }
}
