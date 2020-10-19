using Core.Entities;
using Core.Interfaces;
using System.Collections.Generic;

namespace Infrastructure.Services
{
    public class MedicationService : IMedicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public MedicationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete(Medication medication)
        {
            _unitOfWork.MedicationRepository.Delete(medication);
            _unitOfWork.Save();
        }

        public void DeleteById(int id)
        {
            _unitOfWork.MedicationRepository.Delete(id);
            _unitOfWork.Save();
        }

        public Medication GetById(int id)
        {
            return _unitOfWork.MedicationRepository.GetByID(id);
        }

        public void Insert(Medication medication)
        {
            _unitOfWork.MedicationRepository.Insert(medication);
            _unitOfWork.Save();
        }

        public IEnumerable<Medication> ListMedication()
        {
            return _unitOfWork.MedicationRepository.Get();
        }

        public void Update(Medication medication)
        {
            _unitOfWork.MedicationRepository.Update(medication);
            _unitOfWork.Save();
        }
    }
}
