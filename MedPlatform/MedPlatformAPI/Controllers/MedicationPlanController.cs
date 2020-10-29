using System.Collections.Generic;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Models;
using Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace MedPlatformAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MedicationPlanController : ControllerBase
    {
        private readonly IMedicationPlanService _medicationPlanService;

        public MedicationPlanController(IMedicationPlanService medicationPlanService, 
            IMedicationPlanDetailsService medicationPlanDetailsService)
        {
            _medicationPlanService = medicationPlanService;
        }

        [HttpGet("get/{id}")]
        public MedicationPlanModel GetById(int id)
        {
            return _medicationPlanService.GetById(id);
        }

        [Doctor]
        [HttpGet("getForPatient/{id}")]
        public IActionResult GetMedicationPlanForPatient(int patientId)
        {
            return Ok(_medicationPlanService.GetMedicationPlanForPatient(patientId));
        }

        [HttpGet("plans")]
        public IEnumerable<MedicationPlanModel> ListMedicationPlans()
        {
            return _medicationPlanService.GetMedicationPlans();
        }

        [Doctor]
        [HttpPost("insert")]
        public void InsertMedicationPlan(MedicationPlan medicationPlan)
        {
            _medicationPlanService.Insert(medicationPlan);
        }

        [Doctor]
        [HttpPost("update")]
        public void UpdateMedicationPlan(MedicationPlan medicationPlan)
        {
            _medicationPlanService.Update(medicationPlan);
        }

        [Doctor]
        [HttpPost("delete/{id}")]
        public void DeleteMedicationPlan(int id)
        {
            _medicationPlanService.DeleteById(id);
        }

    }
}
