using PaymentSystem.Models;

namespace WebApi.DTO
{
    public class TransactionDTO
    {
        public int TransactionId { get; set; }
        public int StudentId { get; set; }
        public StudentDTO Student { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }

    }
}
