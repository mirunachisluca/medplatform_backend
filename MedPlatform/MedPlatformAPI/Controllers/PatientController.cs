using System.Collections.Generic;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MedPlatformAPI.Controllers
{
    [Route("[controller]")]
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

        [Authorize]
        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_patientService.GetById(id));
        }

        [Doctor]
        [HttpGet("getByDoctor")]
        public IActionResult GetByIdDoctor(int patientId, int doctorId)
        {
            var patient = _patientService.GetPatientForDoctor(patientId, doctorId);
            if (patient != null)
                return Ok(patient);
            else return Unauthorized();
        }

        [Doctor]
        [HttpGet("forDoctor/{id}")]
        public IActionResult GetPatientsForDoctorr(int doctorId)
        {
            return Ok(_patientService.GetPatientsForDoctor(doctorId));
        }

        [Caregiver]
        [HttpGet("getByCaregiver")]
        public IActionResult GetbyIdCaregiver(int patientId, int caregiverId)
        {
            var patient = _patientService.GetPatientForCaregiver(patientId, caregiverId);
            if (patient != null)
                return Ok(patient);
            else return Unauthorized();
        }

        [Caregiver]
        [HttpGet("forCaregiver/{id}")]
        public IActionResult GetPatientsForCaregiver(int caregiverId)
        {
            return Ok(_patientService.GetPatientsForCaregiver(caregiverId));
        }

        [HttpGet("patients")]
        public IEnumerable<Patient> GetPatient()
        {
            return _patientService.ListPatients();
        }

        [Doctor]
        [HttpPost("insert")]
        public void Insert(Patient patient)
        {
            _patientService.Insert(patient);
        }

        [Doctor]
        [HttpPost("update")]
        public void Update(Patient patient)
        {
            _patientService.Update(patient);
        }

        [Doctor]
        [HttpPost("delete/{id}")]
        public void Delete(int id)
        {
            _patientService.DeleteById(id);
        }

    }
}
