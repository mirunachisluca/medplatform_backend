using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class CaregiverModel
    {
        //public int CaregiverId { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public List<PatientModel> PatientsList { get; set; }
        public UserModel User { get; set; }
    }
}
