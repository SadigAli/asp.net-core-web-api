using CourseEnrollment.Data.Entities;
using CourseEnrollment.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseEnrollment.Repository.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<Student> GetStudentDetails(int id)
        {
            Student student = await _context.Students
                                .Include(x=>x.Enrollments)
                                .ThenInclude(x=>x.Course)
                                .FirstOrDefaultAsync(x=>x.Id == id);

            return student;
        }
    }
}
