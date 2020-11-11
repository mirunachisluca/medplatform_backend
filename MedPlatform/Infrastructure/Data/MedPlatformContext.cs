using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MedPlatformContext : DbContext
    {
        public MedPlatformContext(DbContextOptions<MedPlatformContext> options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Caregiver> Caregivers { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<MedicationPlan> MedicationPlans { get; set; }
        public DbSet<MedicationPlanDetails> MedicationPlanDetails { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<User> Users { get; set;}
        public DbSet<Role> Roles { get; set; }
        public DbSet<Activity> Activities { get; set; }
    }
}
