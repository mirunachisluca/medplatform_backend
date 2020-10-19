using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class MedicalRecord
    {
        public int MedicalRecordId { get; set; }
        public string Description { get; set; }
        public int PatientId { get; set; }
    }
}
