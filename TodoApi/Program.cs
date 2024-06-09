using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PaymentSystem;
using PaymentSystem.DAL;
using PaymentSystem.Models;

namespace TodoApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddDbContext<SystemContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<SystemContext>(); // Get the SystemContext
                seed(context); // Pass the SystemContext to the seed method
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static void seed(SystemContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Students.Any())
            {
                var students = new[]
                {
                    new Student { Firstname = "Jane", Lastname = "Doe", Username = "janedoe", Balance = 0, UID = "87" },
                    new Student { Firstname = "John", Lastname = "Doe", Username = "johndoe", Balance = 0, UID = "91" }
                };

                context.Students.AddRange(students);
                context.SaveChanges();

            }
        }
    }
}
