using System;

namespace Core.Entities
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String ActivityName { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
