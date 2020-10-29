using Core.Entities;
using Core.Models;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IMedicalRecordService
    {
        MedicalRecordModel GetById(int id);
        IEnumerable<MedicalRecordModel> GetByPatientId(int patientId);
        IEnumerable<MedicalRecordModel> ListMedicalRecords();
        void Insert(MedicalRecord medicalRecord);
        void Update(MedicalRecord medicalRecord);
        void DeleteById(int id);
        void Delete(MedicalRecord medicalRecord);
        void AddMedicalRecord(int patientId, MedicalRecord medicalRecord);
    }
}
