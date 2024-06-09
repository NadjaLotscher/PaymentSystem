using PaymentSystem.Models;

namespace WebApi.Models
{
    public class TransactionDTO
    {
        public int? TransactionId { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
