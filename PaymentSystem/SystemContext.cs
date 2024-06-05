using Microsoft.EntityFrameworkCore;
using PaymentSystem.DAL.Models;
using PaymentSystem.Models;

namespace PaymentSystem
{
    public class SystemContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public SystemContext(DbContextOptions<SystemContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PaymentServiceDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure primary key for Student
            modelBuilder.Entity<Student>()
                .HasKey(s => s.StudentId);

            // Configure primary key for Transaction
            modelBuilder.Entity<Transaction>()
                .HasKey(t => t.TransactionId);

            // Configure relationship between Student and Transaction
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Student) // Each Transaction has one Student
                .WithMany() // Specify the collection property in Student if exists
                .HasForeignKey(t => t.StudentId); // Foreign key in the Transaction table

            // Configure primary key for Account
            modelBuilder.Entity<Account>()
                .HasKey(a => a.AccountId);

            // Configure relationship between Student and Account
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Student) // Each Account has one Student
                .WithMany() // Specify the collection property in Student if exists
                .HasForeignKey(a => a.StudentId); // Foreign key in the Account table

        }
    }
}
