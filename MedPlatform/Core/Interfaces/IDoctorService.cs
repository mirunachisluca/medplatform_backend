using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IDoctorService
    {
        Doctor GetById(int id);
        IEnumerable<Doctor> ListDoctors();
        void Insert(Doctor doctor);
        void Update(Doctor doctor);
        void DeleteById(int id);
        void Delete(Doctor doctor);
        IEnumerable<Patient> GetPatientsList(int id);

    }
}
