using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CareSync.Core.Entities;
using Microsoft.AspNetCore.Identity;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Notification> Notifications { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
{
    base.OnModelCreating(builder);

    // Ensure unique appointments per doctor, date, and time
    builder.Entity<Appointment>()
        .HasIndex(a => new { a.DoctorId, a.AppointmentDate, a.StartTime })
        .IsUnique();

    // Configure Doctor relationship
    builder.Entity<Doctor>()
        .HasOne(d => d.User)
        .WithMany(u => u.Doctors)
        .HasForeignKey(d => d.UserId);

    // Configure Patient relationship
    builder.Entity<Patient>()
        .HasOne(p => p.User)
        .WithMany(u => u.Patients)
        .HasForeignKey(p => p.UserId);

    // Configure Notification relationship
    builder.Entity<Notification>()
        .HasOne(n => n.User)
        .WithMany(u => u.Notifications)
        .HasForeignKey(n => n.UserId);

    // ✅ Fix multiple cascade paths in Appointment
    builder.Entity<Appointment>()
        .HasOne(a => a.Doctor)
        .WithMany()
        .HasForeignKey(a => a.DoctorId)
        .OnDelete(DeleteBehavior.Restrict); // prevent cascade from doctor

    builder.Entity<Appointment>()
        .HasOne(a => a.Patient)
        .WithMany()
        .HasForeignKey(a => a.PatientId)
        .OnDelete(DeleteBehavior.Cascade);  // allow cascade from patient
}

}
