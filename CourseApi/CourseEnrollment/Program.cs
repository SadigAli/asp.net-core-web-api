using CourseEnrollment.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using CourseEnrollment.Endpoints;
using CourseEnrollment.Data.DTOs.Course;
using CourseEnrollment.Data.Configurations;

namespace CourseEnrollment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(MapperConfig));
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });
            builder.Services.AddCors(opt =>
                                opt.AddPolicy("AllowAll", pol =>
                                pol.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            };

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.MapGet("api/courses", async (AppDbContext context) =>
            {
                List<CourseDTO> data = new List<CourseDTO>();
                var courses = await context.Courses.ToListAsync();
                foreach (var item in courses)
                {
                    data.Add(new CourseDTO
                    {
                        Credit = item.Credit,
                        Id = item.Id,
                        Name = item.Name,
                    });
                }
                return data;
            });

            app.MapGet("api/courses/{id}", async (AppDbContext context, int id) =>
            {
                var course = await context.Courses.FindAsync(id);
                if (course is null) return Results.NotFound();
                var data = new CourseDTO()
                {
                    Id = id,
                    Name = course.Name,
                    Credit = course.Credit,
                };
                return Results.Ok(data);
            });

            app.MapPost("api/courses", async (AppDbContext context, CreateCourseDTO model) =>
            {
                var course = new Course()
                {
                    Credit = model.Credit,
                    Name = model.Name,
                };
                await context.Courses.AddAsync(course);
                await context.SaveChangesAsync();
                return Results.Created($"api/courses/{course.Id}", course);
            });

            app.MapPut("api/courses/{id}", async (AppDbContext context, CreateCourseDTO model, int id) =>
            {
                Course course = await context.Courses.FindAsync(id);
                if (course is null) return Results.NotFound();
                course.Credit = model.Credit;
                course.Name = model.Name;
                await context.SaveChangesAsync();

                return Results.Accepted($"api/courses/{course.Id}", model);
            });

            app.MapDelete("api/courses/{id}", async (AppDbContext context, int id) =>
            {
                Course course = await context.Courses.FindAsync(id);
                if (course is null) return Results.NotFound();

                context.Courses.Remove(course);
                await context.SaveChangesAsync();
                return Results.NoContent();
            });





            app.MapControllers();

            app.MapStudentEndpoints();

            app.Run();
        }
    }
}