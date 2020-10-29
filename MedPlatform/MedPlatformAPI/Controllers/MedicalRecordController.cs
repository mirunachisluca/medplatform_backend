using System.Collections.Generic;
using Core.Entities;
using Core.Interfaces;
using Core.Models;
using Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MedPlatformAPI.Controllers
{
    [Doctor]
    [Route("[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        private readonly ILogger<MedicalRecordController> _logger;
        private readonly IMedicalRecordService _medicalRecordService;

        public MedicalRecordController(ILogger<MedicalRecordController> logger, IMedicalRecordService medicalRecordService)
        {
            _logger = logger;
            _medicalRecordService = medicalRecordService;
        }

        [HttpGet("get/{id}")]
        public MedicalRecordModel GetById(int id)
        {
            return _medicalRecordService.GetById(id);
        }

        [Doctor]
        [HttpGet("getForPatient/{id}")]
        public IEnumerable<MedicalRecordModel> GetByPatientId(int patientId)
        {
            return _medicalRecordService.GetByPatientId(patientId);
        }

        [HttpGet("records")]
        public IEnumerable<MedicalRecordModel> GetMedicalRecords()
        {
            return _medicalRecordService.ListMedicalRecords();
        }

        [Doctor]
        [HttpPost("insert")]
        public void Insert(MedicalRecord medicalRecord)
        {
            _medicalRecordService.Insert(medicalRecord);
        }

        [Doctor]
        [HttpPost("update")]
        public void Update(MedicalRecord medicalRecord)
        {
            _medicalRecordService.Update(medicalRecord);
        }

        [Doctor]
        [HttpPost("delete/{id}")]
        public void Delete(int id)
        {
            _medicalRecordService.DeleteById(id);
        }


    }
}
