using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Caregiver
    {
        public int CaregiverId { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public List<Patient> PatientsList { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
