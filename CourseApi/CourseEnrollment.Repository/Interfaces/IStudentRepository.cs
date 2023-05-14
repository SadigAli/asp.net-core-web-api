using CourseEnrollment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseEnrollment.Repository.Interfaces
{
    public interface IStudentRepository : IGenericRepository<Student> 
    {
        Task<Student> GetStudentDetails(int id);
    }
}
