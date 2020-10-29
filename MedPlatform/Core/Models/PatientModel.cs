using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class PatientModel
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string BirthdateString { get { return this.Birthdate.ToString("dd/MM/yyyy"); } }
        public string Gender { get; set; }
        public string Address { get; set; }
        public List<MedicalRecordModel> MedicalRecordList { get; set; }
        public List<MedicationPlanModel> MedicationPlans { get; set; }
        public UserModel User { get; set; }
        public int DoctorId { get; set; }
        public int CaregiverId { get; set; }

    }
}
