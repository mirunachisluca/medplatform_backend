using Core.Entities;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IDoctorService
    {
        DoctorModel GetById(int id);
        IEnumerable<DoctorModel> ListDoctors();
        void Insert(Doctor doctor);
        void Update(Doctor doctor);
        void DeleteById(int id);
        void Delete(Doctor doctor);
        //IEnumerable<PatientModel> GetPatientsList(int id);

    }
}
