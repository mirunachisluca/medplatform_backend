using Core.Entities;
using Core.Models;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IMedicationService
    {
        MedicationModel GetById(int id);
        IEnumerable<Medication> ListMedication();
        void Insert(Medication medication);
        void Update(Medication medication);
        void DeleteById(int id);
        void Delete(Medication medication);
    }
}
