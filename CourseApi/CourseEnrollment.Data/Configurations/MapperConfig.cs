using AutoMapper;
using CourseEnrollment.Data.DTOs.Course;
using CourseEnrollment.Data.DTOs.Student;
using CourseEnrollment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseEnrollment.Data.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        { 
            CreateMap<Course,CourseDTO>().ReverseMap();
            CreateMap<Course, CreateCourseDTO>().ReverseMap();

            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Student, CreateStudentDTO>().ReverseMap();
        }

    }
}
