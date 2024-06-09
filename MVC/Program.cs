using Microsoft.EntityFrameworkCore;
using MVC.Services;
using PaymentSystem;
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

// Register ApiService for dependency injection
builder.Services.AddScoped<IApiService, ApiService>();

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
        var services = scope.ServiceProvider;
    }

}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
