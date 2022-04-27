using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiStudent3.Models;
using WebApiStudent3.Services;

namespace WebApiStudent3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly GradeServices gradeServices;

        public GradeController(GradeServices gradeServices)
        {
            this.gradeServices = gradeServices;
        }

        [HttpGet]
        [Route("{id}")]

        public Grade GetGradesByStudentId(int id)
        {
            return gradeServices.GetGradesByStudentId(id);
        }
    }
}
