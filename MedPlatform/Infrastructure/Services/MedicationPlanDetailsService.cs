using Core.Entities;
using Core.Interfaces;
using System.Collections.Generic;

namespace Infrastructure.Services
{
    public class MedicationPlanDetailsService : IMedicationPlanDetailsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MedicationPlanDetailsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete(MedicationPlanDetails details)
        {
            _unitOfWork.MedicationPlanDetailsRepository.Delete(details);
            _unitOfWork.Save();
        }

        public void DeleteById(int id)
        {
            _unitOfWork.MedicationPlanDetailsRepository.Delete(id);
            _unitOfWork.Save();
        }

        public MedicationPlanDetails GetById(int id)
        {
            return _unitOfWork.MedicationPlanDetailsRepository.GetByID(id);
        }

        public void Insert(MedicationPlanDetails details)
        {
            _unitOfWork.MedicationPlanDetailsRepository.Insert(details);
            _unitOfWork.Save();
        }

        public IEnumerable<MedicationPlanDetails> ListDetails()
        {
            return _unitOfWork.MedicationPlanDetailsRepository.Get();
        }

        public void Update(MedicationPlanDetails details)
        {
            _unitOfWork.MedicationPlanDetailsRepository.Insert(details);
            _unitOfWork.Save();
        }

        public void AddMedicationToList(int medicationPlanId, MedicationPlanDetails medication)
        {
            medication.MedicationPlanId = medicationPlanId;
            _unitOfWork.MedicationPlanDetailsRepository.Insert(medication);
        }
    }
}
