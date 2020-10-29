using Core.Entities;
using Core.Models;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IPatientService
    {
        PatientModel GetById(int id);
        PatientModel GetPatientForDoctor(int patientId, int doctorId);
        PatientModel GetPatientForCaregiver(int patientId, int caregiverId);
        IEnumerable<PatientModel> GetPatientsForDoctor(int doctorId);
        IEnumerable<PatientModel> GetPatientsForCaregiver(int caregiverId);
        IEnumerable<Patient> ListPatients();
        void Insert(Patient  patient);
        void Update(Patient patient);
        void DeleteById(int id);
        void Delete(Patient patient);
        

    }
}
