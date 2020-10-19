using Core.Entities;
using Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Services
{
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete(Patient patient)
        {
            _unitOfWork.PatientRepository.Delete(patient);
            _unitOfWork.Save();
        }

        public void DeleteById(int id)
        {
            _unitOfWork.PatientRepository.Delete(id);
            _unitOfWork.Save();
        }

        public Patient GetById(int id)
        {
            return _unitOfWork.PatientRepository.Get(patient => patient.PatientId == id, null, includeProperties: "MedicalRecordList,MedicationPlan,MedicationPlan.MedicationList").FirstOrDefault();
        }

        public void Insert(Patient patient)
        {
            _unitOfWork.PatientRepository.Insert(patient);
            _unitOfWork.Save();
        }

        public IEnumerable<Patient> ListPatients()
        {
            return _unitOfWork.PatientRepository.Get(includeProperties: "MedicalRecordList,MedicationPlan,MedicationPlan.MedicationList");
        }

        public void Update(Patient patient)
        {
            _unitOfWork.PatientRepository.Update(patient);
            _unitOfWork.Save();
        }
    }
}
