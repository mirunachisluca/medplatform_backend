using Core.Entities;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IMedicationPlanDetailsService
    {
        MedicationPlanDetails GetById(int id);
        IEnumerable<MedicationPlanDetails> ListDetails();
        void Insert(MedicationPlanDetails details);
        void Update(MedicationPlanDetails details);
        void DeleteById(int id);
        void Delete(MedicationPlanDetails details);
        void AddMedicationToList(int medicationPlanId, MedicationPlanDetails medication);
    }
}
