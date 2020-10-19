using System.Collections.Generic;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MedPlatformAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly ILogger<DoctorController> _logger;
        private readonly IDoctorService _doctorService;

        public DoctorController(ILogger<DoctorController> logger, IDoctorService doctorService)
        {
            _logger = logger;
            _doctorService = doctorService;
        }

        [HttpGet("get/{id}")]
        public Doctor GetById(int id)
        {
            return _doctorService.GetById(id);
        }

        [HttpGet("doctors")]
        public IEnumerable<Doctor> GetDoctors()
        {
            return _doctorService.ListDoctors();
        }

        [HttpPost("insert")]
        public void Insert(Doctor doctor)
        {
            _doctorService.Insert(doctor);
        }

        [HttpPost("update")]
        public void Update(Doctor doctor)
        {
            _doctorService.Update(doctor);
        }

        [HttpPost("delete/{id}")]
        public void Delete(int id)
        {
            _doctorService.DeleteById(id);
        }

        [HttpGet("patients")]
        public IEnumerable<Patient> GetPatientsList(int id)
        {
            return _doctorService.GetPatientsList(id);
        }
    }
}
