using Carter;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using BookService;

var builder = WebApplication.CreateBuilder(args);

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowNextJs", builder =>
    {
        builder.WithOrigins("http://localhost:3000")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddCarter();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Apply CORS middleware before routing
app.UseCors("AllowNextJs");
app.MapCarter();

app.Run();