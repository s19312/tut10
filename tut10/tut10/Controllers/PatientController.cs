using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tut10.Models;

namespace tut10.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class PatientController : ControllerBase
    {
        public readonly PatientDbContext _context;
        public PatientController(PatientDbContext context) {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetPatient() {
            return Ok(_context.Patient.ToList());
        }
    }
}
