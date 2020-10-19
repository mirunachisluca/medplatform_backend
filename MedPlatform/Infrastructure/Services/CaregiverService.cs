using Core.Entities;
using Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Services
{
    public class CaregiverService : ICaregiverService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CaregiverService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete(Caregiver caregiver)
        {
            _unitOfWork.CaregiverRepository.Delete(caregiver);
            _unitOfWork.Save();
        }

        public void DeleteById(int id)
        {
            _unitOfWork.CaregiverRepository.Delete(id);
            _unitOfWork.Save();
        }

        public Caregiver GetById(int id)
        {
            return _unitOfWork.CaregiverRepository.Get(caregiver => caregiver.CaregiverId==id, null, includeProperties : "PatientsList,PatientsList.MedicalRecordList,PatientsList.MedicationPlans,PatientsList.MedicationPlans.MedicationList,User").FirstOrDefault();
        }

        public IEnumerable<Patient> GetPatientsList(int id)
        {
            var caregiver = GetById(id);
            return caregiver.PatientsList;
        }

        public void Insert(Caregiver caregiver)
        {
            _unitOfWork.CaregiverRepository.Insert(caregiver);
            _unitOfWork.Save();
        }

        public IEnumerable<Caregiver> ListCaregivers()
        {
            return _unitOfWork.CaregiverRepository.Get(includeProperties: "PatientsList,PatientsList.MedicalRecordList,PatientsList.MedicationPlans,PatientsList.MedicationPlans.MedicationList,User");
        }

        public void Update(Caregiver caregiver)
        {
            _unitOfWork.CaregiverRepository.Update(caregiver);
            _unitOfWork.Save();
        }

        //public void AddPatientToCaregiver(int caregiverId, Patient patient)
        //{
        //    var caregiver = GetById(caregiverId);
        //    caregiver.PatientsList.Add(patient);
        //}
    }
}
