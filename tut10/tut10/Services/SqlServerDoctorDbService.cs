using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using tut10.Models;

namespace tut10.Services
{
    public class SqlServerDoctorDbService : ControllerBase, IDoctorDbService
    {
  
        public readonly PatientDbContext context;


        public SqlServerDoctorDbService(PatientDbContext context)
        {
            this.context = context;
        }
        private Doctor newDoctor = new Doctor();

        public IActionResult PromoteStudent(PromoteStudent promote)
        {
            //Checks if the Studies Name exists
            int studiesId = context.Studies.Where(s => s.Name == promote.Studies).Select(s1 => s1.IdStudy).FirstOrDefault();

            if (studiesId == 0) {
                return NotFound("Stadies does not exist");
            }

            //Update table Endrollment
            context.Enrollment.Where(e => e.IdStudy == studiesId && e.Semester == promote.Semester).ToList().ForEach(e1 => e1.Semester = promote.Semester + 1);
            context.SaveChanges();
            return Ok();
        }

        public IActionResult DeleteStudent(int id)
        {
            //Search for Student index number to make sure that Student exist
            int idDoctor = context.Doctor.Where(d => d.IdDoctor == id).Select(d => d.IdDoctor).FirstOrDefault();
          
            if (idDoctor == 0)
            {
                return NotFound("Doctor does not Exist!");
            }
            else {
                //remove student from Db
                context.Doctor.Remove(context.Doctor.Where(d => d.IdDoctor == id).First());
            }

            context.SaveChanges();
            return Ok("Student has been deleted from Database!");
          
        }

        public IActionResult EnrollStudent(Doctor doctor)
        {
           
            int indexNumberExist = context.Doctor.Where(d => d.IdDoctor == doctor.IdDoctor).Count();
            if (indexNumberExist > 0) {
                return BadRequest("Try to enter enother idDoctor for this Doctor!\n" +
                    $"The last enrolled Doctor has idDoctor : {context.Doctor.OrderBy(s1 => s1.IdDoctor).Select(d => d.IdDoctor).Last().ToString()}");
            }


            newDoctor = doctor;
            

            int doctorExist = context.Doctor.Where(d => d.FirstName == doctor.FirstName
                                                       && d.LastName == doctor.LastName
                                                       && d.Email == doctor.Email).Select(s1 => s1.IdDoctor).FirstOrDefault();

            if (doctorExist == 0)
            {
                context.Doctor.Add(newDoctor);
                context.SaveChanges();
            }
            else
            {
                return BadRequest($"This Doctor already exists idDoctor : {doctorExist}");
            }
            return Ok($"A new Doctor has been added idDoctor : {newDoctor.IdDoctor}");
        }

        public IActionResult GetDoctorData(int id)
        {
            if (context.Doctor.Any(d => d.IdDoctor == id)) {
                return NotFound("Such Doctor does now exist! ");
            }
            Doctor doctor = context.Doctor.Where(d => d.IdDoctor == id).First();
            return Ok(doctor);
        }
    }
}
