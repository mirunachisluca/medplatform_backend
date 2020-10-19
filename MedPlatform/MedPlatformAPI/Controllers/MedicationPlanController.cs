using System.Collections.Generic;
using Core.Entities;
using Core.Interfaces;
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
        public MedicationPlan GetById(int id)
        {
            return _medicationPlanService.GetById(id);
        }

        [HttpGet("plans")]
        public IEnumerable<MedicationPlan> ListMedicationPlans()
        {
            return _medicationPlanService.GetMedicationPlans();
        }

        [HttpPost("insert")]
        public void InsertMedicationPlan(MedicationPlan medicationPlan)
        {
            _medicationPlanService.Insert(medicationPlan);
        }

        [HttpPost("update")]
        public void UpdateMedicationPlan(MedicationPlan medicationPlan)
        {
            _medicationPlanService.Update(medicationPlan);
        }

        [HttpPost("delete/{id}")]
        public void DeleteMedicationPlan(int id)
        {
            _medicationPlanService.DeleteById(id);
        }

        //[HttpPost("addPlan")]
        //public void AddMedicationPlan(int patientId, MedicationPlan medicationPlan)
        //{
        //    _medicationPlanService.AddMedicationPlan(patientId, medicationPlan);
        //}

    }
}
