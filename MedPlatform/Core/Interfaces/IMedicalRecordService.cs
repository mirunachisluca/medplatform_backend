using Core.Entities;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IMedicalRecordService
    {
        MedicalRecord GetById(int id);
        IEnumerable<MedicalRecord> ListMedicalRecords();
        void Insert(MedicalRecord medicalRecord);
        void Update(MedicalRecord medicalRecord);
        void DeleteById(int id);
        void Delete(MedicalRecord medicalRecord);
        void AddMedicalRecord(int patientId, MedicalRecord medicalRecord);
    }
}
