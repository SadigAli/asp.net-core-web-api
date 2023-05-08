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
    internal class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasData
                (
                    new Enrollment { Id = 1, CourseId = 1, StudentId =1 },
                    new Enrollment { Id = 2, CourseId = 2, StudentId = 1 },
                    new Enrollment { Id = 3, CourseId = 3, StudentId = 1 },
                    new Enrollment { Id = 4, CourseId = 2, StudentId = 2 },
                    new Enrollment { Id = 5, CourseId = 4, StudentId = 2 },
                    new Enrollment { Id = 6, CourseId = 1, StudentId = 3 },
                    new Enrollment { Id = 7, CourseId = 4, StudentId = 3 }
                );
        }
    }
}
