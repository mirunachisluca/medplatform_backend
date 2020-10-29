using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class MedicationPlanModel
    {
        //public int MedicationPlanId { get; set; }
        public DateTime StartDate { get; set; }
        public string StartDateString { get { return this.StartDate.ToString("dd/MM/yyyy"); } }
        public DateTime EndDate { get; set; }
        public string EndDateString { get { return this.EndDate.ToString("dd/MM/yyyy"); } }
        public List<MedicationPlanDetailsModel> MedicationList { get; set; }
        //public PatientModel Patient { get; set; }
    }
}
