using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApiStudent3.Models;

namespace WebApiStudent3.Services
{
    public class GradeServices
    {
        private readonly school3Context context;

        public GradeServices(school3Context context)
        {
            this.context = context;
        }

        public Grade GetGradesByStudentId(int id)
        {
            return context.Grades.First(Grade => Grade.StudentId == id);
            //return context.Grades.Include(Grade => Grade.StudentId == id).First(Student => Student.StudentId == id);
            //return context.Grades.First(g => g.StudentId == id);
        }
    }
}
