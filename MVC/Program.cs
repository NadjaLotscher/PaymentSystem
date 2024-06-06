using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MVC.Models;
using PaymentSystem;
using PaymentSystem.DAL;
using PaymentSystem.MVC.Services;
using PaymentSystem.MVC.DTOs;
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

using (var scope = app.Services.CreateScope())
{
    var options = new DbContextOptionsBuilder<SystemContext>()
               .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PaymentServiceDB")
               .Options;
    var context = new SystemContext(options);

    var created = context.Database.EnsureCreated();
    if (created)
    {
        // Add data into Database
        var services = scope.ServiceProvider;
        // seed(services);
    }
    
}

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

/*
void seed(IServiceProvider serviceProvider)
{
    using var context = new SystemContext(serviceProvider.GetRequiredService<DbContextOptions<SystemContext>>());

        var account1 = new Account() { Username = "user1", Balance = 100.0m };
        var account2 = new Account() { Username = "user2", Balance = 150.0m };
        context.Accounts.AddRange(account1, account2);

        var student1 = new Student() { Firstname = "John", Lastname = "Doe" };
        var student2 = new Student() { Firstname = "Jane", Lastname = "Doe" };
        context.Students.AddRange(student1, student2);

        var transaction1 = new Transaction() { StudentId = student1.StudentId, Amount = 50.0m};
        var transaction2 = new Transaction() { StudentId = student2.StudentId, Amount = 75.0m};
        context.Transactions.AddRange(transaction1, transaction2);

        context.SaveChanges();
    
}
*/