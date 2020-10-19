using Core.Entities;
using Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Services
{
    public class DoctorService : IDoctorService
    {
        public readonly IUnitOfWork _unitOfWork;

        public DoctorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public void Delete(Doctor doctor)
        {
            _unitOfWork.DoctorRepository.Delete(doctor);
            _unitOfWork.Save();
        }

        public void DeleteById(int id)
        {
            _unitOfWork.DoctorRepository.Delete(id);
            _unitOfWork.Save();
        }

        public Doctor GetById(int id)
        {
            return _unitOfWork.DoctorRepository.Get(doctor => doctor.DoctorId==id, null, includeProperties: "PatientsList,PatientsList.MedicalRecordList,PatientsList.MedicationPlans,PatientsList.MedicationPlans.MedicationList").FirstOrDefault();
        }

        public IEnumerable<Patient> GetPatientsList(int id)
        {
            var doctor = GetById(id);
            return doctor.PatientsList;
        }

        public void Insert(Doctor doctor)
        {
            _unitOfWork.DoctorRepository.Insert(doctor);
            _unitOfWork.Save();
        }

        public IEnumerable<Doctor> ListDoctors()
        {
            return _unitOfWork.DoctorRepository.Get(includeProperties:"PatientsList,PatientsList.MedicalRecordList,PatientsList.MedicationPlans,PatientsList.MedicationPlans.MedicationList");
            
        }

        public void Update(Doctor doctor)
        {
            _unitOfWork.DoctorRepository.Update(doctor);
            _unitOfWork.Save();
        }
    }
}
