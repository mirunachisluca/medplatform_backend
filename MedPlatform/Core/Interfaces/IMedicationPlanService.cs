using Core.Entities;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IMedicationPlanService
    {
        MedicationPlan GetById(int id);
        IEnumerable<MedicationPlan> GetMedicationPlans();
        void Insert(MedicationPlan medicationPlan);
        void Update(MedicationPlan medicationPlan);
        void DeleteById(int id);
        void Delete(MedicationPlan medicationPlan);
        void AddMedicationPlan(int patientId, MedicationPlan medicationPlan);
    }
}
