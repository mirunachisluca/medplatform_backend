using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Services
{
    public class PatientService : IPatientService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PatientService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
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

        public PatientModel GetById(int id)
        {
            var patient = _unitOfWork.PatientRepository.Get(patient => patient.PatientId == id, null, includeProperties: "MedicalRecordList,MedicationPlans,MedicationPlans.MedicationList,User").FirstOrDefault();
            return _mapper.Map<PatientModel>(patient);
        }

        public PatientModel GetPatientForDoctor(int patientId, int doctorId)
        {
            var patient = _unitOfWork.PatientRepository.Get(p => p.PatientId == patientId && p.DoctorId == doctorId).FirstOrDefault();
            return _mapper.Map<PatientModel>(patient);
        }

        public PatientModel GetPatientForCaregiver(int patientId, int caregiverId)
        {
            var patient = _unitOfWork.PatientRepository.Get(p => p.PatientId == patientId && p.CaregiverId == caregiverId).FirstOrDefault();
            return _mapper.Map<PatientModel>(patient);

        }

        public IEnumerable<PatientModel> GetPatientsForDoctor(int doctorId)
        {
            return _mapper.Map<IEnumerable<PatientModel>>(_unitOfWork.PatientRepository.Get(p => p.DoctorId == doctorId));
        }

        public IEnumerable<PatientModel> GetPatientsForCaregiver(int caregiverId)
        {
            return _mapper.Map<IEnumerable<PatientModel>>(_unitOfWork.PatientRepository.Get(p => p.CaregiverId == caregiverId));
        }

        public void Insert(Patient patient)
        {
            _unitOfWork.PatientRepository.Insert(patient);
            _unitOfWork.Save();
        }

        public IEnumerable<Patient> ListPatients()
        {
            return _unitOfWork.PatientRepository.Get(includeProperties: "MedicalRecordList,MedicationPlans,MedicationPlans.MedicationList,User");
        }

        public void Update(Patient patient)
        {
            _unitOfWork.PatientRepository.Update(patient);
            _unitOfWork.Save();
        }

        public IEnumerable<MedicationPlanModel> GetMedicationPlans(int id)
        {
            return GetById(id).MedicationPlans;
        }
    }
}
