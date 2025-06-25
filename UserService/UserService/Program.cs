using Carter;
using Microsoft.EntityFrameworkCore;
using UserService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCarter();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
app.MapCarter();
app.Run();