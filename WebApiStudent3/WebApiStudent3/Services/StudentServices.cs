using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiStudent3.Models;

namespace WebApiStudent3.Services
{
    public class StudentServices
    {
        private readonly school3Context context;

        public StudentServices(school3Context context)
        {
            this.context = context;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            /*
            var first = context.Students.Include(Student => Student.Subjects).ToList();
            var second = context.Students.Include(Student => Student.Grades).ToList();
            */
            return context.Students.Include(Student => Student.Subjects).Include(Student => Student.Grades).ToList();
        }

        public Student GetStudentByEmail(string email)
        {
            return context.Students.First(Student => Student.Email == email);
        }
    }
}
