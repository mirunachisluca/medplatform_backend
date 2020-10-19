using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface ICaregiverService
    {
        Caregiver GetById(int id);
        IEnumerable<Caregiver> ListCaregivers();
        void Insert(Caregiver caregiver);
        void Update(Caregiver caregiver);
        void DeleteById(int id);
        void Delete(Caregiver caregiver);
        IEnumerable<Patient> GetPatientsList(int id);
    }
}
