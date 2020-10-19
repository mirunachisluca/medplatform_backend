using Core.Entities;
using Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Services
{
    public class MedicationPlanService : IMedicationPlanService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MedicationPlanService(IUnitOfWork unitOfWork)
        {
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

        public MedicationPlan GetById(int id)
        {
            return _unitOfWork.MedicationPlanRepository.Get(plan => plan.MedicationPlanId == id, null, includeProperties: "MedicationList").FirstOrDefault();
        }

        public IEnumerable<MedicationPlan> GetMedicationPlans()
        {
            return _unitOfWork.MedicationPlanRepository.Get(includeProperties: "MedicationList");
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
