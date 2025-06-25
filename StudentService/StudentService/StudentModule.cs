using Carter;
using Microsoft.EntityFrameworkCore;

namespace StudentService;

public class StudentModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/students", async (ApplicationDbContext db) =>
            await db.Students.ToListAsync());

        app.MapGet("/api/students/{id}", async (int id, ApplicationDbContext db) =>
            await db.Students.FindAsync(id) is Student student
                ? Results.Ok(student)
                : Results.NotFound());

        app.MapPost("/api/students", async (Student student, ApplicationDbContext db) =>
        {
            db.Students.Add(student);
            await db.SaveChangesAsync();
            return Results.Created($"/api/students/{student.StudentId}", student);
        });

        app.MapPut("/api/students/{id}", async (int id, Student input, ApplicationDbContext db) =>
        {
            var student = await db.Students.FindAsync(id);
            if (student is null) return Results.NotFound();

            student.Name = input.Name;
            student.Email = input.Email;
            student.ContactNumber = input.ContactNumber;
            student.Department = input.Department;
            await db.SaveChangesAsync();
            return Results.NoContent();
        });

        app.MapDelete("/api/students/{id}", async (int id, ApplicationDbContext db) =>
        {
            var student = await db.Students.FindAsync(id);
            if (student is null) return Results.NotFound();

            db.Students.Remove(student);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}