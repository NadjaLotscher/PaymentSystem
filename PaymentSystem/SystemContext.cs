using Microsoft.EntityFrameworkCore;
using PaymentSystem.Models;

namespace PaymentSystem
{
    public class SystemContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public SystemContext(DbContextOptions<SystemContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure primary key for Student
            modelBuilder.Entity<Student>()
                .HasKey(s => s.StudentId);

            // Configure additional properties for Student
            modelBuilder.Entity<Student>()
                .Property(s => s.UID)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(s => s.Balance)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            // Configure primary key for Transaction
            modelBuilder.Entity<Transaction>()
                .HasKey(t => t.TransactionId);

            // Configure relationship between Student and Transaction
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Student) // Each Transaction has one Student
                .WithMany() // Specify the collection property in Student if exists
                .HasForeignKey(t => t.StudentId); // Foreign key in the Transaction table
        }
    }
}