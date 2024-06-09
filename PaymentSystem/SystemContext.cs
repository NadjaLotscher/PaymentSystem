using Microsoft.EntityFrameworkCore;
using PaymentSystem.Models;

namespace PaymentSystem
{
    public class SystemContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

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
            modelBuilder.Entity<Student>()
                .HasKey(s => s.StudentId);

            modelBuilder.Entity<Transaction>()
                .HasKey(t => t.TransactionId);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Student)
                .WithMany(s => s.TransactionList)
                .HasForeignKey(t => t.StudentId);
        }
    }
}
