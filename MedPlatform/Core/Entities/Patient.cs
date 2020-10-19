using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Patient
    {
        public int PatientId { get; set; }
        public int Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public List<MedicalRecord> MedicalRecordList { get; set; }
        public List<MedicationPlan> MedicationPlans { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
