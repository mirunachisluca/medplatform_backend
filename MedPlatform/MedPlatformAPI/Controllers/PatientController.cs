using System.Collections.Generic;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MedPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;
        private readonly IPatientService _patientService;

        public PatientController(ILogger<PatientController> logger, IPatientService patientService)
        {
            _logger = logger;
            _patientService = patientService;
        }

        [HttpGet("get")]
        public Patient GetById(int id)
        {
            return _patientService.GetById(id);
        }

        [HttpGet("patients")]
        public IEnumerable<Patient> GetPatient()
        {
            return _patientService.ListPatients();
        }

        [HttpPost("insert")]
        public void Insert(Patient patient)
        {
            _patientService.Insert(patient);
        }

        [HttpPost("update")]
        public void Update(Patient patient)
        {
            _patientService.Update(patient);
        }

        [HttpPost("delete")]
        public void Delete(int id)
        {
            _patientService.DeleteById(id);
        }


    }
}
