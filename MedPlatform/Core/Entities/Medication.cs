using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Medication
    {
        //ID, name, list of side effects, dosage
        public int MedicationId { get; set; }
        public string Name { get; set; }
        public string SideEffects { get; set; }
        public string Dosage { get; set; }
    }
}
