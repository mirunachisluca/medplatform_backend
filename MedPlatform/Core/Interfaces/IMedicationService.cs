using Core.Entities;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IMedicationService
    {
        Medication GetById(int id);
        IEnumerable<Medication> ListMedication();
        void Insert(Medication medication);
        void Update(Medication medication);
        void DeleteById(int id);
        void Delete(Medication medication);
    }
}
