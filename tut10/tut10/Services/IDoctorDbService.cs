using Microsoft.AspNetCore.Mvc;


namespace tut10.Services
{
    public interface IDoctorDbService
    {
        IActionResult GetDoctorData(int id);
       //IActionResult EnrollStudent(EnrollStudent enrollStudent);
       //IActionResult DeleteStudent(DeleteStudent indexNumber);
       // IActionResult PromoteStudent(PromoteStudent promote);

    }
}
