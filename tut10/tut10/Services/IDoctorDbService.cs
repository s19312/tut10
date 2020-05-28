using Microsoft.AspNetCore.Mvc;
using tut10.Models;

namespace tut10.Services
{
    public interface IDoctorDbService
    {
        IActionResult GetDoctorData(int id);
        IActionResult EnrollDoctor(Doctor doctor);
        IActionResult DeleteStudent(int id);
        IActionResult ChangeDoctorsEmail(string email);

    }
}
