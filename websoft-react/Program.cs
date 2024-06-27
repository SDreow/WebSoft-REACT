global using websoft_react.Models;
global using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

// // Konfigurace HTTPS
// var certificate = new X509Certificate2("path_to_your_certificate.pfx", "password");
// builder.WebHost.UseKestrel(options =>
// {
//     options.Listen(IPAddress.Any, 443, listenOptions =>
//     {
//         listenOptions.UseHttps(certificate);
//     });
// });
// Přidání CORS služby
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.WithOrigins("https://localhost:5064")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials();
    });
});

builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = options.DefaultPolicy;
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<WebDBContext>(options => options
            .UseSqlServer(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // app.UseMigrationsEndPoint()
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Použití CORS middleware
app.UseCors("AllowAllOrigins");

app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
