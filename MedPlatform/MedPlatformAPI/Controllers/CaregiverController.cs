﻿using System.Collections.Generic;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Infrastructure.Helpers;
using Core.Models;

namespace MedPlatformAPI.Controllers
{
    [Route("[controller]")]
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

        [Doctor]
        [HttpGet("get/{id}")]
        public CaregiverModel GetById(int id)
        {
            return _caregiverService.GetById(id);
        }

        [Doctor]
        [HttpGet("caregivers")]
        public IEnumerable<CaregiverModel> GetCaregivers()
        {
            return _caregiverService.ListCaregivers();
        }

        [Doctor]
        [HttpPost("insert")]
        public void Insert(Caregiver caregiver)
        {
            _caregiverService.Insert(caregiver);
        }

        [Doctor]
        [HttpPost("update")]
        public void Update(Caregiver caregiver)
        {
            _caregiverService.Update(caregiver);
        }

        [Doctor]
        [HttpPost("delete/{id}")]
        public void Delete(int id)
        {
            _caregiverService.DeleteById(id);
        }
    }
}
