using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class MedicationStatus
    {
        public int MedicationStatusId { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int MedicationId { get; set; }
        public Medication Medication {get;set;}
        public string Date { get; set; }
        public string Status { get; set; }

    }
}
