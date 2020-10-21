using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Models;
using System.Collections.Generic;

namespace Infrastructure.Services
{
    public class MedicationService : IMedicationService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        
        public MedicationService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
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

        public MedicationModel  GetById(int id)
        {
            var medication = _unitOfWork.MedicationRepository.GetByID(id);
            var medicationModel = _mapper.Map<MedicationModel>(medication);
            return medicationModel;
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
