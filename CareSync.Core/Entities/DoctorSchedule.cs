using System;

namespace CareSync.Core.Entities;

public class DoctorSchedule
{
    public int Id { get; set; }
    public int ScheduleId { get; set; }
    public int DoctorId { get; set; }
    public int DayOfWeek { get; set; } // 0 = Sunday, 6 = Saturday
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public DateTime CreatedAt { get; set; }

    public Doctor Doctor { get; set; }
}

