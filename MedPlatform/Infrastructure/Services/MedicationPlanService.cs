using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Services
{
    public class MedicationPlanService : IMedicationPlanService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public MedicationPlanService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public void Delete(MedicationPlan medicationPlan)
        {
            _unitOfWork.MedicationPlanRepository.Delete(medicationPlan);
            _unitOfWork.Save();
        }

        public void DeleteById(int id)
        {
            _unitOfWork.MedicationPlanRepository.Delete(id);
            _unitOfWork.Save();
        }

        public MedicationPlanModel GetById(int id)
        {
            var medicationPlan = _unitOfWork.MedicationPlanRepository.Get(plan => plan.MedicationPlanId == id, null, includeProperties: "MedicationList,Patient").FirstOrDefault();
            return _mapper.Map<MedicationPlanModel>(medicationPlan);
        }

        //public MedicationPlanModel GetByPatient(int planId, int patientId)
        //{
        //    var medicationPlan = _unitOfWork.MedicationPlanRepository.Get(plan => plan.MedicationPlanId == planId && plan.PatientId == patientId).FirstOrDefault();
        //    return _mapper.Map<MedicationPlanModel>(medicationPlan);
        //}

        public IEnumerable<MedicationPlanModel> GetMedicationPlanForPatient(int patientId)
        {
            return _mapper.Map<IEnumerable<MedicationPlanModel>>(_unitOfWork.MedicationPlanRepository.Get(p => p.PatientId == patientId, includeProperties: "MedicationList,MedicationList.Medication"));
        }

        public IEnumerable<MedicationPlanModel> GetMedicationPlans()
        {
            return _mapper.Map<IEnumerable<MedicationPlanModel>>(_unitOfWork.MedicationPlanRepository.Get(includeProperties: "MedicationList"));
        }

        public void Insert(MedicationPlan medicationPlan)
        {
            _unitOfWork.MedicationPlanRepository.Insert(medicationPlan);
            _unitOfWork.Save();
        }

        public void Update(MedicationPlan medicationPlan)
        {
            _unitOfWork.MedicationPlanRepository.Update(medicationPlan);
            _unitOfWork.Save();
        }

        public void AddMedicationPlan(int patientId, MedicationPlan medicationPlan)
        {
            medicationPlan.PatientId = patientId;
            _unitOfWork.MedicationPlanRepository.Insert(medicationPlan);
        }
    }
}
