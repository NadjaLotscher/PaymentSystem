using PaymentSystem.Models;

namespace WebApi.Models
{
    public class TransactionDTO
    {
        public int? TransactionId { get; set; }
        public int StudentId { get; set; }  // Foreign key property
        public Student Student { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; } // Either Payment or another type
        public DateTime TransactionDate { get; set; }
    }
}
