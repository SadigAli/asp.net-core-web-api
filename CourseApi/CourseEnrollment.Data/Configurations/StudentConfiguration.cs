using CourseEnrollment.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseEnrollment.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasData
                (
                    new Student { Id = 1,Firstname = "Sadig",Lastname ="Aliyev",StudentId = "STD001" },
                    new Student { Id = 2, Firstname = "Rovshane", Lastname = "Rzayeva", StudentId = "STD002" },
                    new Student { Id = 3, Firstname = "Aysel", Lastname = "Hasanli", StudentId = "STD003" }
                );
        }
    }
}
