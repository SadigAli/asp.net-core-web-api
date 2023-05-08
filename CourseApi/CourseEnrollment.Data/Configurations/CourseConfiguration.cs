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
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasData
                (
                    new Course { Id = 1, Name = "Front End", Credit = 20, CreatedAt =  DateTime.Now, UpdatedAt = DateTime.Now, DeletedAt = null },
                    new Course { Id = 2, Name = "Back End", Credit = 30, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DeletedAt = null },
                    new Course { Id = 3, Name = "Full Stack", Credit = 45, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DeletedAt = null },
                    new Course { Id = 4, Name = "Mobile Programming", Credit = 25, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DeletedAt = null }
                );
        }
    }
}
