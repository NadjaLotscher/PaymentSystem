using Microsoft.EntityFrameworkCore;
using PaymentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem.DAL.Models
{
    public class Quota
    {
        public int QuotaId { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
        public decimal NumberOfCopies { get; set; }
        public decimal EuivalentCHF { get; set; }
        public DateTime DateUpdated { get; set; }
    }
    
}
