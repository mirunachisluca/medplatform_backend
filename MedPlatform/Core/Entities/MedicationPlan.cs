using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class MedicationPlan
    {
        //the doctor can create a medication plan for a patient, consisting of a 
        //list of medication and intake intervals needed to be taken daily, and the period of the treatment.
        public int MedicationPlanId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<MedicationPlanDetails> MedicationList { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
    }
}
