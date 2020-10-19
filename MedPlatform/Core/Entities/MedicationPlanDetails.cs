using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class MedicationPlanDetails
    {
        //the doctor can create a medication plan for a patient, consisting of a 
        //list of medication and intake intervals needed to be taken daily, and the period of the treatment.
        public int MedicationPlanDetailsId { get; set; }
        public string IntakeInterval { get; set; }
        public Medication Medication { get; set; }
        public int MedicationId { get; set; }
        public MedicationPlan MedicationPlan { get; set; }
        public int MedicationPlanId { get; set; }
    }
}
