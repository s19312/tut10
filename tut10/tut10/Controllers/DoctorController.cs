using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tut10.Models;
using tut10.Services;

namespace tut10.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class DoctorController : ControllerBase
    {
        public readonly IDoctorDbService _service;
        public DoctorController(IDoctorDbService service) {
            _service = service;
        }
        [HttpGet("{id}")]
        public IActionResult GetDoctor(int id) {
            return Ok(_service.GetDoctorData(id));
        }

        [HttpPost("enrollment")]
        public IActionResult InrollDoctor(Doctor doctor)
        {
            return _service.EnrollDoctor(doctor);
        }

        [HttpPost("changeEmail")]
        public IActionResult ChangeDoctorEmail(int idDoctor,string email)
        {
            return _service.ChangeDoctorsEmail(idDoctor,email);
        }

        [HttpDelete("{id}/delete")]
        public IActionResult DeleteDoctor(int id)
        {
            return _service.DeleteDoctor(id);
        }
    }
}
