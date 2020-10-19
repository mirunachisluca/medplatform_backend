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


        void Save();

        new void Dispose();
    }
}
