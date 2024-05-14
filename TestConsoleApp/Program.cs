using Microsoft.EntityFrameworkCore;
using PaymentSystem;

namespace TestConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new SystemContext();

            context.Database.Migrate();

            Console.Write("Done");


        }
    }
}
