using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Specialty { get; set; }
        public List<Patient> PatientsList { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
