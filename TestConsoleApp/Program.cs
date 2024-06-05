using Microsoft.EntityFrameworkCore;
using PaymentSystem;
using PaymentSystem.DAL.Models;
using PaymentSystem.Models;
using PaymentSystem.DAL;

namespace TestConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<SystemContext>()
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PaymentServiceDB")
                .Options;
            var context = new SystemContext(options);

            var created = context.Database.EnsureCreated();
            if (created)
            {
                // Add data into Database
                // seed();
            }
            

            Console.Write("Done");


        }

        private static void seed(SystemContext context)
        {

            var student1 = new Student() { Firstname = "Danny", Lastname = "Smith", Username = "DannySmith" };
            var student2 = new Student() { Firstname = "John", Lastname = "Doe", Username = "JohnDoe" };
            context.Students.AddRange(student1, student2);

            var account1 = new Account() { Student = student1, Username = "DannySmith", Balance = 1000, IsActive = true };
            var account2 = new Account() { Student = student2, Username = "JohnDoe", Balance = 2000, IsActive = true };
            context.Accounts.AddRange(account1, account2);

            context.SaveChanges();

            //not adding info ?
        }
    }
}
