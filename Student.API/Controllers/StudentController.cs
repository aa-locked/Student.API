using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.API.Repository;

namespace Student.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _student;

        public StudentController(IStudent student)
        {
            _student = student;
        }

        [HttpGet]
        public IActionResult GetAllStudent()
        {
            var result = _student.GetAllStudent();
            return Ok(result);
        }
    }
}
