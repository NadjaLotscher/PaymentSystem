using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentSystem.DAL.Models;

namespace PaymentSystem.DAL.Data
{
    public class SystemContext : DbContext
    {
        public SystemContext(DbContextOptions<SystemContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
