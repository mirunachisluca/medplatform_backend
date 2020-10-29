using Core.Entities;
using Core.Models;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface ICaregiverService
    {
        CaregiverModel GetById(int id);
        IEnumerable<CaregiverModel> ListCaregivers();
        void Insert(Caregiver caregiver);
        void Update(Caregiver caregiver);
        void DeleteById(int id);
        void Delete(Caregiver caregiver);
        //IEnumerable<Patient> GetPatientsList(int id);
    }
}
