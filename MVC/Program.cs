using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MVC.Models;
using PaymentSystem;
using PaymentSystem.DAL;
using PaymentSystem.MVC.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

// Add the HTTP client service
builder.Services.AddHttpClient();

// Configure MySettings from appsettings.json
builder.Services.Configure<MySettingsModel>(builder.Configuration.GetSection("MySettings"));

// Register ApiService for dependency injection
builder.Services.AddScoped<ApiService>();

// Configure DbContext for local MVC operations (if needed)
builder.Services.AddDbContext<SystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
