using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class MedicationPlanModel
    {
        //public int MedicationPlanId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<MedicationPlanDetailsModel> MedicationList { get; set; }
        //public PatientModel Patient { get; set; }
    }
}
