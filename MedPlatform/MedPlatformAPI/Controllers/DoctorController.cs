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
        public DoctorModel GetById(int id)
        {
            return _doctorService.GetById(id);
        }

        [HttpGet("doctors")]
        public IActionResult GetDoctors()
        {
            return Ok(_doctorService.ListDoctors());
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

        //[HttpGet("patients/{id}")]
        //public IActionResult GetPatientsList(int id)
        //{
        //    return Ok(_doctorService.GetPatientsList(id));
        //}
    }
}
