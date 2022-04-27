using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiStudent3.Models;
using WebApiStudent3.Services;

namespace WebApiStudent3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentServices studentServices;

        public StudentController(StudentServices studentServices)
        {
            this.studentServices = studentServices;
        }

        [HttpGet]
        public IEnumerable<Student> GetAllStudents()
        {
            return studentServices.GetAllStudents();
        }


        [HttpGet]
        [Route("{email}")]
        
        public Student GetAllStudents(string email)
        {
            return studentServices.GetStudentByEmail(email);
        }

    }
}
