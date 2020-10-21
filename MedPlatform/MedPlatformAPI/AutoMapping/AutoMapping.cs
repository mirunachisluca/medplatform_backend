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
            //CreateMap<IEnumerable<Doctor>, IEnumerable<DoctorModel>>();
            //CreateMap<IEnumerable<Caregiver>, IEnumerable<CaregiverModel>>();
            //CreateMap<IEnumerable<Patient>, IEnumerable<PatientModel>>();
            //CreateMap<IEnumerable<MedicationPlanDetails>, IEnumerable<MedicationPlanDetailsModel>>();
            //CreateMap<IEnumerable<MedicationPlan>, IEnumerable<MedicationPlanModel>>();
            //CreateMap<IEnumerable<Medication>, IEnumerable<Medication>>();

        }
        
    }
}
