using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public Student Student { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; } //either Payment or 
        public DateTime TransactionDate { get; set; }

    }
}
