using Core.Entities;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IPatientService
    {
        Patient GetById(int id);
        IEnumerable<Patient> ListPatients();
        void Insert(Patient  patient);
        void Update(Patient patient);
        void DeleteById(int id);
        void Delete(Patient patient);
        IEnumerable<MedicationPlan> GetMedicationPlans(int id);
    }
}
