using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult ChangeDoctorData(Doctor newDoctorData)
        {
            if (!context.Doctor.Any(d => d.IdDoctor == newDoctorData.IdDoctor)) {
                return NotFound("Such Doctor does not exists!");
            }
            Doctor doctor = context.Doctor.Find(newDoctorData.IdDoctor);
            doctor.FirstName = newDoctorData.FirstName;
            doctor.LastName = newDoctorData.LastName;
            doctor.Email = newDoctorData.Email;
            context.SaveChanges();                              
            return Ok("Updated");
        }

        public IActionResult DeleteDoctor(int id)
        {
            int idDoctor = context.Doctor.Where(d => d.IdDoctor == id).Select(d => d.IdDoctor).FirstOrDefault();
            if (idDoctor == 0)
            {
                return NotFound("Doctor does not Exist!");
            }
            else {
               
                context.Doctor.Remove(context.Doctor.Where(d => d.IdDoctor == id).First());
            }
            context.SaveChanges();
            return Ok("Doctor has been deleted from Database!");
          
        }

        public IActionResult EnrollDoctor(Doctor doctor)
        {
           
            int indexNumberExist = context.Doctor.Where(d => d.IdDoctor == doctor.IdDoctor).Count();
            if (indexNumberExist > 0) {
                return BadRequest("Try to enter another idDoctor for this Doctor!\n" +
                    $"The last enrolled Doctor has idDoctor : {context.Doctor.OrderBy(d => d.IdDoctor).Select(d => d.IdDoctor).Last().ToString()}");
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
            if (!context.Doctor.Any(d => d.IdDoctor == id)) {
                return NotFound("Such Doctor does not exists!");
            }
            Doctor doctor = context.Doctor.Where(d => d.IdDoctor == id).First();
            return Ok(doctor);
        }
    }
}
