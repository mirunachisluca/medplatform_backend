using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public List<MedicalRecord> MedicalRecordList { get; set; }
        public List<MedicationPlan> MedicationPlans { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
        public Caregiver Caregiver { get; set; }
        public int CaregiverId { get; set; }
    }
}
