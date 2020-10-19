using System.Collections.Generic;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MedPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaregiverController : ControllerBase
    {
        private readonly ILogger<CaregiverController> _logger;
        private readonly ICaregiverService _caregiverService;

        public CaregiverController(ILogger<CaregiverController> logger, ICaregiverService caregiverService)
        {
            _logger = logger;
            _caregiverService = caregiverService;
        }

        [HttpGet("get")]
        public Caregiver GetById(int id)
        {
            return _caregiverService.GetById(id);
        }

        [HttpGet("caregivers")]
        public IEnumerable<Caregiver> GetCaregivers()
        {
            return _caregiverService.ListCaregivers();
        }

        [HttpPost("insert")]
        public void Insert(Caregiver caregiver)
        {
            _caregiverService.Insert(caregiver);
        }

        [HttpPost("update")]
        public void Update(Caregiver caregiver)
        {
            _caregiverService.Update(caregiver);
        }

        [HttpPost("delete")]
        public void Delete(int id)
        {
            _caregiverService.DeleteById(id);
        }

        [HttpGet("patients")]
        public IEnumerable<Patient> GetPatientsList(int id)
        {
            return _caregiverService.GetPatientsList(id);
        }
    }
}
