using Core.Entities;
using Core.Interfaces;
using System.Collections.Generic;

namespace Infrastructure.Services
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MedicalRecordService(IUnitOfWork unitOfWork)
        {
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

        public MedicalRecord GetById(int id)
        {
            return _unitOfWork.MedicalRecordRepository.GetByID(id);
        }

        public void Insert(MedicalRecord medicalRecord)
        {
            _unitOfWork.MedicalRecordRepository.Insert(medicalRecord);
            _unitOfWork.Save();
        }

        public IEnumerable<MedicalRecord> ListMedicalRecords()
        {
            return _unitOfWork.MedicalRecordRepository.Get();
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
