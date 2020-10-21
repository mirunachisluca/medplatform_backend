using Core.Entities;
using Core.Models;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IMedicationPlanService
    {
        MedicationPlanModel GetById(int id);
        //MedicationPlanModel GetByPatient(int planId, int patientId);
        IEnumerable<MedicationPlanModel> GetMedicationPlanForPatient(int patientId);
        IEnumerable<MedicationPlanModel> GetMedicationPlans();
        void Insert(MedicationPlan medicationPlan);
        void Update(MedicationPlan medicationPlan);
        void DeleteById(int id);
        void Delete(MedicationPlan medicationPlan);
        void AddMedicationPlan(int patientId, MedicationPlan medicationPlan);
    }
}
