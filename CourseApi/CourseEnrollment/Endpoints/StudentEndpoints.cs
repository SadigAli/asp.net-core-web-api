using Microsoft.EntityFrameworkCore;
using CourseEnrollment.Data.Entities;
using AutoMapper;
using CourseEnrollment.Data.DTOs.Student;

namespace CourseEnrollment.Endpoints;

public static class StudentEndpoints
{
    public static void MapStudentEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Student", async (AppDbContext db,IMapper mapper) =>
        {
            List<Student> students = await db.Students.ToListAsync();
            var model = mapper.Map<List<StudentDTO>>(students);
            return model;
        })
        .WithName("GetAllStudents")
        .Produces<List<StudentDTO>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Student/{id}", async (AppDbContext db,IMapper mapper,int id) =>
        {
            Student student = await db.Students.FindAsync(id);
            if (student == null) return Results.NotFound();
            var data = mapper.Map<StudentDTO>(student);
            return Results.Ok(data);
        })
        .WithName("GetStudentById")
        .Produces<Student>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/Student/{Id}", async (int Id, CreateStudentDTO model, AppDbContext db,IMapper mapper) =>
        {
            var foundModel = await db.Students.FindAsync(Id);

            if (foundModel is null)
                return Results.NotFound();

            var student = mapper.Map<CreateStudentDTO, Student>(model);
            student.Id = Id;
            db.Update(student);
            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateStudent")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Student/", async (CreateStudentDTO model, AppDbContext db,IMapper mapper) =>
        {
            var student = mapper.Map<CreateStudentDTO,Student>(model);
            db.Students.Add(student);
            await db.SaveChangesAsync();
            return Results.Created($"/Students/{student.Id}", student);
        })
        .WithName("CreateStudent")
        .Produces<Student>(StatusCodes.Status201Created);

        routes.MapDelete("/api/Student/{Id}", async (int Id, AppDbContext db) =>
        {
            if (await db.Students.FindAsync(Id) is Student student)
            {
                db.Students.Remove(student);
                await db.SaveChangesAsync();
                return Results.Ok(student);
            }

            return Results.NotFound();
        })
        .WithName("DeleteStudent")
        .Produces<Student>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
