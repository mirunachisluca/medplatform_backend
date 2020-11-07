using AutoMapper;
using Core.Entities;
using Core.Models;
using System.Collections.Generic;

namespace MedPlatformAPI.AutoMapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Doctor, DoctorModel>();
            CreateMap<Caregiver, CaregiverModel>();
            CreateMap<Patient, PatientModel>();
            CreateMap<MedicalRecord, MedicalRecordModel>();
            CreateMap<Medication, MedicationModel>();
            CreateMap<MedicationPlan, MedicationPlanModel>();
            CreateMap<MedicationPlanDetails, MedicationPlanDetailsModel>();
            CreateMap<User, UserModel>();

        }
        
    }
}
