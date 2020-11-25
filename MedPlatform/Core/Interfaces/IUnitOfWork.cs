using Core.Entities;
using System;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Doctor> DoctorRepository { get; set; }

        IGenericRepository<Caregiver> CaregiverRepository { get; set; }

        IGenericRepository<Patient> PatientRepository { get; set; }

        IGenericRepository<Medication> MedicationRepository { get; set; }

        IGenericRepository<MedicationPlan> MedicationPlanRepository { get; set; }

        IGenericRepository<MedicationPlanDetails> MedicationPlanDetailsRepository { get; set; }

        IGenericRepository<MedicalRecord> MedicalRecordRepository { get; set; }
        
        IGenericRepository<User> UserRepository { get; set; }

        IGenericRepository<Role> RoleRepository { get; set; }

        IGenericRepository<Activity> ActivityRepository { get; set; }

        IGenericRepository<MedicationStatus> MedicationStatusRepository { get; set; }

        void Save();

        new void Dispose();
    }
}
