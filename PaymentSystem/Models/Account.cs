using Microsoft.EntityFrameworkCore;
using PaymentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem.DAL.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
        public string Username { get; set; }
        public decimal Balance { get; set; }
        public Boolean IsActive { get; set; }
        public decimal NumberOfCopies { get; set; }
    }
}
