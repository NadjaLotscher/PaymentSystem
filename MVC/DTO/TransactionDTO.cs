using PaymentSystem.Models;

namespace PaymentSystem.MVC.DTO
{
    public class TransactionDTO
    {
        public int TransactionId { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }

    }
}
