using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;

        public DoctorService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
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

        public DoctorModel GetById(int id)
        {
            var doctor = _unitOfWork.DoctorRepository.Get(doctor => doctor.DoctorId == id, null, includeProperties: "PatientsList,PatientsList.MedicalRecordList,PatientsList.MedicationPlans,PatientsList.MedicationPlans.MedicationList,PatientsList.MedicationPlans.MedicationList.Medication,User").FirstOrDefault();
            return _mapper.Map<DoctorModel>(doctor);
        }

        public IEnumerable<PatientModel> GetPatientsList(int id)
        {
            var doctor = GetById(id);
            return doctor.PatientsList;
        }

        public void Insert(Doctor doctor)
        {
            doctor.Birthdate = doctor.Birthdate.Date;
            _unitOfWork.DoctorRepository.Insert(doctor);
            _unitOfWork.Save();
        }

        public IEnumerable<DoctorModel> ListDoctors()
        {
            var doctors = _unitOfWork.DoctorRepository.Get(includeProperties:"PatientsList,PatientsList.MedicalRecordList,PatientsList.MedicationPlans,PatientsList.MedicationPlans.MedicationList,User");
            return _mapper.Map<IEnumerable<DoctorModel>>(doctors);
        }

        public void Update(Doctor doctor)
        {
            _unitOfWork.DoctorRepository.Update(doctor);
            _unitOfWork.Save();
        }

        //public void AddPatientToDoctor(int doctorId, Patient patient)
        //{
        //    var doctor = GetById(doctorId);
        //    doctor.PatientsList.Add(patient);
        //}
    }
}
