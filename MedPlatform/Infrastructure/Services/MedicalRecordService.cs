using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Models;
using System.Collections.Generic;

namespace Infrastructure.Services
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public MedicalRecordService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public void Delete(MedicalRecord medicalRecord)
        {
            _unitOfWork.MedicalRecordRepository.Delete(medicalRecord);
            _unitOfWork.Save();
        }

        public void DeleteById(int id)
        {
            _unitOfWork.MedicalRecordRepository.Delete(id);
            _unitOfWork.Save();
        }

        public MedicalRecordModel GetById(int id)
        {
            return _mapper.Map<MedicalRecordModel>(_unitOfWork.MedicalRecordRepository.GetByID(id));
        }

        public IEnumerable<MedicalRecordModel> GetByPatientId(int patientId)
        {
            var medicalRecord = _unitOfWork.MedicalRecordRepository.Get(record => record.PatientId == patientId);
            return _mapper.Map<IEnumerable<MedicalRecordModel>>(medicalRecord);
        }

        public void Insert(MedicalRecord medicalRecord)
        {
            _unitOfWork.MedicalRecordRepository.Insert(medicalRecord);
            _unitOfWork.Save();
        }

        public IEnumerable<MedicalRecordModel> ListMedicalRecords()
        {
            return _mapper.Map<IEnumerable<MedicalRecordModel>>(_unitOfWork.MedicalRecordRepository.Get());
        }

        public void Update(MedicalRecord medicalRecord)
        {
            _unitOfWork.MedicalRecordRepository.Update(medicalRecord);
            _unitOfWork.Save();
        }

        public void AddMedicalRecord(int patientId, MedicalRecord medicalRecord)
        {
            medicalRecord.PatientId = patientId;
            _unitOfWork.MedicalRecordRepository.Insert(medicalRecord);
        }
    }
}
