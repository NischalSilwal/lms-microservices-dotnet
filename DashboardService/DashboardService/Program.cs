using Carter;
using Microsoft.AspNetCore.Server.Kestrel.Core; // Required for KestrelServerOptions
using System.Security.Authentication; // Required for SslProtocols

var builder = WebApplication.CreateBuilder(args);

// Configure Kestrel to explicitly use TLS 1.2 and TLS 1.3
// This helps ensure compatibility with modern clients and enhances security.
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ConfigureHttpsDefaults(listenOptions =>
    {
        // Specify the minimum accepted SSL/TLS protocols.
        // It's generally recommended to support TLS 1.2 and TLS 1.3 for security and compatibility.
        listenOptions.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls13;

        // Optional: If you need to bind to a specific certificate, you can do it here.
        // listenOptions.ServerCertificate = new System.Security.Cryptography.X509Certificates.X509Certificate2("path/to/your/certificate.pfx", "yourpassword");
    });
});

builder.Services.AddHttpClient();
builder.Services.AddCarter();

// Add services for API exploration and Swagger/OpenAPI documentation.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Use Swagger UI in development environment for API documentation.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable HTTPS Redirection to ensure all traffic goes over HTTPS.
// This is crucial for security, especially when dealing with SSL/TLS issues.
app.UseHttpsRedirection();

// Map Carter modules to handle API requests.
app.MapCarter();

// Run the application.
app.Run();