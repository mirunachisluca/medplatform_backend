using System.Collections.Generic;
using AutoMapper;
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
    public class MedicationController : ControllerBase
    {

        private readonly ILogger<MedicationController> _logger;
        private readonly IMedicationService _medicationService;

        public MedicationController(ILogger<MedicationController> logger, IMedicationService medicationService)
        {
            _logger = logger;
            _medicationService = medicationService;
        }

        [HttpGet("get/{id}")]
        public MedicationModel GetById(int id)
        {
            return _medicationService.GetById(id);
        }

        [HttpGet("drugs")]
        public IEnumerable<Medication> GetMedication()
        {
            return _medicationService.ListMedication();
        }

        [HttpPost("insert")]
        public void Insert(Medication medication)
        {
            _medicationService.Insert(medication);
        }

        [HttpPost("update")]
        public void Update(Medication medication)
        {
            _medicationService.Update(medication);
        }

        [HttpPost("delete/{id}")]
        public void Delete(int id)
        {
            _medicationService.DeleteById(id);
        }
    }
}
