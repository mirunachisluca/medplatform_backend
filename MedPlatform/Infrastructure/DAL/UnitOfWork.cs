using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using System;

namespace Infrastructure.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MedPlatformContext _context;
        private IGenericRepository<Doctor> _doctorRepository;
        private IGenericRepository<Caregiver> _caregiverRepository;
        private IGenericRepository<Patient> _patientRepository;
        private IGenericRepository<Medication> _medicationRepository;
        private IGenericRepository<MedicationPlan> _medicationPlanRepository;
        private IGenericRepository<MedicationPlanDetails> _medicationPlanDetailsRepository;
        private IGenericRepository<MedicalRecord> _medicalRecordRepository;
        private IGenericRepository<User> _userRepository;
        private IGenericRepository<Role> _roleRepository;
        private IGenericRepository<Activity> _activityRepository;
        private IGenericRepository<MedicationStatus> _medicationStatusRepository;

        public UnitOfWork(MedPlatformContext context)
        {
            _context = context;
        }

        public IGenericRepository<Doctor> DoctorRepository
        {
            get
            {
                if (_doctorRepository == null)
                {
                    _doctorRepository = new GenericRepository<Doctor>(_context);
                }
                return _doctorRepository;
            }
            set
            {
                _doctorRepository= value;
            }
        }

        public IGenericRepository<Caregiver> CaregiverRepository
    {
            get
            {
                if (_caregiverRepository == null)
                {
                    _caregiverRepository = new GenericRepository<Caregiver>(_context);
                }
                return _caregiverRepository;
            }
            set
            {
                _caregiverRepository = value;
            }
        }

        public IGenericRepository<Patient> PatientRepository
        {
            get
            {
                if (_patientRepository == null)
                {
                    _patientRepository = new GenericRepository<Patient>(_context);
                }
                return _patientRepository;
            }
            set
            {
                _patientRepository = value;
            }
        }

        public IGenericRepository<Medication> MedicationRepository
        {
            get
            {
                if (_medicationRepository == null)
                {
                    _medicationRepository = new GenericRepository<Medication>(_context);
                }
                return _medicationRepository;
            }
            set
            {
                _medicationRepository = value;
            }
        }

        public IGenericRepository<MedicationPlan> MedicationPlanRepository
        {
            get
            {
                if (_medicationPlanRepository == null)
                {
                    _medicationPlanRepository = new GenericRepository<MedicationPlan>(_context);
                }
                return _medicationPlanRepository;
            }
            set
            {
                _medicationPlanRepository = value;
            }
        }

        public IGenericRepository<MedicationPlanDetails> MedicationPlanDetailsRepository
        {
            get
            {
                if (_medicationPlanDetailsRepository == null)
                {
                    _medicationPlanDetailsRepository = new GenericRepository<MedicationPlanDetails>(_context);
                }
                return _medicationPlanDetailsRepository;
            }
            set
            {
                _medicationPlanDetailsRepository = value;
            }

        }

        public IGenericRepository<MedicalRecord> MedicalRecordRepository
        {
            get
            {
                if (_medicalRecordRepository == null)
                {
                    _medicalRecordRepository = new GenericRepository<MedicalRecord>(_context);
                }
                return _medicalRecordRepository;
            }
            set
            {
                _medicalRecordRepository = value;
            }

        }

        public IGenericRepository<User> UserRepository
        {
            get 
            {
                if (_userRepository == null)
                {
                    _userRepository = new GenericRepository<User>(_context);
                }
                return _userRepository;
            }
            set
            {
                _userRepository = value;
            }
        }

        public IGenericRepository<Role> RoleRepository
        {
            get 
            {
                if (_roleRepository==null)
                {
                    _roleRepository = new GenericRepository<Role>(_context);
                }
                return _roleRepository;
            }
            set
            {
                _roleRepository = value;
            }
        }

        public IGenericRepository<Activity> ActivityRepository
        {
            get
            {
                if (_activityRepository == null)
                {
                    _activityRepository = new GenericRepository<Activity>(_context);
                }
                return _activityRepository;
            }
            set
            {
                _activityRepository = value;
            }
        }

        public IGenericRepository<MedicationStatus> MedicationStatusRepository
        {
            get
            {
                if (_medicationStatusRepository == null)
                {
                    _medicationStatusRepository = new GenericRepository<MedicationStatus>(_context);
                }
                return _medicationStatusRepository;
            }
            set
            {
                _medicationStatusRepository = value;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
