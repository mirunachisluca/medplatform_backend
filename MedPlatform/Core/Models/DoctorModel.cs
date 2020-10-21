using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class DoctorModel
    {
        //public int DoctorId { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Specialty { get; set; }
        public List<PatientModel> PatientsList { get; set; }
        public UserModel User { get; set; }

    }
}
