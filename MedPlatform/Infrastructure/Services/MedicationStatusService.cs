using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Services
{
    public class MedicationStatusService : IMedicationStatusService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MedicationStatusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddMedicationStatus(MedicationStatus status)
        {
            _unitOfWork.MedicationStatusRepository.Insert(status);
            _unitOfWork.Save();
        }
    }
}
