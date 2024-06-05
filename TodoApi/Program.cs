using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PaymentSystem;
using PaymentSystem.DAL;
using PaymentSystem.DAL.Models;
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

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore-swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PaymentAPI", Version = "v1" });
            });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<SystemContext>(); // Get the SystemContext
                seed(context); // Pass the SystemContext to the seed method
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PaymentAPI v1"));
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
                    new Student { Firstname = "Nadja", Lastname = "Lötscher", Username = "nadjalotscher" },
                    new Student { Firstname = "John", Lastname = "Doe", Username = "johndoe" }
                };

                context.Students.AddRange(students);
                context.SaveChanges();

                var accounts = new[]
                {
                    new Account { StudentId = students[0].StudentId, Username = "nadjalotscher", Balance = 100.0m, IsActive = true, NumberOfCopies = 0 },
                    new Account { StudentId = students[1].StudentId, Username = "johndoe", Balance = 50.0m, IsActive = true, NumberOfCopies = 0 }
                };

                context.Accounts.AddRange(accounts);
                context.SaveChanges();

                var transactions = new[]
                {
                    new Transaction { StudentId = students[0].StudentId, Amount = 50.0m, TransactionType = "Credit", TransactionDate = DateTime.Now, Status = "Success" },
                    new Transaction { StudentId = students[1].StudentId, Amount = 75.0m, TransactionType = "Credit", TransactionDate = DateTime.Now, Status = "Success" }
                };

                context.Transactions.AddRange(transactions);
                context.SaveChanges();
            }
        }
    }
}
