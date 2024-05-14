using Microsoft.EntityFrameworkCore;
using PaymentSystem.DAL.Models;
using PaymentSystem.Models;


namespace PaymentSystem
{
    public class SystemContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Quota> Quotas { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PaymentServiceDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Set primary key for Student
            modelBuilder.Entity<Student>()
                .HasKey(s => s.StudentId);

            // Populate initial Student data
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, Lastname = "Lötscher", Firstname = "Nadja", Username = "nadjalotscher" }
            );

            // Set primary key for Transaction
            modelBuilder.Entity<Transaction>()
                .HasKey(t => t.TransactionId);

            // Relationship between Student and Transaction
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Student) // Transaction has one Student
                .WithMany() // Optionally, specify the collection property if you have one defined in Student
                .HasForeignKey(t => t.StudentId); // Foreign key in the Transaction table

            // Set primary key for Quota
            modelBuilder.Entity<Quota>()
                .HasKey(q => q.QuotaId);

            // Relationship between Student and Quota
            modelBuilder.Entity<Quota>()
                .HasOne(q => q.Student) // Quota has one Student
                .WithMany() // Optionally, specify the collection property if you have one defined in Student
                .HasForeignKey(q => q.StudentId); // Foreign key in the Quota table

            // Set primary key for Account
            modelBuilder.Entity<Account>()
                .HasKey(a => a.AccountId);

            // Relationship between Student and Account
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Student) // Account has one Student
                .WithMany() // Optionally, specify the collection property if you have one defined in Student
                .HasForeignKey(a => a.StudentId); // Foreign key in the Account table
        }
    }
}
